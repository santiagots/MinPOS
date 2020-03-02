using Producto.Core.Enum;
using Producto.Core.Model;
using System;

namespace FormUI.Formularios.Producto
{
    class MercaderiaListadoItem
    {
        public Mercaderia Mercaderia { get; internal set; }
        public DateTime FechaAlta => Mercaderia.Fecha;
        public DateTime FechaRecepcion => Mercaderia.FechaRecepcion;
        public string Proveedor => Mercaderia.Proveedor.RazonSocial;
        public MercaderiaEstado Estado => Mercaderia.Estado;

        public MercaderiaListadoItem(Mercaderia mercaderia)
        {
            Mercaderia = mercaderia;
        }
    }
}
