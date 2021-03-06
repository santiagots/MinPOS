﻿using System.Drawing;

namespace FormUI.Imprimir.Documento.Elemento
{
    public abstract class Elemento
    {
        public abstract int AnchoImpresion(Rectangle areaImpresion);

        public abstract int AltoImpresion(Graphics graphics, Rectangle areaImpresion, Font fuente);

        public abstract void Dibujar(Graphics graphics, Rectangle areaImpresionElemento, Rectangle areaImpresion, Font fuente);
    }
}
