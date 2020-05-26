using Common.Core.Model;
using System;

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

        public void DisminuirStock(int cantidad) => StockActual -= cantidad;

        internal void AumentarStock(int cantidad) => StockActual += cantidad;
    }
}
