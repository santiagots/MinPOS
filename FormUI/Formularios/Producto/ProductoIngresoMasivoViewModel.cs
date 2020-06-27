using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Producto.Data.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Modelo = Producto.Core.Model;

namespace FormUI.Formularios.Producto
{
    class ProductoIngresoMasivoViewModel : CommonViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public KeyValuePair<Modelo.Categoria, string> CategoriaSeleccionada { get; set; } = new KeyValuePair<Modelo.Categoria, string>(null, string.Empty);
        public List<KeyValuePair<Modelo.Categoria, string>> Categorias { get; set; } = new List<KeyValuePair<Modelo.Categoria, string>>();
        public KeyValuePair<Modelo.Proveedor, string> ProveedorSeleccionada { get; set; } = new KeyValuePair<Modelo.Proveedor, string>(null, string.Empty);
        public List<KeyValuePair<Modelo.Proveedor, string>> Proveedores { get; set; } = new List<KeyValuePair<Modelo.Proveedor, string>>();
        private bool _Suelto;
        public bool Suelto
        {
            get { return _Suelto; }
            set
            {
                _Suelto = value;
                NotifyPropertyChanged(nameof(Suelto));
            }
        }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public int StockMinimo { get; set; }
        public int StockOptimo { get; set; }
        public int StockActual { get; set; }
        public bool Empaquetado => !Suelto;
        public BindingList<ProductoIngresoMasivoItem> ProductosModelo { get; set; } = new BindingList<ProductoIngresoMasivoItem>();

        internal async Task CargarAsync()
        {
            await Task.WhenAll(CargarCategoriaAsync(), CargarProveedorAsync());
        }

        internal void CargarProducto(Modelo.Producto ProductoModel)
        {
            Id = ProductoModel.Id;
            Codigo = ProductoModel.Codigo;
            Descripcion = ProductoModel.Descripcion;

            if(ProductoModel.Categoria != null)
            CategoriaSeleccionada = new KeyValuePair<Modelo.Categoria, string>(ProductoModel.Categoria, ProductoModel.Categoria.Descripcion);

            if (ProductoModel.Proveedores != null)
            {
                Modelo.Proveedor proveedor = ProductoModel.Proveedores.FirstOrDefault();
                if (proveedor != null)
                    ProveedorSeleccionada = new KeyValuePair<Modelo.Proveedor, string>(proveedor, proveedor.RazonSocial);
            }

            _Suelto = ProductoModel.Suelto;
            Costo = ProductoModel.Costo;
            Precio = ProductoModel.Precio;
            StockMinimo = ProductoModel.StockMinimo;
            StockOptimo = ProductoModel.StockOptimo;
            StockActual = ProductoModel.StockActual;

            NotifyPropertyChanged(nameof(Codigo));
        }

        internal async Task CargarProveedorAsync()
        {
            this.Proveedores.Clear();
            IList<Modelo.Proveedor> proveedor = await ProveedorService.Buscar(null, true);
            this.Proveedores.AddRange(proveedor.Select(x => new KeyValuePair<Modelo.Proveedor, string>(x, x.RazonSocial)));
            this.Proveedores.Insert(0, new KeyValuePair<Modelo.Proveedor, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task CargarCategoriaAsync()
        {
            this.Categorias.Clear();
            IList<Modelo.Categoria> categorias = await CategoriaService.Buscar(null, true);
            this.Categorias.AddRange(categorias.Select(x => new KeyValuePair<Modelo.Categoria, string>(x, x.Descripcion)));
            this.Categorias.Insert(0, new KeyValuePair<Modelo.Categoria, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task GuardarAsync()
        {
            List<Modelo.Proveedor> proveedores = ProveedorSeleccionada.Key != null ? new List<Modelo.Proveedor> { ProveedorSeleccionada.Key } : null;

            Modelo.Producto productoModel = new Modelo.Producto(Id, Codigo, Descripcion, CategoriaSeleccionada.Key, proveedores, Suelto, Costo, Precio, true, StockMinimo, StockOptimo, StockActual, Sesion.Usuario.Alias);
            await ProductoService.Guardar(productoModel);

            ActualizarGrillaProdcutos(new ProductoIngresoMasivoItem(productoModel));
        }

        private void ActualizarGrillaProdcutos(ProductoIngresoMasivoItem productoIngresoMasivoItem)
        {
            ProductoIngresoMasivoItem productoEnGrilla = ProductosModelo.FirstOrDefault(x => x.Id == productoIngresoMasivoItem.Id);

            if (productoEnGrilla != null)
            {
                int index = ProductosModelo.IndexOf(productoEnGrilla);
                ProductosModelo[index] = productoIngresoMasivoItem;
            }
            else            
                ProductosModelo.Add(productoIngresoMasivoItem);

            NotifyPropertyChanged(nameof(ProductosModelo));
            Limpiar();
        }

        internal void Limpiar()
        {
            Id = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            CategoriaSeleccionada = new KeyValuePair<Modelo.Categoria, string>(null, string.Empty);
            ProveedorSeleccionada = new KeyValuePair<Modelo.Proveedor, string>(null, string.Empty);
            _Suelto = false;
            Costo = 0;
            Precio = 0;
            StockMinimo = 0;
            StockOptimo = 0;
            StockActual = 0;

            NotifyPropertyChanged(nameof(Codigo));
            NotifyPropertyChanged(nameof(CategoriaSeleccionada));
            NotifyPropertyChanged(nameof(ProveedorSeleccionada));
        }
    }
}
