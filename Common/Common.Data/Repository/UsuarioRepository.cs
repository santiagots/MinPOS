using Common.Core.Exception;
using Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Data.Repository
{
    internal class UsuarioRepository : BaseRepository<Context>
    {
        internal UsuarioRepository(Context Context) : base(Context)
        {
        }

        internal Task Guardar(Usuario usuario)
        {
            if (usuario.Id == 0)
            {
                if (_context.Usuario.Any(x => x.Alias == usuario.Alias))
                    throw new NegocioException($"Ya existe usuario registrado con el nombre {usuario.Alias}. Por favor, ingrese otro valor.");

                _context.Usuario.Add(usuario);
            }
            else
            {
                if (_context.Usuario.Any(x => x.Alias == usuario.Alias && x.Id != usuario.Id))
                    throw new NegocioException($"Ya existe usuario registrado con el nombre {usuario.Alias}. Por favor, ingrese otro valor.");

                _context.Entry(usuario).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        internal Task<List<Usuario>> Buscar(string alias, bool? habilitado)
        {
            IQueryable<Usuario> usuarios = _context.Usuario;
            if (!string.IsNullOrWhiteSpace(alias))
                usuarios = usuarios.Where(x => x.Alias.Contains(alias));

            if (habilitado.HasValue)
                usuarios = usuarios.Where(x => x.Habilitado == habilitado);

            return usuarios.ToListAsync();
        }

        internal Task Borrar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Unchanged;
            _context.Usuario.Remove(usuario);
            return _context.SaveChangesAsync();
        }

        internal Task<Usuario> Obtener(string alias)
        {
            return _context.Usuario.FirstOrDefaultAsync(x => x.Alias == alias);
        }
    }
}
