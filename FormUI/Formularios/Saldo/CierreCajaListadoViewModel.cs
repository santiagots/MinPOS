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

namespace FormUI.Formularios.Saldo
{
    class CierreCajaListadoViewModel : CommonViewModel
    {
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime FechaHasta { get; set; } = DateTime.Now;
        public KeyValuePair<ModeloCommon.Usuario, string> UsuarioSeleccionado { get; set; }
        public List<KeyValuePair<ModeloCommon.Usuario, string>> Usuarios { get; set; } = new List<KeyValuePair<ModeloCommon.Usuario, string>>();
        public List<CierreCajaListadoItem> CierreCajaItems { get; set; } = new List<CierreCajaListadoItem>();
        public string OrdenadoPor { get; set; } = "FechaApertura";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; } = DireccionOrdenamiento.Asc;
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }


        internal async Task BuscarAsync()
        {
            CierreCajaItems.Clear();

            int totalElementos = 0;
            List<Caja> ventas = await CajaService.Buscar(FechaDesde, FechaHasta, UsuarioSeleccionado.Key?.Alias, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            ventas.ForEach(x => CierreCajaItems.Add(new CierreCajaListadoItem(x)));
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

        internal void Ver(CierreCajaListadoItem cierreCajaListadoItem)
        {
            ResumenDiarioForm resumenDiarioForm = new ResumenDiarioForm(cierreCajaListadoItem.CierreCaja, null);
            resumenDiarioForm.ShowDialog();
        }
    }
}
