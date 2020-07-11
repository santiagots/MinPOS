using Common.Core.Enum;
using Common.Core.Exception;
using Common.Core.Extension;
using Common.Data.Repository;
using Saldo.Core.Enum;
using Saldo.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Saldo.Data.Repository
{
    internal class CierreCajaRepository : BaseRepository<Context>
    {
        internal CierreCajaRepository(Context Context) : base(Context)
        {
        }

        internal Task<CierreCaja> Obtener(DateTime fecha)
        {
            IQueryable<CierreCaja> cierreCaja = ObtenerConsulta();
            cierreCaja = cierreCaja.Where(x => DbFunctions.TruncateTime(x.FechaApertura).Value == DbFunctions.TruncateTime(fecha));

            return cierreCaja.FirstOrDefaultAsync();
        }

        internal Task<List<CierreCaja>> Buscar(DateTime fechaDesde, DateTime fechaHasta, string usuario, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<CierreCaja> cierreCaja = ObtenerConsulta()
                                                    .Where(x => DbFunctions.TruncateTime(x.FechaApertura) >= DbFunctions.TruncateTime(fechaDesde) &&
                                                                DbFunctions.TruncateTime(x.FechaApertura).Value <= DbFunctions.TruncateTime(fechaHasta));
            
            if (!string.IsNullOrEmpty(usuario))
                cierreCaja = cierreCaja.Where(x => x.UsuarioApertura == usuario || x.UsuarioCierre == usuario);

            return cierreCaja.Paginar(ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos).ToListAsync();
        }

        internal Task<List<CierreCaja>> ObtenerCajaCerradaAbiertas()
        {
           return ObtenerConsulta().Where(x => x.Estado == EstadoCaja.Abierta).ToListAsync();
        }

        internal void Guardar(CierreCaja cierreCaja)
        {
            if (cierreCaja.Id == 0)
                _context.CierreCaja.Add(cierreCaja);
            else
                _context.Entry(cierreCaja).State = EntityState.Modified;
            
            _context.SaveChanges();
        }

        private IQueryable<CierreCaja> ObtenerConsulta()
        {
            return _context.CierreCaja
                            .Include(x => x.Ingresos)
                            .Include(x => x.Egresos);
        }
    }
}
