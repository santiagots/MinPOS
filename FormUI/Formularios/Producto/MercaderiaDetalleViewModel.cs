using Common.Core.Exception;
using Dispositivos;
using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Formularios.Gasto;
using FormUI.Properties;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo = Producto.Core.Model;

namespace FormUI.Formularios.Producto
{
    class MercaderiaDetalleViewModel : CommonViewModel
    {
        Mercaderia mercaderiaModel = new Mercaderia(Sesion.Usuario.Alias);
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime FechaRecepcion { get; set; } = DateTime.Now;
        public string Usuario { get; set; } = Sesion.Usuario.Alias;
        public string Estado => mercaderiaModel.Estado.ToString();
        public KeyValuePair<Modelo.Proveedor, string> ProveedorSeleccionado { get; set; }
        public List<KeyValuePair<Modelo.Proveedor, string>> Proveedores { get; set; } = new List<KeyValuePair<Modelo.Proveedor, string>>();
        public string Codigo { get; set; }
        public int Cantidad { get; set; } = 1;
        public List<MercaderiaDetalleItem> Mercaderias => mercaderiaModel.MercaderiaItems.Select(x => new MercaderiaDetalleItem(x)).ToList();
        public decimal Total => Mercaderias.Sum(x => x.Total);
        public AutoCompleteStringCollection CodigosDescripcionesProductos { get; set; } = new AutoCompleteStringCollection();
        public bool HabilitarProducto => ProveedorSeleccionado.Key != null;
        public bool HabilitarGuardar => mercaderiaModel.Estado == MercaderiaEstado.Nuevo || mercaderiaModel.Estado == MercaderiaEstado.Guardada;
        public bool HabilitarIngreso => mercaderiaModel.Estado == MercaderiaEstado.Guardada;
        public bool HabilitarPagar => mercaderiaModel.Estado == MercaderiaEstado.Ingresada;

        public MercaderiaDetalleViewModel() 
        { }

        public MercaderiaDetalleViewModel(List<Modelo.Producto> productos, Modelo.Proveedor proveedor)
        {
            mercaderiaModel.AgregarProveedor(proveedor);
            mercaderiaModel.AgregarProductos(productos);
        }

        public MercaderiaDetalleViewModel(Mercaderia mercaderia)
        {
            mercaderiaModel = mercaderia;
            FechaAlta = mercaderia.Fecha;
            FechaRecepcion = mercaderia.FechaRecepcion;
            Usuario = mercaderia.UsuarioActualizacion;
            ProveedorSeleccionado = new KeyValuePair<Proveedor, string>(mercaderia.Proveedor, mercaderia.Proveedor.RazonSocial);
        }

        internal void Actualizar()
        {
            NotifyPropertyChanged(nameof(Total));
        }

        internal async Task CargarAsync()
        {
            await Task.WhenAll(CargarProveedorAsync(), CargarAutocompletadoAsync());
        }

        internal async Task CargarAutocompletadoAsync()
        {
            CodigosDescripcionesProductos.Clear();
            CodigosDescripcionesProductos.AddRange((await ProductoService.ObtenerCodigos(null, ProveedorSeleccionado.Key, null, null)).ToArray());

            NotifyPropertyChanged(nameof(ProveedorSeleccionado));
            NotifyPropertyChanged(nameof(CodigosDescripcionesProductos));
        }

        internal async Task CargarProveedorAsync()
        {
            IList<Modelo.Proveedor> proveedores = await ProveedorService.Buscar(null, true);
            this.Proveedores.AddRange(proveedores.Select(x => new KeyValuePair<Modelo.Proveedor, string>(x, x.RazonSocial)));
            this.Proveedores.Insert(0, new KeyValuePair<Modelo.Proveedor, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(Proveedores));
        }

        internal void ImprimirCaja()
        {
            Imprimir.Documento.Mercaderia mercaderia = new Imprimir.Documento.Mercaderia(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, mercaderiaModel);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, mercaderia);
            impresora.Imprimir();
        }

        internal async Task AgregarProductoAsync()
        {
            if(string.IsNullOrWhiteSpace(Codigo))
                throw new NegocioException(Resources.productoNoExiste);

            Modelo.Producto producto = await ProductoService.ObtenerReducido(Codigo);
            if (producto == null)
                throw new NegocioException(Resources.productoNoExiste);

            int cantidad = Cantidad > 0 ? Cantidad : 1;

            mercaderiaModel.AgregarProducto(producto, cantidad);

            Cantidad = 1;
            Codigo = string.Empty;

            NotifyPropertyChanged(nameof(Mercaderias));
        }

        internal void AgregarProveedor(Proveedor proveedor)
        {
            mercaderiaModel.AgregarProveedor(proveedor);
        }

        internal void Borrar(MercaderiaDetalleItem mercaderiaDetalleItem)
        {
            mercaderiaModel.QuitarProducto(mercaderiaDetalleItem.Codigo);
            NotifyPropertyChanged(nameof(Mercaderias));
        }

        internal async Task ModificarAsync(MercaderiaDetalleItem mercaderiaDetalleItem)
        {
            Modelo.Producto producto = await ProductoService.ObtenerReducido(mercaderiaDetalleItem.Codigo);
            ProductoDetalleForm ProductoDetalleForm = new ProductoDetalleForm(producto);
            ProductoDetalleForm.ShowDialog();

            mercaderiaDetalleItem.MercaderiaItem.ModificarProducto(await ProductoService.Obtener(mercaderiaDetalleItem.Codigo));

            NotifyPropertyChanged(nameof(Mercaderias));
        }

        internal async Task GuardarAsync()
        {
            mercaderiaModel.ModificarEstado(MercaderiaEstado.Guardada, Sesion.Usuario.Alias);
            mercaderiaModel.ModificarFechaRecepcion(FechaRecepcion);
            await MercaderiaService.Guardar(mercaderiaModel);
        }

        internal async Task IngresarAsync()
        {
            mercaderiaModel.ModificarFechaRecepcion(FechaRecepcion);
            mercaderiaModel.ModificarEstado(MercaderiaEstado.Ingresada, Sesion.Usuario.Alias);
            await Task.WhenAll(MercaderiaService.Guardar(mercaderiaModel),
                               MercaderiaService.Ingresar(mercaderiaModel));
        }

        internal async Task<bool> PagarAsync()
        {
            GastoDetalleForm gastoDetalleForm = new GastoDetalleForm(Total, $"Pago ingreso de mercaderia de proveedor {ProveedorSeleccionado.Value}");
            gastoDetalleForm.ShowDialog();
            if (gastoDetalleForm.DialogResult == DialogResult.OK)
            {
                mercaderiaModel.ModificarEstado(MercaderiaEstado.Paga, Sesion.Usuario.Alias);
                await MercaderiaService.Guardar(mercaderiaModel);
                return true;
            }
            return false;
        }

        internal void LimpiarGrilla()
        {
            mercaderiaModel.LimpiarProducto();
            NotifyPropertyChanged(nameof(Mercaderias));
        }
    }
}
