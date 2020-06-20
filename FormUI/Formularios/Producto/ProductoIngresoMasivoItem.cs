using Modelo = Producto.Core.Model;
using System.Linq;

namespace FormUI.Formularios.Producto
{
    class ProductoIngresoMasivoItem
    {
        public Modelo.Producto ProductoItem { get; internal set; }

        public int Id => ProductoItem.Id;
        public string Codigo => ProductoItem.Codigo;
        public string Descripcion => ProductoItem.Descripcion;
        public string Categoria => ProductoItem.Categoria.Descripcion;
        public string Proveedores => ProductoItem.Proveedores.FirstOrDefault()?.RazonSocial;
        public bool Suelto => ProductoItem.Suelto;
        public decimal Costo => ProductoItem.Costo;
        public decimal Precio => ProductoItem.Precio;
        public int StockMinimo => ProductoItem.StockMinimo;
        public int StockOptimo => ProductoItem.StockOptimo;
        public int StockActual => ProductoItem.StockActual;

        public ProductoIngresoMasivoItem(Modelo.Producto producto) => ProductoItem = producto;
    }
}
