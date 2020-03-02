using Common.Core.Enum;
using Common.Core.Extension;
using Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Venta.Core.Enum;
using Model = Venta.Core.Model;

namespace Venta.Data.Repository
{
    internal class VentaRepository : BaseRepository<Context>
    {
        public VentaRepository(Context context) : base(context)
        {
        }

        internal Task<List<Core.Model.Venta>> Buscar(DateTime fecha, FormaPago? formaPago, bool? anulado, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Model.Venta> venta = _context.Venta
                                                    .Include(x => x.Pago)
                                                    .Where(x => DbFunctions.TruncateTime(x.FechaAlta).Value == fecha.Date);

            if(formaPago.HasValue)
                venta = venta.Where(x => x.Pago.FormaPago == formaPago.Value);

            if(anulado.HasValue)
                venta = venta.Where(x => x.Anulada == anulado.Value);

            return venta.Paginar(ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos).ToListAsync();
        }

        internal async Task Guardar(Core.Model.Venta venta)
        {
            if (venta.Id == 0)
            {
                venta.VentaItems.ToList().ForEach(x => _context.Entry(x.Producto).State = EntityState.Modified);
                _context.Venta.Add(venta);
            }
            else
            {
                venta.VentaItems.ToList().ForEach(x => _context.Entry(x).State = EntityState.Unchanged);
                _context.Entry(venta).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }
    }
}
