using Common.Core.Model;

namespace Saldo.Core.Model
{
    public class Egresos : Entity<int>
    {
        public int IdCierreCaja { get; protected set; }
        public CierreCaja CierreCaja { get; protected set; }
        public string Concepto { get; protected set; }
        public decimal Monto { get; protected set; }

        internal Egresos()
        {
        }

        public Egresos(string concepto, decimal monto)
        {
            Concepto = concepto;
            Monto = monto;
        }
    }
}
