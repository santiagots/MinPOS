using FormUI.Componentes;
using FormUI.Formularios.Common;
using Saldo.Core.Enum;
using Saldo.Core.Model;
using Saldo.Data.Service;
using System;
using System.Collections.Generic;

namespace FormUI.Formularios.Saldo
{
    class CajaInicioViewModel : CommonViewModel
    {
        public decimal MontoInicioCaja { get; set; }

        public void AbrirCaja()
        {
            List<Ingresos> ingresos = new List<Ingresos>();
            ingresos.Insert(0, new Ingresos(0, 0, "Inicio de caja", MontoInicioCaja));

            CierreCaja cierreCajaAutomatico = new CierreCaja(0, EstadoCaja.Abierta, DateTime.Now, Sesion.Usuario.Alias, ingresos, null, 0, 0);
            CierreCajaService.Guardar(cierreCajaAutomatico);
        }
    }
}
