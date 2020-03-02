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

        public static Task<List<string>> ObtenerCodigos()
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerCodigos();
        }
    }
}
