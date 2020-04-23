using BarcodeLib;
using FormUI.Imprimir.Documento.Elemento;
using System.Drawing;
using Modelo = Producto.Core.Model;

namespace FormUI.Imprimir.Documento
{
    public class EtiquetaGondola : DocumentoBase
    {
        public static readonly Font Cabecera1 = new Font("Courier New", 22, FontStyle.Bold);
        public static readonly Font Cabecera2 = new Font("Courier New", 14, FontStyle.Bold);
        public static readonly Font Cabecera2Negrita = new Font("Courier New", 11, FontStyle.Bold);
        public static readonly Font cuerpo1 = new Font("Courier New", 9);
        public static readonly Font cuerpo1Negrita = new Font("Courier New", 9, FontStyle.Bold);

        public EtiquetaGondola(Modelo.Producto producto)
        {
            Texto nombre = new Texto(producto.Descripcion, StringAlignment.Center);
            AgregarLinea(Cabecera2, nombre);

            Texto precio = new Texto(producto.Precio.ToString("c2"), StringAlignment.Center);
            AgregarLinea(Cabecera1, precio);

            AgregarLineaBlanco(cuerpo1);

            if (!producto.Suelto && long.TryParse(producto.Codigo, out _))
            {
                Barcode barcode = new Barcode();
                barcode.IncludeLabel = true;
                Image img = barcode.Encode(TYPE.EAN13, producto.Codigo, Color.Black, Color.White, 190, 60);
                AgregarImagen(img);
            }
        }
    }
}
