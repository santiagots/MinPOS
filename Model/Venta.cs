using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Venta
    {
        public DateTime Fecha { get; set; }
        public List<VentaItem> ItemsVenta { get; set; }
        public List<Pago> Pagos { get; set; }
        public bool Anulada { get; set; }
        public bool FechaAnulada { get; set; }
        public string MotivoAnulacion { get; set; }
        public Usuario Usuario { get; set; }
    }
}
