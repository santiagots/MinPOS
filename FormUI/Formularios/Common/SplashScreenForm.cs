using Common.Data.Service;
using FormUI.Componentes;
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
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }

        private async void SplashScreenForm_LoadAsync(object sender, EventArgs e)
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
        }

        private async Task InicializarAplicacion()
        {
            List<Task> tareas = new List<Task>();
            tareas.Add(Task.Run(() => BaseDatos.InstalarEnCarpetaLocal("MiniPOS")));
            tareas.Add(CommonService.InicializarBase());
            tareas.Add(Task.Delay(5000)); //agrego una tarea de 5 segundos como timpo minimo de mostrado

            await Task.WhenAll(tareas);
        }
    }
}
