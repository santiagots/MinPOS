using Common.Core.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Validadores
{
    public class UsuarioValidador : AbstractValidator<Usuario>
    {
        public UsuarioValidador()
        {
            RuleFor(m => m.Alias)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.Nombre)
                .MaximumLength(50);

            RuleFor(m => m.Apellido)
                .MaximumLength(50);

            RuleFor(m => m.Clave)
                .NotEmpty();            
        }
    }
}
