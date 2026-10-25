using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GestionIncidenciasCopilot.Datos;
using GestionIncidenciasCopilot.Entidades;

namespace GestionIncidenciasCopilot.Controladores
{
    public sealed class ControladorIncidencias
    {
        private readonly IRepositorioIncidencias _repositorio;
        private List<Incidencia> _incidencias;

        public ControladorIncidencias(IRepositorioIncidencias repositorio)
        {
            if (repositorio == null)
            {
                throw new ArgumentNullException("repositorio");
            }

            _repositorio = repositorio;
            IReadOnlyList<Incidencia> cargadas = _repositorio.Cargar();
            if (cargadas == null)
            {
                throw new InvalidDataException("El repositorio devolvió una colección nula.");
            }

            _incidencias = new List<Incidencia>();
            var ids = new HashSet<Guid>();
            foreach (Incidencia incidencia in cargadas)
            {
                ValidarIncidenciaPersistida(incidencia);
                if (!ids.Add(incidencia.Id))
                {
                    throw new InvalidDataException("Los datos cargados contienen IDs de incidencia duplicados.");
                }

                _incidencias.Add(Clonar(incidencia));
            }
        }

        public Incidencia Crear(string titulo, string descripcion, Prioridad prioridad)
        {
            string tituloNormalizado = ValidarTitulo(titulo);
            string descripcionNormalizada = ValidarDescripcion(descripcion);
            ValidarPrioridad(prioridad);

            DateTime ahoraUtc = DateTime.UtcNow;
            var incidencia = new Incidencia
            {
                Id = Guid.NewGuid(),
                Titulo = tituloNormalizado,
                Descripcion = descripcionNormalizada,
                Prioridad = prioridad,
                Estado = EstadoIncidencia.Pendiente,
                FechaCreacionUtc = ahoraUtc,
                FechaActualizacionUtc = ahoraUtc
            };

            var siguiente = ClonarColeccion(_incidencias);
            siguiente.Add(Clonar(incidencia));
            PersistirYAplicar(siguiente);
            return Clonar(incidencia);
        }

        public Incidencia Editar(Guid id, string titulo, string descripcion, Prioridad prioridad)
        {
            int indice = ObtenerIndice(id);
            string tituloNormalizado = ValidarTitulo(titulo);
            string descripcionNormalizada = ValidarDescripcion(descripcion);
            ValidarPrioridad(prioridad);

            Incidencia existente = _incidencias[indice];
            var editada = Clonar(existente);
            editada.Titulo = tituloNormalizado;
            editada.Descripcion = descripcionNormalizada;
            editada.Prioridad = prioridad;
            editada.FechaActualizacionUtc = ObtenerFechaActualizacionUtc(existente.FechaCreacionUtc);

            var siguiente = ClonarColeccion(_incidencias);
            siguiente[indice] = Clonar(editada);
            PersistirYAplicar(siguiente);
            return Clonar(editada);
        }

        public Incidencia CambiarEstado(Guid id, EstadoIncidencia destino)
        {
            int indice = ObtenerIndice(id);
            if (!Enum.IsDefined(typeof(EstadoIncidencia), destino))
            {
                throw new ArgumentOutOfRangeException("destino", "El estado indicado no es válido.");
            }

            Incidencia existente = _incidencias[indice];
            if (!EsTransicionPermitida(existente.Estado, destino))
            {
                throw new InvalidOperationException("La transición de estado solicitada no está permitida.");
            }

            var actualizada = Clonar(existente);
            actualizada.Estado = destino;
            actualizada.FechaActualizacionUtc = ObtenerFechaActualizacionUtc(existente.FechaCreacionUtc);

            var siguiente = ClonarColeccion(_incidencias);
            siguiente[indice] = Clonar(actualizada);
            PersistirYAplicar(siguiente);
            return Clonar(actualizada);
        }

        public IReadOnlyList<Incidencia> ObtenerTodas()
        {
            return EnvoltorioDeSoloLectura(_incidencias);
        }

        public Incidencia ObtenerPorId(Guid id)
        {
            return Clonar(_incidencias[ObtenerIndice(id)]);
        }

        public IReadOnlyList<Incidencia> Buscar(string texto, Prioridad? prioridad, EstadoIncidencia? estado)
        {
            if (prioridad.HasValue)
            {
                ValidarPrioridad(prioridad.Value);
            }

            if (estado.HasValue && !Enum.IsDefined(typeof(EstadoIncidencia), estado.Value))
            {
                throw new ArgumentOutOfRangeException("estado", "El estado indicado no es válido.");
            }

            string termino = texto ?? string.Empty;
            IEnumerable<Incidencia> coincidencias = _incidencias;
            if (termino.Length > 0)
            {
                coincidencias = coincidencias.Where(delegate(Incidencia incidencia)
                {
                    return incidencia.Titulo.IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (incidencia.Descripcion ?? string.Empty).IndexOf(termino, StringComparison.OrdinalIgnoreCase) >= 0;
                });
            }

            if (prioridad.HasValue)
            {
                coincidencias = coincidencias.Where(delegate(Incidencia incidencia)
                {
                    return incidencia.Prioridad == prioridad.Value;
                });
            }

            if (estado.HasValue)
            {
                coincidencias = coincidencias.Where(delegate(Incidencia incidencia)
                {
                    return incidencia.Estado == estado.Value;
                });
            }

            return EnvoltorioDeSoloLectura(coincidencias);
        }

        private void PersistirYAplicar(List<Incidencia> siguiente)
        {
            List<Incidencia> copiaParaGuardar = ClonarColeccion(siguiente);
            _repositorio.Guardar(copiaParaGuardar.AsReadOnly());
            _incidencias = siguiente;
        }

        private int ObtenerIndice(Guid id)
        {
            int indice = _incidencias.FindIndex(delegate(Incidencia incidencia)
            {
                return incidencia.Id == id;
            });

            if (indice < 0)
            {
                throw new KeyNotFoundException("No existe una incidencia con el ID indicado.");
            }

            return indice;
        }

        private static string ValidarTitulo(string titulo)
        {
            if (titulo == null)
            {
                throw new ArgumentNullException("titulo", "El título es obligatorio.");
            }

            string normalizado = titulo.Trim();
            if (normalizado.Length == 0)
            {
                throw new ArgumentException("El título es obligatorio.", "titulo");
            }

            if (normalizado.Length > 120)
            {
                throw new ArgumentException("El título no puede superar 120 caracteres.", "titulo");
            }

            return normalizado;
        }

        private static string ValidarDescripcion(string descripcion)
        {
            string normalizada = descripcion ?? string.Empty;
            if (normalizada.Length > 2000)
            {
                throw new ArgumentException("La descripción no puede superar 2000 caracteres.", "descripcion");
            }

            return normalizada;
        }

        private static void ValidarPrioridad(Prioridad prioridad)
        {
            if (!Enum.IsDefined(typeof(Prioridad), prioridad))
            {
                throw new ArgumentOutOfRangeException("prioridad", "La prioridad indicada no es válida.");
            }
        }

        private static void ValidarIncidenciaPersistida(Incidencia incidencia)
        {
            if (incidencia == null || incidencia.Id == Guid.Empty ||
                string.IsNullOrWhiteSpace(incidencia.Titulo) || incidencia.Titulo != incidencia.Titulo.Trim() ||
                incidencia.Titulo.Length > 120 ||
                (incidencia.Descripcion != null && incidencia.Descripcion.Length > 2000) ||
                !Enum.IsDefined(typeof(Prioridad), incidencia.Prioridad) ||
                !Enum.IsDefined(typeof(EstadoIncidencia), incidencia.Estado) ||
                incidencia.FechaCreacionUtc.Kind != DateTimeKind.Utc ||
                incidencia.FechaActualizacionUtc.Kind != DateTimeKind.Utc ||
                incidencia.FechaActualizacionUtc < incidencia.FechaCreacionUtc)
            {
                throw new InvalidDataException("El repositorio devolvió una incidencia con datos inválidos.");
            }
        }

        private static bool EsTransicionPermitida(EstadoIncidencia actual, EstadoIncidencia destino)
        {
            return (actual == EstadoIncidencia.Pendiente && destino == EstadoIncidencia.EnProceso) ||
                (actual == EstadoIncidencia.EnProceso && destino == EstadoIncidencia.Resuelta) ||
                (actual == EstadoIncidencia.Resuelta && destino == EstadoIncidencia.EnProceso);
        }

        private static DateTime ObtenerFechaActualizacionUtc(DateTime fechaCreacionUtc)
        {
            DateTime ahoraUtc = DateTime.UtcNow;
            return ahoraUtc < fechaCreacionUtc ? fechaCreacionUtc : ahoraUtc;
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

        private static List<Incidencia> ClonarColeccion(IEnumerable<Incidencia> incidencias)
        {
            return incidencias.Select(Clonar).ToList();
        }

        private static IReadOnlyList<Incidencia> EnvoltorioDeSoloLectura(IEnumerable<Incidencia> incidencias)
        {
            return ClonarColeccion(incidencias).AsReadOnly();
        }
    }
}
