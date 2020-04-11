using Common.Core.Exception;
using Common.Core.Model;
using Common.Core.Validadores;
using Common.Data.Repository;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Data.Service
{
    public class UsuarioService
    {
        public static Task Guardar(Usuario usuario)
        {
            UsuarioValidador validador = new UsuarioValidador();
            ValidationResult validadorResultado = validador.Validate(usuario);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            UsuarioRepository usuarioRepository = new UsuarioRepository(new Context());
            return usuarioRepository.Guardar(usuario);
        }

        public static Task Borrar(Usuario usuario)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository(new Context());
            return usuarioRepository.Borrar(usuario);
        }

        public static Task<Usuario> Obtener(string alias)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository(new Context());
            return usuarioRepository.Obtener(alias);
        }

        public static Task<List<Usuario>> Buscar(string alias, bool? habilitado)
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository(new Context());
            return usuarioRepository.Buscar(alias, habilitado);
        }
    }
}
