using FluentValidation;
using Saldo.Core.Model;

namespace Saldo.Core.Validadores
{
    public class CierreCajaValidador : AbstractValidator<CierreCaja>
    {
        public CierreCajaValidador()
        {
            RuleFor(m => m.MontoEnCaja)
                .GreaterThan(0);
        }
    }
}
