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
using Dispositivos.Documento;
using Dispositivos;

namespace FormUI.Formularios.Producto
{
    class ProductoDetalleViewModel : CommonViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public KeyValuePair<Modelo.Categoria, string> CategoriaSeleccionada { get; set; }
        public List<KeyValuePair<Modelo.Categoria, string>> Categorias { get; set; } = new List<KeyValuePair<Modelo.Categoria, string>>();
        public List<Modelo.Proveedor> Proveedores { get; set; } = new List<Modelo.Proveedor>();
        public bool Suelto { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public bool Habilitado { get; set; } = true;
        public int  StockMinimo { get; set; }
        public int StockOptimo { get; set; }
        public int StockActual { get; set; }
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
            Proveedores = producto.Proveedores?.ToList();
            Suelto = producto.Suelto;
            Costo = producto.Costo;
            Precio = producto.Precio;
            Habilitado = producto.Habilitado;
            StockMinimo = producto.StockMinimo;
            StockOptimo = producto.StockOptimo;
            StockActual = producto.StockActual;
            UsuarioActualizacion = producto.UsuarioActualizacion;
            FechaActualizacion = producto.FechaActualizacion;

            if (producto.Categoria != null)
                CategoriaSeleccionada = new KeyValuePair<Modelo.Categoria, string>(producto.Categoria, producto.Categoria.Descripcion);
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

        internal void QuitarProveedor(Modelo.Proveedor proveedor)
        {
            Proveedores.Remove(proveedor);
            NotifyPropertyChanged(nameof(Proveedores));
        }

        internal async Task CargarAsync()
        {
            await Task.WhenAll(CargarCategoriaAsync());
        }

        internal async Task CargarCategoriaAsync()
        {
            IList<Modelo.Categoria> categorias = await CategoriaService.Buscar(null);
            this.Categorias.AddRange(categorias.Select(x => new KeyValuePair<Modelo.Categoria, string>(x, x.Descripcion)));
            this.Categorias.Insert(0, new KeyValuePair<Modelo.Categoria, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Categorias));
        }

        internal async Task GuardarAsync()
        {
            Modelo.Producto producto = new Modelo.Producto(Id, Codigo, Descripcion, CategoriaSeleccionada.Key, Proveedores, Suelto, Costo, Precio, Habilitado, StockMinimo, StockOptimo, StockActual, Sesion.Usuario.Alias);
            await ProductoService.Guardar(producto);
        }

        internal void ImprimirEtiqueta()
        {
            Modelo.Producto producto = new Modelo.Producto(Id, Codigo, Descripcion, CategoriaSeleccionada.Key, Proveedores, Suelto, Costo, Precio, Habilitado, StockMinimo, StockOptimo, StockActual, Sesion.Usuario.Alias);
            EtiquetaGondola etiquetaGondola = new EtiquetaGondola(producto);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, etiquetaGondola);
            impresora.Imprimir();
        }
    }
}
