using FluentValidation;
using Saldo.Core.Model;

namespace Saldo.Core.Validadores
{
    public class CierreCajaValidador : AbstractValidator<CierreCaja>
    {
        public CierreCajaValidador()
        {
            RuleFor(m => m.MontoRegistrado)
                .GreaterThan(0);
        }
    }
}
