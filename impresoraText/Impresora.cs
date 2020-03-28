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
    public class Impresora
    {
        private readonly string Nombre;
        private readonly List<Linea> Lineas;

        public Impresora(string nombre, List<Linea> lineas)
        {
            Nombre = nombre;
            Lineas = lineas;
        }

        public void Imprimir()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrinterSettings.PrinterName = Nombre;
            pdoc.DefaultPageSettings.Landscape = true;

            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = pdoc;
            DialogResult result = pp.ShowDialog();
            if (result == DialogResult.OK)
            {
                pdoc.Print();
            }

            //PrintDocument pdoc = new PrintDocument();
            //pdoc.PrinterSettings.PrinterName = Nombre;
            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //pdoc.Print();
        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            SolidBrush sb = new SolidBrush(Color.Black);
            int Offset = 0;

            foreach (Linea linea in Lineas)
            {
                Rectangle rect = new Rectangle(0, Offset, e.PageBounds.Width, linea.Fuente.Height);
                foreach (Texto texto in linea.Textos)
                {
                    e.Graphics.DrawString(texto.Valor, linea.Fuente, sb, rect, texto.Alineacion);
                }
                Offset += linea.Fuente.Height;
            }
        }
    }
}
