using Modelo = Venta.Core.Model;

namespace FormUI.Formularios.Venta
{
    class VentaItem
    {
        public Modelo.Producto Producto { get; internal set; }

        public string Codigo => Producto.Codigo;
        public string Descripcion => Producto.Descripcion;
        public decimal Precio => Producto.Precio;
        public int Cantidad { get; set; }
        public decimal Total => Cantidad * Precio;

        public VentaItem(Modelo.Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
    }
}
