using System;

namespace GestionIncidenciasCopilot.Entidades
{
    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

    public enum EstadoIncidencia
    {
        Pendiente,
        EnProceso,
        Resuelta
    }

    public class Incidencia
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad Prioridad { get; set; }

        public EstadoIncidencia Estado { get; set; }

        public DateTime FechaCreacionUtc { get; set; }

        public DateTime FechaActualizacionUtc { get; set; }
    }
}
