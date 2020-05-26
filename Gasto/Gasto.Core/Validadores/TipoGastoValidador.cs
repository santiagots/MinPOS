using FluentValidation;
using Gasto.Core.Model;

namespace Gasto.Core.Validadores
{
    public class TipoGastoValidador:AbstractValidator<TipoGasto>
    {
        public TipoGastoValidador()
        {
            RuleFor(m => m.Descripcion)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
