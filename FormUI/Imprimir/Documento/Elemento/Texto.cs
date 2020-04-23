using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Imprimir.Documento.Elemento
{
    public class Texto: Elemento
    {
        public string Valor { get; }
        public StringFormat Alineacion { get; }
        public float PorcentajeImpresion { get; }

        public Texto(string valor, StringAlignment alineacionEnX, StringAlignment alineacionEnY, float porcentajeEspacio)
        {
            if (PorcentajeImpresion > 0 && PorcentajeImpresion < 1)
                throw new InvalidOperationException("El valor del porcentajeEspacio es incorrecto");

            Valor = valor;
            PorcentajeImpresion = porcentajeEspacio;
            Alineacion = new StringFormat();
            Alineacion.Alignment = alineacionEnX;
            Alineacion.LineAlignment = alineacionEnY;
        }

        public Texto(string valor, StringAlignment alineacionEnX, float porcentajeEspacio): this(valor, alineacionEnX, StringAlignment.Center, porcentajeEspacio)
        {
        }

        public Texto(string valor, StringAlignment alineacion): this(valor, alineacion, 1)
        {
        }

        public override int AnchoImpresion(Rectangle areaImpresion)
        {
            return Convert.ToInt32(areaImpresion.Width * PorcentajeImpresion);
        }

        public override int AltoImpresion(Graphics graphics, Rectangle areaImpresion, Font fuente)
        {
            if (string.IsNullOrWhiteSpace(Valor))
                return fuente.Height;
            else
            {
                int ancho = AnchoImpresion(areaImpresion);
                float anchoLinealDelTexto = graphics.MeasureString(Valor, fuente).Width;

                int renglones = (int)Math.Ceiling(anchoLinealDelTexto / ancho);
                return fuente.Height * renglones;
            }
        }

        public override void Dibujar(Graphics graphics, Rectangle areaImpresionElemento, Rectangle areaImpresion, Font fuente)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            graphics.DrawString(Valor, fuente, sb, areaImpresionElemento, Alineacion);
        }
    }
}
