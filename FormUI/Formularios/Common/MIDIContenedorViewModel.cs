using Common.Core.Enum;
using FormUI.Componentes;
using FormUI.Enum;
using FormUI.Formularios.Saldo;
using FormUI.Properties;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Data.Service;
using Saldo.Data.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

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
            int cajasCerradas = await CierreCajaService.UltimaCajaCerrada();
            if(cajasCerradas > 0)
                CustomMessageBox.ShowDialog(string.Format(Resources.cajasCierreAutomaticas, cajasCerradas), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);
        }
    }
}
