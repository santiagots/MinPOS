using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Enum;
using Common.Core.Exception;
using FluentValidation.Results;
using Venta.Core.Enum;
using Venta.Core.Validadores;
using Venta.Data.Repository;
using Model = Venta.Core.Model;

namespace Venta.Data.Service
{
    public class VentaService
    {
        public static Task<List<Model.Venta>> Buscar(DateTime fecha, FormaPago? formaPago, bool? anulado, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            VentaRepository ventaRepository = new VentaRepository(new Context());
            return ventaRepository.Buscar(fecha, formaPago, anulado, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task Guardar(Model.Venta venta)
        {
            VentaValidador validador = new VentaValidador();
            ValidationResult validadorResultado = validador.Validate(venta);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            VentaRepository ventaRepository = new VentaRepository(new Context());
            return ventaRepository.Guardar(venta);
        }
    }
}
