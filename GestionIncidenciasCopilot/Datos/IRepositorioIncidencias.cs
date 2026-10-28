using System.Collections.Generic;
using GestionIncidenciasCopilot.Entidades;

namespace GestionIncidenciasCopilot.Datos
{
    public interface IRepositorioIncidencias
    {
        IReadOnlyList<Incidencia> Cargar();

        void Guardar(IReadOnlyList<Incidencia> incidencias);
    }
}
