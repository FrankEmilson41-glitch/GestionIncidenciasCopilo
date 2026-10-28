using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using GestionIncidenciasCopilot.Controladores;
using GestionIncidenciasCopilot.Datos;
using GestionIncidenciasCopilot.Formularios;

namespace GestionIncidenciasCopilot
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string directorioDatos = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GestionIncidenciasCopilot");
            string rutaDatos = Path.Combine(directorioDatos, "incidencias.xml");
            ControladorIncidencias controlador;

            try
            {
                var repositorio = new RepositorioXmlIncidencias(rutaDatos);
                controlador = new ControladorIncidencias(repositorio);
            }
            catch (UnauthorizedAccessException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }
            catch (InvalidDataException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }
            catch (IOException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }
            catch (XmlException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }
            catch (InvalidOperationException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }
            catch (ArgumentException ex)
            {
                MostrarErrorCarga(ex);
                return;
            }

            Application.Run(new FrmPrincipal(controlador));
        }

        private static void MostrarErrorCarga(Exception ex)
        {
            MessageBox.Show(
                "No se pudieron cargar las incidencias. No se modificó el archivo de datos.\n\n" + ex.Message,
                "Error al iniciar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
