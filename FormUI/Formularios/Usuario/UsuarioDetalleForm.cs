using Modelo = Common.Core.Model;
using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Usuario
{
    public partial class UsuarioDetalleForm : CommonForm
    {
        UsuarioDetalleViewModel usuarioDetalleViewModel = new UsuarioDetalleViewModel();

        public UsuarioDetalleForm()
        {
            InitializeComponent();
        }

        public UsuarioDetalleForm(Modelo.Usuario usuario) : this()
        {
            usuarioDetalleViewModel = new UsuarioDetalleViewModel(usuario);
        }

        private void UsuarioDetalleForm_Load(object sender, EventArgs e)
        {
            Ejecutar(() => usuarioDetalleViewModelBindingSource.DataSource = usuarioDetalleViewModel);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await usuarioDetalleViewModel.GuardarAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
