using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class CategoriaListadoForm : CommonForm
    {
        CategoriaListadoViewModel categoriaListadoViewModel = new CategoriaListadoViewModel();
        public CategoriaListadoForm()
        {
            InitializeComponent();
        }

        private void CategoriaListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                categoriaListadoViewModelBindingSource.DataSource = categoriaListadoViewModel;
                await categoriaListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await categoriaListadoViewModel.NuevoAsync();
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await categoriaListadoViewModel.BuscarAsync();
            });
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyChar == (char)Keys.Return)
                    await categoriaListadoViewModel.BuscarAsync();
            });
        }

        private void dgCategoria_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Categoria categoria = (Categoria)dgCategoria.CurrentRow.DataBoundItem;
                if (dgCategoria.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await categoriaListadoViewModel.ModificarAsync(categoria);
                }
                if (dgCategoria.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if(DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        await categoriaListadoViewModel.BorrarAsync(categoria);
                }
            });
        }

        private void dgCategoria_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Categoria categoria = (Categoria)dgCategoria.CurrentRow.DataBoundItem;
                await categoriaListadoViewModel.ModificarAsync(categoria);
            });
        }
    }
}
