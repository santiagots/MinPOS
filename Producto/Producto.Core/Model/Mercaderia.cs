using Common.Core.Exception;
using Common.Core.Model;
using Producto.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Producto.Core.Model
{
    public class Mercaderia : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int? IdProveedor { get; internal set; }
        public Proveedor Proveedor { get; internal set; }
        public virtual IList<MercaderiaItem> MercaderiaItems { get; internal set; } = new List<MercaderiaItem>();
        public DateTime FechaActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public MercaderiaEstado Estado { get; set; }

        internal Mercaderia()
        { 
        }

        public Mercaderia(string usuarioActualizacion)
        {
            Fecha = DateTime.Now;
            FechaActualizacion = Fecha;
            Estado = MercaderiaEstado.Nuevo;
            UsuarioActualizacion = usuarioActualizacion;
        }

        public void ModificarEstado(MercaderiaEstado estado, string usuarioActualizacion)
        {
            Estado = estado;
            FechaActualizacion = DateTime.Now;
            UsuarioActualizacion = usuarioActualizacion;
        }

        public void ModificarFechaRecepcion(DateTime fechaRecepcion)
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercaderia se encuentra en estado {Estado} no se puede modificar el proveedor.");
            FechaRecepcion = fechaRecepcion;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercaderia se encuentra en estado {Estado} no se puede modificar el proveedor.");
            Proveedor = proveedor;
        }

        public void AgregarProductos(List<Producto> productos)
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercadería se encuentra en estado {Estado} no se puede modificar los productos.");
            productos.ForEach(x => AgregarProducto(x, x.ObtenerFaltente()));
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercadería se encuentra en estado {Estado} no se puede modificar los productos.");

            MercaderiaItem mercaderia = MercaderiaItems.FirstOrDefault(x => x.Producto.Codigo == producto.Codigo);
            if (mercaderia == null)
                MercaderiaItems.Add(new MercaderiaItem(producto, cantidad));
            else
                mercaderia.ModificarCantidad(mercaderia.Cantidad + cantidad);
        }

        public void QuitarProducto(string codigo)
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercadería se encuentra en estado {Estado} no se puede modificar los productos.");

            MercaderiaItems.Remove(MercaderiaItems.FirstOrDefault(x => x.Producto.Codigo == codigo));
        }

        public void LimpiarProducto()
        {
            if (Estado != MercaderiaEstado.Nuevo && Estado != MercaderiaEstado.Guardada) throw new NegocioException($"La mercadería se encuentra en estado {Estado} no se puede modificar los productos.");
            MercaderiaItems.Clear();
        }
    }
}
