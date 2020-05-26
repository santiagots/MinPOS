using Modelo = Producto.Core.Model;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Windows.Forms;
using System.Drawing;
using Common.Core.Enum;
using FormUI.Enum;

namespace FormUI.Formularios.Producto
{
    public partial class ProductoListadoFrom : CommonForm
    {
        ProductoListadoViewModel productoListadoViewModel = new ProductoListadoViewModel();
        public ProductoListadoFrom()
        {
            InitializeComponent();
        }

        private void ProductosFrom_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                productoListadoViewModelBindingSource.DataSource = productoListadoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await productoListadoViewModel.CargarAsync();
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await productoListadoViewModel.NuevoAsync();
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyChar == (char)Keys.Return)
                    await productoListadoViewModel.BuscarAsync();
            });
        }

        private void dgProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                Modelo.Producto producto = (Modelo.Producto)dgProductos.CurrentRow.DataBoundItem;

                if (dgProductos.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await productoListadoViewModel.ModificarAsync(producto);
                }
                if (dgProductos.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        await productoListadoViewModel.BorrarAsync(producto);
                }
            });
        }

        private void dgProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                Modelo.Producto producto = (Modelo.Producto)dgProductos.CurrentRow.DataBoundItem;
                await productoListadoViewModel.ModificarAsync(producto);
            });
        }

        private void dgProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgProductos[0, e.RowIndex].Value == null)
                return;

            Modelo.Producto producto = (Modelo.Producto)dgProductos.Rows[e.RowIndex].DataBoundItem;
            if (producto.EnFalta())
                dgProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Coral;
            else
                dgProductos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;

        }

        private void paginado_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoListadoViewModel.PaginaActual += -1;
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaFinalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoListadoViewModel.PaginaActual = paginado.TotalPaginas;
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaInicalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoListadoViewModel.PaginaActual = 1;
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                productoListadoViewModel.PaginaActual += 1;
                await productoListadoViewModel.BuscarAsync();
            });
        }

        private void dgProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (dgProductos.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    productoListadoViewModel.OrdenadoPor = dgProductos.Columns[e.ColumnIndex].DataPropertyName;
                    productoListadoViewModel.DireccionOrdenamiento = productoListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? DireccionOrdenamiento.Desc : DireccionOrdenamiento.Asc;
                    await productoListadoViewModel.BuscarAsync();
                    dgProductos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = productoListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? SortOrder.Ascending : SortOrder.Descending;
                }
            });
        }

        private void btnHacerPedido_Click(object sender, EventArgs e)
        {
            productoListadoViewModel.HacerPedidoAsync();
        }
    }
}
