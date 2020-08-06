﻿using FormUI.Imprimir.Documento.Elemento;
using FormUI.Properties;
using System.Drawing;
using System.Linq;
using Venta.Core.Model;
using Modelo = Venta.Core.Model;

namespace FormUI.Imprimir.Documento
{
    public class Ticket : DocumentoBase
    {
        public static readonly Font Cabecera1 = new Font("Courier New", 14);
        public static readonly Font Cabecera2 = new Font("Courier New", 11);
        public static readonly Font Cabecera2Negrita = new Font("Courier New", 11, FontStyle.Bold);
        public static readonly Font cuerpo1 = new Font("Courier New", 9);
        public static readonly Font cuerpo1Negrita = new Font("Courier New", 9, FontStyle.Bold);

        public Ticket(string NombreFantasia, string Direccion, string Separador, string[] Cabecera, string[] pie, Modelo.Venta Venta)
        {
            Titulo(NombreFantasia, Direccion);

            AgregarLineaSeparador(cuerpo1, Separador);

            Encabezado(Cabecera, Venta);

            AgregarLineaSeparador(cuerpo1, Separador);
            AgregarLineaBlanco(cuerpo1);

            Productos(Venta);

            Descuento(Venta);

            AgregarLineaBlanco(cuerpo1);

            Totales(Venta);

            AgregarLineaBlanco(cuerpo1);

            Pie(pie);
        }

        private void Pie(string[] Pie)
        {
            foreach (string cabecera in Pie)
            {
                Texto texto = new Texto(cabecera, StringAlignment.Near);
                AgregarLinea(cuerpo1, texto);
            }
        }

        private void Totales(Modelo.Venta Venta)
        {
            Texto total = new Texto("Total", StringAlignment.Near, 0.5f);
            Texto montoTotal = new Texto(Venta.Total.ToString("c2"), StringAlignment.Far, 0.5f);
            AgregarLinea(Cabecera2Negrita, total, montoTotal);

            AgregarLineaBlanco(cuerpo1);

            Texto pagoLeyenda = new Texto("Su Pago", StringAlignment.Near);
            AgregarLinea(cuerpo1, pagoLeyenda);

            Texto formaPago = new Texto(Venta.Pago.FormaPago.ToString(), StringAlignment.Near, 0.5f);
            Texto montoPago = new Texto(Venta.Pago.MontoPago.ToString("c2"), StringAlignment.Far, 0.5f);
            AgregarLinea(cuerpo1Negrita, formaPago, montoPago);

            AgregarLineaBlanco(cuerpo1);

            Texto vueltoLeyenda = new Texto("Su vuelto", StringAlignment.Near, 0.5f);
            Texto vuelto = new Texto(Venta.Vuelto.ToString("c2"), StringAlignment.Far, 0.5f);
            AgregarLinea(Cabecera2Negrita, vueltoLeyenda, vuelto);
        }

        private void Descuento(Modelo.Venta Venta)
        {
            if (Venta.Descuento > 0)
            {
                Texto descripcion = new Texto(Resources.productoDescuento, StringAlignment.Near, 0.6f);
                Texto monto = new Texto(Venta.Descuento.ToString("c2"), StringAlignment.Far, StringAlignment.Far, 0.4f);
                AgregarLinea(cuerpo1Negrita, descripcion, monto);
            }
        }

        private void Productos(Modelo.Venta Venta)
        {
            foreach (Modelo.VentaItem VentaItem in Venta.VentaItems)
            {
                Texto detalle;
                if (VentaItem.Producto.Suelto)
                    detalle = new Texto($"{VentaItem.Cantidad} Uni. X {VentaItem.Total.ToString("c2")}", StringAlignment.Near);
                else
                    detalle = new Texto($"{VentaItem.Cantidad} Uni. X {VentaItem.Producto.Precio.ToString("c2")}", StringAlignment.Near);
                AgregarLinea(cuerpo1, detalle);

                Texto descripcion = new Texto(VentaItem.Producto.Descripcion, StringAlignment.Near, 0.6f);
                Texto monto = new Texto(VentaItem.Total.ToString("c2"), StringAlignment.Far, StringAlignment.Far, 0.4f);
                AgregarLinea(cuerpo1Negrita, descripcion, monto);
            }
        }

        private void Encabezado(string[] Cabecera, Modelo.Venta Venta)
        {
            foreach (string cabecera in Cabecera)
            {
                Texto texto = new Texto(cabecera, StringAlignment.Center);
                AgregarLinea(Cabecera2, texto);
            }

            Texto fecha = new Texto($"Fecha:{Venta.FechaAlta.ToString("dd/MM/yyyy")}", StringAlignment.Near, 0.5f);
            Texto hora = new Texto($"Hora:{Venta.FechaAlta.ToString("HH:mm:ss")}", StringAlignment.Far, 0.5f);
            AgregarLinea(cuerpo1, fecha, hora);
        }

        private void Titulo(string NombreFantasia, string Direccion)
        {
            Texto nombreFantasia = new Texto(NombreFantasia, StringAlignment.Center);
            AgregarLinea(Cabecera1, nombreFantasia);

            Texto direccion = new Texto(Direccion, StringAlignment.Center);
            AgregarLinea(Cabecera2, direccion);
        }
    }
}
