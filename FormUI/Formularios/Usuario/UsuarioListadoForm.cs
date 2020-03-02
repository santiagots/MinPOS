using FormUI.Formularios.Common;
using System;

namespace FormUI.Formularios.Usuario
{
    public partial class UsuarioListadoForm : CommonForm
    {
        public UsuarioListadoForm()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e) => MostrarFormularioModal(typeof(UsuarioDetalleForm));

        private void UsuarioListadoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
