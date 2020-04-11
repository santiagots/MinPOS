using System.Drawing;

namespace FormUI.Imprimir.Documento.Elemento
{
    public class Imagen: Elemento
    {

        public Image Valor { get; }
        public StringFormat Alineacion { get; }

        public Imagen(Image valor)
        {
            Valor = valor;
        }

        public override int AnchoImpresion(Rectangle areaImpresion)
        {
            return Valor.Width;
        }

        public override int AltoImpresion(Graphics graphics, Rectangle areaImpresion, Font fuente)
        {
            return Valor.Height;
        }

        public override void Dibujar(Graphics graphics, Rectangle areaImpresionElemento, Rectangle areaImpresion, Font fuente)
        {
            int ancho = (areaImpresion.Width - Valor.Width) / 2;
            graphics.DrawImage(Valor, ancho, areaImpresionElemento.Y, Valor.Width, Valor.Height);
        }
    }
}
