using Common.Data.Repository;
using Producto.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Data.Repository
{
    public class ProveedorRepository : BaseRepository<Context>
    {
        public ProveedorRepository(Context Context) : base(Context)
        {
        }

        internal async Task<IList<Proveedor>> Buscar(string rasonSocial, bool? habilitado)
        {
            IQueryable<Proveedor> proveedor = _context.Proveedor;
            if (!string.IsNullOrWhiteSpace(rasonSocial))
                proveedor = proveedor.Where(x => x.RazonSocial.Contains(rasonSocial));

            if (habilitado.HasValue)
                proveedor = proveedor.Where(x => x.Habilitado == habilitado);

            return await proveedor.ToListAsync();
        }

        internal async Task Guardar(Proveedor proveedor)
        {
            if (proveedor.Id == 0)
                _context.Proveedor.Add(proveedor);
            else
                _context.Entry(proveedor).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
