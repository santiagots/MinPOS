﻿using Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Venta.Core.Model
{
    public class Venta : Entity<int>
    {
        public DateTime FechaAlta { get; protected set; }
        public string UsuarioAlta { get; protected set; }
        public IList<VentaItem> VentaItems { get; protected set; }
        public int IdCaja { get; protected set; }
        public int IdPago { get; protected set; }
        public Pago Pago { get; protected set; }
        public decimal SubTotal => VentaItems == null? 0 : VentaItems.Sum(x => x.Total);
        public decimal Descuento { get; protected set; }
        public decimal Total => SubTotal - Descuento;
        public decimal Vuelto => Pago.MontoPago - Total;
        public bool Anulada { get; protected set; }
        public string MotivoAnulada { get; protected set; }
        public DateTime? FechaAnulada { get; protected set; }
        public string UsuarioAnulada { get; protected set; }

        internal Venta()
        { }

        public Venta(string usuario, int idCaja, IList<VentaItem> ventaItems, Pago pago, decimal descuento)
        {
            IdCaja = idCaja;
            FechaAlta = DateTime.Now;
            UsuarioAlta = usuario;
            VentaItems = ventaItems;
            Pago = pago;
            Descuento = descuento;
        }

        public void DisminuirStock() => VentaItems.ToList().ForEach(x => x.DisminuirStock());

        public void Anular(string motivo, string usuario)
        {
            VentaItems.ToList().ForEach(x => x.AumentarStock());

            MotivoAnulada = motivo;
            UsuarioAnulada = usuario;
            FechaAnulada = DateTime.Now;
            Anulada = true;
        }
    }
}
