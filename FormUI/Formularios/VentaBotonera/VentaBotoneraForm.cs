using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.VentaBotonera
{
    public partial class VentaBotoneraForm : CommonForm
    {
        private VentaBotoneraViewModel ventaBotoneraViewModel = new VentaBotoneraViewModel();

        public VentaBotoneraForm()
        {
            InitializeComponent();

            botoneraCategorias.filas = Settings.Default.VentaCategoriaNumeroFilas;
            botoneraCategorias.columnas = Settings.Default.VentaCategoriaNumeroColumnas;
            botoneraProductos.filas = Settings.Default.VentaCategoriaProductosFilas;
            botoneraProductos.columnas = Settings.Default.VentaCategoriaProductosColumnas;
        }

        private void VentaBotoneraForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaBotoneraViewModelBindingSource.DataSource = ventaBotoneraViewModel;
                this.WindowState = FormWindowState.Maximized;
                await ventaBotoneraViewModel.CargarCategoriasAsync();
                await CargarCategoriasEnBotoneraAsync();
                await CargarProductosEnBotoneraAsync();
            });
        }

        private void botoneraCategorias_ClickEventHandler(string categoria)
        {
            EjecutarAsync(async () =>
            {
                ventaBotoneraViewModel.CategoriaSeleccionada = categoria;
                botoneraProductos.PaginaActual = 1;
                await CargarProductosEnBotoneraAsync();
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
            EjecutarAsync(async () => await ventaBotoneraViewModel.GuardarAsync());
        }

        private void botoneraProductos_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await CargarProductosEnBotoneraAsync();
            });
        }

        private void botoneraProductos_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await CargarProductosEnBotoneraAsync();
            });
        }

        private async Task CargarProductosEnBotoneraAsync()
        {
            int totalElementos = await ventaBotoneraViewModel.CargarProductosAsync(botoneraProductos.PaginaActual, botoneraProductos.ElementosPorPagina);
            List<Tuple<string, Image>> elementos = ventaBotoneraViewModel.Productos.Select(x => new Tuple<string, Image>(x.Descripcion, x.ObtenerImagen() ?? Resources.no_foto)).ToList();

            botoneraProductos.Cargar(elementos, totalElementos);
        }

        private async Task CargarCategoriasEnBotoneraAsync()
        {
                List<string> categoriasPagina = ventaBotoneraViewModel.Categorias.Skip(botoneraCategorias.ElementosPorPagina * (botoneraCategorias.PaginaActual - 1))
                                                                                 .Take(botoneraCategorias.ElementosPorPagina)
                                                                                 .ToList();

            List<Tuple<string, Image>> elementos = categoriasPagina.Select(x => new Tuple<string, Image>(x, null)).ToList();

            botoneraCategorias.Cargar(elementos, ventaBotoneraViewModel.Categorias.Count);
        }

    }
}
