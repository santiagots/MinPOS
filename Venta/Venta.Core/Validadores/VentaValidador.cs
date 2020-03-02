using FluentValidation;
using Model = Venta.Core.Model;

namespace Venta.Core.Validadores
{
    public class VentaValidador : AbstractValidator<Model.Venta>
    {
        public VentaValidador()
        {
            RuleFor(m => m.Pago)
                .NotNull().WithMessage("Debe ingresar un pago para la venta.");

            RuleFor(m => m.VentaItems)
                .NotEmpty().WithMessage("Debe ingresar algun producto parar realizar la venta.");
        }
    }
}
