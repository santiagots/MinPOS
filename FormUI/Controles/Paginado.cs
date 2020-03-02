using System;
using System.Windows.Forms;

namespace FormUI.Controles
{
    public partial class Paginado : UserControl
    {
        private int _TotalElementos = 0;

        public event EventHandler PaginaInicalClick;
        public event EventHandler PaginaAnteriorClick;
        public event EventHandler PaginaSiguienteClick;
        public event EventHandler PaginaFinalClick;

        public int ElementosPorPagina { get; internal set; } = 2;
        public int PaginaActual { get; internal set; } = 1;
        public int TotalElementos
        {
            get => _TotalElementos;
            set
            {
                _TotalElementos = value;
                ActualizarBotones();
                ActualizarLeyenda();
            }
        }

        public int TotalPaginas => TotalElementos % ElementosPorPagina > 0 ? (TotalElementos / ElementosPorPagina) + 1 : TotalElementos / ElementosPorPagina;
        public string Leyenda { get; set; } = "{0} de {1}";

        public Paginado()
        {
            InitializeComponent();
        }

        private void Paginado_Load(object sender, EventArgs e)
        {
            ActualizarLeyenda();
        }

        private void btnPaginaInical_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            PaginaInicalClick?.Invoke(sender, e);
            ActualizarBotones();
            ActualizarLeyenda();
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            PaginaActual -= 1;
            PaginaAnteriorClick?.Invoke(sender, e);
            ActualizarBotones();
            ActualizarLeyenda();
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual += 1;
            PaginaSiguienteClick?.Invoke(sender, e);
            ActualizarBotones();
            ActualizarLeyenda();
        }

        private void btnPaginaFinal_Click(object sender, EventArgs e)
        {
            PaginaActual = TotalPaginas;
            PaginaFinalClick?.Invoke(sender, e);
            ActualizarBotones();
            ActualizarLeyenda();
        }

        private void ActualizarBotones()
        {
            btnPaginaInical.Enabled = PaginaActual != 1 && TotalPaginas > 1;
            btnPaginaAnterior.Enabled = PaginaActual > 1 && TotalPaginas > 1;
            btnPaginaSiguiente.Enabled = PaginaActual < TotalPaginas && TotalPaginas > 1;
            btnPaginaFinal.Enabled = PaginaActual != TotalPaginas && TotalPaginas > 1;
        }

        private void ActualizarLeyenda()
        {
            lbTotalPaginas.Text = string.Format(Leyenda, PaginaActual, TotalPaginas);
        }
    }
}
