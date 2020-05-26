using FluentValidation;
using Modelo = Gasto.Core.Model;

namespace Gasto.Core.Validadores
{
    public class GastoValidador : AbstractValidator<Modelo.Gasto>
    {
        public GastoValidador()
        {
            RuleFor(m => m.Fecha)
                .NotEmpty();

            RuleFor(m => m.TipoGasto)
                .NotNull();

            RuleFor(m => m.Monto)
                .GreaterThan(0);

            RuleFor(m => m)
                .Must(x => !(x.Anulada && string.IsNullOrWhiteSpace(x.MotivoAnulada)))
                .WithMessage("Debe ingresar un motivo de anulación para anular el gasto.");
        }
    }
}
