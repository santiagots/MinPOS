using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Model
{
    public class MovimientoMonto : Entity<int>
    {
        public bool ModificaCaja { get; protected set; }
        public string Concepto { get; protected set; }
        public decimal Monto { get; protected set; }

        public MovimientoMonto(bool modificaCaja, string concepto, decimal monto)
        {
            ModificaCaja = modificaCaja;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
