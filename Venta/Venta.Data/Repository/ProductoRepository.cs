using Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Venta.Core.Model;

namespace Venta.Data.Repository
{
    internal class ProductoRepository : BaseRepository<Context>
    {
        public ProductoRepository(Context context) : base(context)
        {
        }

        internal Task<List<string>> ObtenerDescripciones()
        {
            return _context.Producto.Where(x => !x.Borrado).Select(x => x.Descripcion).ToListAsync();
        }

        internal Task<List<Producto>> ObtenerProductos(string categoria, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Producto> consulta = _context.Producto.Where(x => !x.Borrado && x.Categoria.Descripcion == categoria)
                                                             .OrderBy(x => x.Categoria.Descripcion)
                                                             .ThenBy(x => x.Precio);

            totalElementos = consulta.Count();

            return consulta.Skip(elementosPorPagina * (pagina - 1))
                           .Take(elementosPorPagina)
                           .ToListAsync();
        }

        internal Task<List<Producto>> ObtenerFavoritos(int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Producto> consulta = _context.Producto.Where(x => !x.Borrado && x.Favorito)
                                                    .OrderBy(x => x.Categoria.Descripcion)
                                                    .ThenBy(x => x.Precio);

            totalElementos = consulta.Count();

            return consulta.Skip(elementosPorPagina * (pagina - 1))
                           .Take(elementosPorPagina)
                           .ToListAsync();
        }

        internal Task<Producto> Obtener(string codigoDescripcion)
        {
            return _context.Producto.FirstOrDefaultAsync(x => !x.Borrado && (x.Codigo == codigoDescripcion || x.Descripcion == codigoDescripcion));
        }
    }
}
