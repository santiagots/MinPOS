using System;
using System.Drawing;
using System.Linq;

namespace Dispositivos
{
    public class Linea
    {
        private static readonly int MaximoCaracteresPorLinea = 36;

        public Texto[] Textos { get; }
        public Font Fuente { get; }

        public Linea(Font fuente, params Texto[] textos)
        {
            Textos = textos;
            Fuente = fuente;
        }

        internal int Imprimir(Rectangle areaImpresion, Graphics graphics, int yOffset)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            int xOffset = 0;
            
            int altoAreaImpresion = CalcularAltoAreaImpresion(areaImpresion, graphics);

            foreach (Texto texto in Textos)
            {
                int anchoAreaImpresion = CalcularAnchoAreaImpresion(areaImpresion, texto);
                Rectangle rect = new Rectangle(xOffset, yOffset, anchoAreaImpresion, altoAreaImpresion);

                graphics.DrawString(texto.Valor, Fuente, sb, rect, texto.Alineacion);

                xOffset += anchoAreaImpresion;
            }

            return altoAreaImpresion;
        }

        private int CalcularAnchoAreaImpresion(Rectangle areaImpresion, Texto texto)
        {
            return Convert.ToInt32(areaImpresion.Width * texto.PorcentajeImpresion);
        }

        private int CalcularAltoAreaImpresion(Rectangle areaImpresion, Graphics graphics)
        {
            int AltoAreaImpresionMaxima = 0;
            foreach (Texto texto in Textos)
            {
                int anchoAreaImpresion = CalcularAnchoAreaImpresion(areaImpresion, texto);
                float anchoLinealDelTexto = graphics.MeasureString(texto.Valor, Fuente).Width;
                int renglones = (int)Math.Ceiling(anchoLinealDelTexto / anchoAreaImpresion);
                int AltoAreaImpresion = Fuente.Height* renglones;

                if (AltoAreaImpresion > AltoAreaImpresionMaxima)
                    AltoAreaImpresionMaxima = AltoAreaImpresion;
            }
            return AltoAreaImpresionMaxima;
        }
    }
}
