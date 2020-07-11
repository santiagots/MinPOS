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
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public BindingList<ResumenDiarioItem> Egresos { get; set; } = new BindingList<ResumenDiarioItem>();
        public decimal TotalEgresos => Egresos.Sum(x => x.Monto);
        public BindingList<ResumenDiarioItem> Ingresos { get; set; } = new BindingList<ResumenDiarioItem>();
        public decimal TotalIngresos => Ingresos.Sum(x => x.Monto);
        public decimal Saldo => Ingresos.Where(x => x.ModificaCaja).Sum(x => x.Monto) - TotalEgresos;
        public decimal MontoCierreCaja { get; set; }
        public decimal Diferencia => Estado == EstadoCaja.Abierta ? 0 : MontoCierreCaja - Saldo;
        public EstadoCaja Estado { get; set; }
        public bool AbiertaCaja => Estado == EstadoCaja.Cerrada && Fecha.Date == DateTime.Now.Date;
        public bool CerradaCaja => Estado == EstadoCaja.Abierta;

        public ResumenDiarioViewModel()
        {
        }

        public ResumenDiarioViewModel(CierreCaja cierreCaja)
        {
            ActualizarDatos(cierreCaja);
        }

        public async Task CargarAsync()
        {
            if (Id == 0) //Si hay Id es porque accedio al detalle de una caja cerrada
            {
                CierreCaja CierreCaja = await CierreCajaService.Obtener(Fecha);
                if (CierreCaja != null)
                    ActualizarDatos(CierreCaja);
                else
                    await CargarDatosCajaAbiertaAsync();
            }
        }

        internal void ImprimirCaja()
        {
            Imprimir.Documento.CierreCaja cierreCaja = new Imprimir.Documento.CierreCaja(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, obtenerCajaDesdeViewModel());

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, cierreCaja);
            impresora.Imprimir();
        }

        internal void AbrirCaja() => ModificarCaja(EstadoCaja.Abierta);

        internal void CerraCaja() => ModificarCaja(EstadoCaja.Cerrada);

        private void ModificarCaja(EstadoCaja estadoCaja)
        {
            Estado = estadoCaja;
            CierreCaja cierreCaja = obtenerCajaDesdeViewModel();
            CierreCajaService.Guardar(cierreCaja);

            NotifyPropertyChanged(nameof(Estado));
        }

        private CierreCaja obtenerCajaDesdeViewModel()
        {
            List<Ingresos> ingresos = new List<Ingresos>();
            ingresos.AddRange(Ingresos.Select(x => new Ingresos(x.Id, Id, x.ModificaCaja, x.Concepto, x.Monto)));

            List<Egresos> egresos = new List<Egresos>();
            egresos.AddRange(Egresos.Select(x => new Egresos(x.Id, Id, x.ModificaCaja, x.Concepto, x.Monto)));

            CierreCaja cierreCaja = new CierreCaja(Id, Estado, Fecha, Sesion.Usuario.Alias, ingresos, egresos, MontoCierreCaja, Diferencia);
            return cierreCaja;
        }

        private void ActualizarDatos(CierreCaja cierreCaja)
        {
            Id = cierreCaja.Id;
            Fecha = cierreCaja.FechaAlta;
            Egresos = new BindingList<ResumenDiarioItem>(cierreCaja.Egresos.Select(x => new ResumenDiarioItem(x.Id, true, x.Concepto, x.Monto)).ToList());
            Ingresos = new BindingList<ResumenDiarioItem>(cierreCaja.Ingresos.Select(x => new ResumenDiarioItem(x.Id, x.ModificaCaja, x.Concepto, x.Monto)).ToList());
            MontoCierreCaja = cierreCaja.MontoEnCaja;
            Estado = cierreCaja.Estado;


            NotifyPropertyChanged(nameof(Egresos));
            NotifyPropertyChanged(nameof(Ingresos));
        }

        private async Task CargarDatosCajaAbiertaAsync()
        {
            Task<List<MovimientoMonto>> gastoSaldo = Task.Run(() => GastoService.Saldo(Fecha));
            Task<List<MovimientoMonto>> ventaSaldo = Task.Run(() => VentaService.Saldo(Fecha));
            Task<CierreCaja> cajaDiaAnterior = CierreCajaService.Obtener(Fecha.Date.AddDays(-1));

            await Task.WhenAll(gastoSaldo, ventaSaldo, cajaDiaAnterior);

            Egresos = new BindingList<ResumenDiarioItem>(gastoSaldo.Result
                                       .Where(x => x.ModificaCaja)
                                       .Select(x => new ResumenDiarioItem(0, x.ModificaCaja, x.Concepto, x.Monto)).ToList());

            Ingresos = new BindingList<ResumenDiarioItem>(ventaSaldo.Result
                                       .Select(x => new ResumenDiarioItem(0, x.ModificaCaja, x.Concepto, x.Monto)).ToList());

            NotifyPropertyChanged(nameof(Egresos));
            NotifyPropertyChanged(nameof(Ingresos));
        }
    }
}
