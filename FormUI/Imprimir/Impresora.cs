using Common.Core.Exception;
using FormUI.Imprimir.Documento;
using FormUI.Properties;
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
            if(!Settings.Default.ImprimirTicket)
                throw new NegocioException("No se puede realizar una impresión porque no se tiene configurada una impresora. Por favor, configure una impresora en la opción de Configuración -> Ticket");
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
            Documento.Imprimir(e.PageBounds, e.Graphics);
        }
    }
}
