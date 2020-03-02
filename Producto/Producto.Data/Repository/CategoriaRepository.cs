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

        internal async Task<IList<Categoria>> Buscar(string descripcion)
        {
            if(!string.IsNullOrWhiteSpace(descripcion))
                return await _context.Categoria.Where(x => x.Descripcion.Contains(descripcion)).ToListAsync();
            else
                return await _context.Categoria.ToListAsync();
        }

        internal async Task Borrar(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Unchanged;
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
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
