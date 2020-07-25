using Common.Core.Enum;
using Common.Core.Exception;
using Common.Core.Model;
using Common.Data.Repository;
using Producto.Core.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Modelo = Producto.Core.Model;

namespace Producto.Data.Repository
{
    class ProductoRepository : BaseRepository<Context>
    {
        public ProductoRepository(Context Context) : base(Context)
        {
        }

        internal Task<List<Modelo.Producto>> Buscar(string codigo, Common.Core.Model.Categoria categoria, Modelo.Proveedor proveedor, bool? habilitado, bool? faltante)
        {
            IQueryable<Modelo.Producto> productos = Filtro(codigo, categoria, proveedor, habilitado, faltante);

            return productos.ToListAsync();
        }

        internal Task<List<Modelo.Producto>> Buscar(string codigo, Categoria categoria, Proveedor proveedor, bool? habilitado, bool? faltante, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Modelo.Producto> productos = Filtro(codigo, categoria, proveedor, habilitado, faltante);
            totalElementos = productos.Count();
            return productos                        
                        .OrderBy($"{ordenadoPor} {direccionOrdenamiento}")
                        .Skip(elementosPorPagina * (pagina - 1))
                        .Take(elementosPorPagina)
                        .ToListAsync();
        }

        internal Task<List<string>> ObtenerCodigos(Common.Core.Model.Categoria categoria, Modelo.Proveedor proveedor, bool? habilitado, bool? faltante)
        {
            IQueryable<Modelo.Producto> productos = Filtro(null, categoria, proveedor, habilitado, faltante);
            return productos.Select(x => x.Codigo).Union(productos.Select(x => x.Descripcion)).ToListAsync();
        }

        internal async Task Guardar(Modelo.Producto producto)
        {
            if(producto.Categoria != null)
                _context.Entry(producto.Categoria).State = EntityState.Unchanged;

            if (producto.Proveedores != null)
                producto.Proveedores.ToList().ForEach(x => _context.Entry(x).State = EntityState.Modified);

            if (producto.Id == 0)
            {
                var a = await Obtener(producto.Codigo);
                if (await Obtener(producto.Codigo) != null)
                    throw new NegocioException($"Ya existe un producto con código {producto.Codigo}.");

                _context.Producto.Add(producto);
            }
            else
            {
                var ProductoDB = _context.Producto
                                         .Include(x => x.Proveedores)
                                         .Include(x => x.Categoria)
                                         .FirstOrDefault(x => x.Id == producto.Id);

                _context.Entry(ProductoDB).CurrentValues.SetValues(producto);

                if (producto.Proveedores != null)
                {
                    ProductoDB.Proveedores.ToList().ForEach(ProveedoresDB =>
                    {
                        Proveedor proveedorLocal = producto.Proveedores.FirstOrDefault(x => x.Id == ProveedoresDB.Id);
                        if (proveedorLocal == null)
                            ProductoDB.Proveedores.Remove(ProveedoresDB);
                    });

                    producto.Proveedores.ToList().ForEach(Proveedores =>
                    {
                        Proveedor mercaderiaItemLocal = ProductoDB.Proveedores.FirstOrDefault(x => x.Id == Proveedores.Id);
                        if (mercaderiaItemLocal == null)
                            ProductoDB.Proveedores.Add(Proveedores);
                    });
                }
            }

            await _context.SaveChangesAsync();
        }

        internal async Task<Modelo.Producto> Obtener(string codigo)
        {
            return await _context.Producto
                                .Include(x => x.Proveedores)
                                .Include(x => x.Categoria)
                                .FirstOrDefaultAsync(x => !x.Borrado && x.Codigo == codigo);
        }

        internal async Task<Modelo.Producto> ObtenerReducido(string codigoDescripcion)
        {
            return await _context.Producto
                                .FirstOrDefaultAsync(x => !x.Borrado && (x.Codigo == codigoDescripcion || x.Descripcion.Contains(codigoDescripcion)));
        }

        private IQueryable<Modelo.Producto> Filtro(string codigo, Categoria categoria, Proveedor proveedor, bool? habilitado, bool? faltante)
        {
            IQueryable<Modelo.Producto> productos = _context.Producto.Where(x => !x.Borrado);

            if (!string.IsNullOrWhiteSpace(codigo))
                productos = productos.Where(x => x.Codigo.Contains(codigo) || x.Descripcion.Contains(codigo));

            if (categoria != null)
                productos = productos.Where(x => x.IdCategoria == categoria.Id);

            if (proveedor != null)
                productos = productos.Where(x => x.Proveedores.Any(y => y.Id == proveedor.Id));

            if (habilitado.HasValue)
                productos = productos.Where(x => x.Habilitado == habilitado.Value);

            if (faltante.HasValue)
            {
                if (faltante.Value)
                    productos = productos.Where(x => x.StockActual < x.StockMinimo);
                else
                    productos = productos.Where(x => x.StockActual >= x.StockMinimo);
            }
            return productos;
        }
    }
}
