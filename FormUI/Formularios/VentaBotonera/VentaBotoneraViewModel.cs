using FormUI.Formularios.Common;
using Modelo = Venta.Core.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Model;
using Common.Data.Service;
using Venta.Data.Service;

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
        }

        internal async Task CargarCategoriasAsync()
        {
            IList<Categoria> categorias = await CategoriaService.Buscar(null, true);
            Categorias.AddRange(categorias.Select(x => x.Descripcion));
            NotifyPropertyChanged(nameof(Categorias));
        }
        

        internal async Task CargarProductosAsync(string categoria)
        {
            Productos.Clear();
            IList<string> productosDescripciones = await ProductoService.ObtenerDescripciones(categoria);
            Productos.AddRange(productosDescripciones);
            NotifyPropertyChanged(nameof(Categorias));
        }

        internal void AgregarProducto()
        {
            if (ProductoSeleccionado == null) return;

            VentaBotoneraItem ventaBotoneraItemExistente = VentaBotoneraItem.FirstOrDefault(x => x.Producto == ProductoSeleccionado);
            
            if (ventaBotoneraItemExistente != null)
                ventaBotoneraItemExistente.Cantidad += Cantidad;
            else
                VentaBotoneraItem.Add(new VentaBotoneraItem(ProductoSeleccionado, Cantidad, PrecioUnitario));

            NotifyPropertyChanged(nameof(Total));
            Limpiar();
        }

        internal void Cancelar()
        {
            VentaBotoneraItem.Clear();
            Limpiar();

            NotifyPropertyChanged(nameof(VentaBotoneraItem));
        }

        internal async Task CargarProductoAsync(string productoDescripcion)
        {
            Modelo.Producto productoModel = await ProductoService.Obtener(productoDescripcion);

            if (ProductoSeleccionado != null && ProductoSeleccionado == productoModel)
            {
                Cantidad++;
            }
            else
            {
                ProductoSeleccionado = productoModel;
                Cantidad = 1;
                PrecioUnitario = productoModel.Precio;
            }

            NotifyPropertyChanged(nameof(Subtotal));
        }

        internal void Quitar(VentaBotoneraItem ventaBotoneraItem)
        {
            VentaBotoneraItem.Remove(ventaBotoneraItem);
            NotifyPropertyChanged(nameof(VentaBotoneraItem));
        }

        internal void Limpiar()
        {
            Cantidad = 0;
            PrecioUnitario = 0;
            ProductoSeleccionado = null;

            NotifyPropertyChanged(nameof(ProductoSeleccionado));
        }
    }
}
