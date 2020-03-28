using Dispositivos.Documento;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Dispositivos
{
    public class Impresora
    {
        private readonly string Nombre;
        private readonly DocumentoBase Documento;

        public Impresora(string nombre, DocumentoBase documento)
        {
            Nombre = nombre;
            Documento = documento;
        }

        public void Imprimir()
        {
#if DEBUG
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrinterSettings.PrinterName = Nombre;

            pdoc.PrintPage += new PrintPageEventHandler(ImprimirPagina);

            PrintPreviewDialog pp = new PrintPreviewDialog();
            pp.Document = pdoc;
            DialogResult result = pp.ShowDialog();
            if (result == DialogResult.OK)
            {
                pdoc.Print();
            }
#else
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrinterSettings.PrinterName = Nombre;
            pdoc.PrintPage += new PrintPageEventHandler(ImprimirPagina);
            pdoc.Print();
#endif
        }
        void ImprimirPagina(object sender, PrintPageEventArgs e)
        {
            int offset = 0;
            foreach (Linea linea in Documento.Lineas)
            {
                offset += linea.Imprimir(e.PageBounds, e.Graphics, offset);
            }
        }
    }
}
