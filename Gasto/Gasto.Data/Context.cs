using Modelo = Gasto.Core.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace Gasto.Data
{
    public class Context : DbContext
    {
        public Context() : base("Conexion")
        {
            Database.Log = sql => Debug.Write(sql);
            Database.SetInitializer<Context>(null);
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Modelo.TipoGasto> TipoGasto { get; set; }
        public DbSet<Modelo.Gasto> Gasto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Modelo.TipoGasto>().ToTable("TipoGasto");

            modelBuilder.Entity<Modelo.Gasto>().ToTable("Gasto");
            modelBuilder.Entity<Modelo.Gasto>().Property(x => x.IdTipoGasto).HasColumnName("IdTipoGasto");
            modelBuilder.Entity<Modelo.Gasto>().HasOptional(x => x.TipoGasto).WithMany().HasForeignKey(x => x.IdTipoGasto);
        }
    }
}
