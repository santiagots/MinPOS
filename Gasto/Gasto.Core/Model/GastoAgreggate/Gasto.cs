using Common.Core.Model;
using System;

namespace Gasto.Core.Model.GastoAgreggate
{
    public class Gasto : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public int IdTipoGasto { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public decimal Monto { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }

        public Gasto(DateTime fecha, int idTipoGasto, TipoGasto tipoGasto, decimal monto, string comentario, DateTime fechaActualizacion, string usuarioActualizacion)
        {
            Fecha = fecha;
            IdTipoGasto = idTipoGasto;
            TipoGasto = tipoGasto;
            Monto = monto;
            Comentario = comentario;
            FechaActualizacion = fechaActualizacion;
            UsuarioActualizacion = usuarioActualizacion;
        }
    }
}
