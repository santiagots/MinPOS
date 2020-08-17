using Common.Core.Model;
using Dispositivos;
using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Gasto.Data.Service;
using Saldo.Core.Enum;
using Saldo.Core.Model;
using Saldo.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Venta.Data.Service;

namespace FormUI.Formularios.Saldo
{
    class CajaViewModel : CommonViewModel
    {
        private Caja cierreCajaModel;
        public DateTime? FechaApertura => cierreCajaModel?.FechaApertura;
        public DateTime? FechaCierre => cierreCajaModel?.FechaCierre;
        public string UsuarioApertura => cierreCajaModel?.UsuarioApertura;
        public string UsuarioCierre => cierreCajaModel?.UsuarioCierre;
        public BindingList<CajaItem> Egresos => cierreCajaModel == null ? new BindingList<CajaItem>() : new BindingList<CajaItem>(cierreCajaModel.Gastos.GroupBy(x => x.TipoGasto.Descripcion).Select(x => new CajaItem(x.Key, x.Sum(y => y.Monto))).ToList());
        public decimal TotalEgresos => cierreCajaModel == null? 0: cierreCajaModel.EgresosTotal;
        public BindingList<CajaItem> Ingresos => cierreCajaModel == null ? new BindingList<CajaItem>() : new BindingList<CajaItem>(cierreCajaModel.Ventas.GroupBy(x => x.Pago.FormaPago).Select(x => new CajaItem(x.Key.ToString(), x.Sum(y => y.Total))).ToList());
        public decimal TotalIngresos => cierreCajaModel == null ? 0 : cierreCajaModel.IngresosTotal;
        public decimal Inicio { get; set; }
        public decimal TotalEfectivo => cierreCajaModel == null ? 0 : cierreCajaModel.EfectivoTotal;
        public decimal TotalRegistrado => cierreCajaModel == null ? 0 : cierreCajaModel.RegistroTotal;
        public decimal MontoCierreCaja { get; set; }
        public decimal Diferencia => cierreCajaModel?.Estado == EstadoCaja.Abierta ? 0 : cierreCajaModel.Diferencia;
        public string Estado => cierreCajaModel == null ? "Nueva" : cierreCajaModel.Estado.ToString() ;
        public bool AbiertaCaja => (cierreCajaModel?.Estado == EstadoCaja.Cerrada && FechaApertura.Value.Date == DateTime.Now.Date) || cierreCajaModel == null;
        public bool CerradaCaja => cierreCajaModel?.Estado == EstadoCaja.Abierta;

        public CajaViewModel()
        {
        }

        public CajaViewModel(Caja cierreCaja)
        {
            cierreCajaModel = cierreCaja;
            MontoCierreCaja = cierreCaja.MontoEnCaja;
            Inicio = cierreCaja.Inicio;
        }

        internal void ImprimirCaja()
        {
            Imprimir.Documento.CierreCaja cierreCaja = new Imprimir.Documento.CierreCaja(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, cierreCajaModel);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, cierreCaja);
            impresora.Imprimir();
        }

        internal async Task AbrirCajaAsync()
        {
            if (cierreCajaModel == null)
                cierreCajaModel = new Caja();
            
            cierreCajaModel.Abrir(Sesion.Usuario.Alias, Inicio);
            await CajaService.GuardarAsync(cierreCajaModel);

            Sesion.IdCaja = cierreCajaModel.Id;

            NotifyPropertyChanged(nameof(Estado));
        }

        internal async Task CerraCajaAsync()
        {
            cierreCajaModel.Cerrar(Sesion.Usuario.Alias, MontoCierreCaja);
            await CajaService.GuardarAsync(cierreCajaModel);

            Sesion.IdCaja = null;

            NotifyPropertyChanged(nameof(Estado));
        }
    }
}
