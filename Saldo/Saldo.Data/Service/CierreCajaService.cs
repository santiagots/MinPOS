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
    public class CierreCajaService
    {
        public static Task<CierreCaja> Obtener(DateTime fecha)
        {
            CierreCajaRepository cierreCajaRepository = new CierreCajaRepository(new Context());
            return cierreCajaRepository.Obtener(fecha);
        }

        public static Task<List<CierreCaja>> Buscar(DateTime fechaDesdes, DateTime fechaHasta, string usuario, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            CierreCajaRepository cierreCajaRepository = new CierreCajaRepository(new Context());
            return cierreCajaRepository.Buscar(fechaDesdes, fechaHasta, usuario, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<CierreCaja>> ObtenerCajaCerradaAbiertas()
        {
            CierreCajaRepository cierreCajaRepository = new CierreCajaRepository(new Context());
            return cierreCajaRepository.ObtenerCajaCerradaAbiertas();
        }

        public static void Guardar(CierreCaja cierreCaja)
        {
            CierreCajaValidador validador = new CierreCajaValidador();
            ValidationResult validadorResultado = validador.Validate(cierreCaja);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            CierreCajaRepository cierreCajaRepository = new CierreCajaRepository(new Context());
            cierreCajaRepository.Guardar(cierreCaja);
        }
    }
}
