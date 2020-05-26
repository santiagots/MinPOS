using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Gasto.Core.Model;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoTipoDetalleForm : CommonForm
    {
        private GastoTipoDetalleViewModel gastoTipoDetalleViewModel = new GastoTipoDetalleViewModel();

        public GastoTipoDetalleForm()
        {
            InitializeComponent();
        }

        public GastoTipoDetalleForm(TipoGasto tipoGasto) : this()
        {
            gastoTipoDetalleViewModel = new GastoTipoDetalleViewModel(tipoGasto);
        }

        private void GastoTipoDetalleForm_Load(object sender, EventArgs e)
        {
            gastoTipoDetalleViewModelBindingSource.DataSource = gastoTipoDetalleViewModel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await gastoTipoDetalleViewModel.Guardar();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
