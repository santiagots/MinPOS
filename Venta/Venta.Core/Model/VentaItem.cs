
using Common.Core.Model;
using System;

namespace Venta.Core.Model
{
    public class VentaItem : Entity<int>
    {
        public int IdVenta { get; protected set; }
        public Venta Venta { get; protected set; }
        public int IdProducto { get; protected set; }
        public Producto Producto { get; protected set; }
        public int Cantidad { get; protected set; }

        public VentaItem(Producto producto, int cantidad)
        {
            IdProducto = producto.Id;
            Producto = producto;
            Cantidad = cantidad;
        }

        internal void DisminuirStock() => Producto.DisminuirStock(Cantidad);

    }
}
