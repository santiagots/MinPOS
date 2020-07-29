using FormUI.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using Venta.Data.Service;
using Modelo = Venta.Core.Model;

namespace FormUI.Formularios.Venta
{
    class VentaDetalleViewModel
    {
        private Modelo.Venta Venta;
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public string FormaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal CantidadTotal => VentaItems.Sum(x => x.Cantidad);
        public decimal Subtotal => Venta.SubTotal;
        public decimal Descuento => Venta.Descuento;
        public decimal Total => Venta.Total;
        public List<VentaItem> VentaItems { get; set; } = new List<VentaItem>();
        public string MotivoAnulacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string UsuarioAnulacion { get; set; }
        public bool HabilitarAnular => !Venta.Anulada;

        public VentaDetalleViewModel(Modelo.Venta venta)
        {
            Venta = venta;
            FechaAlta = venta.FechaAlta;
            UsuarioAlta = venta.UsuarioAlta;
            FormaPago = venta.Pago.FormaPago.ToString();
            MontoPago = venta.Pago.MontoPago;
            venta.VentaItems.ToList().ForEach(x => VentaItems.Add(new VentaItem(x.Producto, x.Cantidad, x.Precio)));
            MotivoAnulacion = venta.MotivoAnulada;
            FechaAnulacion = venta.FechaAnulada;
            UsuarioAnulacion = venta.UsuarioAnulada;
        }

        internal async System.Threading.Tasks.Task AnularAsync()
        {
            Venta.Anular(MotivoAnulacion, Sesion.Usuario.Nombre);
            await VentaService.Guardar(Venta);
        }
    }
}

