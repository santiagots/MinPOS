using Common.Data.Service;
using FormUI.Formularios.Common;
using FormUI.Properties;
using Gasto.Data.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Modelo = Gasto.Core.Model;
using ModeloCommon = Common.Core.Model;
using System.Windows.Forms;
using Common.Core.Enum;

namespace FormUI.Formularios.Gasto
{
    class GastoListadoViewModel : CommonViewModel
    {
        public DateTime FechaDesde { get; set; } = DateTime.Now.AddDays(-7);
        public DateTime FechaHasta { get; set; } = DateTime.Now;
        public KeyValuePair<Modelo.TipoGasto, string> TipoGastoSeleccionada { get; set; }
        public List<KeyValuePair<Modelo.TipoGasto, string>> TiposGastos { get; set; } = new List<KeyValuePair<Modelo.TipoGasto, string>>();
        public KeyValuePair<ModeloCommon.Usuario, string> UsuarioSeleccionado { get; set; }
        public List<KeyValuePair<ModeloCommon.Usuario, string>> Usuarios { get; set; } = new List<KeyValuePair<ModeloCommon.Usuario, string>>();
        public KeyValuePair<bool?, string> AnuladaSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> Anulada { get; set; } = new List<KeyValuePair<bool?, string>>();
        public KeyValuePair<bool?, string> SaleDeCajaSeleccionado { get; set; }
        public List<KeyValuePair<bool?, string>> SaleDeCaja { get; set; } = new List<KeyValuePair<bool?, string>>();
        public BindingList<GastoListadoItem> Gastos { get; set; } = new BindingList<GastoListadoItem>();
        public string OrdenadoPor { get; set; } = "Fecha";
        public DireccionOrdenamiento DireccionOrdenamiento { get; set; }
        public int PaginaActual { get; set; } = 1;
        public int ElementosPorPagina { get; set; }
        public int TotalElementos { get; set; }

        public GastoListadoViewModel() 
        {
            Anulada.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            Anulada.Add(new KeyValuePair<bool?, string>(true, "Si"));
            Anulada.Add(new KeyValuePair<bool?, string>(false, "No"));

            SaleDeCaja.Add(new KeyValuePair<bool?, string>(null, "Todos"));
            SaleDeCaja.Add(new KeyValuePair<bool?, string>(true, "Si"));
            SaleDeCaja.Add(new KeyValuePair<bool?, string>(false, "No"));
        }

        internal async Task Cargar()
        {
            await Task.WhenAll(CargarUsuarios(), CargarTipoGastoAsync());
        }

        internal async Task CargarUsuarios()
        {
            List<ModeloCommon.Usuario> usuariosModel = await UsuarioService.Buscar(null, true);
            
            Usuarios.AddRange(usuariosModel.Select(x => new KeyValuePair<ModeloCommon.Usuario, string>(x, x.Alias)));
            Usuarios.Insert(0, new KeyValuePair<ModeloCommon.Usuario, string>(null, Resources.comboTodos));

            NotifyPropertyChanged(nameof(Usuarios));
        }

        internal async Task CargarTipoGastoAsync()
        {
            IList<Modelo.TipoGasto> tipoGasto = await TipoGastoService.Buscar(null, true);
            TiposGastos.AddRange(tipoGasto.Select(x => new KeyValuePair<Modelo.TipoGasto, string>(x, x.Descripcion)));
            TiposGastos.Insert(0, new KeyValuePair<Modelo.TipoGasto, string>(null, Resources.comboSeleccionarOpcion));

            NotifyPropertyChanged(nameof(TiposGastos));
        }

        internal async Task NuevoAsync()
        {
            GastoDetalleForm gastoDetalleForm = new GastoDetalleForm();
            gastoDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(GastoListadoItem gastoListadoItem)
        {
            GastoDetalleForm gastoDetalleForm = new GastoDetalleForm(gastoListadoItem.Gasto);
            gastoDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task BuscarAsync()
        {
            int totalElementos = 0;
            Gastos.Clear();

            List<Modelo.Gasto> gastoModel = await GastoService.Buscar(FechaDesde, FechaHasta, TipoGastoSeleccionada.Key, UsuarioSeleccionado.Key?.Alias, AnuladaSeleccionado.Key, SaleDeCajaSeleccionado.Key, OrdenadoPor, DireccionOrdenamiento, PaginaActual, ElementosPorPagina, out totalElementos);
            gastoModel.ForEach(x => Gastos.Add(new GastoListadoItem(x)));

            TotalElementos = totalElementos;
            NotifyPropertyChanged(nameof(gastoModel));
        }
    }
}
