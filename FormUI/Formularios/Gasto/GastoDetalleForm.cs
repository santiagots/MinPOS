using FormUI.Componentes;
using System;
using System.Windows.Forms;
using ModeloGasto = Gasto.Core.Model.GastoAgreggate;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoDetalleForm : Form
    {
        public GastoDetalleForm()
        {
            InitializeComponent();
        }

        public GastoDetalleForm(ref ModeloGasto.Gasto gasto) : this()
        {
            gasto = new ModeloGasto.Gasto(DateTime.Now, 1, null, 12, "Comentario", DateTime.Now, Sesion.Usuario.Alias);
        }

        private void GastoDetalleForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
