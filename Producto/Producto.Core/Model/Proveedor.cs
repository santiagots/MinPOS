
using Common.Core.Model;

namespace Producto.Core.Model
{
    public class Proveedor : Entity<int>
    {
        public string RazonSocial { get; protected set; }
        public string Direccion { get; protected set; }
        public string Telefono { get; protected set; }
        public string Email { get; protected set; }
        public bool Habilitado { get; protected set; }

        protected Proveedor() { }

        public Proveedor(int id, string razonSocial, string direccion, string telefono, string email, bool habilitado)
        {
            Id = id;
            RazonSocial = razonSocial;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
            Habilitado = habilitado;
        }
    }
}
