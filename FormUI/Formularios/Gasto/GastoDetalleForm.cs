using FormUI.Componentes;
using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Windows.Forms;
using ModeloGasto = Gasto.Core.Model;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoDetalleForm : CommonForm
    {
        private GastoDetalleViewModel gastoDetalleViewModel = new GastoDetalleViewModel();

        public GastoDetalleForm()
        {
            InitializeComponent();
        }

        public GastoDetalleForm(Decimal montoGasto, string comentario) : this()
        {
            gastoDetalleViewModel = new GastoDetalleViewModel(montoGasto, comentario);
        }

        public GastoDetalleForm(ModeloGasto.Gasto gasto) : this()
        {
            gastoDetalleViewModel = new GastoDetalleViewModel(gasto);
        }

        private void GastoDetalleForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                gastoDetalleViewModelBindingSource.DataSource = gastoDetalleViewModel;
                await gastoDetalleViewModel.CargarTipoGastoAsync();
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await gastoDetalleViewModel.GuardarAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                DialogResult = DialogResult.OK;
            });
        }
    }
}
