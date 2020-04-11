using FormUI.Formularios.Common;
using System;

namespace FormUI.Formularios.Usuario
{
    public partial class LogInFrom : CommonForm
    {
        LogInViewModel logInViewModel = new LogInViewModel();
        public LogInFrom()
        {
            InitializeComponent();
        }

        private void LogInFrom_Load(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                logInViewModelBindingSource.DataSource = logInViewModel;

                SplashScreenForm splashScreenForm = new SplashScreenForm();
                splashScreenForm.ShowDialog();
            });
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                await logInViewModel.IngresarAsync();
                MostrarFormulario(typeof(MIDIContenedorForm));
                Visible = false;               
            });
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
