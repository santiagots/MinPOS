using Gasto.Core.Model;
using Gasto.Data.Service;
using System.Threading.Tasks;

namespace FormUI.Formularios.Gasto
{
    class GastoTipoDetalleViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitada { get; set; } = true;

        public GastoTipoDetalleViewModel()
        { }

        public GastoTipoDetalleViewModel(TipoGasto tipoGasto)
        {
            Id = tipoGasto.Id;
            Descripcion = tipoGasto.Descripcion;
            Habilitada = tipoGasto.Habilitada;
        }

        internal Task Guardar()
        {
            TipoGasto tipoGasto = new TipoGasto(Id, Descripcion, Habilitada);
            return TipoGastoService.Guardar(tipoGasto);
        }
    }
}
