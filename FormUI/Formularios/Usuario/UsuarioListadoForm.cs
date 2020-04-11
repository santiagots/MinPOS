using FormUI.Formularios.Common;
using Modelo = Common.Core.Model;
using System;
using System.Windows.Forms;
using FormUI.Enum;
using FormUI.Properties;

namespace FormUI.Formularios.Usuario
{
    public partial class UsuarioListadoForm : CommonForm
    {
        UsuarioListadoViewModel usuarioListadoViewModel = new UsuarioListadoViewModel();

        public UsuarioListadoForm()
        {
            InitializeComponent();
        }

        private void UsuarioListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                usuarioListadoViewModelBindingSource.DataSource = usuarioListadoViewModel;
                await usuarioListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await usuarioListadoViewModel.NuevoAsync();
            });
        }

        private void dgUsuario_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Modelo.Usuario usuario = (Modelo.Usuario)dgUsuario.CurrentRow.DataBoundItem;

                if (dgUsuario.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await usuarioListadoViewModel.ModificarAsync(usuario);
                }
                if (dgUsuario.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        await usuarioListadoViewModel.BorrarAsync(usuario);
                }
            });
        }

        private void dgUsuario_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Modelo.Usuario usuario = (Modelo.Usuario)dgUsuario.CurrentRow.DataBoundItem;
                await usuarioListadoViewModel.ModificarAsync(usuario);
            });
        }
    }
}
