using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Service
{
    public class CommonService
    {
        public static Task InicializarBase()
        {
            return Task.Run(() =>
            {
                Context asas = new Context();
                asas.Database.Initialize(false);
            });
        }
    }
}
