using FormUI.Componentes;
using FormUI.Formularios.Common;
using Producto.Core.Model;
using Producto.Data.Service;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    class ProveedorBusquedaViewModel : CommonViewModel
    {
        public string RasonSocial { get; set; }
        public SortableBindingList<Proveedor> Proveedores { get; set; }

        internal async Task BuscarAsync()
        {
            Proveedores = new SortableBindingList<Proveedor>(await ProveedorService.Buscar(RasonSocial, true));
            NotifyPropertyChanged(nameof(Proveedores));
        }
    }
}
