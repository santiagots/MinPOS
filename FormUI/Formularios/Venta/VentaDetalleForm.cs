using Modelo = Venta.Core.Model;
using System.Windows.Forms;

namespace FormUI.Formularios.Venta
{
    public partial class VentaDetalleForm : Form
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
            Close();
        }
    }
}
