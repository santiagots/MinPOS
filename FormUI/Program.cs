using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Formularios.Usuario;
using FormUI.Formularios.VentaBotonera;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace FormUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            ConfigurarCultura();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInFrom());
        }

        private static void ConfigurarCultura()
        {
            var culture = CultureInfo.GetCultureInfo("es-AR");

            CultureInfo ci = new CultureInfo(culture.Name);
            ci.NumberFormat.NumberDecimalSeparator = ".";

            //Culture for any thread
            CultureInfo.DefaultThreadCurrentCulture = ci;

            //Culture for UI in any thread
            CultureInfo.DefaultThreadCurrentUICulture = ci;
        }
    }
}
