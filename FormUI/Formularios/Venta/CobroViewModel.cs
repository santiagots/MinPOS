using Common.Core.Exception;
using FormUI.Formularios.Common;
using System;
using Venta.Core.Enum;

namespace FormUI.Formularios.Venta
{
    class CobroViewModel : CommonViewModel
    {
        public readonly decimal TotalACobrar;
        public decimal Efectivo { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal NumeroLote { get; set; }
        public decimal NumeroComprobante { get; set; }

        public CobroViewModel(decimal totalACobrar)
        {
            TotalACobrar = totalACobrar;
            Efectivo = totalACobrar;
        }

        public FormaPago ObtenerFormaPago() 
        {
            if (Efectivo != 0)
                return FormaPago.Efectivo;
            else if (Debito != 0)
                return FormaPago.Débito;
            else if (Credito != 0)
                return FormaPago.Crédito;
            else
                return FormaPago.Efectivo;

            throw new NegocioException("Error al obtener el tipo del pago, debe ingresar un monto de pago.");
        }

        internal bool CobroValido()
        {
            if (ObtenerMontoPago() >= TotalACobrar)
                return true;
            else
                throw new NegocioException($"El monto ingresado es menor al total de la venta. Por favor ingrese un monto igual o mayor a {TotalACobrar.ToString("c2")}");
        }

        internal void CargarDebito()
        {
            Efectivo = 0;
            Debito = TotalACobrar;
            Credito = 0;

            NotifyPropertyChanged(nameof(Debito));
        }

        internal void CargarEfectivo()
        {
            Efectivo = TotalACobrar;
            Debito = 0;
            Credito = 0;

            NotifyPropertyChanged(nameof(Efectivo));
        }

        internal void CargarCredito()
        {
            Efectivo = 0;
            Debito = 0;
            Credito = TotalACobrar;

            NotifyPropertyChanged(nameof(Credito));
        }

        public decimal ObtenerMontoPago()
        {
            switch (ObtenerFormaPago())
            {
                case FormaPago.Efectivo: return Efectivo;
                case FormaPago.Débito: return Debito;
                case FormaPago.Crédito: return Credito;
                default: throw new NegocioException("Error al obtener el monto del pago, no se pudo determinar la forma de pago.");
            }
        }
    }
}
