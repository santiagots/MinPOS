using Common.Core.Enum;
using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Venta
{
    public partial class VentaListadoForm : CommonForm
    {
        VentaListadoViewModel ventaListadoViewModel = new VentaListadoViewModel();
        public VentaListadoForm()
        {
            InitializeComponent();
        }

        private void VentaListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                this.WindowState = FormWindowState.Maximized;
                ventaListadoViewModelBindingSource.DataSource = ventaListadoViewModel;
                ventaListadoViewModel.CargarFormasDePago();
                await ventaListadoViewModel.CargarUsuarios();
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void dgVentas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                VentaListadoItem ventaListadoItem = (VentaListadoItem)dgVentas.CurrentRow.DataBoundItem;

                if (dgVentas.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await ventaListadoViewModel.ModificarAsync(ventaListadoItem);
                }
            });
        }

        private void dgVentas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                VentaListadoItem ventaListadoItem = (VentaListadoItem)dgVentas.CurrentRow.DataBoundItem;
                await ventaListadoViewModel.ModificarAsync(ventaListadoItem);
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaListadoViewModel.PaginaActual += -1;
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaFinalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaListadoViewModel.PaginaActual = paginado.TotalPaginas;
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaInicalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaListadoViewModel.PaginaActual = 1;
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                ventaListadoViewModel.PaginaActual += 1;
                await ventaListadoViewModel.BuscarAsync();
            });
        }

        private void dgVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (dgVentas.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    switch (dgVentas.Columns[e.ColumnIndex].HeaderText)
                    {
                        case "Fecha":
                            ventaListadoViewModel.OrdenadoPor = "FechaAlta"; break;
                        case "Forma de Pago":
                            ventaListadoViewModel.OrdenadoPor = "Pago.FormaPago"; break;
                        case "Total":
                            ventaListadoViewModel.OrdenadoPor = "Pago.Monto"; break;
                        case "Usuario Alta":
                            ventaListadoViewModel.OrdenadoPor = "UsuarioAlta"; break;
                        case "Anulada":
                            ventaListadoViewModel.OrdenadoPor = "Anulada"; break;
                        case "F. Anulación":
                            ventaListadoViewModel.OrdenadoPor = "FechaAnulada"; break;
                        default:
                            throw new InvalidOperationException();
                    }
                    ventaListadoViewModel.DireccionOrdenamiento = ventaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? DireccionOrdenamiento.Desc : DireccionOrdenamiento.Asc;
                    await ventaListadoViewModel.BuscarAsync();
                    dgVentas.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ventaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? SortOrder.Ascending : SortOrder.Descending;
                }
            });
        }
    }
}
