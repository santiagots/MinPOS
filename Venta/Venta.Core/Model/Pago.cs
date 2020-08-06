using Common.Core.Model;
using Venta.Core.Enum;

namespace Venta.Core.Model
{
    public class Pago : Entity<int>
    {
        public FormaPago FormaPago { get; protected set; }
        public decimal Monto { get; protected set; }
        public decimal MontoPago { get; protected set; }
        public int NumeroLote { get; protected set; }
        public int NumeroComprobante { get; protected set; }

        internal Pago() 
        { 
        }
        public Pago(FormaPago formaPago, decimal montoVenta, decimal montoPago, int numeroLote, int numeroComprobante)
        {
            FormaPago = formaPago;
            Monto = montoVenta;
            MontoPago = montoPago;
            NumeroLote = numeroLote;
            NumeroComprobante = numeroComprobante;
        }
    }
}
