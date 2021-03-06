﻿using FluentValidation;

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


            RuleFor(m => m)
                .Must(x => !(x.Anulada && string.IsNullOrWhiteSpace(x.MotivoAnulada)))
                .WithMessage("Debe ingresar un motivo de anulación para anular la venta.");
        }
    }
}
