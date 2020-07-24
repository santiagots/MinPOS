using FormUI.Formularios.Common;
using Modelo = Venta.Core.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FormUI.Formularios.VentaBotonera
{
    class VentaBotoneraViewModel: CommonViewModel
    {
        public string nombre { get; set; }
        public List<string> Categorias { get; set; } = new List<string>();
        public List<string> Productos { get; set; } = new List<string>();
        public decimal Total => VentaBotoneraItem.Sum(x => x.Total);
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
        private Modelo.Producto ProductoSeleccionado { get; set; }
        public BindingList<VentaBotoneraItem> VentaBotoneraItem { get; set; } = new BindingList<VentaBotoneraItem>();

        public VentaBotoneraViewModel()
        {
            for (int i = 0; i < 15; i++)
            {
                Categorias.Add($"Categoria {i}");
            }
        }

        internal async Task CargarProductosAsync(string categoria)
        {
            Productos.Clear();
            await Task.Run(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Productos.Add($"Prodcuto {i} [{categoria}]");
                }
            });

            NotifyPropertyChanged(nameof(Productos));
        }

        internal void AgregarProducto()
        {
            if (ProductoSeleccionado == null) return;
            VentaBotoneraItem.Add(new VentaBotoneraItem(ProductoSeleccionado, Cantidad, PrecioUnitario));

            NotifyPropertyChanged(nameof(Total));
        }

        internal async Task CargarProductoAsync(string producto)
        {
            await Task.Run(() =>
            {
                Modelo.Producto productoCargado = BuscarProducto(producto);

                if (ProductoSeleccionado != null && ProductoSeleccionado.Codigo == productoCargado.Codigo)
                {
                    Cantidad++;
                }
                else
                {
                    ProductoSeleccionado = productoCargado;
                    Cantidad = 1;
                    PrecioUnitario = productoCargado.Precio;
                }
            });

            NotifyPropertyChanged(nameof(Subtotal));
        }

        private Modelo.Producto BuscarProducto(string nombreProducto)
        {
            Modelo.Producto producto;

            producto = new Modelo.Producto(nombreProducto, nombreProducto, false, 10, 1, true);

            return producto;
        }
    }
}
