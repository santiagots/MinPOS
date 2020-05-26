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
                await gastoListadoViewModel.NuevoAsync(this.MdiParent);
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
                    await gastoListadoViewModel.ModificarAsync(gastoListadoItem, this.MdiParent);
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
                await gastoListadoViewModel.ModificarAsync(gastoListadoItem, this.MdiParent);
            });
        }
    }
}
