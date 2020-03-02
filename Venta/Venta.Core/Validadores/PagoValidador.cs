using FluentValidation;
using Venta.Core.Model;

namespace Venta.Core.Validadores
{
    public class PagoValidador : AbstractValidator<Pago>
    {
        public PagoValidador()
        {
            RuleFor(m => m.Monto)
                .GreaterThan(0);
        }
    }
}
