using Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saldo.Core.Model
{
    public class Venta : Entity<int>
    {
        public int IdCaja { get; protected set; }
        public Caja Caja { get; protected set; }
        public int IdPago { get; protected set; }
        public Pago Pago { get; protected set; }
        public decimal Descuento { get; protected set; }
        public decimal Total => Pago.Monto - Descuento;
        public bool Anulada { get; protected set; }

        internal Venta()
        { }
    }
}
