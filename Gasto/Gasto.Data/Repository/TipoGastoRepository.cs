using Common.Data.Repository;
using Gasto.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Gasto.Data.Repository
{
    internal class TipoGastoRepository : BaseRepository<Context>
    {
        internal TipoGastoRepository(Context Context) : base(Context)
        {
        }

        internal async Task Guardar(TipoGasto tipoGasto)
        {
            if (tipoGasto.Id == 0)
                _context.TipoGasto.Add(tipoGasto);
            else
                _context.Entry(tipoGasto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        internal async Task<IList<TipoGasto>> Buscar(string descripcion, bool? habilitado)
        {
            IQueryable<TipoGasto> tipoGasto = _context.TipoGasto.Where(x => !x.Borrado);

            if (!string.IsNullOrWhiteSpace(descripcion))
                tipoGasto = tipoGasto.Where(x => x.Descripcion.Contains(descripcion));

            if (habilitado.HasValue)
                tipoGasto = tipoGasto.Where(x => x.Habilitada == habilitado);

            return await tipoGasto.ToListAsync();
        }
    }
}
