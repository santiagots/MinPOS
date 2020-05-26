using Common.Core.Model;
using System;

namespace Gasto.Core.Model
{
    public class Gasto : Entity<int>
    {
        public DateTime Fecha { get; set; }
        public int? IdTipoGasto { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public decimal Monto { get; set; }
        public bool SaleDeCaja { get; protected set; }
        public string Comentario { get; set; }
        public bool Anulada { get; protected set; }
        public string MotivoAnulada { get; protected set; }
        public DateTime FechaActualizacion { get; protected set; }
        public string UsuarioActualizacion { get; protected set; }

        protected Gasto() { }

        public Gasto(int id, DateTime fecha, TipoGasto tipoGasto, decimal monto, bool saleDeCaja, string comentario, bool anulada, string motivoAnulada, DateTime fechaActualizacion, string usuarioActualizacion)
        {
            Id = id;
            Fecha = fecha;
            IdTipoGasto = tipoGasto?.Id;
            TipoGasto = tipoGasto;
            Monto = monto;
            SaleDeCaja = saleDeCaja;
            Comentario = comentario;
            FechaActualizacion = fechaActualizacion;
            UsuarioActualizacion = usuarioActualizacion;
            Anulada = anulada;
            MotivoAnulada = motivoAnulada;
        }
    }
}
