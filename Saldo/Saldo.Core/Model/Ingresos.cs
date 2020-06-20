using Common.Core.Model;

namespace Saldo.Core.Model
{
    public class Ingresos : Entity<int>
    {
        public int IdCierreCaja { get; protected set; }
        public CierreCaja CierreCaja { get; protected set; }
        public string Concepto { get; protected set; }
        public decimal Monto { get; protected set; }

        internal Ingresos()
        {
        }

        public Ingresos(int id, int idCierreCaja, string concepto, decimal monto)
        {
            Id = id;
            IdCierreCaja = idCierreCaja;
            Concepto = concepto;
            Monto = monto;
        }
    }
}
