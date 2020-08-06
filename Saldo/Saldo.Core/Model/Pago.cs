using Common.Core.Model;
using Venta.Core.Enum;

namespace Saldo.Core.Model
{
    public class Pago : Entity<int>
    {
        public FormaPago FormaPago { get; protected set; }
        public decimal Monto { get; protected set; }

        internal Pago() 
        { 
        }
    }
}
