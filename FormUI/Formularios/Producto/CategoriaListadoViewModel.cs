using Common.Core.Model;
using Common.Data.Service;
using FormUI.Componentes;
using FormUI.Formularios.Common;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    class CategoriaListadoViewModel: CommonViewModel
    {
        public string Descripcion { get; set; }
        public SortableBindingList<Categoria> Categorias { get; set; }

        internal async Task BuscarAsync()
        {
            Categorias = new SortableBindingList<Categoria>(await CategoriaService.Buscar(Descripcion, null));
            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task BorrarAsync(Categoria categoria)
        {
            categoria.Borrar();
            await CategoriaService.Guardar(categoria);
            await BuscarAsync();
        }

        internal async Task NuevoAsync()
        {
            CategoriaDetalleForm categoriaDetalleForm = new CategoriaDetalleForm();
            categoriaDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(Categoria categoria)
        {
            CategoriaDetalleForm categoriaDetalleForm = new CategoriaDetalleForm(categoria);
            categoriaDetalleForm.ShowDialog();
            await BuscarAsync();
        }
    }
}
