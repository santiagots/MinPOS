using Modelo = Producto.Core.Model;
using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;
using FormUI.Properties;
using FormUI.Enum;
using FormUI.Imprimir.Documento;

namespace FormUI.Formularios.Producto
{
    public partial class ProductoDetalleForm : CommonForm
    {
        private ProductoDetalleViewModel productoDetalleViewModel = new ProductoDetalleViewModel();

        public ProductoDetalleForm()
        {
            InitializeComponent();
        }

        public ProductoDetalleForm(Modelo.Producto producto) : this()
        {
            productoDetalleViewModel = new ProductoDetalleViewModel(producto);
        }

        private void ProductoDetalleForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoDetalleViewModelBindingSource.DataSource = productoDetalleViewModel;
                await productoDetalleViewModel.CargarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await productoDetalleViewModel.GuardarAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnEtiquetaGondola_Click(object sender, EventArgs e)
        {
            Ejecutar(() => productoDetalleViewModel.ImprimirEtiqueta());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            productoDetalleViewModel.AgregarProveedor();
        }

        private void dgProveedor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0)
                    return;

                Modelo.Proveedor proveedor = (Modelo.Proveedor)dgProveedor.CurrentRow.DataBoundItem;

                if (dgProveedor.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.quitarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        productoDetalleViewModel.QuitarProveedor(proveedor);
                }
            });
        }

        private void chkSuelto_CheckedChanged(object sender, EventArgs e)
        {
            Ejecutar(() => productoDetalleViewModel.CambiarTipoEmpaque());
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Ejecutar(() =>
            {
                Modelo.Producto producto = new Modelo.Producto(productoDetalleViewModel.Id, productoDetalleViewModel.Codigo, productoDetalleViewModel.Descripcion, productoDetalleViewModel.CategoriaSeleccionada.Key, productoDetalleViewModel.Proveedores, productoDetalleViewModel.Suelto, productoDetalleViewModel.Costo, productoDetalleViewModel.Precio, productoDetalleViewModel.Habilitado, productoDetalleViewModel.StockMinimo, productoDetalleViewModel.StockOptimo, productoDetalleViewModel.StockActual, null);
                EtiquetaGondola etiquetaGondola = new EtiquetaGondola(producto);
                etiquetaGondola.Imprimir(e.ClipRectangle, e.Graphics);
            });
        }
    }
}
