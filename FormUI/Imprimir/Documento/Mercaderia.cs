using FormUI.Imprimir.Documento.Elemento;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Modelo = Producto.Core.Model;

namespace FormUI.Imprimir.Documento
{
    public class Mercaderia : DocumentoBase
    {
        public static readonly Font Cabecera1 = new Font("Courier New", 14);
        public static readonly Font Cabecera2 = new Font("Courier New", 11);
        public static readonly Font Cabecera2Negrita = new Font("Courier New", 11, FontStyle.Bold);
        public static readonly Font cuerpo1 = new Font("Courier New", 9);
        public static readonly Font cuerpo1Negrita = new Font("Courier New", 9, FontStyle.Bold);

        public Mercaderia(string NombreFantasia, string Direccion, string Separador, Modelo.Mercaderia mercaderia)
        {
            Texto nombreFantasia = new Texto(NombreFantasia, StringAlignment.Center);
            AgregarLinea(Cabecera1, nombreFantasia);

            Texto direccion = new Texto(Direccion, StringAlignment.Center);
            AgregarLinea(Cabecera2, direccion);

            AgregarLineaSeparador(cuerpo1, Separador);

            Texto titulo = new Texto("Mercadería", StringAlignment.Center);
            AgregarLinea(Cabecera2, titulo);
            Texto proveedor = new Texto($"Prov.: {mercaderia.Proveedor.RazonSocial}", StringAlignment.Center);
            AgregarLinea(Cabecera2, proveedor);

            Texto fecha = new Texto($"Fecha:{mercaderia.Fecha.ToString("dd/MM/yyyy")}", StringAlignment.Near, 0.5f);
            Texto hora = new Texto($"Hora:{mercaderia.Fecha.ToString("HH:mm:ss")}", StringAlignment.Far, 0.5f);
            AgregarLinea(cuerpo1, fecha, hora);

            AgregarLineaSeparador(cuerpo1, Separador);

            IList<(string, string, int)> productos = mercaderia.MercaderiaItems.Select(x => (x.Producto.Codigo, x.Producto.Descripcion, x.Cantidad)).ToList();
            AgregarMovimientos(productos, "Productos");
        }

        private void AgregarMovimientos(IList<(string, string, int)> movimientos, string leyendaGrupo)
        {
            Texto grupo = new Texto(leyendaGrupo, StringAlignment.Center);
            AgregarLinea(Cabecera2, grupo);

            foreach ((string, string, int) movimiento in movimientos)
            {
                Texto codigo = new Texto(movimiento.Item1, StringAlignment.Near, 0.7f);
                Texto cantidad = new Texto(movimiento.Item3.ToString(), StringAlignment.Near, 0.3f);
                AgregarLinea(cuerpo1, codigo, cantidad);

                Texto descripcion = new Texto(movimiento.Item2, StringAlignment.Far);
                AgregarLinea(cuerpo1Negrita, descripcion);
            }
        }
    }
}
