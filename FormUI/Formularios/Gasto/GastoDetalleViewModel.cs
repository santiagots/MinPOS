using FormUI.Componentes;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Gasto.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo = Gasto.Core.Model;

namespace FormUI.Formularios.Gasto
{
    class GastoDetalleViewModel : CommonViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public KeyValuePair<Modelo.TipoGasto, string> TipoGastoSeleccionada { get; set; }
        public List<KeyValuePair<Modelo.TipoGasto, string>> TiposGastos { get; set; } = new List<KeyValuePair<Modelo.TipoGasto, string>>();
        public decimal Monto { get; set; }
        public string Comentario { get; set; }
        public bool SaleDeCaja { get; set; } = true;

        public bool _Anulada;
        public bool Anulada 
        { 
            get { return _Anulada; }
            set { _Anulada = value; NotifyPropertyChanged(nameof(Anulada)); }
        }
        public string MotivoAnulada { get; set; }
        public DateTime FechaActualizacion { get; protected set; } = DateTime.Now;
        public string UsuarioActualizacion { get; protected set; } = Sesion.Usuario.Alias;
        public bool HabilitarAnular => Id > 0;

        public GastoDetalleViewModel()
        {
        }

        public GastoDetalleViewModel(decimal montoGasto, string comentario)
        {
            Monto = montoGasto;
            Comentario = comentario;
        }

        public GastoDetalleViewModel(Modelo.Gasto gasto)
        {
            Id = gasto.Id;
            Fecha = gasto.Fecha;
            Monto = gasto.Monto;
            SaleDeCaja = gasto.SaleDeCaja;
            Comentario = gasto.Comentario;
            FechaActualizacion = gasto.FechaActualizacion;
            UsuarioActualizacion = gasto.UsuarioActualizacion;
            Anulada = gasto.Anulada;
            MotivoAnulada = gasto.MotivoAnulada;

            if (gasto.TipoGasto != null)
                TipoGastoSeleccionada = new KeyValuePair<Modelo.TipoGasto, string>(gasto.TipoGasto, gasto.TipoGasto.Descripcion);
        }

        internal async Task CargarTipoGastoAsync()
        {
            IList<Modelo.TipoGasto> tipoGasto = await TipoGastoService.Buscar(null, true);
            this.TiposGastos.AddRange(tipoGasto.Select(x => new KeyValuePair<Modelo.TipoGasto, string>(x, x.Descripcion)));
            this.TiposGastos.Insert(0, new KeyValuePair<Modelo.TipoGasto, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(TiposGastos));
        }

        internal async Task GuardarAsync()
        {
            Modelo.Gasto gasto = new Modelo.Gasto(Id, Fecha, TipoGastoSeleccionada.Key, Monto, SaleDeCaja, Sesion.Caja.Id, Comentario, Anulada, MotivoAnulada, FechaActualizacion, Sesion.Usuario.Alias);
            await GastoService.Guardar(gasto);
        }
    }
}
