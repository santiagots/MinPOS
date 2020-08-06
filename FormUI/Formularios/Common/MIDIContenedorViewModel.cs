using Common.Core.Enum;
using Common.Core.Model;
using FormUI.Componentes;
using FormUI.Enum;
using FormUI.Formularios.Saldo;
using FormUI.Properties;
using Gasto.Data.Service;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Data.Service;
using Saldo.Core.Enum;
using Saldo.Core.Model;
using Saldo.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Venta.Data.Service;

namespace FormUI.Formularios.Common
{
    class MIDIContenedorViewModel : CommonViewModel
    {
        public readonly DateTime fechaRecepcionMercaderiaHasta = DateTime.Now.AddDays(Settings.Default.AnticipacionAvisoIngresoMercaderia);

        internal async Task ActualizarMercaderiaARecibir(ToolStripStatusLabel toolStripStatusPedido, PopupNotifier popupNotifier)
        {
            int totalMercaderiaARecibir = 0;
            List<Mercaderia> MercaderiaARecibir = await MercaderiaService.Buscar(null, null, DateTime.Now, fechaRecepcionMercaderiaHasta,null, MercaderiaEstado.Guardada, "Fecha", DireccionOrdenamiento.Desc, 1, Settings.Default.PaginadoCantidadElementosPorPagina, out totalMercaderiaARecibir);
            toolStripStatusPedido.Text = $"Total Ingreso Mercaderia: {totalMercaderiaARecibir}";

            if (totalMercaderiaARecibir > 0)
            {
                popupNotifier.ContentText = string.Format(popupNotifier.ContentText, totalMercaderiaARecibir);
                popupNotifier.Popup();
            }
        }

        internal void CargarUsuario(ToolStripStatusLabel toolStripStatusUsuario)
        {
            toolStripStatusUsuario.Text = $"Usuario: {Sesion.Usuario.Alias}";
        }

        internal async Task MostrarResumenDiarioAsync(Action<bool> modificacionHabilitacionFunciones)
        {
            Caja cajasCajaDelDia = await CajaService.Obtener(DateTime.Now);
            ResumenDiarioForm resumenDiarioForm = new ResumenDiarioForm(cajasCajaDelDia, modificacionHabilitacionFunciones);
            resumenDiarioForm.ShowDialog();
        }

        internal async Task AbrirCajasDelDia(Action<bool> modificacionHabilitacionFunciones)
        {
            //Caja cajasCajaDelDia = await CajaService.Obtener(DateTime.Now);
            //if (cajasCajaDelDia == null)
            //{
            //    Caja cierrarCaja = new Caja();
            //    cierrarCaja.Abrir(Sesion.Usuario.Alias);
            //    await CajaService.GuardarAsync(cierrarCaja);
            //    CustomMessageBox.ShowDialog(string.Format(Resources.aperturaCaja, Sesion.Usuario.Alias), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);
            //}
            //else 
            //{
            //    modificacionHabilitacionFunciones(cajasCajaDelDia.Estado != EstadoCaja.Cerrada);
            //}
        }

        private static async Task<bool> ExisteCajaParaDiaEnCursoAsync()
        {
            return await CajaService.Obtener(DateTime.Now) != null;
        }

        internal async Task CerrarCajasPendientes(Form mdiParent)
        {
            List<Caja> cajasPendientesDeCierre = await CajaService.ObtenerCajaCerradaAbiertas();
            if (cajasPendientesDeCierre.Count > 0)
            {
                CustomMessageBox.ShowDialog(string.Format(Resources.cajasCierreAutomaticas, cajasPendientesDeCierre.Count), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);

                using(BarraProgresoForm barraProgresoForm = new BarraProgresoForm("Cerrando Cajas Abiertas", 100))
                {
                    barraProgresoForm.MdiParent = mdiParent;
                    barraProgresoForm.Show();

                    await Task.Run(async () => {
                        for (int i = 0; i < cajasPendientesDeCierre.Count; i++)
                        {
                            Caja cajaPendiente = cajasPendientesDeCierre[i];
                            cajaPendiente.CerrarAutomatico();
                            await CajaService.GuardarAsync(cajaPendiente);
                            barraProgresoForm.Progress.Report(i);
                        }
                    });
                }
            }
        }
    }
}
