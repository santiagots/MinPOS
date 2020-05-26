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

        internal async Task CerrarCajasPendientes()
        {
            CierreCaja cierreCaja = await CierreCajaService.UltimaCajaCerrada();
            double dias = (DateTime.Now.Date - cierreCaja.FechaAlta.Date).TotalDays + 1;

            for (int i = 1; i < dias; i++)
            {
                DateTime fechaCierreAutomatico = cierreCaja.FechaAlta.AddDays(i);

                if (fechaCierreAutomatico.Date >= DateTime.Now.Date)
                    continue;

                Task<List<KeyValuePair<string, decimal>>> gastoSaldo = Task.Run(() => GastoService.Saldo(fechaCierreAutomatico));
                Task<List<KeyValuePair<string, decimal>>> ventaSaldo = Task.Run(() => VentaService.Saldo(fechaCierreAutomatico));
                Task<CierreCaja> cajaDiaAnterior = CierreCajaService.Obtener(fechaCierreAutomatico.Date.AddDays(-1));

                await Task.WhenAll(gastoSaldo, ventaSaldo);

                List<Egresos> egresos = new List<Egresos>();
                egresos.AddRange(gastoSaldo.Result.Select(x => new Egresos(x.Key, x.Value)));

                List<Ingresos> ingresos = new List<Ingresos>();
                ingresos.AddRange(ventaSaldo.Result.Select(x => new Ingresos(x.Key, x.Value)));

                if (cajaDiaAnterior.Result != null)
                    ingresos.Insert(0, new Ingresos("Inicio de caja", cajaDiaAnterior.Result.MontoRegistrado));

                CierreCaja cierreCajaAutomatico = new CierreCaja(0, fechaCierreAutomatico, "Automatico", ingresos, egresos, cierreCaja.MontoRegistrado, 0);
                CierreCajaService.Cerrar(cierreCajaAutomatico);
            }
        }

        internal void CargarUsuario(ToolStripStatusLabel toolStripStatusUsuario)
        {
            toolStripStatusUsuario.Text = $"Usuario: {Sesion.Usuario.Alias}";
        }
    }
}
