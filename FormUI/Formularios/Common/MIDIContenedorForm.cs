using FormUI.Formularios.Common;
using FormUI.Formularios.Gasto;
using FormUI.Formularios.Producto;
using FormUI.Formularios.Saldo;
using FormUI.Formularios.Usuario;
using FormUI.Formularios.Venta;
using FormUI.Properties;
using System;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace FormUI.Formularios.Common
{
    public partial class MIDIContenedorForm : CommonForm
    {
        MIDIContenedorViewModel MidiContenedorViewModel = new MIDIContenedorViewModel();
        public MIDIContenedorForm()
        {
            InitializeComponent();
        }

        private void MIDIContenedorForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                MidiContenedorViewModel.CargarUsuario(toolStripStatusUsuario);
                await MidiContenedorViewModel.CargarMercaderiaARecibir(toolStripStatusPedido, popupNotifier);
                await MidiContenedorViewModel.CerrarCajasPendientes();
            });
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoListadoFrom), this);
        private void tsbProductos_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoListadoFrom), this);

        private void cargarVariosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoIngresoMasivo), this);

        private void tsbIngresos_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(MercaderiaListadoForm), this);

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(MercaderiaDetalleForm), this);

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(CategoriaListadoForm), this);

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaListadoForm), this);

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaForm), this);

        private void administrarToolStripMenuItem1_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoListadoForm), this);

        private void tiposGastosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoTipoListadoForm), this);

        private void administrarToolStripMenuItem2_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProveedorListadoForm), this);

        private void administrarToolStripMenuItem3_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(CierreCajaListado), this);

        private void resumenDiarioToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ResumenDiarioForm), this);

        private void administrarToolStripMenuItem4_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(MercaderiaListadoForm), this);

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(UsuarioListadoForm), this);

        private void informaciónPersonalToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(UsuarioDetalleForm), this);

        private void configuracionStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ConfiguracionForm), this);
        
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void MIDIContenedorForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tsbNuevaVenta_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaForm), this);

        private void tsbNuevaGasto_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoDetalleForm), this);

        private void tsbCierreCaja_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ResumenDiarioForm), this);

        private void toolStripStatusPedido_Click(object sender, EventArgs e)
        {
            Ejecutar(() =>
            {
                MercaderiaListadoForm mercaderiaListadoForm = new MercaderiaListadoForm(MidiContenedorViewModel.fechaRecepcionMercaderiaHasta);
                mercaderiaListadoForm.MdiParent = this;
                mercaderiaListadoForm.Show();
            });
        }

        private void toolStripStatusUsuario_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(UsuarioDetalleForm), this);
    }
}
