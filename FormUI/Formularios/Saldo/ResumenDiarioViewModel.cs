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
        private CierreCaja cierreCajaModel;
        public DateTime Fecha => cierreCajaModel.FechaApertura;
        public BindingList<ResumenDiarioItem> Egresos => new BindingList<ResumenDiarioItem>(cierreCajaModel.Egresos.Select(x => new ResumenDiarioItem(x.Id, true, x.Concepto, x.Monto)).ToList());
        public decimal TotalEgresos => cierreCajaModel.EgresosTotal;
        public BindingList<ResumenDiarioItem> Ingresos => new BindingList<ResumenDiarioItem>(cierreCajaModel.Ingresos.Select(x => new ResumenDiarioItem(x.Id, x.ModificaCaja, x.Concepto, x.Monto)).ToList());
        public decimal TotalIngresos => cierreCajaModel.IngresosTotal;
        public decimal Saldo => cierreCajaModel.SaldoTotal;
        public decimal MontoCierreCaja { get; set; }
        public decimal Diferencia => Estado == EstadoCaja.Abierta ? 0 : MontoCierreCaja - Saldo;
        public EstadoCaja Estado => cierreCajaModel.Estado;
        public bool AbiertaCaja => Estado == EstadoCaja.Cerrada && Fecha.Date == DateTime.Now.Date;
        public bool CerradaCaja => Estado == EstadoCaja.Abierta;

        public ResumenDiarioViewModel(CierreCaja cierreCaja)
        {
            cierreCajaModel = cierreCaja;
        }

        public async Task CargarAsync()
        {
            if (cierreCajaModel.FechaApertura.Date == DateTime.Now.Date)
            {
                await CargarDatosCajaAbiertaAsync();

                NotifyPropertyChanged(nameof(Egresos));
                NotifyPropertyChanged(nameof(Ingresos));
            }
        }

        internal void ImprimirCaja()
        {
            Imprimir.Documento.CierreCaja cierreCaja = new Imprimir.Documento.CierreCaja(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, cierreCajaModel);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, cierreCaja);
            impresora.Imprimir();
        }

        internal void AbrirCaja()
        {
            cierreCajaModel.Abrir(Sesion.Usuario.Alias);
            CierreCajaService.Guardar(cierreCajaModel);

            NotifyPropertyChanged(nameof(Estado));
        }

        internal void CerraCaja()
        {
            cierreCajaModel.Cerrar(Sesion.Usuario.Alias, MontoCierreCaja);
            CierreCajaService.Guardar(cierreCajaModel);

            NotifyPropertyChanged(nameof(Estado));
        }

        private async Task CargarDatosCajaAbiertaAsync()
        {
            Task<List<MovimientoMonto>> egresos = Task.Run(() => GastoService.Saldo(Fecha));
            Task<List<MovimientoMonto>> ingresos = Task.Run(() => VentaService.Saldo(Fecha));

            await Task.WhenAll(egresos, ingresos);

            List<Ingresos> ingresosModel = new List<Ingresos>();
            ingresosModel.AddRange(ingresos.Result.Select(x => new Ingresos(x.Id, cierreCajaModel.Id, x.ModificaCaja, x.Concepto, x.Monto)));
            cierreCajaModel.AgregarIngresos(ingresosModel);

            List<Egresos> egresosModel = new List<Egresos>();
            egresosModel.AddRange(egresos.Result.Select(x => new Egresos(x.Id, cierreCajaModel.Id, x.ModificaCaja, x.Concepto, x.Monto)));
            cierreCajaModel.AgregarEgresos(egresosModel);
        }
    }
}
