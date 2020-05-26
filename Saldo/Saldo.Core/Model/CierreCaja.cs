using Common.Core.Model;
using System;
using System.Collections.Generic;

namespace Saldo.Core.Model
{
    public class CierreCaja : Entity<int>
    {
        public DateTime FechaAlta { get; protected set; }
        public string UsuarioAlta { get; protected set; }
        public IList<Ingresos> Ingresos { get; protected set; }
        public IList<Egresos> Egresos { get; protected set; }
        public decimal MontoRegistrado { get; protected set; }
        public decimal Diferencia { get; protected set; }

        internal CierreCaja()
        {
        }

        public CierreCaja(int id, DateTime fechaAlta, string usuarioAlta, IList<Ingresos> ingresos, IList<Egresos> egresos, decimal montoRegistrado, decimal diferencia)
        {
            Id = id;
            FechaAlta = fechaAlta;
            UsuarioAlta = usuarioAlta;
            Ingresos = ingresos;
            Egresos = egresos;
            MontoRegistrado = montoRegistrado;
            Diferencia = diferencia;
        }
    }
}

