using Modelo = Gasto.Core.Model;
using System;

namespace FormUI.Formularios.Gasto
{
    public class GastoListadoItem
    {
        public Modelo.Gasto Gasto { get; internal set; }

        public DateTime Fecha => Gasto.Fecha;
        public string TipoGasto => Gasto.TipoGasto.Descripcion;
        public bool SaleDeCaja => Gasto.SaleDeCaja;
        public decimal Monto => Gasto.Monto;
        public bool Anulada => Gasto.Anulada;
        public DateTime FechaActualizacion => Gasto.FechaActualizacion;
        public string UsuarioActualizacion => Gasto.UsuarioActualizacion;

        public GastoListadoItem(Modelo.Gasto gasto)
        {
            Gasto = gasto;
        }
    }
}
