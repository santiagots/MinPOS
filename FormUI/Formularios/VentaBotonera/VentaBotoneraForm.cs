using FormUI.Formularios.Common;
using System;

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
            EjecutarAsync(async () =>
            {
                await ventaBotoneraViewModel.CargarProductoAsync(producto);
            });
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => ventaBotoneraViewModel.AgregarProducto());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
