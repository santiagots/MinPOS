using FormUI.Enum;
using FormUI.Properties;
using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class ConfiguracionForm : CommonForm
    {
        ConfiguracionViewModel configuracionViewModel = new ConfiguracionViewModel();
        public ConfiguracionForm()
        {
            InitializeComponent();
        }

        private void ConfiguracionForm_Load(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                configuracionViewModelBindingSource.DataSource = configuracionViewModel;
                configuracionViewModel.CargarImpresoras();
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ejecutar(() => {
                configuracionViewModel.Guardar();
                CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
            });
        }

        private void btnPruebaTicket_Click(object sender, EventArgs e)
        {
            Ejecutar(() => configuracionViewModel.PruebaTicket());
        }

    }
}
