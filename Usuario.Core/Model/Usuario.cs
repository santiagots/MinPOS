using Common.Core.Model;

namespace Usuario.Core.Model
{
    public class Usuario : Entity<int>
    {
        public string Alias { get; protected set; }
        public string Nombre { get; protected set; }
        public string Apellido { get; protected set; }
        public string Clave { get; protected set; }
    }
}
