using FluentValidation;
using Producto.Core.Model;

namespace Producto.Core.Validadores
{
    public class CategoriaValidador: AbstractValidator<Categoria>
    {
        public CategoriaValidador()
        {
            RuleFor(m => m.Descripcion)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
