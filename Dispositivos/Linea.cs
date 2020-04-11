using System;
using System.Drawing;
using System.Linq;

namespace Dispositivos
{
    public class Linea
    {
        public Elemento[] Elementos { get; }
        public Font Fuente { get; }

        public Linea(Font fuente, params Elemento[] elementos)
        {
            this.Elementos = elementos;
            Fuente = fuente;
        }

        public int Imprimir(Rectangle areaImpresion, Graphics graphics, int yOffset)
        {
            int xOffset = 0;           
            int altoAreaImpresion = CalcularAltoAreaImpresion(areaImpresion, graphics);

            foreach (Elemento elemento in Elementos)
            {
                int anchoAreaImpresion = elemento.AnchoImpresion(areaImpresion);
                Rectangle areaImpresionElementos = new Rectangle(xOffset, yOffset, anchoAreaImpresion, altoAreaImpresion);

                elemento.Dibujar(graphics, areaImpresionElementos, areaImpresion, Fuente);
               
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
            return Elementos
                .Select(x => x.AltoImpresion(graphics, areaImpresion, Fuente))
                .ToList()
                .Max();
        }
    }
}
