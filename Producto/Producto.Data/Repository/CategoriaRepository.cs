using Common.Data.Repository;
using Producto.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Data.Repository
{
    internal class CategoriaRepository: BaseRepository<Context>
    {
        internal CategoriaRepository(Context Context) : base(Context)
        {
        }

        internal async Task<IList<Categoria>> Buscar(string descripcion, bool? habilitado)
        {
            IQueryable<Categoria> categoria = _context.Categoria;
            if (!string.IsNullOrWhiteSpace(descripcion))
                categoria = categoria.Where(x => x.Descripcion.Contains(descripcion));

            if (habilitado.HasValue)
                categoria = categoria.Where(x => x.Habilitada == habilitado);

            return await categoria.ToListAsync();
        }

        internal async Task Borrar(Categoria categoria)
        {
            //TODO: BORRADO LOGICO
            throw new NotImplementedException();
        }

        internal async Task Guardar(Categoria categoria)
        {
            if (categoria.Id == 0)
                _context.Categoria.Add(categoria);
            else
                _context.Entry(categoria).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
