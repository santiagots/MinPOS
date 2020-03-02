using Common.Core.Enum;
using System.Linq.Dynamic;
using System.Linq;

namespace Common.Data.Repository
{
    public abstract class BaseRepository<T>
    {
        protected readonly T _context;

        public BaseRepository(T context)
        {
            _context = context;
        }

        public IQueryable paginar(IQueryable consulta, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, int totalElementos)
        {
            return consulta
                        .OrderBy($"{ordenadoPor} {direccionOrdenamiento}")
                        .Skip(elementosPorPagina * (pagina - 1))
                        .Take(elementosPorPagina);
        }
    }
}
