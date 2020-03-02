using Common.Core.Exception;
using FormUI.Componentes;
using FormUI.Formularios.Common;
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
        private static Font MESSAGE_BOX_FONT = new Font("Microsoft Sans Serif", 24);

        public string CodigoDescripcion { get; set; }
        public int Cantidad { get; set; } = 1;
        public decimal Total => Productos.Sum(x => x.Total);
        public List<VentaItem> Productos { get; set; } = new List<VentaItem>();
        public string[] CodigosDescripcionesProductos { get; set; }

        internal async Task CargarAutocompletadoAsync()
        {
            CodigosDescripcionesProductos = (await ProductoService.ObtenerCodigos()).ToArray();

            NotifyPropertyChanged(nameof(CodigosDescripcionesProductos));
        }

        internal async Task GuardarAsyn()
        {
            CobroForm cobroForm = new CobroForm(Total);
            if (cobroForm.ShowDialog() == DialogResult.OK)
            {
                ModeloVenta.Pago pago = new ModeloVenta.Pago(cobroForm.FormaPago, Total, cobroForm.MontoPago, 0, 0);

                IList<ModeloVenta.VentaItem> ventaItems = Productos.Select(x => new ModeloVenta.VentaItem(x.Producto, x.Cantidad)).ToList();

                ModeloVenta.Venta venta = new ModeloVenta.Venta(Sesion.Usuario.Alias, ventaItems, pago);
                venta.DisminuirStock();
                await VentaService.Guardar(venta);

                if (pago.Vuelto > 0)
                    CustomMessageBox.ShowDialog($"El vuelto es de {pago.Vuelto}\n\nLa venta se ha guardado de forma correcta.", "Venta", MessageBoxButtons.OK, Enum.CustomMessageBoxIcon.Success, DialogResult.OK, MESSAGE_BOX_FONT, 2000);
                else
                    CustomMessageBox.ShowDialog($"La venta se ha guardado de forma correcta.", "Venta", MessageBoxButtons.OK, Enum.CustomMessageBoxIcon.Success, DialogResult.OK, MESSAGE_BOX_FONT, 2000);

                Productos.Clear();
                NotifyPropertyChanged(nameof(Productos));
            }
        }

        internal async Task AgregarAsync()
        {
            if (string.IsNullOrWhiteSpace(CodigoDescripcion))
                throw new NegocioException(Resources.productoNoExiste);

            ModeloVenta.Producto producto = await ProductoService.Obtener(CodigoDescripcion);
            if (producto == null)
                throw new NegocioException(Resources.productoNoExiste);

            int cantidad = Cantidad > 0 ? Cantidad : 1;

            VentaItem ventaItems = Productos.FirstOrDefault(x => x.Codigo == producto.Codigo);
            if (ventaItems == null)
                Productos.Add(new VentaItem(producto, cantidad));
            else
                ventaItems.Cantidad += cantidad;

            Cantidad = 1;
            CodigoDescripcion = string.Empty;

            NotifyPropertyChanged(nameof(Productos));
        }

        internal void Quitar(VentaItem ventaItems)
        {
            Productos.Remove(ventaItems);
            NotifyPropertyChanged(nameof(Productos));
        }
    }
}
