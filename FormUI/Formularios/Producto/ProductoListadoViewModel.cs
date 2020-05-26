using Modelo = Producto.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormUI.Formularios.Common;
using Producto.Data.Service;
using System.Linq;
using FormUI.Properties;
using Common.Core.Enum;
using FormUI.Componentes;

namespace FormUI.Formularios.Producto
{
    class ProductoListadoViewModel : CommonViewModel
    {
        public string Codigo { get; set; }
        public KeyValuePair<Modelo.Categoria, string> CategoriaSeleccionada { get; set; }
        public List<KeyValuePair<Modelo.Categoria, string>> Categorias { get; set; } = new List<KeyValuePair<Modelo.Categoria, string>>();
        public KeyValuePair<Modelo.Proveedor, string> ProveedorSeleccionado { get; set; }
        public List<KeyValuePair<Modelo.Proveedor, string>> Proveedores { get; set; } = new List<KeyValuePair<Modelo.Proveedor, string>>();
        public KeyValuePair<bool?, string> HabilitadoSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> Habilitado { get; set; } = new List<KeyValuePair<bool?, string>>();
        public KeyValuePair<bool?, string> FaltanteSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> Faltante { get; set; } = new List<KeyValuePair<bool?, string>>();
        public List<Modelo.Producto> Productos { get; set; }
        public string OrdenadoPor { get; set; } = "Codigo";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; }
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }
        public bool HabilitarHacerPedido => ProveedorSeleccionado.Key != null;

        public ProductoListadoViewModel()
        {
            Habilitado.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            Habilitado.Add(new KeyValuePair<bool?, string>(true, "Si"));
            Habilitado.Add(new KeyValuePair<bool?, string>(false, "No"));

            Faltante.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            Faltante.Add(new KeyValuePair<bool?, string>(true, "Si"));
            Faltante.Add(new KeyValuePair<bool?, string>(false, "No"));
        }

        internal async Task BuscarAsync()
        {
            int totalElementos = 0;
            Productos = await ProductoService.Buscar(Codigo, CategoriaSeleccionada.Key, ProveedorSeleccionado.Key, HabilitadoSeleccionado.Key, FaltanteSeleccionado.Key, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            TotalElementos = totalElementos;

            NotifyPropertyChanged(nameof(HabilitarHacerPedido));
            NotifyPropertyChanged(nameof(TotalElementos));
            NotifyPropertyChanged(nameof(Productos));
        }

        internal async Task BorrarAsync(Modelo.Producto producto)
        {
            producto.Borrar(Sesion.Usuario.Alias);
            await ProductoService.Guardar(producto);
            await BuscarAsync();
        }

        internal async Task CargarAsync()
        {
            await Task.WhenAll(CargarCategoriaAsync(), CargarProveedorAsync());
        }

        internal async Task CargarCategoriaAsync()
        {
            IList<Modelo.Categoria> categorias = await CategoriaService.Buscar(null, true);
            this.Categorias.AddRange(categorias.Select(x => new KeyValuePair<Modelo.Categoria, string>(x, x.Descripcion)));
            this.Categorias.Insert(0, new KeyValuePair<Modelo.Categoria, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task CargarProveedorAsync()
        {
            IList<Modelo.Proveedor> proveedores = await ProveedorService.Buscar(null, true);
            this.Proveedores.AddRange(proveedores.Select(x => new KeyValuePair<Modelo.Proveedor, string>(x, x.RazonSocial)));
            this.Proveedores.Insert(0, new KeyValuePair<Modelo.Proveedor, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(Proveedores));
        }

        internal async Task NuevoAsync()
        {
            ProductoDetalleForm productoDetalleForm = new ProductoDetalleForm();
            productoDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(Modelo.Producto producto)
        {
            producto = await ProductoService.Obtener(producto.Codigo);
            ProductoDetalleForm ProductoDetalleForm = new ProductoDetalleForm(producto);
            ProductoDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal void HacerPedidoAsync()
        {
            List<Modelo.Producto> productosAPedir = Productos.Where(x => x.EnFalta()).ToList();
            MercaderiaDetalleForm mercaderiaDetalleForm = new MercaderiaDetalleForm(productosAPedir, ProveedorSeleccionado.Key);
            mercaderiaDetalleForm.ShowDialog();
        }
    }
}
