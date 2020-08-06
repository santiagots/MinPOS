using Common.Core.Model;
using System;

namespace Saldo.Core.Model
{
    public class Gasto : Entity<int>
    {
        public int? IdCaja { get; protected set; }
        public Caja Caja { get; protected set; }
        public int? IdTipoGasto { get; protected set; }
        public TipoGasto TipoGasto { get; protected set; }
        public decimal Monto { get; protected set; }
        public bool Anulada { get; protected set; }

        protected Gasto() { }
    }
}
