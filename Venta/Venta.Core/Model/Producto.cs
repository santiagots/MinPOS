using Common.Core.Model;

namespace Venta.Core.Model
{
    public class Producto : Entity<int>
    {
        public string Codigo { get; protected set; }
        public string Descripcion { get; protected set; }
        public bool Suelto { get; protected set; }
        public decimal Precio { get; protected set; }
        public int StockActual { get; protected set; }
        public bool Habilitado { get; protected set; }

        public void DisminuirStock(int cantidad) => StockActual -= cantidad;
    }
}
