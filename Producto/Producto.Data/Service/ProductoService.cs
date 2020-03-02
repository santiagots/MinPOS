using Common.Core.Enum;
using Common.Core.Exception;
using FluentValidation.Results;
using Producto.Core.Validadores;
using Producto.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo = Producto.Core.Model;

namespace Producto.Data.Service
{
    public class ProductoService
    {
        public static Task<List<Modelo.Producto>> Buscar(string codigo, Modelo.Categoria categoria, Modelo.Proveedor proveedor, bool? habilitado, bool? faltante, string ordenadoPor, DireccionOrdenamiento direccionOrdenamiento, int pagina, int elementosPorPagina, out int totalElementos)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.Buscar(codigo, categoria, proveedor, habilitado, faltante, ordenadoPor, direccionOrdenamiento, pagina, elementosPorPagina, out totalElementos);
        }

        public static Task<List<string>> ObtenerCodigos(Modelo.Categoria categoria, Modelo.Proveedor proveedor, bool? habilitado, bool? faltante)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerCodigos(categoria, proveedor, habilitado, faltante);
        }

        public static Task<Modelo.Producto> Obtener(string codigo)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.Obtener(codigo);
        }

        public static Task<Modelo.Producto> ObtenerReducido(string codigoDescripcion)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.ObtenerReducido(codigoDescripcion);
        }

        public static Task Borrar(Modelo.Producto producto)
        {
            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.Borrar(producto);
        }

        public static Task Guardar(Modelo.Producto producto)
        {
            ProductoValidador validador = new ProductoValidador();
            ValidationResult validadorResultado = validador.Validate(producto);

            if (!validadorResultado.IsValid)
                throw new NegocioException(string.Join(Environment.NewLine, validadorResultado.Errors.Select(x => x.ErrorMessage)));

            ProductoRepository productoRepository = new ProductoRepository(new Context());
            return productoRepository.Guardar(producto);
        }
    }
}
