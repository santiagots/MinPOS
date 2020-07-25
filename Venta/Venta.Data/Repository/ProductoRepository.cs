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

        internal Task<List<string>> ObtenerDescripciones(string categoria)
        {
            return _context.Producto.Where(x => !x.Borrado && x.Categoria.Descripcion == categoria).Select(x => x.Descripcion).ToListAsync();
        }

        internal Task<Producto> Obtener(string codigoDescripcion)
        {
            return _context.Producto.FirstOrDefaultAsync(x => !x.Borrado && (x.Codigo == codigoDescripcion || x.Descripcion.Contains(codigoDescripcion)));
        }
    }
}
