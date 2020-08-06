using Saldo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Formularios.Saldo
{
    class CierreCajaListadoItem
    {
        public Caja CierreCaja { get; private set; }

        public DateTime FechaApertura => CierreCaja.FechaApertura;
        public DateTime? FechaCierre => CierreCaja.FechaCierre;
        public string UsuarioApertura => CierreCaja.UsuarioApertura;
        public string UsuarioCierre => CierreCaja.UsuarioCierre;
        public decimal Ingresos => CierreCaja.IngresosTotal;
        public decimal Egresos => CierreCaja.EgresosTotal;
        public decimal Saldo => CierreCaja.SaldoTotal;
        public decimal MontoRegistrado => CierreCaja.MontoEnCaja;
        public decimal Diferencia => CierreCaja.Diferencia;

        public CierreCajaListadoItem(Caja cierreCaja)
        {
            CierreCaja = cierreCaja;
        }
    }
}
