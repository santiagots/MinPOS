using FormUI.Enum;
using FormUI.Formularios.Common;
using FormUI.Properties;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Saldo
{
    public partial class CajaInicio : CommonForm
    {
        CajaInicioViewModel cajaInicioViewModel = new CajaInicioViewModel();
        public CajaInicio()
        {
            InitializeComponent();
        }

        private void CajaInicio_Load(object sender, EventArgs e)
        {
            Ejecutar(() => cajaInicioViewModelBindingSource.DataSource = cajaInicioViewModel);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                cajaInicioViewModel.AbrirCaja();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                Close();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
