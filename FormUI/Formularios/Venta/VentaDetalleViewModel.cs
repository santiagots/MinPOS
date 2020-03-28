using System;
using System.Collections.Generic;
using System.Linq;
using Modelo = Venta.Core.Model;

namespace FormUI.Formularios.Venta
{
    class VentaDetalleViewModel
    {
        public DateTime FechaAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public string FormaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal Total => VentaItems.Sum(x => x.Total);
        public List<VentaItem> VentaItems { get; set; } = new List<VentaItem>();
        public string MotivoAnulacion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string UsuarioAnulacion { get; set; }

        public VentaDetalleViewModel(Modelo.Venta venta)
        {
            FechaAlta = venta.FechaAlta;
            UsuarioAlta = venta.UsuarioAlta;
            FormaPago = venta.Pago.FormaPago.ToString();
            MontoPago = venta.Pago.MontoPago;
            venta.VentaItems.ToList().ForEach(x => VentaItems.Add(new VentaItem(x.Producto, x.Cantidad, x.Precio)));
            MotivoAnulacion = venta.MotivoAnulada;
            FechaAnulacion = venta.FechaAnulada;
            UsuarioAnulacion = venta.UsuarioAnulada;
        }
    }
}

