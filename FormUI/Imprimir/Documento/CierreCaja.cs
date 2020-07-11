using FormUI.Imprimir.Documento.Elemento;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Modelo = Saldo.Core.Model;

namespace FormUI.Imprimir.Documento
{
    public class CierreCaja : DocumentoBase
    {
        public static readonly Font Cabecera1 = new Font("Courier New", 14);
        public static readonly Font Cabecera2 = new Font("Courier New", 11);
        public static readonly Font Cabecera2Negrita = new Font("Courier New", 11, FontStyle.Bold);
        public static readonly Font cuerpo1 = new Font("Courier New", 9);
        public static readonly Font cuerpo1Negrita = new Font("Courier New", 9, FontStyle.Bold);

        public CierreCaja(string NombreFantasia, string Direccion, string Separador, Modelo.CierreCaja cierreCaja)
        {
            Texto nombreFantasia = new Texto(NombreFantasia, StringAlignment.Center);
            AgregarLinea(Cabecera1, nombreFantasia);

            Texto direccion = new Texto(Direccion, StringAlignment.Center);
            AgregarLinea(Cabecera2, direccion);

            AgregarLineaSeparador(cuerpo1, Separador);

            Texto titulo = new Texto("Cierre Caja", StringAlignment.Center);
            AgregarLinea(Cabecera2, titulo);

            Texto fecha = new Texto($"F. Aper:{cierreCaja.FechaApertura.ToString("dd/MM/yyyy")}", StringAlignment.Near, 0.5f);
            Texto hora = new Texto($"H. Aper:{cierreCaja.FechaApertura.ToString("HH:mm:ss")}", StringAlignment.Far, 0.5f);
            AgregarLinea(cuerpo1, fecha, hora);

            if (cierreCaja.FechaCierre.HasValue)
            {
                fecha = new Texto($"F. Cier.:{cierreCaja.FechaCierre.Value.ToString("dd/MM/yyyy")}", StringAlignment.Near, 0.5f);
                hora = new Texto($"H. Cier.:{cierreCaja.FechaCierre.Value.ToString("HH:mm:ss")}", StringAlignment.Far, 0.5f);
                AgregarLinea(cuerpo1, fecha, hora);
            }
            AgregarLineaSeparador(cuerpo1, Separador);

            IList<(string, decimal)> ingresos = cierreCaja.Ingresos.Select(x => (x.Concepto, x.Monto)).ToList();
            AgregarMovimientos(ingresos, "Ingresos", "SubTotal Ingresos");

            AgregarLineaBlanco(cuerpo1);

            IList<(string, decimal)> egresos = cierreCaja.Egresos.Select(x => (x.Concepto, x.Monto)).ToList();
            AgregarMovimientos(egresos, "Egresos", "SubTotal Egresos");

            AgregarLineaBlanco(cuerpo1);

            decimal MontoTotal = ingresos.Sum(x => x.Item2) - egresos.Sum(x => x.Item2);
            Texto total = new Texto("Total", StringAlignment.Near, 0.5f);
            Texto montoTotal = new Texto(MontoTotal.ToString("c2"), StringAlignment.Far, 0.5f); 
            AgregarLinea(Cabecera2Negrita, total, montoTotal);
        }

        private void AgregarMovimientos(IList<(string, decimal)> movimientos, string leyendaGrupo, string leyendaTotalizado)
        {
            Texto grupo = new Texto(leyendaGrupo, StringAlignment.Center);
            AgregarLinea(Cabecera2, grupo);

            foreach ((string, decimal) movimiento in movimientos)
            {
                Texto descripcion = new Texto(movimiento.Item1, StringAlignment.Near, 0.6f);
                Texto monto = new Texto(movimiento.Item2.ToString("c2"), StringAlignment.Far, StringAlignment.Far, 0.4f);
                AgregarLinea(cuerpo1, descripcion, monto);
            }

            AgregarLineaBlanco(cuerpo1);

            Texto total = new Texto(leyendaTotalizado, StringAlignment.Near, 0.5f);
            Texto montoTotal = new Texto(movimientos.Sum(x => x.Item2).ToString("c2"), StringAlignment.Far, 0.5f);
            AgregarLinea(cuerpo1Negrita, total, montoTotal);
        }
    }
}
