using FluentValidation;
using Modelo = Producto.Core.Model;

namespace Producto.Core.Validadores
{
    public class ProductoValidador : AbstractValidator<Modelo.Producto>
    {
        public ProductoValidador()
        {
            RuleFor(m => m.Codigo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Descripcion)
                .NotEmpty();

            RuleFor(m => m.Proveedores)
                .NotNull();

            RuleFor(m => m.Categoria)
                .NotNull();

            RuleFor(m => m.Precio)
                .GreaterThan(0);
        }
    }
}
