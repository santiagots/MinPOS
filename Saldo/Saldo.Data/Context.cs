using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Modelo = Saldo.Core.Model;

namespace Saldo.Data
{
    public class Context : DbContext
    {
        public Context() : base("Conexion")
        {
            Database.Log = sql => Debug.Write(sql);
            Database.SetInitializer<Context>(null);
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Modelo.CierreCaja> CierreCaja { get; set; }
        public DbSet<Modelo.Egresos> Egresos { get; set; }
        public DbSet<Modelo.Ingresos> Ingresos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Modelo.CierreCaja>().ToTable("CierreCaja");
            modelBuilder.Entity<Modelo.CierreCaja>().HasMany(x => x.Ingresos).WithRequired(x => x.CierreCaja).HasForeignKey(x => x.IdCierreCaja);
            modelBuilder.Entity<Modelo.CierreCaja>().HasMany(x => x.Egresos).WithRequired(x => x.CierreCaja).HasForeignKey(x => x.IdCierreCaja);

            modelBuilder.Entity<Modelo.Egresos>().ToTable("Egresos");

            modelBuilder.Entity<Modelo.Ingresos>().ToTable("Ingresos");
        }
    }
}
