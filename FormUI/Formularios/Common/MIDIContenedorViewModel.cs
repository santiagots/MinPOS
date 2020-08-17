using Common.Core.Enum;
using Common.Core.Exception;
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

        internal async Task AdministrarCajaEnCurso(Action<bool> modificacionHabilitacionFunciones)
        {
            Caja cajaAbiertaDelDiaEnCurso = await CajaService.ObtenerCajaAbierta();
            if (cajaAbiertaDelDiaEnCurso != null)
            {
                CustomMessageBox.ShowDialog(string.Format(Resources.cajasRecuperadaDiaEnCurso, cajaAbiertaDelDiaEnCurso.UsuarioApertura), "Cierre Caja", MessageBoxButtons.OK, CustomMessageBoxIcon.Info);
                Sesion.IdCaja = cajaAbiertaDelDiaEnCurso.Id;
                modificacionHabilitacionFunciones(true);
            }
            else
            {
                modificacionHabilitacionFunciones(false);
            }
        }

        internal void CargarUsuario(ToolStripStatusLabel toolStripStatusUsuario)
        {
            toolStripStatusUsuario.Text = $"Usuario: {Sesion.Usuario.Alias}";
        }

        internal async Task MostrarCajaAsync()
        {
            if (!Sesion.IdCaja.HasValue)
            {
                CajaForm cajaForm = new CajaForm();
                cajaForm.ShowDialog();
            }
            else
            {
                Caja cajasEnCurso = await CajaService.Obtener(Sesion.IdCaja.Value);
                CajaForm resumenDiarioForm = new CajaForm(cajasEnCurso);
                resumenDiarioForm.ShowDialog();
            }
        }

        internal async Task CerrarCajasPendientes(Form mdiParent)
        {
            List<Caja> cajasPendientesDeCierre = await CajaService.ObtenerCajaPendienteDeCierre();
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
