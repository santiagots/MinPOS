using Common.Core.Model;
using System;

namespace Producto.Core.Model
{
    public class Categoria: Entity<int>
    {
        public string Descripcion { get; protected set; }
        public bool Habilitada { get; protected set; }
        public bool Borrado { get; protected set; }

        protected Categoria() { }

        public Categoria(int id, string descripcion, bool habilitada) 
        {
            Id = id;
            Descripcion = descripcion;
            Habilitada = habilitada;
        }

        public void Borrar()
        {
            Borrado = true;
        }
    }
}
