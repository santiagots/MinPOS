using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class ProveedorListadoForm : CommonForm
    {
        ProveedorListadoViewModel proveedorListadoViewModel = new ProveedorListadoViewModel();
        public ProveedorListadoForm()
        {
            InitializeComponent();
        }

        private void ProveedorListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                proveedorListadoViewModelBindingSource.DataSource = proveedorListadoViewModel;
                await proveedorListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await proveedorListadoViewModel.NuevoAsync();
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await proveedorListadoViewModel.BuscarAsync();
            });
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyChar == (char)Keys.Return)
                    await proveedorListadoViewModel.BuscarAsync();
            });
        }

        private void dgProveedor_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Proveedor proveedor = (Proveedor)dgProveedor.CurrentRow.DataBoundItem;

                if (dgProveedor.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await proveedorListadoViewModel.ModificarAsync(proveedor);
                }
                if (dgProveedor.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        await proveedorListadoViewModel.BorrarAsync(proveedor);
                }
            });
        }

        private void dgProveedor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                Proveedor proveedor = (Proveedor)dgProveedor.CurrentRow.DataBoundItem;
                await proveedorListadoViewModel.ModificarAsync(proveedor);
            });
        }
    }
}
