using FormUI.Formularios.Common;
using Producto.Core.Model;
using System.Windows.Forms;
using System;

namespace FormUI.Formularios.Producto
{
    public partial class ProveedorBusquedaForm : CommonForm
    {
        ProveedorBusquedaViewModel proveedorBusquedaViewModel = new ProveedorBusquedaViewModel();

        public Proveedor Proveedro { get; internal set; }

        public ProveedorBusquedaForm()
        {
            InitializeComponent();
        }

        private void ProveedorBusquedaForm_Load(object sender, EventArgs e)
        {
            proveedorBusquedaViewModelBindingSource.DataSource = proveedorBusquedaViewModel;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await proveedorBusquedaViewModel.BuscarAsync();
            });
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Proveedro = (Proveedor)dgProveedor.CurrentRow.DataBoundItem;
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
