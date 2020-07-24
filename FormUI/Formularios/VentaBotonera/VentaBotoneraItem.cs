using Modelo = Venta.Core.Model;

namespace FormUI.Formularios.VentaBotonera
{
    class VentaBotoneraItem
    {
        public Modelo.Producto Producto { get; internal set; }

        public string Codigo => Producto.Codigo;
        public string Descripcion => Producto.Descripcion;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Cantidad * Precio;

        public VentaBotoneraItem(Modelo.Producto producto, int cantidad, decimal precio)
        {
            Producto = producto;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
