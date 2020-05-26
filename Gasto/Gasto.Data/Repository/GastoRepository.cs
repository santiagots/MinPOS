using Modelo = Gasto.Core.Model;
using Common.Data.Repository;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using Gasto.Core.Model;
using System;
using System.Linq;

namespace Gasto.Data.Repository
{
    internal class GastoRepository : BaseRepository<Context>
    {
        internal GastoRepository(Context Context) : base(Context)
        {
        }

        internal async Task Guardar(Modelo.Gasto gasto)
        {
            _context.Entry(gasto.TipoGasto).State = EntityState.Unchanged;

            if (gasto.Id == 0)
                _context.Gasto.Add(gasto);
            else
                _context.Entry(gasto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        internal Task<List<Modelo.Gasto>> Buscar(DateTime fechaDesde, DateTime fechaHasta, TipoGasto tipoGasto, string usuario, bool? anulada)
        {
            IQueryable<Modelo.Gasto> gastos = _context.Gasto
                                                      .Include(x => x.TipoGasto)
                                                      .Where(x => DbFunctions.TruncateTime(x.Fecha).Value >= fechaDesde.Date &&
                                                                  DbFunctions.TruncateTime(x.Fecha).Value <= fechaDesde.Date);

            gastos = gastos;

            if(tipoGasto != null)
                gastos = gastos.Where(x => x.TipoGasto.Id == tipoGasto.Id);

            if (!string.IsNullOrEmpty(usuario))
                gastos = gastos.Where(x => x.UsuarioActualizacion == usuario);

            if(anulada.HasValue)
                gastos = gastos.Where(x => x.Anulada == anulada.Value);

            return gastos.ToListAsync();
        }

        internal List<KeyValuePair<string, decimal>> Saldo(DateTime fecha)
        {
            IQueryable<Modelo.Gasto> gastos = _context.Gasto
                                                    .Where(x => !x.Anulada &&
                                                                x.SaleDeCaja &&
                                                                DbFunctions.TruncateTime(x.Fecha).Value == fecha.Date);

            List<KeyValuePair<string, decimal>> saldo = gastos.GroupBy(x => x.TipoGasto)
                                                                    .AsEnumerable()
                                                                    .Select(g => new KeyValuePair<string, decimal>(
                                                                        g.Key.Descripcion,
                                                                        g.Sum(s => s.Monto))
                                                                    ).ToList();
            return saldo;
        }
    }
}
