using Common.Core.Model;
using System;

namespace Saldo.Core.Model
{
    public class TipoGasto : Entity<int>
    {
        public string Descripcion { get; protected set; }

        protected TipoGasto() { }
    }
}
