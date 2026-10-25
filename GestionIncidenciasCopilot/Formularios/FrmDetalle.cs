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
    public partial class FrmDetalle : Form
    {
        private ControladorIncidencias _controlador;
        private Guid _id;
        private bool _inicializadoParaUso;
        private bool _huboCambios;

        public FrmDetalle()
        {
            InitializeComponent();
            PrepararFormulario();
            Shown += AjustarAlAreaDeTrabajo;
            FormClosing += FrmDetalle_FormClosing;
        }

        public FrmDetalle(ControladorIncidencias controlador, Guid id)
            : this()
        {
            if (controlador == null)
            {
                throw new ArgumentNullException("controlador");
            }

            _controlador = controlador;
            _id = id;
            CargarIncidencia();
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
            comboDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            comboDestino.Format += delegate(object sender, ListControlConvertEventArgs e)
            {
                e.Value = TextoEstado((EstadoIncidencia)e.ListItem);
            };
        }

        private void CargarIncidencia()
        {
            Incidencia incidencia = _controlador.ObtenerPorId(_id);
            Text = "Detalle de incidencia " + incidencia.Id.ToString("D");
            labelEncabezado.Text = "Detalle de incidencia";
            labelSubtitulo.Text = "Consulta la información y gestiona el estado.";
            textId.Text = incidencia.Id.ToString("D");
            textTitulo.Text = incidencia.Titulo;
            textDescripcion.Text = incidencia.Descripcion ?? string.Empty;
            textPrioridad.Text = TextoPrioridad(incidencia.Prioridad);
            textEstado.Text = TextoEstado(incidencia.Estado);
            textFechaCreacion.Text = FormatearFechaUtc(incidencia.FechaCreacionUtc);
            textFechaActualizacion.Text = FormatearFechaUtc(incidencia.FechaActualizacionUtc);
            CargarDestinosValidos(incidencia.Estado);
        }

        private void CargarDestinosValidos(EstadoIncidencia estadoActual)
        {
            comboDestino.Items.Clear();
            switch (estadoActual)
            {
                case EstadoIncidencia.Pendiente:
                    comboDestino.Items.Add(EstadoIncidencia.EnProceso);
                    break;
                case EstadoIncidencia.EnProceso:
                    comboDestino.Items.Add(EstadoIncidencia.Resuelta);
                    break;
                case EstadoIncidencia.Resuelta:
                    comboDestino.Items.Add(EstadoIncidencia.EnProceso);
                    break;
            }

            comboDestino.SelectedIndex = comboDestino.Items.Count == 0 ? -1 : 0;
            comboDestino.Enabled = comboDestino.Items.Count > 0;
            botonCambiarEstado.Enabled = comboDestino.Enabled;
        }

        private void botonCambiarEstado_Click(object sender, EventArgs e)
        {
            if (!_inicializadoParaUso || _controlador == null || comboDestino.SelectedItem == null)
            {
                return;
            }

            try
            {
                _controlador.CambiarEstado(_id, (EstadoIncidencia)comboDestino.SelectedItem);
                _huboCambios = true;
                CargarIncidencia();
            }
            catch (KeyNotFoundException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                MostrarError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para guardar los datos. " + ex.Message);
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
            if (!_inicializadoParaUso || _controlador == null)
            {
                return;
            }

            try
            {
                using (var formulario = new FrmIncidencia(_controlador, _id))
                {
                    if (formulario.ShowDialog(this) == DialogResult.OK)
                    {
                        _huboCambios = true;
                        CargarIncidencia();
                    }
                }
            }
            catch (KeyNotFoundException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MostrarError(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                MostrarError(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarError("No hay permiso para leer los datos. " + ex.Message);
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

        private void botonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDetalle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_huboCambios)
            {
                DialogResult = DialogResult.OK;
            }
            else if (DialogResult == DialogResult.None)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(this, mensaje, "No se pudo completar la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
