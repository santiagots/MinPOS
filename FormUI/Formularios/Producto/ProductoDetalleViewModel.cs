using Modelo = Producto.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Producto.Data.Service;
using System.Linq;
using FormUI.Formularios.Common;
using FormUI.Componentes;
using System;
using FormUI.Properties;
using System.Windows.Forms;
using Dispositivos;
using FormUI.Imprimir.Documento;
using Common.Core.Model;
using Common.Data.Service;
using System.Drawing;
using Helper = Common.Core.Helper;

namespace FormUI.Formularios.Producto
{
    class ProductoDetalleViewModel : CommonViewModel
    {
        private int StockMinimoAuxiliar = 0;
        private int StockOptimoAuxiliar = 0;
        private int StockActualAuxiliar = 0;
        private decimal PrecioAuxiliar = 0;

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Image Imagen { get; set; } = Resources.no_foto;
        public KeyValuePair<Categoria, string> CategoriaSeleccionada { get; set; }
        public List<KeyValuePair<Categoria, string>> Categorias { get; set; } = new List<KeyValuePair<Categoria, string>>();
        public List<Modelo.Proveedor> Proveedores { get; set; } = new List<Modelo.Proveedor>();
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
        public bool Habilitado { get; set; } = true;
        public int StockMinimo { get; set; }
        public int StockOptimo { get; set; }
        public int StockActual { get; set; }
        public bool Favorito { get; set; }
        public bool Empaquetado => !Suelto;
        public string UsuarioActualizacion { get; set; } = Sesion.Usuario.Alias;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;

        public ProductoDetalleViewModel()
        {
        }

        public ProductoDetalleViewModel(Modelo.Producto producto)
        {
            Id = producto.Id;
            Codigo = producto.Codigo;
            Descripcion = producto.Descripcion;
            Imagen = producto.ObtenerImagen() ?? Resources.no_foto;
            Proveedores = producto.Proveedores?.ToList();
            Suelto = producto.Suelto;
            Costo = producto.Costo;
            Precio = producto.Precio;
            Habilitado = producto.Habilitado;
            StockMinimo = producto.StockMinimo;
            StockOptimo = producto.StockOptimo;
            StockActual = producto.StockActual;
            Favorito = producto.Favorito;
            UsuarioActualizacion = producto.UsuarioActualizacion;
            FechaActualizacion = producto.FechaActualizacion;

            StockMinimoAuxiliar = StockMinimo;
            StockOptimoAuxiliar = StockOptimo;
            StockActualAuxiliar = StockActual;
            PrecioAuxiliar = Precio;

            if (producto.Categoria != null)
                CategoriaSeleccionada = new KeyValuePair<Categoria, string>(producto.Categoria, producto.Categoria.Descripcion);
        }

        internal void AgregarProveedor()
        {
            ProveedorBusquedaForm proveedorBusquedaForm = new ProveedorBusquedaForm();
            if (proveedorBusquedaForm.ShowDialog() == DialogResult.OK)
            {
                Proveedores.Add(proveedorBusquedaForm.Proveedro);
                NotifyPropertyChanged(nameof(Proveedores));
            }
        }

        internal async Task CargarAsync()
        {
            await Task.WhenAll(CargarCategoriaAsync());
        }

        internal async Task CargarCategoriaAsync()
        {
            IList<Categoria> categorias = await CategoriaService.Buscar(null, true);
            this.Categorias.AddRange(categorias.Select(x => new KeyValuePair<Categoria, string>(x, x.Descripcion)));
            this.Categorias.Insert(0, new KeyValuePair<Categoria, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Categorias));
        }

        internal void AgregarImagen(Image imagen)
        {
            Imagen = Helper.Imagen.Compress(imagen);
            NotifyPropertyChanged(nameof(Imagen));
        }

        internal void CambiarTipoEmpaque()
        {
            if (Suelto)
            {
                StockMinimoAuxiliar = StockMinimo;
                StockOptimoAuxiliar = StockOptimo;
                StockActualAuxiliar = StockActual;
                PrecioAuxiliar = Precio;

                StockMinimo = 0;
                StockOptimo = 0;
                StockActual = 0;
                Precio = 0;
            }
            else
            {
                StockMinimo = StockMinimoAuxiliar;
                StockOptimo = StockOptimoAuxiliar;
                StockActual = StockActualAuxiliar;
                Precio = PrecioAuxiliar;
            }
            NotifyPropertyChanged(nameof(StockMinimo));
            NotifyPropertyChanged(nameof(StockOptimo));
            NotifyPropertyChanged(nameof(StockActual));
            NotifyPropertyChanged(nameof(Precio));
        }

        internal async Task GuardarAsync()
        {
            Modelo.Producto producto = new Modelo.Producto(Id, Codigo, Descripcion, Imagen, CategoriaSeleccionada.Key, Proveedores, Suelto, Costo, Precio, Habilitado, StockMinimo, StockOptimo, StockActual, Favorito, Sesion.Usuario.Alias);
            await ProductoService.Guardar(producto);
        }

        internal void ImprimirEtiqueta()
        {
            Modelo.Producto producto = new Modelo.Producto(Id, Codigo, Descripcion, Imagen, CategoriaSeleccionada.Key, Proveedores, Suelto, Costo, Precio, Habilitado, StockMinimo, StockOptimo, StockActual, Favorito, Sesion.Usuario.Alias);
            EtiquetaGondola etiquetaGondola = new EtiquetaGondola(producto);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, etiquetaGondola);
            impresora.Imprimir();
        }

        internal void QuitarProveedor(Modelo.Proveedor proveedor)
        {
            Proveedores.Remove(proveedor);
            NotifyPropertyChanged(nameof(Proveedores));
        }
    }
}
