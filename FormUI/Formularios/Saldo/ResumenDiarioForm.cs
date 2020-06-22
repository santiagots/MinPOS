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
        public delegate void HabilitacionDeshabilitarSitema(bool habilitar);

        public HabilitacionDeshabilitarSitema ModificarHabilitacionSisitema;

        private ResumenDiarioViewModel resumenDiarioViewModel = new ResumenDiarioViewModel();

        public ResumenDiarioForm(HabilitacionDeshabilitarSitema modificarHabilitacionSisitema)
        {
            InitializeComponent();
            ModificarHabilitacionSisitema = modificarHabilitacionSisitema;
        }

        public ResumenDiarioForm(CierreCaja cierreCaja, HabilitacionDeshabilitarSitema modificarHabilitacionSisitema) : this(modificarHabilitacionSisitema)
        {
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
            Ejecutar(() =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.cerrarCaja, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    resumenDiarioViewModel.CerraCaja();
                    ModificarHabilitacionSisitema?.Invoke(false);
                    CustomMessageBox.ShowDialog(Resources.guardadoOk, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Success);
                }
            });
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.abrirCaja, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    resumenDiarioViewModel.AbrirCaja();
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
