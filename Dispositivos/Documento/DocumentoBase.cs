using System.Collections.Generic;
using System.Drawing;

namespace Dispositivos.Documento
{
    public abstract class DocumentoBase
    {
        public readonly List<Linea> Lineas = new List<Linea>();

        public void AgregarLinea(Font fuente, params Texto[] textos)
        {
            Linea linea = new Linea(fuente, textos);
            Lineas.Add(linea);
        }

        public void AgregarLineaSeparador(Font fuente, string separador)
        {
            Texto texto = new Texto(separador, StringAlignment.Near);
            Linea linea = new Linea(fuente, texto);
            Lineas.Add(linea);
        }

        public void AgregarLineaBlanco(Font fuente)
        {
            Texto texto = new Texto(" ", StringAlignment.Near);
            Linea linea = new Linea(fuente, texto);
            Lineas.Add(linea);
        }
    }
}
