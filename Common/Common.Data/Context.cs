using Common.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    class Context : DbContext
    {
        public Context() : base("Conexion")
        {
            Database.Log = sql => Debug.Write(sql);
            Database.SetInitializer<Context>(null);
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }
    }
}
