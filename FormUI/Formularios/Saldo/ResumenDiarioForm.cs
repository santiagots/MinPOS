using FormUI.Formularios.Common;
using System;
using Saldo.Core.Model;
using FormUI.Properties;
using System.Windows.Forms;
using FormUI.Enum;

namespace FormUI.Formularios.Saldo
{
    public partial class ResumenDiarioForm : CommonForm
    {
        public Action<bool> ModificarHabilitacionSisitema;

        private ResumenDiarioViewModel resumenDiarioViewModel;

        public ResumenDiarioForm(CierreCaja cierreCaja, Action<bool> modificarHabilitacionSisitema)
        {
            InitializeComponent();

            ModificarHabilitacionSisitema = modificarHabilitacionSisitema;
            resumenDiarioViewModel = new ResumenDiarioViewModel(cierreCaja);
        }

        private void ResumenDiarioForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async() => {
                resumenDiarioViewModelBindingSource.DataSource = resumenDiarioViewModel;
                await resumenDiarioViewModel.CargarAsync();
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.cerrarCaja, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    await resumenDiarioViewModel.CerraCajaAsync();
                    ModificarHabilitacionSisitema?.Invoke(false);
                    CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                }
            });
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.abrirCaja, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    await resumenDiarioViewModel.AbrirCajaAsync();
                    ModificarHabilitacionSisitema?.Invoke(true);
                    CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.imprimirDocumento, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    resumenDiarioViewModel.ImprimirCaja();
                }
            });
        }
    }
}
