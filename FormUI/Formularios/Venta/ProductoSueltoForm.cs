using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.Venta
{
    public partial class ProductoSueltoForm : Form
    {
        public decimal Monto => productoSueltoViewModel.Monto;

        ProductoSueltoViewModel productoSueltoViewModel = new ProductoSueltoViewModel();

        public ProductoSueltoForm()
        {
            InitializeComponent();
        }

        private void ProductoSueltoForm_Load(object sender, EventArgs e)
        {
            productoSueltoViewModelBindingSource.DataSource = productoSueltoViewModel;
        }

        private void btnAceptar_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void BtnCancelar_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}
