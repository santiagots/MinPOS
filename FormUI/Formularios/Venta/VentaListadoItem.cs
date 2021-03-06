﻿using Model = Venta.Core.Model;
using System;
using Venta.Core.Enum;

namespace FormUI.Formularios.Venta
{
    class VentaListadoItem
    {
        public Model.Venta Venta { get; internal set; }

        public DateTime Fecha => Venta.FechaAlta;
        public FormaPago FormaPago => Venta.Pago.FormaPago;
        public decimal TotalVenta => Venta.Pago.Monto;
        public string UsuarioAlta => Venta.UsuarioAlta;
        public bool Anulada => Venta.Anulada;
        public DateTime? FechaAnulada => Venta.FechaAnulada;

        public VentaListadoItem(Model.Venta venta)
        {
            Venta = venta;
        }
    }
}
