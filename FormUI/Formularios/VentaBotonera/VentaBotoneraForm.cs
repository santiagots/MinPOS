using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.VentaBotonera
{
    public partial class VentaBotoneraForm : CommonForm
    {
        private VentaBotoneraViewModel ventaBotoneraViewModel = new VentaBotoneraViewModel();

        public VentaBotoneraForm()
        {
            InitializeComponent();
        }

        private void VentaBotoneraForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaBotoneraViewModelBindingSource.DataSource = ventaBotoneraViewModel;
                this.WindowState = FormWindowState.Maximized;
                await ventaBotoneraViewModel.CargarCategoriasAsync();
                botoneraCategorias.Cargar(ventaBotoneraViewModel.Categorias);
            });
        }

        private void botoneraCategorias_ClickEventHandler(string categoria)
        {
            EjecutarAsync(async () =>
            {
                await ventaBotoneraViewModel.CargarProductosAsync(categoria);
                botoneraProductos.Cargar(ventaBotoneraViewModel.Productos);
            });
        }

        private void botoneraProductos_ClickEventHandler(string producto)
        {
            EjecutarAsync(async () => await ventaBotoneraViewModel.CargarProductoAsync(producto));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => ventaBotoneraViewModel.AgregarProducto());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => ventaBotoneraViewModel.Cancelar());
        }

        private void dgProductos_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0)
                    return;

                VentaBotoneraItem ventaBotoneraItem = (VentaBotoneraItem)dgProductos.CurrentRow.DataBoundItem;
                if (dgProductos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.quitarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                    {
                        ventaBotoneraViewModel.Quitar(ventaBotoneraItem);
                    }
                }
            });
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => ventaBotoneraViewModel.GuardarAsync());
        }
    }
}
