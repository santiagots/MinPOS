using FluentValidation;
using Common.Core.Model;

namespace Common.Core.Validadores
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
