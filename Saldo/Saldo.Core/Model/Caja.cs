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
        public decimal Inicio { get; set; }
        public EstadoCaja Estado { get; protected set; }
        public IList<Venta> Ventas { get; protected set; } = new List<Venta>();
        public decimal IngresosTotal => Ventas.Where(x => !x.Anulada).Sum(x => x.Total);
        public IList<Gasto> Gastos { get; protected set; } = new List<Gasto>();
        public decimal EgresosTotal => Gastos.Where(x => !x.Anulada).Sum(x => x.Monto);
        public decimal EfectivoTotal => Ventas.Where(x => !x.Anulada && x.Pago.FormaPago == FormaPago.Efectivo).Sum(x => x.Total);
        public decimal RegistroTotal => Inicio + EfectivoTotal - EgresosTotal;
        public decimal MontoEnCaja { get; protected set; }
        public decimal Diferencia { get; protected set; }

        public Caja() { }

        public void Cerrar(string usuarioCierre, decimal montoEnCaja)
        {
            Estado = EstadoCaja.Cerrada;
            UsuarioCierre = usuarioCierre;
            FechaCierre = DateTime.Now;
            MontoEnCaja = montoEnCaja;
            Diferencia = montoEnCaja - RegistroTotal;
        }

        public void CerrarAutomatico() => Cerrar("Automático", EfectivoTotal);

        public void Abrir(string usuarioApertura, decimal inicio)
        {
            Estado = EstadoCaja.Abierta;
            UsuarioCierre = "";
            UsuarioApertura = usuarioApertura;
            FechaApertura = DateTime.Now;
            FechaCierre = null;
            Inicio = inicio;
            MontoEnCaja = 0;
            Diferencia = 0;
        }
    }
}

