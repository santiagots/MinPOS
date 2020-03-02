using Common.Core.Model;

namespace Producto.Core.Model
{
    public class ProductoProveedor : Entity<int>
    {
        public int IdProducto { get; protected set; }
        public Producto Producto { get; protected set; }
        public int IdProveedor { get; protected set; }
        public Proveedor Proveedor { get; protected set; }
    }
}
