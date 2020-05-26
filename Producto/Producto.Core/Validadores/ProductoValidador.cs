using FluentValidation;
using FluentValidation.Results;
using Modelo = Producto.Core.Model;

namespace Producto.Core.Validadores
{
    public class ProductoValidador : AbstractValidator<Modelo.Producto>
    {
        public ProductoValidador()
        {
            RuleFor(m => m.Codigo)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Descripcion)
                .NotEmpty();

            RuleFor(m => m)
                .Custom((x, context) => {
                    if (!x.Suelto && x.Precio == 0)
                        context.AddFailure(new ValidationFailure("Precio", "El precio debe ser mayor a cero."));
                });
        }
    }
}
