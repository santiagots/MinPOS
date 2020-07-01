using Common.Data.Repository;
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

        internal Task<List<string>> ObtenerCodigos()
        {
            return _context.Producto.Where(x => !x.Borrado).Select(x => x.Descripcion).ToListAsync();
        }

        internal async Task<Producto> Obtener(string codigoDescripcion)
        {
            return await _context.Producto
                                .FirstOrDefaultAsync(x => !x.Borrado && (x.Codigo == codigoDescripcion || x.Descripcion.Contains(codigoDescripcion)));
        }
    }
}
