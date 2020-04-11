using FormUI.Imprimir.Documento.Elemento;
using System.Collections.Generic;
using System.Drawing;

namespace FormUI.Imprimir.Documento
{
    public abstract class DocumentoBase
    {
        internal readonly List<Linea> Lineas = new List<Linea>();

        internal void AgregarLinea(Font fuente, params Texto[] textos)
        {
            Linea linea = new Linea(fuente, textos);
            Lineas.Add(linea);
        }

        internal void AgregarLineaSeparador(Font fuente, string separador)
        {
            Texto texto = new Texto(separador, StringAlignment.Near);
            Linea linea = new Linea(fuente, texto);
            Lineas.Add(linea);
        }

        internal void AgregarLineaBlanco(Font fuente)
        {
            Texto texto = new Texto(" ", StringAlignment.Near);
            Linea linea = new Linea(fuente, texto);
            Lineas.Add(linea);
        }

        internal void AgregarImagen(Image image)
        {
            Imagen imagen = new Imagen(image);
            Linea linea = new Linea(null, imagen);
            Lineas.Add(linea);
        }

        public void Imprimir(Rectangle areaImpresion, Graphics graphics)
        {
            int offset = 0;
            foreach (Linea linea in Lineas)
            {
                offset += linea.Imprimir(areaImpresion, graphics, offset);
            }
        }
    }
}
