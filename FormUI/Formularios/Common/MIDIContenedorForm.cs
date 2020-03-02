using FormUI.Formularios.Common;
using FormUI.Formularios.Gasto;
using FormUI.Formularios.Producto;
using FormUI.Formularios.Saldo;
using FormUI.Formularios.Usuario;
using FormUI.Formularios.Venta;
using System;
using Tulpep.NotificationWindow;

namespace FormUI.Formularios.Common
{
    public partial class MIDIContenedorForm : CommonForm
    {
        public MIDIContenedorForm()
        {
            InitializeComponent();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoListadoFrom), this);

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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void MIDIContenedorForm_Load(object sender, EventArgs e)
        {
            PopupNotifier popupNotifier2 = new PopupNotifier();
            popupNotifier2.TitleText = "Ingreso Mercaderia";
            popupNotifier2.TitleFont = new System.Drawing.Font("Segoe UI", 8);
            popupNotifier2.ContentText = "Tiene 3 ingresos de mercaderia por ingresar.";
            popupNotifier2.ContentFont = new System.Drawing.Font("Segoe UI", 11);
            popupNotifier2.IsRightToLeft = false;
            popupNotifier2.Popup();
        }
    }
}
