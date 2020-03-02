using Common.Core.Model;
using System;
using System.Collections.Generic;

namespace Producto.Core.Model
{
    public class Producto : Entity<int>
    {
        public string Codigo { get; protected set; }
        public string Descripcion { get; protected set; }
        public int? IdCategoria { get; protected set; }
        public Categoria Categoria { get; protected set; }
        public IList<Proveedor> Proveedores { get; protected set; }
        public bool Suelto { get; protected set; }
        public decimal Costo { get; protected set; }
        public decimal Precio { get; protected set; }
        public bool Habilitado { get; protected set; }
        public int StockMinimo { get; protected set; }
        public int StockOptimo { get; protected set; }
        public int StockActual { get; protected set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }

        protected Producto() { }

        public Producto(int id, string codigo, string descripcion, Categoria categoria, IList<Proveedor> proveedor, bool suelto, decimal costo, decimal precio, bool habilitado, int stockMinimo, int stockOptimo, int stockActual, string usuarioActualizacion)
        {
            Id = id;
            Codigo = codigo;
            Descripcion = descripcion;
            IdCategoria = categoria?.Id;
            Categoria = categoria;
            Proveedores = proveedor;
            Suelto = suelto;
            Costo = costo;
            Precio = precio;
            Habilitado = habilitado;
            StockMinimo = stockMinimo;
            StockOptimo = stockOptimo;
            StockActual = stockActual;
            FechaActualizacion = DateTime.Now;
            UsuarioActualizacion = usuarioActualizacion;
        }

        public void AgregarStock(int cantidad) => StockActual += cantidad;

        public int ObtenerFaltente() => StockOptimo - StockActual;

        public bool EnFalta() => StockActual < StockMinimo;
    }
}
