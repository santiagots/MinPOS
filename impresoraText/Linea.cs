using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impresoraText
{
    public class Linea
    {
        public Texto[] Textos { get; }
        public Font Fuente { get; }

        public Linea(Texto[] textos, Font fuente)
        {
            Textos = textos;
            Fuente = fuente;
        }
    }

    public class Texto
    {
        public string Valor { get; }
        public StringFormat Alineacion { get; }

        public Texto(string valor, StringAlignment alineacion)
        {
            Valor = valor;
            Alineacion = new StringFormat();
            Alineacion.Alignment = alineacion;
        }
    }

}

