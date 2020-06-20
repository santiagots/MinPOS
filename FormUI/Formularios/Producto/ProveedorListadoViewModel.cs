using FormUI.Componentes;
using FormUI.Formularios.Common;
using Producto.Core.Model;
using Producto.Data.Service;
using System;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    class ProveedorListadoViewModel : CommonViewModel
    {
        public string RasonSocial { get; set; }
        public SortableBindingList<Proveedor> Proveedores { get; set; }

        internal async Task BuscarAsync()
        {
            Proveedores = new SortableBindingList<Proveedor>(await ProveedorService.Buscar(RasonSocial, null));
            NotifyPropertyChanged(nameof(Proveedores));
        }

        internal async Task NuevoAsync()
        {
            ProveedorDetalleForm proveedorDetalleForm = new ProveedorDetalleForm();
            proveedorDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(Proveedor proveedor)
        {
            ProveedorDetalleForm proveedorDetalleForm = new ProveedorDetalleForm(proveedor);
            proveedorDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task BorrarAsync(Proveedor proveedor)
        {
            proveedor.Borrar();
            await ProveedorService.Guardar(proveedor);
            await BuscarAsync();
        }
    }
}
