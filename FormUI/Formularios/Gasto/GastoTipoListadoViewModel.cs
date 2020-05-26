using FormUI.Componentes;
using FormUI.Formularios.Common;
using Gasto.Core.Model;
using Gasto.Data.Service;
using System.Threading.Tasks;

namespace FormUI.Formularios.Gasto
{
    class GastoTipoListadoViewModel : CommonViewModel
    {
        public string Descripcion { get; set; }
        public SortableBindingList<TipoGasto> TipoGastos { get; set; }

        internal async Task BuscarAsync()
        {
            TipoGastos = new SortableBindingList<TipoGasto>(await TipoGastoService.Buscar(Descripcion, null));
            NotifyPropertyChanged(nameof(TipoGastos));
        }

        internal async Task BorrarAsync(TipoGasto tipoGastos)
        {
            await TipoGastoService.Borrar(tipoGastos);
            await BuscarAsync();
        }

        internal async Task NuevoAsync()
        {
            GastoTipoDetalleForm gastoTipoDetalleForm = new GastoTipoDetalleForm();
            gastoTipoDetalleForm.ShowDialog();
            await BuscarAsync();
        }

        internal async Task ModificarAsync(TipoGasto tipoGasto)
        {
            GastoTipoDetalleForm gastoTipoDetalleForm = new GastoTipoDetalleForm(tipoGasto);
            gastoTipoDetalleForm.ShowDialog();
            await BuscarAsync();
        }
    }
}
