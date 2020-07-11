
using Venta.Core.Enum;

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

        public MovimientoMonto(FormaPago formaPago, decimal monto)
        {
            ModificaCaja = formaPago == FormaPago.Efectivo? true : false;
            Concepto = formaPago.ToString();
            Monto = monto;
        }
    }
}
