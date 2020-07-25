using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormUI.Controles
{
    public partial class Botonera : UserControl
    {
        [Category("Label"), Browsable(true)]
        public Font FuenteLabel { get; set; } = new Font("Microsoft Sans Serif", 12);
        [Category("Label"), Browsable(true)]
        public string TextoLabel { get; set; }
        [Category("Botones"), Browsable(true)]
        public int columnas { get; set; } = 2;
        [Category("Botones"), Browsable(true)]
        public int filas { get; set; } = 10;
        [Category("Botones"), Browsable(true)]
        public Font FuenteBoton { get; set; } = new Font("Microsoft Sans Serif", 12);
        [Category("Botones"), Browsable(true)]
        public FlatStyle FlatStyle { get; set; } = FlatStyle.Flat;
        [Category("Botones"), Browsable(true)]
        public Color ButtonBackColor { get; set; } = SystemColors.Control;
        [Category("Botones"), Browsable(true)]
        public Color FlatBorderColor { get; set; } = Color.Empty;
        [Category("Botones"), Browsable(true)]
        public Color FlatMouseOverBackColor { get; set; } = Color.Empty;
        [Category("Botones"), Browsable(true)]
        public Color FlatMouseDownBackColor { get; set; } = Color.Empty;
        [Category("Botones"), Browsable(true)]
        public int FlatBorderSize { get; set; } = 1;
        [Category("Botones"), Browsable(true)]
        public event Action<string> ClickEventHandler;
        private List<string> Elementos = new List<string>();
        private int ElementosPorPagina => columnas * filas;
        private int TotalPaginas => TotalElementos % ElementosPorPagina > 0 ? (TotalElementos / ElementosPorPagina) + 1 : TotalElementos / ElementosPorPagina;
        private int TotalElementos => Elementos.Count;
        private int PaginaActual = 1;

        public Botonera()
        {
            InitializeComponent();
        }

        private void Botonera_Load(object sender, EventArgs e)
        {
            label1.Text = TextoLabel;
            label1.Font = FuenteLabel;

            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < columnas; i++)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnas));
            tableLayoutPanel.ColumnCount = columnas;

            for (int i = 0; i < filas; i++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / filas));
            tableLayoutPanel.RowCount = filas;
        }

        private void btnSiguente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarBotones();
            ActualizarBotones();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            PaginaActual--;
            CargarBotones();
            ActualizarBotones();
        }

        public void Cargar(List<string> elementos)
        {
            Elementos = elementos;
            PaginaActual = 1;
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
            btn.BackColor = ButtonBackColor;
            btn.FlatStyle = FlatStyle;
            btn.FlatAppearance.BorderColor = FlatBorderColor;
            btn.FlatAppearance.BorderSize = FlatBorderSize;
            btn.FlatAppearance.MouseDownBackColor = FlatMouseDownBackColor;
            btn.FlatAppearance.MouseOverBackColor = FlatMouseOverBackColor;
            btn.Text = texto;
            btn.Dock = DockStyle.Fill;
            btn.Font = FuenteBoton;
            return btn;
        }

        private void CargarBotones()
        {
            if (!Elementos.Any()) return;

            string[] tempElementos = Elementos.OrderBy(x => x)
                                              .Skip(ElementosPorPagina * (PaginaActual - 1))
                                              .Take(ElementosPorPagina)
                                              .ToArray();

            tableLayoutPanel.Controls.Clear();
            int posicionControl = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (tempElementos.Length <= posicionControl)
                        return;

                    Button btn = ObtenerBoton(tempElementos[posicionControl]);
                    tableLayoutPanel.Controls.Add(btn);
                    posicionControl++;
                }
            }
        }

        private void btn_Click(object sender, System.EventArgs e)
        {
            foreach (Button btn in tableLayoutPanel.Controls)
                btn.BackColor = ButtonBackColor;

            Button btnEvento = (Button)sender;
            btnEvento.BackColor = btnEvento.FlatAppearance.MouseOverBackColor;
            ClickEventHandler?.Invoke(btnEvento.Text);
        }
    }
}
