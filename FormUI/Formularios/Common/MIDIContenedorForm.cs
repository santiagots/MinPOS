﻿using FormUI.Componentes;
using FormUI.Enum;
using FormUI.Formularios.Gasto;
using FormUI.Formularios.Producto;
using FormUI.Formularios.Saldo;
using FormUI.Formularios.Usuario;
using FormUI.Formularios.Venta;
using FormUI.Formularios.VentaBotonera;
using FormUI.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Formularios.Common
{
    public partial class MIDIContenedorForm : CommonForm
    {
        MIDIContenedorViewModel MidiContenedorViewModel = new MIDIContenedorViewModel();
        private static MIDIContenedorForm instancia;

        public MIDIContenedorForm()
        {
            InitializeComponent();
            instancia = this;
        }

        private void MIDIContenedorForm_Load(object sender, EventArgs e)
        {
            EjecutarAsync(async () =>
            {
                MercaderiaDetalleForm.actualizarMercaderiaARecibirAsync = ActualizarMercaderiaARecibirAsync;
                MercaderiaListadoForm.actualizarMercaderiaARecibirAsync = ActualizarMercaderiaARecibirAsync;

                MidiContenedorViewModel.CargarUsuario(toolStripStatusUsuario);
                await ActualizarMercaderiaARecibirAsync();
                await MidiContenedorViewModel.CerrarCajasPendientes(this);
                await MidiContenedorViewModel.AdministrarCajaEnCurso(ModificacionHabilitacionFunciones);
            });
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoListadoFrom), this);
        private void tsbProductos_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoListadoFrom), this);

        private void cargarVariosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProductoIngresoMasivo), this);

        private void tsbIngresos_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(MercaderiaListadoForm), this);
       
        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(CategoriaListadoForm), this);

        private void administrarToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaListadoForm), this);

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaBotoneraForm), this);

        private void administrarToolStripMenuItem1_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoListadoForm), this);

        private void tiposGastosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoTipoListadoForm), this);

        private void administrarToolStripMenuItem2_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ProveedorListadoForm), this);

        private void administrarToolStripMenuItem3_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(CajaListado), this);

        private void resumenDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ejecutar(() => MidiContenedorViewModel.MostrarCajaAsync());
        }

        private void administrarToolStripMenuItem4_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(MercaderiaListadoForm), this);

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(UsuarioListadoForm), this);

        private void informaciónPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDetalleForm usuarioDetalleForm = new UsuarioDetalleForm(Sesion.Usuario);
            usuarioDetalleForm.ShowDialog();
        }

        private void configuracionStripMenuItem_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(ConfiguracionForm), this);
        
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void tsbNuevaVenta_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(VentaBotoneraForm), this);

        private void tsbNuevaGasto_Click(object sender, EventArgs e) => MostrarFormularioEnContenedor(typeof(GastoDetalleForm), this, true);

        private void tsbCierreCaja_Click(object sender, EventArgs e)
        {
            Ejecutar(() => MidiContenedorViewModel.MostrarCajaAsync());
        }


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
        
        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);
        
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);
        
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);
        
        private void cerraToolStripMenuItem_Click(object sender, EventArgs e) => MdiChildren.ToList().ForEach(x => x.Close());

        public static void ModificacionHabilitacionFunciones(bool habilitar)
        {
            instancia.ModificarEstado(habilitar);
        }

        private void ModificarEstado(bool habilitar)
        {
            ModificarHabilitacionToolStripMenuItem(ventaToolStripMenuItem, habilitar);
            ModificarHabilitacionToolStripMenuItem(gastosToolStripMenuItem, habilitar);
            tsbNuevaVenta.Enabled = habilitar;
            tsbNuevaGasto.Enabled = habilitar;
        }

        public async Task ActualizarMercaderiaARecibirAsync()
        {
            await MidiContenedorViewModel.ActualizarMercaderiaARecibir(toolStripStatusPedido, popupNotifier);
        }

        private void ModificarHabilitacionToolStripMenuItem(ToolStripMenuItem toolStripMenuItem, bool habilitar)
        {
            toolStripMenuItem.Enabled = habilitar;

            foreach (ToolStripItem item in toolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                    ModificarHabilitacionToolStripMenuItem((ToolStripMenuItem)item, habilitar);
            }
        }

        private void MIDIContenedorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Sesion.IdCaja > 0  
                && DialogResult.No == CustomMessageBox.ShowDialog(Resources.aplicacionCerrarConCajaAbierta, this.Text, MessageBoxButtons.YesNo, CustomMessageBoxIcon.Info))
                    e.Cancel = true;
        }

        private void MIDIContenedorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
