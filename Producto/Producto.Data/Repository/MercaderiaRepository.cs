using Common.Data.Repository;
using Modelo = Producto.Core.Model;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using Producto.Core.Enum;
using System.Collections.Generic;
using Common.Core.Enum;
using Producto.Core.Model;
using Common.Core.Extension;

namespace Producto.Data.Repository
{
    internal class MercaderiaRepository : BaseRepository<Context>
    {
        public MercaderiaRepository(Context context) : base(context)
        {
        }

        internal async Task Borrar(Mercaderia mercaderia)
        {
            _context.Entry(mercaderia).State = EntityState.Unchanged;
            _context.Mercaderia.Remove(mercaderia);
            await _context.SaveChangesAsync();
        }

        internal Task<List<Mercaderia>> Buscar(DateTime? fechaAltaDesde, DateTime? fechaAltaHasta, DateTime? fechaRecepcionDesde, DateTime? fechaRecepcionHasta, Modelo.Proveedor proveedor, MercaderiaEstado? estado, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Modelo.Mercaderia> mercaderia = _context.Mercaderia.Include(x => x.Proveedor);

            if (fechaAltaDesde.HasValue && fechaAltaHasta.HasValue)
                mercaderia = mercaderia.Where(x => DbFunctions.TruncateTime(x.Fecha) >= DbFunctions.TruncateTime(fechaAltaDesde.Value) &&
                                                   DbFunctions.TruncateTime(x.Fecha) <= DbFunctions.TruncateTime(fechaAltaHasta.Value));

            if (fechaRecepcionDesde.HasValue && fechaRecepcionHasta.HasValue)
                mercaderia = mercaderia.Where(x => DbFunctions.TruncateTime(x.FechaRecepcion) >= DbFunctions.TruncateTime(fechaRecepcionDesde.Value) &&
                                                   DbFunctions.TruncateTime(x.FechaRecepcion) <= DbFunctions.TruncateTime(fechaRecepcionHasta.Value));

            if (proveedor != null)
                mercaderia = mercaderia.Where(x => x.Proveedor.Id == proveedor.Id);

            if (estado.HasValue)
                mercaderia = mercaderia.Where(x => x.Estado == estado.Value);

            totalElementos = mercaderia.Count();

            return mercaderia.Paginar(ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos).ToListAsync();
        }

        internal Task<List<Mercaderia>> DetallPendienteIngreso(DateTime fechaRecepcionDesde, DateTime fechaRecepcionHasta, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            IQueryable<Modelo.Mercaderia> mercaderia = _context.Mercaderia.Include(x => x.Proveedor).Where(x => x.Estado == MercaderiaEstado.Guardada);

            mercaderia = mercaderia.Where(x => DbFunctions.TruncateTime(x.FechaRecepcion) >= DbFunctions.TruncateTime(fechaRecepcionDesde) &&
                                               DbFunctions.TruncateTime(x.FechaRecepcion) <= DbFunctions.TruncateTime(fechaRecepcionHasta));
            totalElementos = mercaderia.Count();

            return mercaderia.Paginar(ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos).ToListAsync();
        }

        internal async Task<int> Ingresar(Modelo.Mercaderia mercaderia)
        {
            Modelo.Mercaderia mercaderaDB = _context.Mercaderia
                                        .FirstOrDefault(x => x.Id == mercaderia.Id);

            mercaderaDB.ModificarEstado(mercaderia.Estado);

            mercaderia.MercaderiaItems.ToList().ForEach(x =>
            {
                Modelo.Producto producto = _context.Producto.FirstOrDefault(y => y.Id == x.Producto.Id);
                producto.AgregarStock(x.Cantidad);
            });

            return await _context.SaveChangesAsync();
        }

        internal async Task<int> Guardar(Modelo.Mercaderia mercaderia)
        {
            if (mercaderia.Id == 0)
            {
                _context.Entry(mercaderia.Proveedor).State = EntityState.Unchanged;
                mercaderia.MercaderiaItems.ToList().ForEach(x => _context.Entry(x.Producto).State = EntityState.Unchanged);

                _context.Mercaderia.Add(mercaderia);
            }
            else
            {
                Modelo.Mercaderia mercaderaDB = await _context.Mercaderia
                    .Include(x => x.MercaderiaItems.Select(y => y.Producto))
                    .FirstOrDefaultAsync(x => x.Id == mercaderia.Id);

                mercaderaDB.Fecha = mercaderia.Fecha;
                mercaderaDB.FechaActualizacion = mercaderia.FechaActualizacion;
                mercaderaDB.UsuarioActualizacion = mercaderia.UsuarioActualizacion;
                mercaderaDB.FechaRecepcion = mercaderia.FechaRecepcion;

                mercaderaDB.MercaderiaItems.ToList().ForEach(mercaderiaItemDB =>
                {
                    Modelo.MercaderiaItem mercaderiaItemLocal = mercaderia.MercaderiaItems.FirstOrDefault(x => x.Producto.Id == mercaderiaItemDB.Producto.Id);
                    if (mercaderiaItemLocal != null)
                        mercaderiaItemDB.ModificarCantidad(mercaderiaItemLocal.Cantidad);
                    else
                        _context.MercaderiaItem.Remove(mercaderiaItemDB);
                });

                mercaderia.MercaderiaItems.Where(x => x.Id == 0).ToList().ForEach(mercaderiaItemLocal =>
                {
                    if (!mercaderaDB.MercaderiaItems.Any(x => x.Producto.Id == mercaderiaItemLocal.Producto.Id))
                    {
                        _context.Entry(mercaderiaItemLocal.Producto).State = EntityState.Unchanged;
                        mercaderaDB.MercaderiaItems.Add(mercaderiaItemLocal);
                    }
                });
            }

            return await _context.SaveChangesAsync();
        }

        internal Task<Modelo.Mercaderia> Obtener(int id) => _context.Mercaderia.Include(x => x.MercaderiaItems.Select(y => y.Producto))
                                                                        .Include(x => x.Proveedor)
                                                                        .FirstOrDefaultAsync(x => x.Id == id);
    }
}
