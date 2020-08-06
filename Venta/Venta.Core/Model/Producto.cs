using Common.Core.Model;
using System.Drawing;
using Helper = Common.Core.Helper;

namespace Venta.Core.Model
{
    public class Producto : Entity<int>
    {
        public string Codigo { get; protected set; }
        public string Descripcion { get; protected set; }
        public byte[] Imagen { get; set; }
        public bool Suelto { get; protected set; }
        public decimal Precio { get; protected set; }
        public int StockActual { get; protected set; }
        public bool Habilitado { get; protected set; }
        public bool Favorito { get; protected set; }
        public bool Borrado { get; protected set; }
        public int? IdCategoria { get; protected set; }
        public Categoria Categoria { get; protected set; }

        internal Producto()
        { }

        public Producto(string codigo, string descripcion, bool suelto, decimal precio, int stockActual, bool habilitado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Suelto = suelto;
            Precio = precio;
            StockActual = stockActual;
            Habilitado = habilitado;
        }

        public Image ObtenerImagen() => Helper.Imagen.ByteArrayToImage(Imagen);

        public void DisminuirStock(int cantidad) => StockActual -= cantidad;

        internal void AumentarStock(int cantidad) => StockActual += cantidad;
    }
}
