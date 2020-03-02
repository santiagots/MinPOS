using Common.Core.Model;

namespace Producto.Core.Model
{
    public class MercaderiaItem : Entity<int>
    {
        public int IdMercaderia { get; internal set; }
        public Mercaderia Mercaderia { get; internal set; }
        public int IdProducto { get; internal set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; internal set; }
        public decimal TotalCosto => Producto.Costo * Cantidad;

        public MercaderiaItem()
        { }

        public MercaderiaItem(Producto producto, int cantidad)
        {
            IdProducto = producto.Id;
            Producto = producto;
            Cantidad = cantidad;
        }

        public void ModificarCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }

        public void ModificarProducto(Producto producto)
        {
            IdProducto = producto.Id;
            Producto = producto;
        }
    }
}
