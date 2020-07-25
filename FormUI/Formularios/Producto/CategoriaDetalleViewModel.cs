using Common.Core.Model;
using Common.Data.Service;
using System.Threading.Tasks;

namespace FormUI.Formularios.Producto
{
    public class CategoriaDetalleViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitada { get; set; } = true;

        public CategoriaDetalleViewModel()
        { }

        public CategoriaDetalleViewModel(Categoria categoria)
        {
            Id = categoria.Id;
            Descripcion = categoria.Descripcion;
            Habilitada = categoria.Habilitada;
        }

        internal Task Guardar()
        {
            Categoria categoria = new Categoria(Id, Descripcion, Habilitada);
            return CategoriaService.Guardar(categoria);
        }
    }
}
