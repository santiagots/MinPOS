
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
        public decimal Precio { get; protected set; }
        public decimal Total => Cantidad * Precio;

        internal VentaItem()
        { }

        public VentaItem(Producto producto, int cantidad, decimal precio)
        {
            IdProducto = producto.Id;
            Producto = producto;
            Cantidad = cantidad;
            Precio = precio;
        }

        internal void DisminuirStock() => Producto.DisminuirStock(Cantidad);

        internal void AumentarStock() => Producto.AumentarStock(Cantidad);

    }
}
