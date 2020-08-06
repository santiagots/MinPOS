using Common.Core.Model;
using Saldo.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using Venta.Core.Enum;

namespace Saldo.Core.Model
{
    public class Caja : Entity<int>
    {
        public DateTime FechaApertura { get; protected set; }
        public DateTime? FechaCierre { get; protected set; }
        public string UsuarioApertura { get; protected set; }
        public string UsuarioCierre { get; protected set; }
        public EstadoCaja Estado { get; protected set; }
        public IList<Venta> Ventas { get; protected set; }
        public decimal IngresosTotal => Ventas.Where(x => !x.Anulada).Sum(x => x.Total);
        public IList<Gasto> Gastos { get; protected set; }
        public decimal EgresosTotal => Gastos.Where(x => !x.Anulada).Sum(x => x.Monto);
        public decimal SaldoTotal => Ventas.Where(x => !x.Anulada && x.Pago.FormaPago == FormaPago.Efectivo).Sum(x => x.Total) - EgresosTotal;
        public decimal MontoEnCaja { get; protected set; }
        public decimal Diferencia { get; protected set; }

        public Caja()
        {
            Id = 1;
        }

        public void Cerrar(string usuarioCierre, decimal montoEnCaja)
        {
            Estado = EstadoCaja.Cerrada;
            UsuarioCierre = usuarioCierre;
            FechaCierre = DateTime.Now;
            MontoEnCaja = montoEnCaja;
            Diferencia = montoEnCaja - SaldoTotal;
        }

        public void CerrarAutomatico() => Cerrar("Automático", SaldoTotal);

        public void Abrir(string usuarioApertura)
        {
            Estado = EstadoCaja.Abierta;
            UsuarioCierre = "";
            UsuarioApertura = usuarioApertura;
            FechaApertura = DateTime.Now;
            FechaCierre = null;
            MontoEnCaja = 0;
            Diferencia = 0;
        }
    }
}

