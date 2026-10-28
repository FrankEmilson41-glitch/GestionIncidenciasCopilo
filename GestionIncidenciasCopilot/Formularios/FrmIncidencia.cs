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
    public partial class FrmIncidencia : Form
    {
        private ControladorIncidencias _controlador;
        private Guid? _id;
        private bool _inicializadoParaUso;

        public FrmIncidencia()
        {
            InitializeComponent();
            PrepararFormulario();
            Shown += AjustarAlAreaDeTrabajo;
        }

        public FrmIncidencia(ControladorIncidencias controlador, Guid? id)
            : this()
        {
            if (controlador == null)
            {
                throw new ArgumentNullException("controlador");
            }

            _controlador = controlador;
            _id = id;
            CargarDatosExistentes();
            _inicializadoParaUso = true;
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
            comboPrioridad.Items.Add(Prioridad.Baja);
            comboPrioridad.Items.Add(Prioridad.Media);
            comboPrioridad.Items.Add(Prioridad.Alta);
            comboPrioridad.SelectedItem = Prioridad.Media;

            comboPrioridad.Format += delegate(object sender, ListControlConvertEventArgs e)
            {
                e.Value = TextoPrioridad((Prioridad)e.ListItem);
            };

            Text = "Nueva incidencia";
            textEstado.Text = EstadoIncidencia.Pendiente.ToString();
            textFechaCreacion.Text = "Se asigna al guardar";
            textFechaActualizacion.Text = "Se asigna al guardar";
            labelEncabezado.Text = "Registrar incidencia";
            labelSubtitulo.Text = "Describe el problema y define su prioridad.";
        }

        private void CargarDatosExistentes()
        {
            if (!_id.HasValue)
            {
                return;
            }

            Incidencia incidencia = _controlador.ObtenerPorId(_id.Value);
            Text = "Editar incidencia";
            labelEncabezado.Text = "Editar incidencia";
            labelSubtitulo.Text = "Se conservan el estado y la creación; la actualización cambia al guardar.";
            textTitulo.Text = incidencia.Titulo;
            textDescripcion.Text = incidencia.Descripcion;
            comboPrioridad.SelectedItem = incidencia.Prioridad;
            textEstado.Text = TextoEstado(incidencia.Estado);
            textFechaCreacion.Text = FormatearFechaUtc(incidencia.FechaCreacionUtc);
            textFechaActualizacion.Text = FormatearFechaUtc(incidencia.FechaActualizacionUtc);
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!_inicializadoParaUso || _controlador == null)
            {
                errorProvider.SetError(textTitulo, "Abra este formulario desde la aplicación para guardar.");
                return;
            }

            if (comboPrioridad.SelectedItem == null)
            {
                errorProvider.SetError(comboPrioridad, "Seleccione una prioridad.");
                return;
            }

            try
            {
                Prioridad prioridad = (Prioridad)comboPrioridad.SelectedItem;
                if (_id.HasValue)
                {
                    _controlador.Editar(_id.Value, textTitulo.Text, textDescripcion.Text, prioridad);
                }
                else
                {
                    _controlador.Crear(textTitulo.Text, textDescripcion.Text, prioridad);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MostrarErrorValidacion(ex);
            }
            catch (KeyNotFoundException ex)
            {
                MostrarErrorGeneral(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarErrorGeneral(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                MostrarErrorGeneral(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarErrorGeneral("No hay permiso para guardar los datos. " + ex.Message);
            }
            catch (IOException ex)
            {
                MostrarErrorGeneral("No se pudieron guardar los datos. " + ex.Message);
            }
            catch (XmlException ex)
            {
                MostrarErrorGeneral("No se pudieron procesar los datos XML. " + ex.Message);
            }
        }

        private void MostrarErrorValidacion(ArgumentException ex)
        {
            if (string.Equals(ex.ParamName, "titulo", StringComparison.OrdinalIgnoreCase))
            {
                errorProvider.SetError(textTitulo, ex.Message);
                textTitulo.Focus();
            }
            else if (string.Equals(ex.ParamName, "descripcion", StringComparison.OrdinalIgnoreCase))
            {
                errorProvider.SetError(textDescripcion, ex.Message);
                textDescripcion.Focus();
            }
            else if (string.Equals(ex.ParamName, "prioridad", StringComparison.OrdinalIgnoreCase))
            {
                errorProvider.SetError(comboPrioridad, ex.Message);
                comboPrioridad.Focus();
            }
            else
            {
                MostrarErrorGeneral(ex.Message);
            }
        }

        private void MostrarErrorGeneral(string mensaje)
        {
            MessageBox.Show(this, mensaje, "No se pudo guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case EstadoIncidencia.EnProceso:
                    return "En proceso";
                case EstadoIncidencia.Pendiente:
                    return "Pendiente";
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
    }
}
