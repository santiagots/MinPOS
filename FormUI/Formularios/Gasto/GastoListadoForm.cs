using Common.Core.Enum;
using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoListadoForm : CommonForm
    {
        private GastoListadoViewModel gastoListadoViewModel = new GastoListadoViewModel();

        public GastoListadoForm()
        {
            InitializeComponent();
        }

        private void GastoListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                gastoListadoViewModelBindingSource.DataSource = gastoListadoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await gastoListadoViewModel.Cargar();
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await gastoListadoViewModel.NuevoAsync();
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void dgGastos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                GastoListadoItem gastoListadoItem = (GastoListadoItem)dgGastos.CurrentRow.DataBoundItem;

                if (dgGastos.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await gastoListadoViewModel.ModificarAsync(gastoListadoItem);
                }
            });
        }

        private void dgGastos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                GastoListadoItem gastoListadoItem = (GastoListadoItem)dgGastos.CurrentRow.DataBoundItem;
                await gastoListadoViewModel.ModificarAsync(gastoListadoItem);
            });
        }

        private void paginado_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoListadoViewModel.PaginaActual += -1;
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaFinalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoListadoViewModel.PaginaActual = paginado.TotalPaginas;
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaInicalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoListadoViewModel.PaginaActual = 1;
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoListadoViewModel.PaginaActual += 1;
                await gastoListadoViewModel.BuscarAsync();
            });
        }

        private void dgGastos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (dgGastos.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    if (dgGastos.Columns[e.ColumnIndex].DataPropertyName == "TipoGasto")
                        gastoListadoViewModel.OrdenadoPor = "TipoGasto.Descripcion";
                    else
                        gastoListadoViewModel.OrdenadoPor = dgGastos.Columns[e.ColumnIndex].DataPropertyName;
                    
                    gastoListadoViewModel.DireccionOrdenamiento = gastoListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? DireccionOrdenamiento.Desc : DireccionOrdenamiento.Asc;
                    await gastoListadoViewModel.BuscarAsync();
                    dgGastos.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = gastoListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? SortOrder.Ascending : SortOrder.Descending;
                }
            });
        }
    }
}
