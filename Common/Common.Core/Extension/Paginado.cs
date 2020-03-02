using Common.Core.Enum;
using System.Linq.Dynamic;
using System.Linq;

namespace Common.Core.Extension
{
    public static class Paginado
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> consulta, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            totalElementos = consulta.Count();

            return consulta
                        .OrderBy($"{ordenadoPor} {direccionOrdenamiento}")
                        .Skip(elementosPorPagina * (pagina - 1))
                        .Take(elementosPorPagina);
        }
    }
}
