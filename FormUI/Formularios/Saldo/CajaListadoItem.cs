using Saldo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI.Formularios.Saldo
{
    class CajaListadoItem
    {
        public Caja CierreCaja { get; private set; }

        public DateTime FechaApertura => CierreCaja.FechaApertura;
        public DateTime? FechaCierre => CierreCaja.FechaCierre;
        public string Estado => CierreCaja.Estado.ToString();
        public string UsuarioApertura => CierreCaja.UsuarioApertura;
        public string UsuarioCierre => CierreCaja.UsuarioCierre;
        public decimal Ingresos => CierreCaja.IngresosTotal;
        public decimal Egresos => CierreCaja.EgresosTotal;
        public decimal RegistroEnCaja => CierreCaja.RegistroTotal;
        public decimal ContabilizadoEnCaja => CierreCaja.MontoEnCaja;
        public decimal Diferencia => CierreCaja.Diferencia;

        public CajaListadoItem(Caja cierreCaja)
        {
            CierreCaja = cierreCaja;
        }
    }
}
