using FormUI.Formularios.Common;
using System;
using Saldo.Core.Model;
using FormUI.Properties;
using System.Windows.Forms;
using FormUI.Enum;

namespace FormUI.Formularios.Saldo
{
    public partial class CajaForm : CommonForm
    {
        private CajaViewModel cajaViewModel = new CajaViewModel();

        public CajaForm()
        {
            InitializeComponent();
        }

        public CajaForm(Caja cierreCaja) : this()
        {
            cajaViewModel = new CajaViewModel(cierreCaja);
        }

        private void CajaForm_Load(object sender, EventArgs e)
        {
            Ejecutar(() => resumenDiarioViewModelBindingSource.DataSource = cajaViewModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (DialogResult.Yes == CustomMessageBox.ShowDialog(Resources.cajaCierre, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                {
                    await cajaViewModel.CerraCajaAsync();
                    MIDIContenedorForm.ModificacionHabilitacionFunciones(false);
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
                    await cajaViewModel.AbrirCajaAsync();
                    MIDIContenedorForm.ModificacionHabilitacionFunciones(true);
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
                    cajaViewModel.ImprimirCaja();
                }
            });
        }
    }
}
