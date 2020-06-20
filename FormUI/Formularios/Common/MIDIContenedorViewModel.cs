using Common.Core.Enum;
using FormUI.Componentes;
using FormUI.Properties;
using Gasto.Data.Service;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Data.Service;
using Saldo.Core.Model;
using Saldo.Data.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using Venta.Data.Service;
using FormUI.Formularios.Saldo;
using Common.Core.Model;
using System.Threading;
using FormUI.Enum;
using Saldo.Core.Enum;

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

        internal async Task CerrarCajasPendientes()
        {
            CierreCaja cierreCaja = await CierreCajaService.UltimaCajaCerrada();

            if(cierreCaja == null) return;

            double diasPendientesCierresCaja = (DateTime.Now.Date.AddDays(-1) - cierreCaja.FechaAlta.Date).TotalDays;

            if (diasPendientesCierresCaja <= 0) return;

            CustomMessageBox.ShowDialog(string.Format(Resources.cajasPendientesDeCierre, diasPendientesCierresCaja), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);

            BarraProgresoForm BarraProgresoForm = new BarraProgresoForm("Cerrando Cajas Pendientes", (int)diasPendientesCierresCaja);
            BarraProgresoForm.Show();

            await Task.Run(async () =>
            {
                for (int i = 1; i <= diasPendientesCierresCaja; i++)
                {
                    DateTime fechaCierreAutomatico = cierreCaja.FechaAlta.AddDays(i);
                    await cerrarCaja(fechaCierreAutomatico, cierreCaja.MontoEnCaja);
                    BarraProgresoForm.Progress?.Report(i);
                }
            });

            BarraProgresoForm.Close();
        }

        private async Task cerrarCaja(DateTime fechaCierre, decimal montoEnCaja)
        {
            Task<List<MovimientoMonto>> gastoSaldo = Task.Run(() => GastoService.Saldo(fechaCierre));
            Task<List<MovimientoMonto>> ventaSaldo = Task.Run(() => VentaService.Saldo(fechaCierre));
            Task<CierreCaja> cajaDiaAnterior = CierreCajaService.Obtener(fechaCierre.Date.AddDays(-1));

            await Task.WhenAll(gastoSaldo, ventaSaldo);

            List<Egresos> egresos = new List<Egresos>();
            egresos.AddRange(gastoSaldo.Result
                                       .Where(x => x.ModificaCaja)
                                       .Select(x => new Egresos(0, 0, x.Concepto, x.Monto)));

            List<Ingresos> ingresos = new List<Ingresos>();
            ingresos.AddRange(ventaSaldo.Result
                                         .Where(x => x.ModificaCaja)
                                         .Select(x => new Ingresos(0, 0, x.Concepto, x.Monto)));

            if (cajaDiaAnterior.Result != null)
                ingresos.Insert(0, new Ingresos(0, 0, "Inicio de caja", cajaDiaAnterior.Result.MontoEnCaja));

            CierreCaja cierreCajaAutomatico = new CierreCaja(0, EstadoCaja.Cerrada, fechaCierre, "Automatico", ingresos, egresos, montoEnCaja, 0);
            CierreCajaService.Guardar(cierreCajaAutomatico);
        }
    }
}
