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
    public class ProveedorService
    {
        public static Task<IList<Proveedor>> Buscar(string rasonSocial, bool? habilitado)
        {
            ProveedorRepository proveedorRepository = new ProveedorRepository(new Context());
            return proveedorRepository.Buscar(rasonSocial, habilitado);
        }

        public static Task Guardar(Proveedor proveedor)
        {
            ProveedorValidador validador = new ProveedorValidador();
            ValidationResult validadorResultado = validador.Validate(proveedor);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            ProveedorRepository proveedorRepository = new ProveedorRepository(new Context());
            return proveedorRepository.Guardar(proveedor);
        }
    }
}
