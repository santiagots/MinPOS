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

        internal async Task CargarMercaderiaARecibir(ToolStripStatusLabel toolStripStatusPedido, PopupNotifier popupNotifier)
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
            CierreCaja cajasCajaDelDia = await CierreCajaService.Obtener(DateTime.Now);
            ResumenDiarioForm resumenDiarioForm = new ResumenDiarioForm(cajasCajaDelDia, modificacionHabilitacionFunciones);
            resumenDiarioForm.ShowDialog();
        }

        internal async Task AbrirCajasDelDia(Action<bool> modificacionHabilitacionFunciones)
        {
            CierreCaja cajasCajaDelDia = await CierreCajaService.Obtener(DateTime.Now);
            if (cajasCajaDelDia == null)
            {
                CierreCaja cierrarCaja = new CierreCaja();
                cierrarCaja.Abrir(Sesion.Usuario.Alias);
                await CierreCajaService.GuardarAsync(cierrarCaja);
                CustomMessageBox.ShowDialog(string.Format(Resources.aperturaCaja, Sesion.Usuario.Alias), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);
            }
            else 
            {
                modificacionHabilitacionFunciones(cajasCajaDelDia.Estado != EstadoCaja.Cerrada);
            }
        }

        private static async Task<bool> ExisteCajaParaDiaEnCursoAsync()
        {
            return await CierreCajaService.Obtener(DateTime.Now) != null;
        }

        internal async Task CerrarCajasPendientes(Form mdiParent)
        {
            List<CierreCaja> cajasPendientesDeCierre = await CierreCajaService.ObtenerCajaCerradaAbiertas();
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
                            CierreCaja cajaPendiente = cajasPendientesDeCierre[i];
                            await CerrarCaja(cajaPendiente);
                            await CierreCajaService.GuardarAsync(cajaPendiente);
                            barraProgresoForm.Progress.Report(i);
                        }
                    });
                }
            }
        }


        private static async Task CerrarCaja(CierreCaja cierreCaja)
        {
            Task<List<MovimientoMonto>> gastoSaldo = Task.Run(() => GastoService.Saldo(DateTime.Now));
            Task<List<MovimientoMonto>> ventaSaldo = Task.Run(() => VentaService.Saldo(DateTime.Now));

            await Task.WhenAll(gastoSaldo, ventaSaldo);

            List<Ingresos> ingresos = new List<Ingresos>();
            ingresos.AddRange(ventaSaldo.Result.Select(x => new Ingresos(x.Id, cierreCaja.Id, x.ModificaCaja, x.Concepto, x.Monto)));
            cierreCaja.AgregarIngresos(ingresos);

            List<Egresos> egresos = new List<Egresos>();
            egresos.AddRange(gastoSaldo.Result.Select(x => new Egresos(x.Id, cierreCaja.Id, x.ModificaCaja, x.Concepto, x.Monto)));
            cierreCaja.AgregarEgresos(egresos);

            decimal montoEnCaja = ingresos.Where(x => x.ModificaCaja).Sum(x => x.Monto);

            cierreCaja.Cerrar("Automático", montoEnCaja);
        }
    }
}
