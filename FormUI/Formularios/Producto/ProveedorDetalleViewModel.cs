using FormUI.Formularios.Common;
using Producto.Core.Model;
using Producto.Data.Service;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    class ProveedorDetalleViewModel : CommonViewModel
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Habilitado { get; set; } = true;

        public ProveedorDetalleViewModel()
        {
        }

        public ProveedorDetalleViewModel(Proveedor proveedor)
        {
            Id = proveedor.Id;
            RazonSocial = proveedor.RazonSocial;
            Direccion = proveedor.Direccion;
            Telefono = proveedor.Telefono;
            Email = proveedor.Email;
            Habilitado = proveedor.Habilitado;
        }

        internal async Task GuardarAsync()
        {
            Proveedor proveedor = new Proveedor(Id, RazonSocial, Direccion, Telefono, Email, Habilitado);
            await ProveedorService.Guardar(proveedor);
        }
    }
}
