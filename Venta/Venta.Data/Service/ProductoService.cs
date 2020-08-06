using System.Collections.Generic;
using System.Threading.Tasks;
using Venta.Core.Model;
using Venta.Data.Repository;

namespace Venta.Data.Service
{
    public class ProductoService
    {
        public static Task<Producto> Obtener(string codigoDescripcion)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.Obtener(codigoDescripcion);
        }

        public static Task<List<Producto>> ObtenerProductos(string categoria, int pagina, int elementosPorPagina, out int totalElementos)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerProductos(categoria, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<Producto>> ObtenerFavoritos(int pagina, int elementosPorPagina, out int totalElementos)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerFavoritos(pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<string>> ObtenerDescripciones()
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerDescripciones();
        }
    }
}
