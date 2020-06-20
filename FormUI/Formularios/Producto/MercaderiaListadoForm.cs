using Common.Core.Enum;
using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Producto
{
    public partial class MercaderiaListadoForm : CommonForm
    {
        MercaderiaListadoViewModel mercaderiaListadoViewModel = new MercaderiaListadoViewModel();
        public MercaderiaListadoForm()
        {
            InitializeComponent();
        }

        public MercaderiaListadoForm(DateTime fechaRecepcion) : this()
        {
            mercaderiaListadoViewModel = new MercaderiaListadoViewModel(fechaRecepcion);
        }

        private void MercaderiaListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaListadoViewModel.ElementosPorPagina = paginado.ElementosPorPagina;
                mercaderiaListadoViewModelBindingSource.DataSource = mercaderiaListadoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await mercaderiaListadoViewModel.CargarAsync();
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                MostrarFormularioModal(typeof(MercaderiaDetalleForm));
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void dgMercaderia_CellMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                MercaderiaListadoItem mercaderiaListadoItem = (MercaderiaListadoItem)dgMercaderia.CurrentRow.DataBoundItem;
                if (dgMercaderia.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await mercaderiaListadoViewModel.ModificarAsync(mercaderiaListadoItem);
                    await mercaderiaListadoViewModel.BuscarAsync();
                }
                if (dgMercaderia.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                    {
                        await mercaderiaListadoViewModel.BorrarAsync(mercaderiaListadoItem);
                        await mercaderiaListadoViewModel.BuscarAsync();
                    }
                }
            });
        }

        private void dgMercaderia_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.RowIndex < 0)
                    return;

                MercaderiaListadoItem mercaderiaListadoItem = (MercaderiaListadoItem)dgMercaderia.CurrentRow.DataBoundItem;
                await mercaderiaListadoViewModel.ModificarAsync(mercaderiaListadoItem);
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaAnteriorClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaListadoViewModel.PaginaActual += -1;
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaFinalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaListadoViewModel.PaginaActual = paginado.TotalPaginas;
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaInicalClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaListadoViewModel.PaginaActual = 1;
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void paginado_PaginaSiguienteClick(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                mercaderiaListadoViewModel.PaginaActual += 1;
                await mercaderiaListadoViewModel.BuscarAsync();
            });
        }

        private void dgMercaderia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (dgMercaderia.Columns[e.ColumnIndex].SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    switch (dgMercaderia.Columns[e.ColumnIndex].HeaderText)
                    {
                        case "F. Alta":
                            mercaderiaListadoViewModel.OrdenadoPor = "Fecha"; break;
                        case "F. Ingreso":
                            mercaderiaListadoViewModel.OrdenadoPor = "FechaRecepcion"; break;
                        case "Proveedor":
                            mercaderiaListadoViewModel.OrdenadoPor = "Proveedor.RazonSocial"; break;
                        case "Estado":
                            mercaderiaListadoViewModel.OrdenadoPor = "Estado"; break;
                        default:
                            throw new InvalidOperationException();
                    }
                    mercaderiaListadoViewModel.DireccionOrdenamiento = mercaderiaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? DireccionOrdenamiento.Desc : DireccionOrdenamiento.Asc;
                    await mercaderiaListadoViewModel.BuscarAsync();
                    dgMercaderia.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = mercaderiaListadoViewModel.DireccionOrdenamiento == DireccionOrdenamiento.Asc ? SortOrder.Ascending : SortOrder.Descending;
                }
            });
        }
    }
}
