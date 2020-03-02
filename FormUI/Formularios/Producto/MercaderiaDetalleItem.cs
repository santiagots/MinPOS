using Modelo = Producto.Core.Model;

namespace FormUI.Formularios.Producto
{
    class MercaderiaDetalleItem
    {
        public Modelo.MercaderiaItem MercaderiaItem { get; internal set; } = new Modelo.MercaderiaItem();
        public string Codigo => MercaderiaItem.Producto.Codigo;
        public string Descripcion => MercaderiaItem.Producto.Descripcion;
        public decimal Costo => MercaderiaItem.Producto.Costo;
        public decimal Precio => MercaderiaItem.Producto.Precio;
        public int StockMinimo => MercaderiaItem.Producto.StockMinimo;
        public int StockOptimo => MercaderiaItem.Producto.StockOptimo;
        public int StockActual => MercaderiaItem.Producto.StockActual;
        public int Cantidad { get => MercaderiaItem.Cantidad; set => MercaderiaItem.ModificarCantidad(value); }
        public decimal Total => MercaderiaItem.TotalCosto;

        public MercaderiaDetalleItem(Modelo.Producto productos, int cantidad) => MercaderiaItem = new Modelo.MercaderiaItem(productos, cantidad);

        public MercaderiaDetalleItem(Modelo.MercaderiaItem mercaderiaItem) => MercaderiaItem = mercaderiaItem;
    }
}
