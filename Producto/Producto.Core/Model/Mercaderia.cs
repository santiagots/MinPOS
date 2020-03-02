using Common.Core.Model;
using Producto.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Producto.Core.Model
{
    public class Mercaderia : Entity<int>
    {
        public DateTime Fecha { get; internal set; }
        public DateTime FechaRecepcion { get; internal set; }
        public int? IdProveedor { get; internal set; }
        public Proveedor Proveedor { get; internal set; }
        public IList<MercaderiaItem> MercaderiaItems { get; internal set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }
        public MercaderiaEstado Estado { get; protected set; }
        public decimal TotalCosto => MercaderiaItems.Sum(x => x.TotalCosto);

        public Mercaderia() 
        { }

        public Mercaderia(int id, DateTime fecha, DateTime fechaRecepcion, Proveedor proveedor, IList<MercaderiaItem> mercaderiaItems, string usuarioActualizacion, MercaderiaEstado estado)
        {
            Id = id;
            Fecha = fecha;
            FechaRecepcion = fechaRecepcion;
            IdProveedor = proveedor.Id;
            Proveedor = proveedor;
            FechaActualizacion = DateTime.Now;
            MercaderiaItems = mercaderiaItems;
            UsuarioActualizacion = usuarioActualizacion;
            Estado = estado;
        }

        public void ModificarEstado(MercaderiaEstado estado)
        {
            Estado = estado;
        }
    }
}
