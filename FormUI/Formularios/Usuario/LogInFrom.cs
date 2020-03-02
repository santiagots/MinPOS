using FormUI.Componentes;
using FormUI.Formularios.Common;
using Modelo = Common.Core.Model.UsuarioAgreggate;
using System;

namespace FormUI.Formularios.Usuario
{
    public partial class LogInFrom : CommonForm
    {
        public LogInFrom()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MostrarFormulario(typeof(MIDIContenedorForm));
            Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LogInFrom_Load(object sender, EventArgs e)
        {
            Sesion.Usuario = new Modelo.Usuario("Santi", "Santiago", "Tambour", "holaMundo", DateTime.Now.AddDays(-1), DateTime.Now, "Santi");
        }
    }
}
