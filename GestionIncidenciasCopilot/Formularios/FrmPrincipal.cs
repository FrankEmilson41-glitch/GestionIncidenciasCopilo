using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using GestionIncidenciasCopilot.Controladores;
using GestionIncidenciasCopilot.Entidades;

namespace GestionIncidenciasCopilot.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private ControladorIncidencias _controlador;

        public FrmPrincipal()
        {
            InitializeComponent();
            PrepararFormulario();
            Shown += AjustarAlAreaDeTrabajo;
        }

        public FrmPrincipal(ControladorIncidencias controlador)
            : this()
        {
            if (controlador == null)
            {
                throw new ArgumentNullException("controlador");
            }

            _controlador = controlador;
            CargarIncidencias();
        }

        private void AjustarAlAreaDeTrabajo(object sender, EventArgs e)
        {
            Rectangle areaTrabajo = Screen.FromControl(this).WorkingArea;
            MinimumSize = new Size(Math.Min(MinimumSize.Width, areaTrabajo.Width),
                Math.Min(MinimumSize.Height, areaTrabajo.Height));
            int ancho = Math.Min(Width, areaTrabajo.Width);
            int alto = Math.Min(Height, areaTrabajo.Height);
            Bounds = new Rectangle(
                areaTrabajo.Left + (areaTrabajo.Width - ancho) / 2,
                areaTrabajo.Top + (areaTrabajo.Height - alto) / 2,
                ancho,
                alto);
        }

        private void PrepararFormulario()
        {
            comboPrioridad.Items.Clear();
            comboPrioridad.Items.Add("Todas");
            comboPrioridad.Items.Add("Baja");
            comboPrioridad.Items.Add("Media");
            comboPrioridad.Items.Add("Alta");
            comboPrioridad.SelectedIndex = 0;

            comboEstado.Items.Clear();
            comboEstado.Items.Add("Todos");
            comboEstado.Items.Add("Pendiente");
            comboEstado.Items.Add("En proceso");
            comboEstado.Items.Add("Resuelta");
            comboEstado.SelectedIndex = 0;

            botonEditar.Enabled = false;
            botonDetalle.Enabled = false;
            dataGridIncidencias.SelectionChanged += dataGridIncidencias_SelectionChanged;
            textBuscar.TextChanged += filtros_Changed;
            comboPrioridad.SelectedIndexChanged += filtros_Changed;
            comboEstado.SelectedIndexChanged += filtros_Changed;
        }

        private void CargarIncidencias()
        {
            if (_controlador == null)
            {
                dataGridIncidencias.Rows.Clear();
                labelContador.Text = "0 incidencias";
                return;
            }

            Prioridad? prioridad = ObtenerPrioridadSeleccionada();
            EstadoIncidencia? estado = ObtenerEstadoSeleccionado();
            IReadOnlyList<Incidencia> incidencias = _controlador.Buscar(textBuscar.Text, prioridad, estado);

            dataGridIncidencias.Rows.Clear();
            foreach (Incidencia incidencia in incidencias)
            {
                int indice = dataGridIncidencias.Rows.Add(
                    incidencia.Id.ToString("D"),
                    incidencia.Titulo,
                    TextoPrioridad(incidencia.Prioridad),
                    TextoEstado(incidencia.Estado),
                    FormatearFechaUtc(incidencia.FechaCreacionUtc),
                    FormatearFechaUtc(incidencia.FechaActualizacionUtc));
                dataGridIncidencias.Rows[indice].Tag = incidencia.Id;
            }

            dataGridIncidencias.ClearSelection();
            dataGridIncidencias.CurrentCell = null;
            labelContador.Text = incidencias.Count == 1
                ? "1 incidencia"
                : incidencias.Count + " incidencias";
            ActualizarAccionesSeleccion();
        }

        private Prioridad? ObtenerPrioridadSeleccionada()
        {
            switch (comboPrioridad.SelectedItem as string)
            {
                case "Baja":
                    return Prioridad.Baja;
                case "Media":
                    return Prioridad.Media;
                case "Alta":
                    return Prioridad.Alta;
                default:
                    return null;
            }
        }

        private EstadoIncidencia? ObtenerEstadoSeleccionado()
        {
            switch (comboEstado.SelectedItem as string)
            {
                case "Pendiente":
                    return EstadoIncidencia.Pendiente;
                case "En proceso":
                    return EstadoIncidencia.EnProceso;
                case "Resuelta":
                    return EstadoIncidencia.Resuelta;
                default:
                    return null;
            }
        }

        private void filtros_Changed(object sender, EventArgs e)
        {
            CargarIncidenciasConManejoDeError();
        }

        private void dataGridIncidencias_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarAccionesSeleccion();
        }

        private void ActualizarAccionesSeleccion()
        {
            bool haySeleccion = dataGridIncidencias.SelectedRows.Count > 0;
            botonEditar.Enabled = haySeleccion && _controlador != null;
            botonDetalle.Enabled = haySeleccion && _controlador != null;
        }

        private Guid? ObtenerIdSeleccionado()
        {
            if (dataGridIncidencias.SelectedRows.Count == 0)
            {
                return null;
            }

            object valor = dataGridIncidencias.SelectedRows[0].Tag;
            return valor is Guid ? (Guid?)valor : null;
        }

        private void botonNueva_Click(object sender, EventArgs e)
        {
            if (_controlador == null)
            {
                return;
            }

            try
            {
                using (var formulario = new FrmIncidencia(_controlador, null))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarIncidencias();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MostrarError("No se pudo completar el formulario. " + ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para acceder a los datos. " + ex.Message);
            }
            catch (IOException ex)
            {
                MostrarError("No se pudieron guardar los datos. " + ex.Message);
            }
            catch (XmlException ex)
            {
                MostrarError("No se pudieron procesar los datos XML. " + ex.Message);
            }
        }

        private void botonEditar_Click(object sender, EventArgs e)
        {
            Guid? id = ObtenerIdSeleccionado();
            if (_controlador == null || !id.HasValue)
            {
                return;
            }

            try
            {
                using (var formulario = new FrmIncidencia(_controlador, id.Value))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        CargarIncidencias();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MostrarError("No se pudo completar la edición. " + ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para acceder a los datos. " + ex.Message);
            }
            catch (IOException ex)
            {
                MostrarError("No se pudieron guardar los datos. " + ex.Message);
            }
            catch (XmlException ex)
            {
                MostrarError("No se pudieron procesar los datos XML. " + ex.Message);
            }
        }

        private void botonDetalle_Click(object sender, EventArgs e)
        {
            Guid? id = ObtenerIdSeleccionado();
            if (_controlador == null || !id.HasValue)
            {
                return;
            }

            try
            {
                using (var formulario = new FrmDetalle(_controlador, id.Value))
                {
                    formulario.ShowDialog(this);
                }
            }
            catch (ArgumentException ex)
            {
                MostrarError("No se pudo abrir el detalle. " + ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para acceder a los datos. " + ex.Message);
            }
            catch (IOException ex)
            {
                MostrarError("No se pudieron leer los datos. " + ex.Message);
            }
            catch (XmlException ex)
            {
                MostrarError("No se pudieron procesar los datos XML. " + ex.Message);
            }
            finally
            {
                CargarIncidenciasConManejoDeError();
            }
        }

        private void CargarIncidenciasConManejoDeError()
        {
            try
            {
                CargarIncidencias();
            }
            catch (ArgumentException ex)
            {
                MostrarError("No se pudo actualizar el listado. " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError("No se pudo actualizar el listado. " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para acceder a los datos. " + ex.Message);
            }
            catch (IOException ex)
            {
                MostrarError("No se pudieron leer los datos. " + ex.Message);
            }
            catch (XmlException ex)
            {
                MostrarError("No se pudieron procesar los datos XML. " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(this, mensaje, "Gestor de incidencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static string TextoPrioridad(Prioridad prioridad)
        {
            switch (prioridad)
            {
                case Prioridad.Baja:
                    return "Baja";
                case Prioridad.Media:
                    return "Media";
                case Prioridad.Alta:
                    return "Alta";
                default:
                    return prioridad.ToString();
            }
        }

        private static string TextoEstado(EstadoIncidencia estado)
        {
            switch (estado)
            {
                case EstadoIncidencia.Pendiente:
                    return "Pendiente";
                case EstadoIncidencia.EnProceso:
                    return "En proceso";
                case EstadoIncidencia.Resuelta:
                    return "Resuelta";
                default:
                    return estado.ToString();
            }
        }

        private static string FormatearFechaUtc(DateTime fechaUtc)
        {
            return fechaUtc.ToString("dd/MM/yyyy HH:mm:ss 'UTC'");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
