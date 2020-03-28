using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace impresoraText
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Font cabecera1 = new Font("Courier New", 12);
            Font cabecera2 = new Font("Courier New", 10);
            Font cuerpo1 = new Font("Courier New", 8);
            Font cuerpo2 = new Font("Courier New", 8, FontStyle.Bold);

            List<Linea> lineas = new List<Linea>();

            Texto[] textos = new Texto[2] { new Texto("", StringAlignment.Center), new Texto("", StringAlignment.Center)};

            lineas.Add(
                new Linea(
                    new Texto[1] { new Texto("Azulgrana", StringAlignment.Center) }
                    , cabecera1
                    ));

            lineas.Add(
                new Linea(
                    new Texto[1] { new Texto("Av. Saavedra 299 – Chacabuco", StringAlignment.Center) }
                    , cabecera2
                    ));

            lineas.Add(
                new Linea(
                    new Texto[1] { new Texto("-----------------------------------------", StringAlignment.Center) }
                    , cabecera2
                    ));

            lineas.Add(
                new Linea(
                    new Texto[2] { new Texto("Fecha:01/01/0001", StringAlignment.Near), new Texto("Hora:12:12:12", StringAlignment.Far) }
                    , cabecera2
                    ));

            lineas.Add(
                new Linea(
                    new Texto[2] { new Texto("Producto A", StringAlignment.Near), new Texto("$300,00", StringAlignment.Far) }
                    , cabecera2
                    ));




            //lineas.Add(new Linea("Azulgrana"                                 , cabecera1, StringAlignment.Center));
            //lineas.Add(new Linea("Av. Saavedra 299 – Chacabuco", cabecera2, StringAlignment.Center));
            //lineas.Add(new Linea("-----------------------------------------", cuerpo1, StringAlignment.Center));
            //lineas.Add(new Linea("Comprobante Compra", cabecera2, StringAlignment.Center));
            //lineas.Add(new Linea("(No valido como factura)"                   , cabecera2, StringAlignment.Center));
            //lineas.Add(new Linea("Fecha:01/01/0001            Hora:12:12:12", cuerpo1, StringAlignment.Near));
            //lineas.Add(new Linea("-----------------------------------------", cuerpo1, StringAlignment.Center));
            //lineas.Add(new Linea("1 Uni. X 100"                             , cuerpo1, StringAlignment.Near));
            //lineas.Add(new Linea("Producto A                        $300,00", cuerpo2, StringAlignment.Near));
            //lineas.Add(new Linea("1 Uni. X 100"                             , cuerpo1, StringAlignment.Near));
            //lineas.Add(new Linea("Producto B                        $300,00", cuerpo2, StringAlignment.Near));
            //lineas.Add(new Linea("1 Uni. X 100"                             , cuerpo1, StringAlignment.Near));
            //lineas.Add(new Linea("Producto C                        $300,00", cuerpo2, StringAlignment.Near));
            //lineas.Add(new Linea("Total                             $900,00", cuerpo2, StringAlignment.Near));
            //lineas.Add(new Linea("Gracias por su compra"                    , cuerpo1, StringAlignment.Near));

            Impresora impresora = new Impresora("80mm Series Printer", lineas);

            impresora.Imprimir();
        }
    }
}
