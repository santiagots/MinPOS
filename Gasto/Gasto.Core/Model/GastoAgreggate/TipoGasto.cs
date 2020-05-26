using Common.Core.Model;

namespace Gasto.Core.Model
{
    public class TipoGasto : Entity<int>
    {
        public string Descripcion { get; protected set; }
        public bool Habilitada { get; protected set; }
        public bool Borrado { get; protected set; }

        protected TipoGasto() { }

        public TipoGasto(int id, string descripcion, bool habilitada)
        {
            Id = id;
            Descripcion = descripcion;
            Habilitada = habilitada;
        }
    }
}
