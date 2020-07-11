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
        public CierreCaja CierreCaja { get; private set; }

        public DateTime FechaAlta => CierreCaja.FechaAlta;
        public string UsuarioAlta => CierreCaja.UsuarioAlta;
        public decimal Ingresos => CierreCaja.IngresosTotal;
        public decimal Egresos => CierreCaja.EgresosTotal;
        public decimal Saldo => CierreCaja.SaldoTotal;
        public decimal MontoRegistrado => CierreCaja.MontoEnCaja;
        public decimal Diferencia => CierreCaja.Diferencia;

        public CierreCajaListadoItem(CierreCaja cierreCaja)
        {
            CierreCaja = cierreCaja;
        }
    }
}
