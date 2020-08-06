using Saldo.Core.Model;
using Saldo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using Saldo.Core.Validadores;
using Common.Core.Exception;
using System.Linq;
using Common.Core.Enum;

namespace Saldo.Data.Service
{
    public class CajaService
    {
        public static Task<Caja> Obtener(DateTime fecha)
        {
            CajaRepository cierreCajaRepository = new CajaRepository(new Context());
            return cierreCajaRepository.Obtener(fecha);
        }

        public static Task<List<Caja>> Buscar(DateTime fechaDesdes, DateTime fechaHasta, string usuario, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            CajaRepository cierreCajaRepository = new CajaRepository(new Context());
            return cierreCajaRepository.Buscar(fechaDesdes, fechaHasta, usuario, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<Caja>> ObtenerCajaCerradaAbiertas()
        {
            CajaRepository cierreCajaRepository = new CajaRepository(new Context());
            return cierreCajaRepository.ObtenerCajaCerradaAbiertas();
        }

        public static async Task GuardarAsync(Caja cierreCaja)
        {
            CierreCajaValidador validador = new CierreCajaValidador();
            ValidationResult validadorResultado = validador.Validate(cierreCaja);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            CajaRepository cierreCajaRepository = new CajaRepository(new Context());
            await cierreCajaRepository.GuardarAsync(cierreCaja);
        }
    }
}
