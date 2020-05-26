using Common.Core.Exception;
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
        private int Id  { get; set; }
        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime FechaRecepcion { get; set; } = DateTime.Now;
        public string Usuario { get; set; } = Sesion.Usuario.Alias;
        public KeyValuePair<Modelo.Proveedor, string> ProveedorSeleccionado { get; set; }
        public List<KeyValuePair<Modelo.Proveedor, string>> Proveedores { get; set; } = new List<KeyValuePair<Modelo.Proveedor, string>>();
        public string Codigo { get; set; }
        public int Cantidad { get; set; } = 1;
        public List<MercaderiaDetalleItem> Mercaderias { get; set; } = new List<MercaderiaDetalleItem>();
        public decimal Total => Mercaderias.Sum(x => x.Total);
        public AutoCompleteStringCollection CodigosDescripcionesProductos { get; set; } = new AutoCompleteStringCollection();
        public bool HabilitarProducto => ProveedorSeleccionado.Key != null;
        public bool HabilitarPago => Mercaderias.Count > 0;

        public MercaderiaDetalleViewModel() 
        { }

        public MercaderiaDetalleViewModel(List<Modelo.Producto> productos, Modelo.Proveedor proveedor)
        {
            ProveedorSeleccionado = new KeyValuePair<Proveedor, string>(proveedor, proveedor.RazonSocial);
            productos.ForEach(x =>
            {
                Mercaderias.Add(new MercaderiaDetalleItem(x, x.ObtenerFaltente()));
            });
        }

        public MercaderiaDetalleViewModel(Mercaderia mercaderia)
        {
            Id = mercaderia.Id;
            FechaAlta = mercaderia.Fecha;
            FechaRecepcion = mercaderia.FechaRecepcion;
            Usuario = mercaderia.UsuarioActualizacion;
            ProveedorSeleccionado = new KeyValuePair<Proveedor, string>(mercaderia.Proveedor, mercaderia.Proveedor.RazonSocial);
            mercaderia.MercaderiaItems.ToList().ForEach(x =>
            {
                Mercaderias.Add(new MercaderiaDetalleItem(x));
            });
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

        internal async Task AgregarAsync()
        {
            if(string.IsNullOrWhiteSpace(Codigo))
                throw new NegocioException(Resources.productoNoExiste);

            Modelo.Producto producto = await ProductoService.ObtenerReducido(Codigo);
            if (producto == null)
                throw new NegocioException(Resources.productoNoExiste);

            int cantidad = Cantidad > 0 ? Cantidad : 1;

            MercaderiaDetalleItem mercaderia = Mercaderias.FirstOrDefault(x => x.Codigo == producto.Codigo);
            if (mercaderia == null)
                Mercaderias.Add(new MercaderiaDetalleItem(producto, cantidad));
            else
                mercaderia.Cantidad += cantidad;

            Cantidad = 1;
            Codigo = string.Empty;

            NotifyPropertyChanged(nameof(Mercaderias));
        }

        internal void Borrar(MercaderiaDetalleItem mercaderiaDetalleItem)
        {
                Mercaderias.Remove(mercaderiaDetalleItem);
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
            Mercaderia mercaderia = new Modelo.Mercaderia(Id, FechaAlta, FechaRecepcion, ProveedorSeleccionado.Key, Mercaderias.Select(x => x.MercaderiaItem).ToList(), Usuario, MercaderiaEstado.Guardada);
            await MercaderiaService.Guardar(mercaderia);
        }

        internal async Task IngresarAsync()
        {
            GastoDetalleForm gastoDetalleForm = new GastoDetalleForm(Total, $"Pago ingreso de mercaderia de proveedor {ProveedorSeleccionado.Value}");
            gastoDetalleForm.ShowDialog();

            Mercaderia mercaderia = new Modelo.Mercaderia(Id, FechaAlta, FechaRecepcion, ProveedorSeleccionado.Key, Mercaderias.Select(x => x.MercaderiaItem).ToList(), Usuario, MercaderiaEstado.Ingresada);
            await Task.WhenAll(MercaderiaService.Guardar(mercaderia),
                               MercaderiaService.Ingresar(mercaderia));
        }

        internal void LimpiarGrilla()
        {
            Mercaderias = new List<MercaderiaDetalleItem>();
            NotifyPropertyChanged(nameof(Mercaderias));
        }
    }
}
