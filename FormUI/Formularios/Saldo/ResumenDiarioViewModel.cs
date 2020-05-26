using FormUI.Componentes;
using FormUI.Formularios.Common;
using Gasto.Data.Service;
using Saldo.Core.Model;
using Saldo.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        public decimal Saldo => TotalIngresos - TotalEgresos;
        public decimal MontoCierreCaja { get; set; }
        public decimal Diferencia => Abierta ? 0 : MontoCierreCaja - Saldo;
        public string Estado => Abierta ? "Abierta" : "Cerrada";
        public Boolean Abierta => Id == 0;

        public ResumenDiarioViewModel()
        {
        }

        public ResumenDiarioViewModel(CierreCaja cierreCaja)
        {
            ActualizarDatos(cierreCaja);
        }

        public async Task CargarAsync()
        {
            await VerificarCajaDiaEnCurso();
            if (Abierta) await CargarDatosCajaAbiertaAsync();
        }

        private async Task VerificarCajaDiaEnCurso()
        {
            if (Id == 0) //Si hay Id es porque accedio al detalle de una caja cerrada
            {
                CierreCaja CierreCaja = await CierreCajaService.Obtener(Fecha);
                if (CierreCaja != null)
                {
                    NotifyPropertyChanged(nameof(Egresos));
                    NotifyPropertyChanged(nameof(Ingresos));
                }
            }
        }

        internal void CerraCaja()
        {
            List<Ingresos> ingresos = new List<Ingresos>();
            ingresos.AddRange(Ingresos.Select(x => new Ingresos(x.Concepto, x.Monto)));

            List<Egresos> egresos = new List<Egresos>();
            egresos.AddRange(Egresos.Select(x => new Egresos(x.Concepto, x.Monto)));

            CierreCaja cierreCaja = new CierreCaja(Id, Fecha, Sesion.Usuario.Alias, ingresos, egresos, MontoCierreCaja, Diferencia);
            CierreCajaService.Cerrar(cierreCaja);
        }

        private void ActualizarDatos(CierreCaja cierreCaja)
        {
            Id = cierreCaja.Id;
            Fecha = cierreCaja.FechaAlta;
            Egresos = new BindingList<ResumenDiarioItem>(cierreCaja.Egresos.Select(x => new ResumenDiarioItem(x.Concepto, x.Monto)).ToList());
            Ingresos = new BindingList<ResumenDiarioItem>(cierreCaja.Ingresos.Select(x => new ResumenDiarioItem(x.Concepto, x.Monto)).ToList());
            MontoCierreCaja = cierreCaja.MontoRegistrado;
        }

        private async Task CargarDatosCajaAbiertaAsync()
        {
            Task<List<KeyValuePair<string, decimal>>> gastoSaldo = Task.Run(() => GastoService.Saldo(Fecha));
            Task<List<KeyValuePair<string, decimal>>> ventaSaldo = Task.Run(() => VentaService.Saldo(Fecha));
            Task<CierreCaja> cajaDiaAnterior = CierreCajaService.Obtener(Fecha.Date.AddDays(-1));

            await Task.WhenAll(gastoSaldo, ventaSaldo, cajaDiaAnterior);

            Egresos = new BindingList<ResumenDiarioItem>(gastoSaldo.Result.Select(x => new ResumenDiarioItem(x.Key, x.Value)).ToList());
            Ingresos = new BindingList<ResumenDiarioItem>(ventaSaldo.Result.Select(x => new ResumenDiarioItem(x.Key, x.Value)).ToList());
            if(cajaDiaAnterior.Result != null)
                Ingresos.Insert(0, new ResumenDiarioItem("Inicio de caja", cajaDiaAnterior.Result.MontoRegistrado));

            NotifyPropertyChanged(nameof(Egresos));
            NotifyPropertyChanged(nameof(Ingresos));
        }
    }
}
