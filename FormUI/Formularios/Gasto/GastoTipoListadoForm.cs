using FormUI.Formularios.Common;
using FormUI.Formularios.Producto;
using System;

namespace FormUI.Formularios.Gasto
{
    public partial class GastoTipoListadoForm : CommonForm
    {
        public GastoTipoListadoForm()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e) => MostrarFormularioModal(typeof(MercaderiaDetalleForm));
    }
}
