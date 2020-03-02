using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;
using Venta.Core.Enum;

namespace FormUI.Formularios.Venta
{
    public partial class CobroForm : CommonForm
    {
        CobroViewModel cobroViewModel;
        public decimal MontoPago => cobroViewModel.ObtenerMontoPago();
        public FormaPago FormaPago => cobroViewModel.ObtenerFormaPago();

        public CobroForm(decimal totalACobrar)
        {
            InitializeComponent();

            cobroViewModel = new CobroViewModel(totalACobrar);
        }

        private void CobroForm_Load(object sender, EventArgs e)
        {
            cobroViewModelBindingSource.DataSource = cobroViewModel;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (cobroViewModel.CobroValido())
                    DialogResult = DialogResult.OK;
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
