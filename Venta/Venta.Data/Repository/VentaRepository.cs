using Common.Core.Enum;
using Common.Core.Extension;
using Common.Core.Model;
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

        internal Task<List<Model.Venta>> Buscar(DateTime fechaDesde, DateTime fechaHasta, FormaPago? formaPago, string usuarioAlta, bool? anulado, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Model.Venta> venta = _context.Venta
                                                    .Include(x => x.Pago)
                                                    .Where(x => DbFunctions.TruncateTime(x.FechaAlta).Value >= fechaDesde.Date &&
                                                                DbFunctions.TruncateTime(x.FechaAlta).Value <= fechaHasta.Date);

            if(formaPago.HasValue)
                venta = venta.Where(x => x.Pago.FormaPago == formaPago.Value);

            if (!string.IsNullOrEmpty(usuarioAlta))
                venta = venta.Where(x => x.UsuarioAlta.Contains(usuarioAlta));

            if (anulado.HasValue)
                venta = venta.Where(x => x.Anulada == anulado.Value);

            return venta.Paginar(ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos).ToListAsync();
        }

        internal async Task Guardar(Core.Model.Venta venta)
        {
            venta.VentaItems.ToList()
                .ForEach(x => {
                    if (x.Producto.Suelto)
                        _context.Entry(x.Producto).State = EntityState.Unchanged;
                    else
                        _context.Entry(x.Producto).State = EntityState.Modified;
                });

            if (venta.Id == 0)
                _context.Venta.Add(venta);
            else
                _context.Entry(venta).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        internal Task<Model.Venta> Obtener(int id) => _context.Venta.Include(x => x.Pago)
                                                                    .Include(x => x.VentaItems.Select(y => y.Producto))
                                                                    .FirstOrDefaultAsync(x => x.Id == id);

        internal List<MovimientoMonto> Saldo(DateTime fecha)
        {
            List<Model.Venta> venta = _context.Venta.Include(x => x.Pago)
                                                    .Where(x => DbFunctions.TruncateTime(x.FechaAlta).Value == fecha.Date)
                                                    .ToList();

            return venta.GroupBy(x => x.Pago.FormaPago)
                            .Select(g => new MovimientoMonto(
                                g.Key,
                                g.Sum(s => s.Pago.Monto))
                            ).ToList();
        }
    }
}
