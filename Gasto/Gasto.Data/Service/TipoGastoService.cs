using Common.Core.Exception;
using FluentValidation.Results;
using Gasto.Core.Model;
using Gasto.Core.Validadores;
using Gasto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gasto.Data.Service
{
    public class TipoGastoService
    {
        public static Task<IList<TipoGasto>> Buscar(string descripcion, bool? habilitado)
        {
            TipoGastoRepository tipoGastoRepository = new TipoGastoRepository(new Context());
            return tipoGastoRepository.Buscar(descripcion, habilitado);
        }

        public static Task Guardar(TipoGasto tipoGasto)
        {
            TipoGastoValidador validador = new TipoGastoValidador();
            ValidationResult validadorResultado = validador.Validate(tipoGasto);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            TipoGastoRepository tipoGastoRepository = new TipoGastoRepository(new Context());
            return tipoGastoRepository.Guardar(tipoGasto);
        }
    }
}
