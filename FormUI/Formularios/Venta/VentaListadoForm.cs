using Common.Core.Enum;
using FormUI.Formularios.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Ejecutar(() =>
            {
                ventaListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                ventaListadoViewModelBindingSource.DataSource = ventaListadoViewModel;
                ventaListadoViewModel.CargarFormasDePago();
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
