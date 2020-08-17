using FormUI.Formularios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using ModeloCommon = Common.Core.Model;
using System.Threading.Tasks;
using Common.Data.Service;
using FormUI.Properties;
using Saldo.Data.Service;
using Saldo.Core.Model;
using Common.Core.Enum;
using Saldo.Core.Enum;
using Common.Core.Extension;
using Common.Core.Exception;

namespace FormUI.Formularios.Saldo
{
    class CajaListadoViewModel : CommonViewModel
    {
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime FechaHasta { get; set; } = DateTime.Now;
        public KeyValuePair<EstadoCaja?, string> EstadoSeleccionado { get; set; }
        public List<KeyValuePair<EstadoCaja?, string>> Estados { get; set; } = new List<KeyValuePair<EstadoCaja?, string>>();
        public KeyValuePair<ModeloCommon.Usuario, string> UsuarioSeleccionado { get; set; }
        public List<KeyValuePair<ModeloCommon.Usuario, string>> Usuarios { get; set; } = new List<KeyValuePair<ModeloCommon.Usuario, string>>();
        public List<CajaListadoItem> CierreCajaItems { get; set; } = new List<CajaListadoItem>();
        public string OrdenadoPor { get; set; } = "FechaApertura";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; } = DireccionOrdenamiento.Asc;
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }


        internal void CargarEstados()
        {
            Estados = Enum<EstadoCaja>.ToKeyValuePairList().ToList();
            Estados.Insert(0, new KeyValuePair<EstadoCaja?, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(Estados));
        }

        internal async Task BuscarAsync()
        {
            CierreCajaItems.Clear();

            int totalElementos = 0;
            List<Caja> ventas = await CajaService.Buscar(FechaDesde, FechaHasta, EstadoSeleccionado.Key, UsuarioSeleccionado.Key?.Alias, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            ventas.ForEach(x => CierreCajaItems.Add(new CajaListadoItem(x)));
            TotalElementos = totalElementos;

            NotifyPropertyChanged(nameof(CierreCajaItems));
            NotifyPropertyChanged(nameof(TotalElementos));
        }

        internal async Task CargarUsuarios()
        {
            List<ModeloCommon.Usuario> usuariosModel = await UsuarioService.Buscar(null, true);

            Usuarios.AddRange(usuariosModel.Select(x => new KeyValuePair<ModeloCommon.Usuario, string>(x, x.Alias)));
            Usuarios.Insert(0, new KeyValuePair<ModeloCommon.Usuario, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(Usuarios));
        }

        internal void Ver(CajaListadoItem cierreCajaListadoItem)
        {
            CajaForm resumenDiarioForm = new CajaForm(cierreCajaListadoItem.CierreCaja);
            resumenDiarioForm.ShowDialog();
        }

        internal async Task AbrirNuevaCajaAsync()
        {
            Caja cajaAbierta = await CajaService.ObtenerCajaAbierta();

            if (cajaAbierta != null) 
                throw new NegocioException(Resources.cajaErrorAlAbrirUnaSegundaCaja);

            CajaForm cajaForm = new CajaForm();
            cajaForm.ShowDialog();
            await BuscarAsync();
        }
    }
}
