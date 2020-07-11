using Common.Core.Model;
using Saldo.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saldo.Core.Model
{
    public class CierreCaja : Entity<int>
    {
        public DateTime FechaAlta { get; protected set; }
        public string UsuarioAlta { get; protected set; }
        public EstadoCaja Estado { get; protected set; }
        public IList<Ingresos> Ingresos { get; protected set; }
        public decimal IngresosTotal => Ingresos.Sum(x => x.Monto);
        public IList<Egresos> Egresos { get; protected set; }
        public decimal EgresosTotal => Egresos.Sum(x => x.Monto);
        public decimal SaldoTotal => Ingresos.Where(x => x.ModificaCaja).Sum(x => x.Monto) - EgresosTotal;
        public decimal MontoEnCaja { get; protected set; }
        public decimal Diferencia { get; protected set; }

        internal CierreCaja()
        {
        }

        public CierreCaja(int id, EstadoCaja estado, DateTime fechaAlta, string usuarioAlta, IList<Ingresos> ingresos, IList<Egresos> egresos, decimal montoEnCaja, decimal diferencia)
        {
            Id = id;
            Estado = estado;
            FechaAlta = fechaAlta;
            UsuarioAlta = usuarioAlta;
            Ingresos = ingresos;
            Egresos = egresos;
            MontoEnCaja = montoEnCaja;
            Diferencia = diferencia;
        }

        public void Cerrar()
        {
            Estado = EstadoCaja.Cerrada;
        }
    }
}

