using Common.Core.Model;
using Saldo.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saldo.Core.Model
{
    public class CierreCaja : Entity<int>
    {
        public DateTime FechaApertura { get; protected set; }
        public DateTime? FechaCierre { get; protected set; }
        public string UsuarioApertura { get; protected set; }
        public string UsuarioCierre { get; protected set; }
        public EstadoCaja Estado { get; protected set; }
        public IList<Ingresos> Ingresos { get; protected set; }
        public decimal IngresosTotal => Ingresos.Sum(x => x.Monto);
        public IList<Egresos> Egresos { get; protected set; }
        public decimal EgresosTotal => Egresos.Sum(x => x.Monto);
        public decimal SaldoTotal => Ingresos.Where(x => x.ModificaCaja).Sum(x => x.Monto) - EgresosTotal;
        public decimal MontoEnCaja { get; protected set; }
        public decimal Diferencia { get; protected set; }

        public CierreCaja()
        {
        }

        public void Cerrar(string usuarioCierre, decimal montoEnCaja)
        {
            Estado = EstadoCaja.Cerrada;
            UsuarioCierre = usuarioCierre;
            FechaCierre = DateTime.Now;
            MontoEnCaja = montoEnCaja;
            Diferencia = SaldoTotal - montoEnCaja;
        }

        public void Abrir(string usuarioApertura)
        {
            Estado = EstadoCaja.Abierta;
            UsuarioCierre = "";
            UsuarioApertura = usuarioApertura;
            FechaApertura = DateTime.Now;
            FechaCierre = null;
            MontoEnCaja = 0;
            Diferencia = 0;
        }

        public void AgregarIngresos(IList<Ingresos> ingresos) => Ingresos = ingresos;

        public void AgregarEgresos(IList<Egresos> egresos) => Egresos = egresos;
    }
}

