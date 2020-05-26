using Modelo = Venta.Core.Model;
using FormUI.Formularios.Common;
using System.Windows.Forms;
using FormUI.Enum;
using FormUI.Properties;

namespace FormUI.Formularios.Venta
{
    public partial class VentaDetalleForm : CommonForm
    {
        VentaDetalleViewModel ventaDetalleViewModel;
        public VentaDetalleForm(Modelo.Venta venta)
        {
            InitializeComponent();
            ventaDetalleViewModel = new VentaDetalleViewModel(venta);
        }

        private void VentaDetalleForm_Load(object sender, System.EventArgs e)
        {
            ventaDetalleViewModelBindingSource.DataSource = ventaDetalleViewModel;
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAnular_Click(object sender, System.EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                DialogResult confirmaAnulacionVemta = CustomMessageBox.ShowDialog(Resources.anularVenta, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info);
                if (confirmaAnulacionVemta == DialogResult.No) return;
                
                await ventaDetalleViewModel.AnularAsync();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }
    }
}
