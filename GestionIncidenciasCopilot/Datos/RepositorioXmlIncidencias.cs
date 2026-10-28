using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using GestionIncidenciasCopilot.Entidades;

namespace GestionIncidenciasCopilot.Datos
{
    public sealed class RepositorioXmlIncidencias : IRepositorioIncidencias
    {
        private const string NombreRaiz = "Incidencias";
        private const string NombreElemento = "Incidencia";
        private const string VersionFormato = "1";
        private readonly string _rutaArchivo;
        private bool _cargaCompletada;
        private bool _bloqueadoPorErrorDeCarga;

        public RepositorioXmlIncidencias(string rutaArchivo)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivo))
            {
                throw new ArgumentException("La ruta del archivo es obligatoria.", "rutaArchivo");
            }

            _rutaArchivo = Path.GetFullPath(rutaArchivo);
        }

        public IReadOnlyList<Incidencia> Cargar()
        {
            if (_bloqueadoPorErrorDeCarga)
            {
                throw new InvalidOperationException("La carga anterior falló; el repositorio permanece bloqueado para proteger los datos.");
            }

            _bloqueadoPorErrorDeCarga = true;
            List<Incidencia> incidencias = LeerArchivo();

            _cargaCompletada = true;
            _bloqueadoPorErrorDeCarga = false;
            return incidencias.AsReadOnly();
        }

        public void Guardar(IReadOnlyList<Incidencia> incidencias)
        {
            if (_bloqueadoPorErrorDeCarga)
            {
                throw new InvalidOperationException("No se puede guardar porque la carga falló y el archivo debe conservarse intacto.");
            }

            if (!_cargaCompletada)
            {
                throw new InvalidOperationException("Debe cargar y validar los datos antes de guardar.");
            }

            if (incidencias == null)
            {
                throw new ArgumentNullException("incidencias");
            }

            var ids = new HashSet<Guid>();
            var elementos = new List<XElement>();

            foreach (Incidencia incidencia in incidencias)
            {
                ValidarIncidencia(incidencia);
                if (!ids.Add(incidencia.Id))
                {
                    throw new InvalidDataException("La colección contiene IDs de incidencia duplicados.");
                }

                elementos.Add(CrearElemento(incidencia));
            }

            var documento = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(NombreRaiz,
                    new XAttribute("version", VersionFormato),
                    elementos));

            string directorio = Path.GetDirectoryName(_rutaArchivo);
            Directory.CreateDirectory(directorio);
            string rutaTemporal = _rutaArchivo + ".tmp." + Guid.NewGuid().ToString("N");
            bool temporalCreado = false;
            try
            {
                EscribirTemporal(rutaTemporal, documento, ref temporalCreado);

                if (File.Exists(_rutaArchivo))
                {
                    File.Replace(rutaTemporal, _rutaArchivo, null);
                }
                else
                {
                    File.Move(rutaTemporal, _rutaArchivo);
                }
            }
            finally
            {
                if (temporalCreado)
                {
                    try
                    {
                        File.Delete(rutaTemporal);
                    }
                    catch (IOException)
                    {
                        // La limpieza no debe ocultar el error original del guardado.
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Conservar el destino y el error original si no se puede limpiar.
                    }
                }
            }
        }

        private List<Incidencia> LeerArchivo()
        {
            var configuracion = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null
            };

            FileStream flujo;
            try
            {
                flujo = new FileStream(_rutaArchivo, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (FileNotFoundException)
            {
                return new List<Incidencia>();
            }
            catch (DirectoryNotFoundException)
            {
                return new List<Incidencia>();
            }

            XDocument documento;
            using (flujo)
            using (XmlReader lector = XmlReader.Create(flujo, configuracion))
            {
                documento = XDocument.Load(lector, LoadOptions.None);
            }

            XElement raiz = documento.Root;
            if (raiz == null || raiz.Name != NombreRaiz ||
                raiz.Attributes().Count() != 1 ||
                (string)raiz.Attribute("version") != VersionFormato)
            {
                throw new InvalidDataException("El archivo XML no tiene la raíz o versión admitida.");
            }

            ValidarNodosDeContenedor(raiz);
            var incidencias = new List<Incidencia>();
            var ids = new HashSet<Guid>();

            foreach (XElement elemento in raiz.Elements())
            {
                if (elemento.Name != NombreElemento || elemento.HasAttributes)
                {
                    throw new InvalidDataException("El archivo XML contiene un elemento de incidencia no válido.");
                }

                ValidarNodosDeContenedor(elemento);
                string[] nombres = { "Id", "Titulo", "Descripcion", "Prioridad", "Estado", "FechaCreacionUtc", "FechaActualizacionUtc" };
                var campos = new Dictionary<string, string>(StringComparer.Ordinal);

                foreach (XElement campo in elemento.Elements())
                {
                    if (campo.HasAttributes || campo.HasElements || !nombres.Contains(campo.Name.LocalName, StringComparer.Ordinal) ||
                        campo.Name.Namespace != XNamespace.None || campos.ContainsKey(campo.Name.LocalName))
                    {
                        throw new InvalidDataException("El archivo XML contiene campos desconocidos o repetidos.");
                    }

                    campos.Add(campo.Name.LocalName, campo.Value);
                }

                if (campos.Count != nombres.Length)
                {
                    throw new InvalidDataException("El archivo XML no contiene todos los campos requeridos.");
                }

                Guid id;
                Prioridad prioridad;
                EstadoIncidencia estado;
                DateTime fechaCreacionUtc;
                DateTime fechaActualizacionUtc;

                if (!Guid.TryParseExact(campos["Id"], "D", out id) || id == Guid.Empty ||
                    !TryParseEnum(campos["Prioridad"], out prioridad) ||
                    !TryParseEnum(campos["Estado"], out estado) ||
                    !TryParseFechaUtc(campos["FechaCreacionUtc"], out fechaCreacionUtc) ||
                    !TryParseFechaUtc(campos["FechaActualizacionUtc"], out fechaActualizacionUtc))
                {
                    throw new InvalidDataException("El archivo XML contiene un ID, enum o fecha inválidos.");
                }

                if (!ids.Add(id))
                {
                    throw new InvalidDataException("El archivo XML contiene IDs de incidencia duplicados.");
                }

                var incidencia = new Incidencia
                {
                    Id = id,
                    Titulo = campos["Titulo"],
                    Descripcion = campos["Descripcion"],
                    Prioridad = prioridad,
                    Estado = estado,
                    FechaCreacionUtc = fechaCreacionUtc,
                    FechaActualizacionUtc = fechaActualizacionUtc
                };
                ValidarIncidencia(incidencia);
                incidencias.Add(incidencia);
            }

            return incidencias;
        }

        private static void ValidarNodosDeContenedor(XElement elemento)
        {
            foreach (XNode nodo in elemento.Nodes())
            {
                var texto = nodo as XText;
                if (!(nodo is XElement) && (texto == null || !string.IsNullOrWhiteSpace(texto.Value)))
                {
                    throw new InvalidDataException("El archivo XML contiene contenido no admitido.");
                }
            }
        }

        private static bool TryParseEnum<TEnum>(string valor, out TEnum resultado)
            where TEnum : struct
        {
            return Enum.TryParse(valor, false, out resultado) &&
                Enum.IsDefined(typeof(TEnum), resultado) &&
                string.Equals(Enum.GetName(typeof(TEnum), resultado), valor, StringComparison.Ordinal);
        }

        private static bool TryParseFechaUtc(string valor, out DateTime resultado)
        {
            resultado = default(DateTime);
            return valor.EndsWith("Z", StringComparison.Ordinal) &&
                DateTime.TryParseExact(valor, "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out resultado) &&
                resultado.Kind == DateTimeKind.Utc;
        }

        private static void ValidarIncidencia(Incidencia incidencia)
        {
            if (incidencia == null)
            {
                throw new InvalidDataException("La colección contiene una incidencia nula.");
            }

            if (incidencia.Id == Guid.Empty || string.IsNullOrWhiteSpace(incidencia.Titulo) ||
                incidencia.Titulo != incidencia.Titulo.Trim() || incidencia.Titulo.Length > 120 ||
                (incidencia.Descripcion != null && incidencia.Descripcion.Length > 2000) ||
                !Enum.IsDefined(typeof(Prioridad), incidencia.Prioridad) ||
                !Enum.IsDefined(typeof(EstadoIncidencia), incidencia.Estado) ||
                incidencia.FechaCreacionUtc.Kind != DateTimeKind.Utc ||
                incidencia.FechaActualizacionUtc.Kind != DateTimeKind.Utc ||
                incidencia.FechaActualizacionUtc < incidencia.FechaCreacionUtc)
            {
                throw new InvalidDataException("La incidencia contiene datos inválidos o fechas que no son UTC.");
            }
        }

        private static XElement CrearElemento(Incidencia incidencia)
        {
            return new XElement(NombreElemento,
                new XElement("Id", incidencia.Id.ToString("D")),
                new XElement("Titulo", incidencia.Titulo),
                new XElement("Descripcion", incidencia.Descripcion ?? string.Empty),
                new XElement("Prioridad", incidencia.Prioridad.ToString()),
                new XElement("Estado", incidencia.Estado.ToString()),
                new XElement("FechaCreacionUtc", incidencia.FechaCreacionUtc.ToString("o", CultureInfo.InvariantCulture)),
                new XElement("FechaActualizacionUtc", incidencia.FechaActualizacionUtc.ToString("o", CultureInfo.InvariantCulture)));
        }

        private static void EscribirTemporal(string rutaTemporal, XDocument documento, ref bool temporalCreado)
        {
            var configuracion = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                Indent = true,
                CloseOutput = false
            };

            using (var flujo = new FileStream(rutaTemporal, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                temporalCreado = true;
                using (XmlWriter escritor = XmlWriter.Create(flujo, configuracion))
                {
                    documento.Save(escritor);
                    escritor.Flush();
                }

                flujo.Flush(true);
            }
        }
    }
}
