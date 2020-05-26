using Common.Core.Exception;
using Common.Core.Helper;
using FormUI.Enum;
using FormUI.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();
        }

        internal void MostrarFormularioEnContenedor(Type formulario, Form contenedor)
        {
            Form formularioAbierto = ObtenerFormularioAbierto(formulario);
            if (formularioAbierto != null) 
                formularioAbierto.BringToFront();
            else
            {
                Form instancia = (Form)Activator.CreateInstance(formulario);
                instancia.MdiParent = contenedor;
                instancia.Show();
            }
        }

        private static Form ObtenerFormularioAbierto(Type formulario)
        {
            foreach (var openForm in Application.OpenForms)
            {
                if (openForm.GetType() == formulario)
                    return (Form)openForm;
            }

            return null;
        }

        internal void MostrarFormularioModal(Type formulario)
        {
            Form instancia = (Form)Activator.CreateInstance(formulario);
            instancia.ShowDialog();
        }

        internal void MostrarFormulario(Type formulario)
        {
            Form instancia = (Form)Activator.CreateInstance(formulario);
            instancia.Show();
        }

        internal void Ejecutar(Action accion)
        {
            try
            {
                this.UseWaitCursor = true;
                accion();
            }
            catch (NegocioException ex)
            {
                Log.Error(ex);
                CustomMessageBox.ShowDialog(ex.Message, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                CustomMessageBox.ShowDialog(Resources.accionError, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        internal async void EjecutarAsync(Func<Task> accion)
        {
            try
            {
                this.UseWaitCursor = true;
                await accion();
            }
            catch (NegocioException ex)
            {
                Log.Error(ex);
                CustomMessageBox.ShowDialog(ex.Message, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                CustomMessageBox.ShowDialog(Resources.accionError, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private void CommonForm_Load(object sender, EventArgs e)
        {

        }
    }
}
