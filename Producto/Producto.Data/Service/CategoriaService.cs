using Common.Core.Exception;
using FluentValidation.Results;
using Producto.Core.Model;
using Producto.Core.Validadores;
using Producto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Data.Service
{
    public class CategoriaService
    {
        public static Task<IList<Categoria>> Buscar(string descripcion, bool? habilitado)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(new Context());
            return categoriaRepository.Buscar(descripcion, habilitado);
        }

        public static Task Borrar(Categoria categoria)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(new Context());
            return categoriaRepository.Borrar(categoria);
        }

        public static Task Guardar(Categoria categoria)
        {
            CategoriaValidador validador = new CategoriaValidador();
            ValidationResult validadorResultado = validador.Validate(categoria);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            CategoriaRepository categoriaRepository = new CategoriaRepository(new Context());
            return categoriaRepository.Guardar(categoria);
        }
    }
}
