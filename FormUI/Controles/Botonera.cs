using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormUI.Controles
{
    public partial class Botonera : UserControl
    {
        [Category("Botones"), Browsable(true)]
        public Font FuenteBoton { get; set; } = new Font("Microsoft Sans Serif", 15);
        [Category("Botones"), Browsable(true)]
        public Size BotonSize { get; set; } = new Size(90, 90);
        [Category("Botones"), Browsable(true)]
        public event Action<string> ClickEventHandler;

        private List<string> Elementos { get; set; }
        private int ElementosPorPagina => (flowLayoutPanel.Height / BotonSize.Height) * (flowLayoutPanel.Width / BotonSize.Height);
        private int TotalPaginas => TotalElementos % ElementosPorPagina > 0 ? (TotalElementos / ElementosPorPagina) + 1 : TotalElementos / ElementosPorPagina;
        private int TotalElementos => Elementos.Count;
        private int PaginaActual = 1;

        public Botonera()
        {
            InitializeComponent();
        }

        public void Cargar(List<string> elementos)
        {
            Elementos = elementos;
            CargarBotones();
            ActualizarBotones();
        }

        private void btnSiguente_Click(object sender, System.EventArgs e)
        {
            PaginaActual++;
            CargarBotones();
            ActualizarBotones();
        }

        private void btnAnterior_Click(object sender, System.EventArgs e)
        {
            PaginaActual--;
            CargarBotones();
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            btnAnterior.Enabled = PaginaActual > 1 && TotalPaginas > 1;
            btnSiguente.Enabled = PaginaActual < TotalPaginas && TotalPaginas > 1;
        }

        private Button ObtenerBoton(string texto)
        {
            Button btn = new Button();
            btn.Click += btn_Click;
            btn.Text = texto;
            btn.Size = BotonSize;
            btn.Margin = new Padding(0);
            btn.Font = FuenteBoton;
            return btn;
        }

        private void CargarBotones()
        {
            if (!Elementos.Any()) return;

            flowLayoutPanel.Controls.Clear();
            Control[] temp = Elementos.Select(x => ObtenerBoton(x))
                                      .OrderBy(x => x.Text)
                                      .Skip(ElementosPorPagina * (PaginaActual - 1))
                                      .Take(ElementosPorPagina)
                                      .ToArray();

            flowLayoutPanel.Controls.AddRange(temp);
        }

        private void btn_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            ClickEventHandler?.Invoke(btn.Text);
        }
    }
}
