using Common.Core.Model;

namespace Gasto.Core.Model.GastoAgreggate
{
    public class TipoGasto : Entity<int>
    {
        public string Descripcion { get; protected set; }
        public bool Habilitada { get; protected set; }
    }
}
