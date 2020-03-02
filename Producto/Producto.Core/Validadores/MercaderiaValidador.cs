using FluentValidation;
using Producto.Core.Model;

namespace Producto.Core.Validadores
{
    public class MercaderiaValidador : AbstractValidator<Mercaderia>
    {
        public MercaderiaValidador()
        {
            RuleFor(m => m.Proveedor)
                .NotNull();

            RuleFor(m => m.MercaderiaItems)
                .Must(x => x.Count > 0);

            RuleForEach(m => m.MercaderiaItems)
                .Must(x => x.Cantidad > 0)
                .WithMessage((x,y) => $"El producto \"{y.Producto.Codigo}\" debe tener una cantidad mayor a Cero ");
        }
    }
}
