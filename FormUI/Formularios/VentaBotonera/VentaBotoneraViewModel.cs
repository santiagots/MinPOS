using FormUI.Formularios.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace FormUI.Formularios.VentaBotonera
{
    class VentaBotoneraViewModel: CommonViewModel
    {
        public string nombre { get; set; }
        public List<string> Categorias { get; set; } = new List<string>();
        public List<string> Productos { get; set; } = new List<string>();

        public VentaBotoneraViewModel()
        {
            for (int i = 0; i < 15; i++)
            {
                Categorias.Add($"Categoria {i}");
            }
        }

        internal async Task CargarProductosAsync(string categoria)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Productos.Add($"Prodcuto {i} [{categoria}]");
                }
            });

            NotifyPropertyChanged(nameof(Productos));
        }
    }
}
