using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivos
{
    public class Texto
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
    }
}
