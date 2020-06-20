using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class BarraProgresoForm : Form
    {
        public IProgress<int> Progress { get; private set; }

        public BarraProgresoForm(string accion, int maximo)
        {
            InitializeComponent();

            groupBox.Text = accion;
            progressBar.Minimum = 0;
            progressBar.Maximum = maximo;

            Progress = new Progress<int>(valor =>
            {
                progressBar.Value = valor;
            });
        }
    }
}
