using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using GestionIncidenciasCopilot.Controladores;
using GestionIncidenciasCopilot.Datos;
using GestionIncidenciasCopilot.Entidades;

namespace GestionIncidenciasCopilot.Pruebas
{
    internal static class Program
    {
        private static int _fallos;

        private static int Main()
        {
            Ejecutar("Alta, límites y enums", PruebaAltaLimitesYEnums);
            Ejecutar("Edición conserva ID y fechas UTC", PruebaEdicionConservaIdentidadYFechas);
            Ejecutar("Transiciones válidas e inválidas", PruebaTransiciones);
            Ejecutar("Búsqueda y filtros combinados", PruebaBusquedaYFiltros);
            Ejecutar("Clones no exponen el estado interno", PruebaClones);
            Ejecutar("Fallo al guardar no cambia la memoria", PruebaFalloDeGuardado);
            Ejecutar("XML roundtrip y reemplazo seguro", PruebaRoundtripYReemplazo);
            Ejecutar("Corrupción, versión, IDs y UTC conservan archivo y bloquean guardado", PruebaDatosInvalidosProtegidos);

            Console.WriteLine();
            Console.WriteLine(_fallos == 0 ? "RESULTADO: todas las pruebas pasaron." : "RESULTADO: " + _fallos + " prueba(s) fallaron.");
            return _fallos == 0 ? 0 : 1;
        }

        private static void Ejecutar(string nombre, Action prueba)
        {
            try
            {
                prueba();
                Console.WriteLine("[OK] " + nombre);
            }
            catch (Exception ex)
            {
                _fallos++;
                Console.WriteLine("[FALLO] " + nombre + " — " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void PruebaAltaLimitesYEnums()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var repositorio = new RepositorioFalso();
                var controlador = new ControladorIncidencias(repositorio);
                Incidencia creada = controlador.Crear("  Incidencia válida  ", new string('d', 2000), Prioridad.Alta);

                Afirmar(creada.Titulo == "Incidencia válida", "El título no fue recortado.");
                Afirmar(creada.Descripcion.Length == 2000, "Se rechazó o alteró la descripción en el límite.");
                Afirmar(creada.Estado == EstadoIncidencia.Pendiente, "El estado inicial no es Pendiente.");
                Afirmar(creada.Id != Guid.Empty, "El ID no fue asignado.");
                Afirmar(creada.FechaCreacionUtc.Kind == DateTimeKind.Utc, "La fecha de creación no es UTC.");
                Afirmar(creada.FechaActualizacionUtc == creada.FechaCreacionUtc, "Las fechas de alta deben ser iguales.");
                Afirmar(controlador.ObtenerTodas().Count == 1, "El alta no se reflejó en la colección.");

                controlador.Crear(new string('t', 120), string.Empty, Prioridad.Baja);
                Afirmar(controlador.ObtenerTodas().Count == 2, "El título de 120 caracteres debe aceptarse.");
                AfirmarLanza<ArgumentException>(delegate { controlador.Crear(new string('t', 121), "", Prioridad.Media); });
                AfirmarLanza<ArgumentException>(delegate { controlador.Crear("   ", "", Prioridad.Media); });
                AfirmarLanza<ArgumentException>(delegate { controlador.Crear("Título", new string('d', 2001), Prioridad.Media); });
                AfirmarLanza<ArgumentOutOfRangeException>(delegate { controlador.Crear("Título", "", (Prioridad)99); });
                AfirmarLanza<ArgumentOutOfRangeException>(delegate { controlador.Buscar("", (Prioridad)99, null); });
                AfirmarLanza<ArgumentOutOfRangeException>(delegate { controlador.Buscar("", null, (EstadoIncidencia)99); });
                Afirmar(controlador.ObtenerTodas().Count == 2, "Una entrada inválida cambió la colección.");
            }
        }

        private static void PruebaEdicionConservaIdentidadYFechas()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var controlador = new ControladorIncidencias(new RepositorioFalso());
                Incidencia original = controlador.Crear("Antes", "Descripción", Prioridad.Baja);
                Incidencia editada = controlador.Editar(original.Id, "Después", "Actualizada", Prioridad.Alta);

                Afirmar(editada.Id == original.Id, "La edición cambió el ID.");
                Afirmar(editada.FechaCreacionUtc == original.FechaCreacionUtc, "La edición cambió fecha de creación.");
                Afirmar(editada.FechaActualizacionUtc.Kind == DateTimeKind.Utc, "La fecha de actualización no es UTC.");
                Afirmar(editada.FechaActualizacionUtc >= editada.FechaCreacionUtc, "La actualización precede a la creación.");
                Afirmar(editada.Titulo == "Después" && editada.Descripcion == "Actualizada" && editada.Prioridad == Prioridad.Alta,
                    "La edición no guardó los campos solicitados.");
                AfirmarLanza<KeyNotFoundException>(delegate { controlador.Editar(Guid.NewGuid(), "X", "", Prioridad.Media); });
            }
        }

        private static void PruebaTransiciones()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var controlador = new ControladorIncidencias(new RepositorioFalso());
                Incidencia incidencia = controlador.Crear("Flujo", "", Prioridad.Media);
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Pendiente); });
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Resuelta); });

                incidencia = controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.EnProceso);
                Afirmar(incidencia.Estado == EstadoIncidencia.EnProceso, "Falló Pendiente → EnProceso.");
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.EnProceso); });
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Pendiente); });

                incidencia = controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Resuelta);
                Afirmar(incidencia.Estado == EstadoIncidencia.Resuelta, "Falló EnProceso → Resuelta.");
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Resuelta); });
                AfirmarLanza<InvalidOperationException>(delegate { controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.Pendiente); });

                incidencia = controlador.CambiarEstado(incidencia.Id, EstadoIncidencia.EnProceso);
                Afirmar(incidencia.Estado == EstadoIncidencia.EnProceso, "Falló Resuelta → EnProceso.");
                AfirmarLanza<ArgumentOutOfRangeException>(delegate { controlador.CambiarEstado(incidencia.Id, (EstadoIncidencia)88); });
            }
        }

        private static void PruebaBusquedaYFiltros()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var controlador = new ControladorIncidencias(new RepositorioFalso());
                Incidencia a = controlador.Crear("Error de inicio", "Falla al abrir", Prioridad.Alta);
                Incidencia b = controlador.Crear("Carga lenta", "ERROR en el servicio", Prioridad.Alta);
                Incidencia c = controlador.Crear("Otro caso", "Comportamiento normal", Prioridad.Baja);
                controlador.CambiarEstado(b.Id, EstadoIncidencia.EnProceso);

                Afirmar(controlador.Buscar("error", null, null).Count == 2, "La búsqueda no encontró título y descripción sin distinguir mayúsculas.");
                IReadOnlyList<Incidencia> combinados = controlador.Buscar("ERROR", Prioridad.Alta, EstadoIncidencia.EnProceso);
                Afirmar(combinados.Count == 1 && combinados[0].Id == b.Id, "Los criterios combinados no se aplicaron conjuntamente.");
                Afirmar(controlador.Buscar("", Prioridad.Baja, null).Single().Id == c.Id, "El filtro de prioridad no coincide.");
                Afirmar(controlador.Buscar("", null, EstadoIncidencia.Pendiente).Count == 2, "El filtro de estado no coincide.");
                Afirmar(controlador.Buscar("sin coincidencia", null, null).Count == 0, "La búsqueda vacía de resultados no devolvió lista vacía.");
                Afirmar(a.Id != Guid.Empty, "La incidencia de prueba no se creó.");
            }
        }

        private static void PruebaClones()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var repositorio = new RepositorioFalso();
                var controlador = new ControladorIncidencias(repositorio);
                Incidencia creada = controlador.Crear("Original", "Texto", Prioridad.Media);
                creada.Titulo = "Alterada en resultado";
                Afirmar(controlador.ObtenerPorId(creada.Id).Titulo == "Original", "El resultado de Crear expuso el estado interno.");

                IReadOnlyList<Incidencia> todas = controlador.ObtenerTodas();
                todas[0].Titulo = "Alterada en lista";
                Afirmar(controlador.ObtenerPorId(creada.Id).Titulo == "Original", "ObtenerTodas expuso una incidencia interna.");
                Incidencia porId = controlador.ObtenerPorId(creada.Id);
                porId.Descripcion = "Alterada por ID";
                Afirmar(controlador.ObtenerPorId(creada.Id).Descripcion == "Texto", "ObtenerPorId expuso una incidencia interna.");
                AfirmarLanza<NotSupportedException>(delegate { ((IList<Incidencia>)todas).Add(porId); });

                repositorio.UltimoGuardado[0].Titulo = "Alterada por repositorio";
                Afirmar(controlador.ObtenerPorId(creada.Id).Titulo == "Original", "El repositorio recibió referencias internas.");
            }
        }

        private static void PruebaFalloDeGuardado()
        {
            using (var temporal = new DirectorioTemporal())
            {
                var repositorio = new RepositorioFalso();
                var controlador = new ControladorIncidencias(repositorio);
                Incidencia original = controlador.Crear("Persistida", "Texto", Prioridad.Media);
                repositorio.FallarAlGuardar = true;

                AfirmarLanza<IOException>(delegate { controlador.Editar(original.Id, "No guardada", "Texto nuevo", Prioridad.Alta); });
                Incidencia despuesDeEditar = controlador.ObtenerPorId(original.Id);
                Afirmar(despuesDeEditar.Titulo == "Persistida" && despuesDeEditar.Prioridad == Prioridad.Media,
                    "Un fallo de guardar aplicó parcialmente la edición en memoria.");
                AfirmarLanza<IOException>(delegate { controlador.Crear("Tampoco guardada", "", Prioridad.Baja); });
                Afirmar(controlador.ObtenerTodas().Count == 1, "Un alta fallida modificó la memoria.");
            }
        }

        private static void PruebaRoundtripYReemplazo()
        {
            using (var temporal = new DirectorioTemporal())
            {
                string ruta = temporal.Archivo("incidencias.xml");
                var repositorio = new RepositorioXmlIncidencias(ruta);
                Afirmar(repositorio.Cargar().Count == 0, "Un archivo ausente no produjo una colección vacía.");
                var registro = CrearIncidencia(Guid.NewGuid(), "Primera escritura", EstadoIncidencia.Pendiente);
                repositorio.Guardar(new[] { registro });
                byte[] bytesPrimeraEscritura = File.ReadAllBytes(ruta);

                var reemplazo = CrearIncidencia(Guid.NewGuid(), "Reemplazo seguro", EstadoIncidencia.EnProceso);
                repositorio.Guardar(new[] { registro, reemplazo });
                byte[] bytesTrasReemplazo = File.ReadAllBytes(ruta);
                Afirmar(!bytesPrimeraEscritura.SequenceEqual(bytesTrasReemplazo), "La segunda escritura no reemplazó el archivo.");

                IReadOnlyList<Incidencia> cargadas = new RepositorioXmlIncidencias(ruta).Cargar();
                Afirmar(cargadas.Count == 2, "El roundtrip XML no recuperó todos los registros.");
                Incidencia recuperada = cargadas.Single(i => i.Id == reemplazo.Id);
                Afirmar(recuperada.Titulo == "Reemplazo seguro" && recuperada.Estado == EstadoIncidencia.EnProceso,
                    "El roundtrip XML alteró los datos.");
                Afirmar(recuperada.FechaCreacionUtc.Kind == DateTimeKind.Utc && recuperada.FechaActualizacionUtc.Kind == DateTimeKind.Utc,
                    "El roundtrip no conservó el tipo UTC.");
            }
        }

        private static void PruebaDatosInvalidosProtegidos()
        {
            VerificarArchivoInvalido("XML corrupto", "<Incidencias", typeof(XmlException));
            VerificarArchivoInvalido("Versión desconocida", CrearXml(2, CrearElemento(Guid.NewGuid(), "Versión")), typeof(InvalidDataException));

            Guid idDuplicado = Guid.NewGuid();
            VerificarArchivoInvalido("IDs duplicados",
                CrearXml(1, CrearElemento(idDuplicado, "Duplicado"), CrearElemento(idDuplicado, "Duplicado")),
                typeof(InvalidDataException));

            XElement fechaSinZ = CrearElemento(Guid.NewGuid(), "Fecha sin zona");
            fechaSinZ.Element("FechaCreacionUtc").Value = "2025-01-01T00:00:00.0000000";
            VerificarArchivoInvalido("Fecha UTC sin Z", CrearXml(1, fechaSinZ), typeof(InvalidDataException));
        }

        private static void VerificarArchivoInvalido(string nombre, string contenido, Type tipoEsperado)
        {
            using (var temporal = new DirectorioTemporal())
            {
                string ruta = temporal.Archivo("incidencias.xml");
                byte[] bytesOriginales = new System.Text.UTF8Encoding(false).GetBytes(contenido);
                File.WriteAllBytes(ruta, bytesOriginales);
                var repositorio = new RepositorioXmlIncidencias(ruta);
                AfirmarLanza(tipoEsperado, delegate { repositorio.Cargar(); });
                AfirmarLanza<InvalidOperationException>(delegate
                {
                    repositorio.Guardar(new[] { CrearIncidencia(Guid.NewGuid(), "No sobrescribir", EstadoIncidencia.Pendiente) });
                });
                Afirmar(bytesOriginales.SequenceEqual(File.ReadAllBytes(ruta)), "El archivo se alteró ante " + nombre + ".");
            }
        }

        private static Incidencia CrearIncidencia(Guid id, string titulo, EstadoIncidencia estado)
        {
            DateTime fecha = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return new Incidencia
            {
                Id = id,
                Titulo = titulo,
                Descripcion = "Descripción de prueba",
                Prioridad = Prioridad.Media,
                Estado = estado,
                FechaCreacionUtc = fecha,
                FechaActualizacionUtc = fecha
            };
        }

        private static XElement CrearElemento(Guid id, string titulo)
        {
            Incidencia incidencia = CrearIncidencia(id, titulo, EstadoIncidencia.Pendiente);
            return new XElement("Incidencia",
                new XElement("Id", incidencia.Id.ToString("D")),
                new XElement("Titulo", incidencia.Titulo),
                new XElement("Descripcion", incidencia.Descripcion),
                new XElement("Prioridad", incidencia.Prioridad.ToString()),
                new XElement("Estado", incidencia.Estado.ToString()),
                new XElement("FechaCreacionUtc", incidencia.FechaCreacionUtc.ToString("o")),
                new XElement("FechaActualizacionUtc", incidencia.FechaActualizacionUtc.ToString("o")));
        }

        private static string CrearXml(int version, params XElement[] elementos)
        {
            return new XDocument(new XElement("Incidencias", new XAttribute("version", version), elementos))
                .ToString(SaveOptions.DisableFormatting);
        }

        private static void Afirmar(bool condicion, string mensaje)
        {
            if (!condicion)
            {
                throw new InvalidOperationException(mensaje);
            }
        }

        private static void AfirmarLanza<TException>(Action accion)
            where TException : Exception
        {
            AfirmarLanza(typeof(TException), accion);
        }

        private static void AfirmarLanza(Type tipoEsperado, Action accion)
        {
            try
            {
                accion();
            }
            catch (Exception ex)
            {
                if (tipoEsperado.IsAssignableFrom(ex.GetType()))
                {
                    return;
                }

                throw new InvalidOperationException("Se esperaba " + tipoEsperado.Name + " pero ocurrió " + ex.GetType().Name + ".", ex);
            }

            throw new InvalidOperationException("Se esperaba la excepción " + tipoEsperado.Name + ".");
        }

        private sealed class RepositorioFalso : IRepositorioIncidencias
        {
            private readonly List<Incidencia> _datos = new List<Incidencia>();

            public bool FallarAlGuardar { get; set; }

            public IReadOnlyList<Incidencia> UltimoGuardado { get; private set; }

            public IReadOnlyList<Incidencia> Cargar()
            {
                return _datos.Select(Clonar).ToList().AsReadOnly();
            }

            public void Guardar(IReadOnlyList<Incidencia> incidencias)
            {
                if (FallarAlGuardar)
                {
                    throw new IOException("Fallo de escritura simulado.");
                }

                List<Incidencia> copia = incidencias.Select(Clonar).ToList();
                _datos.Clear();
                _datos.AddRange(copia.Select(Clonar));
                UltimoGuardado = copia.AsReadOnly();
            }

            private static Incidencia Clonar(Incidencia incidencia)
            {
                return new Incidencia
                {
                    Id = incidencia.Id,
                    Titulo = incidencia.Titulo,
                    Descripcion = incidencia.Descripcion,
                    Prioridad = incidencia.Prioridad,
                    Estado = incidencia.Estado,
                    FechaCreacionUtc = incidencia.FechaCreacionUtc,
                    FechaActualizacionUtc = incidencia.FechaActualizacionUtc
                };
            }
        }

        private sealed class DirectorioTemporal : IDisposable
        {
            private readonly string _ruta;

            public DirectorioTemporal()
            {
                _ruta = Path.Combine(Path.GetTempPath(), "GestionIncidenciasCopilot.Pruebas." + Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(_ruta);
            }

            public string Archivo(string nombre)
            {
                return Path.Combine(_ruta, nombre);
            }

            public void Dispose()
            {
                if (Directory.Exists(_ruta))
                {
                    Directory.Delete(_ruta, true);
                }
            }
        }
    }
}
