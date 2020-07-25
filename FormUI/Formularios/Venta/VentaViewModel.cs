using Common.Core.Exception;
using Dispositivos;
using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Imprimir.Documento;
using FormUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Venta.Data.Service;
using ModeloVenta = Venta.Core.Model;

namespace FormUI.Formularios.Venta
{
    class VentaViewModel : CommonViewModel
    {
        public string CodigoDescripcion { get; set; }
        public int Cantidad { get; set; } = 1;
        public decimal TotalCantidad => VentaItems.Sum(x => x.Cantidad);
        public decimal Total => VentaItems.Sum(x => x.Total);
        public List<VentaItem> VentaItems { get; set; } = new List<VentaItem>();
        public string[] CodigosDescripcionesProductos { get; set; }

        internal async Task CargarAutocompletadoAsync()
        {
            CodigosDescripcionesProductos = (await ProductoService.ObtenerDescripciones()).ToArray();

            NotifyPropertyChanged(nameof(CodigosDescripcionesProductos));
        }

        internal async Task GuardarAsyn()
        {
            CobroForm cobroForm = new CobroForm(Total);
            if (cobroForm.ShowDialog() == DialogResult.OK)
            {
                ModeloVenta.Pago pago = new ModeloVenta.Pago(cobroForm.FormaPago, Total, cobroForm.MontoPago, 0, 0);

                IList<ModeloVenta.VentaItem> ventaItems = VentaItems.Select(x => new ModeloVenta.VentaItem(x.Producto, x.Cantidad, x.Precio)).ToList();

                ModeloVenta.Venta venta = new ModeloVenta.Venta(Sesion.Usuario.Alias, ventaItems, pago);
                venta.DisminuirStock();
                await VentaService.Guardar(venta);

                Imprimir(venta);

                VueltoForm vueltoForm = new VueltoForm(pago.Vuelto);
                vueltoForm.ShowDialog();

                VentaItems.Clear();
                NotifyPropertyChanged(nameof(VentaItems));
            }
        }

        internal async Task AgregarAsync()
        {
            ModeloVenta.Producto producto = await BuscarProducto();

            bool productoAgregado;
            if (producto.Suelto)
                productoAgregado = AgregarVentaItemSuelto(producto);
            else
                productoAgregado = AgregarVentaItem(producto);

            if (productoAgregado) Inicializar(productoAgregado);

            NotifyPropertyChanged(nameof(VentaItems));
        }

        private void Inicializar(bool productoAgregado)
        {
            Cantidad = 1;
            CodigoDescripcion = string.Empty;
        }

        private async Task<ModeloVenta.Producto> BuscarProducto()
        {
            if (string.IsNullOrWhiteSpace(CodigoDescripcion))
                throw new NegocioException(Resources.productoNoExiste);

            VentaItem ventaItem = VentaItems.Where(x => x.Codigo == CodigoDescripcion || x.Descripcion == CodigoDescripcion).FirstOrDefault();
            if (ventaItem != null) return ventaItem.Producto;

            ModeloVenta.Producto producto = await ProductoService.Obtener(CodigoDescripcion);
            if (producto == null) throw new NegocioException(Resources.productoNoExiste);

            return producto;
        }

        private bool AgregarVentaItem(ModeloVenta.Producto producto)
        {
            int cantidad = Cantidad > 0 ? Cantidad : 1;

            VentaItem ventaItems = VentaItems.FirstOrDefault(x => x.Codigo == producto.Codigo);
            if (ventaItems == null)
                VentaItems.Add(new VentaItem(producto, cantidad, producto.Precio));
            else
                ventaItems.Cantidad += cantidad;

            return true;
        }

        private bool AgregarVentaItemSuelto(ModeloVenta.Producto producto)
        {
            ProductoSueltoForm productoSueltoForm = new ProductoSueltoForm();

            if (productoSueltoForm.ShowDialog() == DialogResult.Cancel) return false;

            decimal montoSuelto = productoSueltoForm.Monto;
            VentaItems.Add(new VentaItem(producto, 1, montoSuelto));

            return true;
        }

        private void Imprimir(ModeloVenta.Venta venta)
        {
            string[] cabeceras = Settings.Default.ComprobanteCompraCabecera.Split(new string[] { "\\n" }, StringSplitOptions.None);
            string[] pie = Settings.Default.ComprobanteCompraPie.Split(new string[] { "\\n" }, StringSplitOptions.None);
            Ticket ticket = new Ticket(Settings.Default.NombreFantasia, Settings.Default.Direccion, Settings.Default.ComprobanteCompraSeparador, cabeceras, pie, venta);

            Impresora impresora = new Impresora(Settings.Default.ImpresoraNombre, ticket);
            impresora.Imprimir();
        }

        internal void Quitar(VentaItem ventaItems)
        {
            VentaItems.Remove(ventaItems);
            NotifyPropertyChanged(nameof(VentaItems));
        }
    }
}
