using FormUI.Formularios.Common;
using System;
using System.Windows.Forms;
using Venta.Core.Enum;

namespace FormUI.Formularios.VentaBotonera
{
    public partial class CobroForm : CommonForm
    {
        CobroViewModel cobroViewModel;
        public decimal MontoTotal => cobroViewModel.Total;
        public decimal MontoPago => cobroViewModel.PagaCon;
        public decimal MontoDescuento => cobroViewModel.DescuentoMonto;
        public FormaPago FormaPago => cobroViewModel.FormaPagoSeleccionado.Key.Value;

        public CobroForm(decimal totalACobrar)
        {
            InitializeComponent();

            cobroViewModel = new CobroViewModel(totalACobrar);
        }

        private void CobroForm_Load(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                cobroViewModelBindingSource.DataSource = cobroViewModel;
                cobroViewModel.CargarFormasDePago();
            });
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            Ejecutar(() => cobroViewModel.ActualizarPorcentajeDescuento());
        }

        private void porcentajeUpDown1_Leave(object sender, EventArgs e)
        {
            Ejecutar(() => cobroViewModel.ActualizarMontoDescuento());
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
