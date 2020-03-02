using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class ProveedorDetalleForm : CommonForm
    {
        ProveedorDetalleViewModel proveedorDetalleViewModel = new ProveedorDetalleViewModel();
        public ProveedorDetalleForm()
        {
            InitializeComponent();
        }

        public ProveedorDetalleForm(Proveedor proveedor): this()
        {
            proveedorDetalleViewModel = new ProveedorDetalleViewModel(proveedor);
        }

        private void ProveedorDetalleForm_Load(object sender, EventArgs e)
        {
            proveedorDetalleViewModelBindingSource.DataSource = proveedorDetalleViewModel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await proveedorDetalleViewModel.GuardarAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Info);
                Close();
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
