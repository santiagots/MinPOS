﻿using Model = Gasto.Core.Model;
using Gasto.Core.Validadores;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Common.Core.Exception;
using Gasto.Data.Repository;
using System.Collections.Generic;
using Gasto.Core.Model;

namespace Gasto.Data.Service
{
    public class GastoService
    {
        public static Task Guardar(Model.Gasto gasto)
        {
            GastoValidador validador = new GastoValidador();
            ValidationResult validadorResultado = validador.Validate(gasto);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            GastoRepository gastoRepository = new GastoRepository(new Context());
            return gastoRepository.Guardar(gasto);
        }

        public static Task Borrar(TipoGasto tipoGastos)
        {
            throw new NotImplementedException();
        }

        public static Task<List<Model.Gasto>> Buscar(DateTime fechaDesde, DateTime fechaHasta, TipoGasto tipoGasto, string usuario, bool? anulada)
        {
            GastoRepository categoriaRepository = new GastoRepository(new Context());
            return categoriaRepository.Buscar(fechaDesde, fechaHasta, tipoGasto, usuario, anulada);
        }

        public static List<KeyValuePair<string, decimal>> Saldo(DateTime fecha)
        {
            GastoRepository categoriaRepository = new GastoRepository(new Context());
            return categoriaRepository.Saldo(fecha);
        }
    }
}
