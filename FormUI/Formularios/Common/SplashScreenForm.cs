using Common.Core.Helper;
using Common.Data.Service;
using FormUI.Componentes;
using FormUI.Enum;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class SplashScreenForm : CommonForm
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    ApplicationDeployment cd = ApplicationDeployment.CurrentDeployment;
                    lblVersion.Text = $"Ver. {cd.CurrentVersion}";
                }
                else
                    lblVersion.Text = $"Ver. {Application.ProductVersion}";

                await InicializarAplicacion();

                Close();
            });
        }

        private async Task InicializarAplicacion()
        {
            try
            {
                List<Task> tareas = new List<Task>();
                tareas.Add(Task.Run(() => BaseDatos.InstalarEnCarpetaLocal("MiniPOS")));
                tareas.Add(CommonService.InicializarBase());
                tareas.Add(Task.Delay(5000)); //agrego una tarea de 5 segundos como timpo minimo de mostrado

                await Task.WhenAll(tareas);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                CustomMessageBox.ShowDialog(Resources.accionError, this.Text, MessageBoxButtons.OK, CustomMessageBoxIcon.Error);
            }
        }
    }
}
