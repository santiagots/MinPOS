using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Formularios.Producto;
using FormUI.Properties;
using Gasto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoTipoListadoForm : CommonForm
    {
        private GastoTipoListadoViewModel gastoTipoListadoViewModel = new GastoTipoListadoViewModel();

        public GastoTipoListadoForm()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () => await gastoTipoListadoViewModel.NuevoAsync());
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () => { await gastoTipoListadoViewModel.BuscarAsync(); });
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (e.KeyChar == (char)Keys.Return)
                    await gastoTipoListadoViewModel.BuscarAsync();
            });
        }

        private void GastoTipoListadoForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoTipoListadoViewModelBindingSource.DataSource = gastoTipoListadoViewModel;
                this.WindowState = FormWindowState.Maximized;
                await gastoTipoListadoViewModel.BuscarAsync();
            });
        }

        private void dgTipoGasto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                TipoGasto tipoGasto = (TipoGasto)dgTipoGasto.CurrentRow.DataBoundItem;
                if (dgTipoGasto.Columns[e.ColumnIndex].Name == "Editar")
                {
                    await gastoTipoListadoViewModel.ModificarAsync(tipoGasto);
                }
                if (dgTipoGasto.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.eliminarElemento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                        await gastoTipoListadoViewModel.BorrarAsync(tipoGasto);
                }
            });
        }

        private void dgTipoGasto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EjecutarAsync(async () =>
            {
                TipoGasto tipoGasto = (TipoGasto)dgTipoGasto.CurrentRow.DataBoundItem;
                await gastoTipoListadoViewModel.ModificarAsync(tipoGasto);
            });
        }
    }
}
