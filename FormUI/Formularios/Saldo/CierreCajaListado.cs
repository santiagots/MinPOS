using Common.Core.Enum;
using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Saldo
{
    public partial class CierreCajaListado : CommonForm
    {
        CierreCajaListadoViewModel cierreCajaListadoViewModel = new CierreCajaListadoViewModel();
        public CierreCajaListado()
        {
            InitializeComponent();
        }

        private void CierreCajaListado_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                cierreCajaListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                cierreCajaListadoViewModelBindingSource.DataSource = cierreCajaListadoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await cierreCajaListadoViewModel.CargarUsuarios();
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }

        private void dgCierreCaja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0)
                    return;

                CierreCajaListadoItem cierreCajaListadoItem = (CierreCajaListadoItem)dgCierreCaja.CurrentRow.DataBoundItem;
                cierreCajaListadoViewModel.Ver(cierreCajaListadoItem);
            });
        }

        private void dgCierreCaja_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Ejecutar(() =>
            {
                if (e.RowIndex < 0)
                    return;

                if (dgCierreCaja.Columns[e.ColumnIndex].Name == "Ver")
                {
                    CierreCajaListadoItem cierreCajaListadoItem = (CierreCajaListadoItem)dgCierreCaja.CurrentRow.DataBoundItem;
                    cierreCajaListadoViewModel.Ver(cierreCajaListadoItem);
                }
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                cierreCajaListadoViewModel.PaginaActual += -1;
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaFinalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                cierreCajaListadoViewModel.PaginaActual = paginado.TotalPaginas;
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaInicalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                cierreCajaListadoViewModel.PaginaActual = 1;
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                cierreCajaListadoViewModel.PaginaActual += 1;
                await cierreCajaListadoViewModel.BuscarAsync();
            });
        }
        private void dgCierreCaja_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (dgCierreCaja.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    cierreCajaListadoViewModel.OrdenadoPor = dgCierreCaja.Columns[e.ColumnIndex].DataPropertyName;

                    cierreCajaListadoViewModel.DireccionOrdenamiento = cierreCajaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? DireccionOrdenamiento.Desc : DireccionOrdenamiento.Asc;
                    await cierreCajaListadoViewModel.BuscarAsync();
                    dgCierreCaja.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = cierreCajaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? SortOrder.Ascending : SortOrder.Descending;
                }
            });
        }
    }
}
