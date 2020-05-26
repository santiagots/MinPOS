using Common.Core.Enum;
using Common.Core.Exception;
using FluentValidation.Results;
using Producto.Core.Enum;
using Producto.Core.Model;
using Producto.Core.Validadores;
using Producto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Data.Service
{
    public class MercaderiaService
    {
        public static Task<List<Mercaderia>> Buscar(DateTime? fechaAltaDesde, DateTime? fechaAltaHasta, DateTime? fechaRecepcionDesde, DateTime? fechaRecepcionHasta, Proveedor proveedor, MercaderiaEstado? estado, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.Buscar(fechaAltaDesde, fechaAltaHasta, fechaRecepcionDesde, fechaRecepcionHasta, proveedor, estado, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<Mercaderia>> DetallPendienteIngreso(DateTime fechaRecepcionDesde, DateTime fechaRecepcionHasta, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.DetallPendienteIngreso(fechaRecepcionDesde, fechaRecepcionHasta, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task Borrar(Mercaderia mercaderia)
        {
            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.Borrar(mercaderia);
        }

        public static Task Guardar(Mercaderia mercaderia)
        {
            Validar(mercaderia);

            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.Guardar(mercaderia);
        }

        public static Task Ingresar(Mercaderia mercaderia)
        {
            Validar(mercaderia);

            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.Ingresar(mercaderia);                                
        }

        public static Task<Mercaderia> Obtener(int id)
        {
            MercaderiaRepository mercaderiaRepository = new MercaderiaRepository(new Context());
            return mercaderiaRepository.Obtener(id);
        }

        private static void Validar(Mercaderia mercaderia)
        {
            MercaderiaValidador validador = new MercaderiaValidador();
            ValidationResult validadorResultado = validador.Validate(mercaderia);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));
        }

    }
}
