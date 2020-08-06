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
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler PaginaSiguienteClick;
        public event Action<string> ClickEventHandler;

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
        public int ElementosPorPagina => columnas * filas;
        private int TotalPaginas => TotalElementos % ElementosPorPagina > 0 ? (TotalElementos / ElementosPorPagina) + 1 : TotalElementos / ElementosPorPagina;
        public int TotalElementos { get; set; }
        public int PaginaActual { get; set; } = 1;
        public List<Tuple<string, Image>> Elementos { get; set; } = new List<Tuple<string, Image>>();

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
            PaginaSiguienteClick?.Invoke(sender, e);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            PaginaActual--;
            PaginaAnteriorClick?.Invoke(sender, e);
        }

        public void Cargar(List<Tuple<string, Image>> elementos, int totalElementos)
        {
            Elementos = elementos;
            TotalElementos = totalElementos;
            CargarBotones();
            ActualizarBotones();
        }

        private void ActualizarBotones()
        {
            btnAnterior.Enabled = PaginaActual > 1 && TotalPaginas > 1;
            btnSiguente.Enabled = PaginaActual < TotalPaginas && TotalPaginas > 1;
        }

        private Button ObtenerBoton(string texto, Image imagen)
        {
            Button btn;

            if (imagen == null)
            {
                btn = new Button();
                btn.Text = texto;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn = new ImageButton();
                ((ImageButton)btn).Texto = texto;
                btn.ForeColor = Color.White;
                btn.BackgroundImage = imagen;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
            }

            btn.Click += btn_Click;
            btn.BackColor = ButtonBackColor;
            btn.FlatStyle = FlatStyle;
            btn.FlatAppearance.BorderColor = FlatBorderColor;
            btn.FlatAppearance.BorderSize = FlatBorderSize;
            btn.FlatAppearance.MouseDownBackColor = FlatMouseDownBackColor;
            btn.FlatAppearance.MouseOverBackColor = FlatMouseOverBackColor;
            btn.Dock = DockStyle.Fill;
            btn.Font = FuenteBoton;
            return btn;
        }

        private void CargarBotones()
        {
            if (!Elementos.Any()) return;

            tableLayoutPanel.Controls.Clear();
            int posicionControl = 0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (Elementos.Count <= posicionControl)
                        return;

                    Button btn = ObtenerBoton(Elementos[posicionControl].Item1, Elementos[posicionControl].Item2);
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
            if(sender is ImageButton)
                ClickEventHandler?.Invoke(((ImageButton)btnEvento).Texto);
            else
                ClickEventHandler?.Invoke(btnEvento.Text);
        }
    }

    public class ImageButton : Button
    {
        public string Texto { get; set; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            SizeF stringSize = pevent.Graphics.MeasureString(Texto, Font, new SizeF(Width, Height), stringFormat);
            
            Rectangle rect = new Rectangle(0, Height - (int)stringSize.Height, Width, (int)stringSize.Height);

            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
            pevent.Graphics.FillRectangle(semiTransBrush, rect);

            SolidBrush stringBrush = new SolidBrush(ForeColor);
            pevent.Graphics.DrawString(Texto, Font, stringBrush, rect, stringFormat);
        }
    }
}
