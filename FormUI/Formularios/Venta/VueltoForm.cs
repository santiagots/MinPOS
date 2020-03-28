using System;
using System.Windows.Forms;

namespace FormUI.Formularios.Venta
{
    public partial class VueltoForm : Form
    {
        private decimal Vuelto = 0;
        private static int TIEMPO_CIERRE_AUTOMATICO = 2000;

        public VueltoForm(decimal vuelto)
        {
            InitializeComponent();
            Vuelto = vuelto;
        }

        private void VueltoForm_Load(object sender, System.EventArgs e)
        {
            lblVuelto.Text = Vuelto.ToString("c2");
            InicializarCierreAutomatico(TIEMPO_CIERRE_AUTOMATICO);
        }

        private void InicializarCierreAutomatico(int timeOut)
        {
            Timer timer = new Timer();
            timer.Tick += CheckForTime_Elapsed;
            timer.Interval = timeOut;
            timer.Start();
        }

        private void CheckForTime_Elapsed(object sender, EventArgs e)
        {
            btnPagar.PerformClick();
        }

        private void btnPagar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
