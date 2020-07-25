using Common.Core.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Data.Repository
{
    internal class CategoriaRepository: BaseRepository<Context>
    {
        internal CategoriaRepository(Context Context) : base(Context)
        {
        }

        internal async Task<IList<Categoria>> Buscar(string descripcion, bool? habilitado)
        {
            IQueryable<Categoria> categoria = _context.Categoria.Where(x => !x.Borrado);

            if (!string.IsNullOrWhiteSpace(descripcion))
                categoria = categoria.Where(x => x.Descripcion.Contains(descripcion));

            if (habilitado.HasValue)
                categoria = categoria.Where(x => x.Habilitada == habilitado);

            return await categoria.ToListAsync();
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
