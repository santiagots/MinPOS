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
    class ResumenDiarioViewModel : CommonViewModel
    {
        private Caja cierreCajaModel;
        public DateTime FechaApertura => cierreCajaModel.FechaApertura;
        public DateTime? FechaCierre => cierreCajaModel.FechaCierre;
        public string UsuarioApertura => cierreCajaModel.UsuarioApertura;
        public string UsuarioCierre => cierreCajaModel.UsuarioCierre;
        public BindingList<ResumenDiarioItem> Egresos => new BindingList<ResumenDiarioItem>(cierreCajaModel.Gastos.Select(x => new ResumenDiarioItem(x.Id, true, x.TipoGasto.Descripcion, x.Monto)).ToList());
        public decimal TotalEgresos => cierreCajaModel.EgresosTotal;
        public BindingList<ResumenDiarioItem> Ingresos => new BindingList<ResumenDiarioItem>(cierreCajaModel.Ventas.Select(x => new ResumenDiarioItem(x.Id, true, x.Pago.FormaPago.ToString(), x.Total)).ToList());
        public decimal TotalIngresos => cierreCajaModel.IngresosTotal;
        public decimal Saldo => cierreCajaModel.SaldoTotal;
        public decimal MontoCierreCaja { get; set; }
        public decimal Diferencia => Estado == EstadoCaja.Abierta ? 0 : cierreCajaModel.Diferencia;
        public EstadoCaja Estado => cierreCajaModel.Estado;
        public bool AbiertaCaja => Estado == EstadoCaja.Cerrada && FechaApertura.Date == DateTime.Now.Date;
        public bool CerradaCaja => Estado == EstadoCaja.Abierta;

        public ResumenDiarioViewModel(Caja cierreCaja)
        {
            cierreCajaModel = cierreCaja;
            MontoCierreCaja = cierreCaja.MontoEnCaja;
        }

        public async Task CargarAsync()
        {

        }

        internal void ImprimirCaja()
        {
            Imprimir.Documento.CierreCaja cierreCaja = new Imprimir.Documento.CierreCaja(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, cierreCajaModel);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, cierreCaja);
            impresora.Imprimir();
        }

        internal async Task AbrirCajaAsync()
        {
            cierreCajaModel.Abrir(Sesion.Usuario.Alias);
            await CajaService.GuardarAsync(cierreCajaModel);

            NotifyPropertyChanged(nameof(Estado));
        }

        internal async Task CerraCajaAsync()
        {
            cierreCajaModel.Cerrar(Sesion.Usuario.Alias, MontoCierreCaja);
            await CajaService.GuardarAsync(cierreCajaModel);

            NotifyPropertyChanged(nameof(Estado));
        }
    }
}
