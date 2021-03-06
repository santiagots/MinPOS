﻿using FluentValidation;
using Producto.Core.Model;

namespace Producto.Core.Validadores
{
    public class ProveedorValidador : AbstractValidator<Proveedor>
    {
        public ProveedorValidador()
        {
            RuleFor(m => m.RazonSocial)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Email)
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(m => m.Direccion)
                .MaximumLength(100);

            RuleFor(m => m.Telefono)
                .MaximumLength(25);
        }
    }
}
