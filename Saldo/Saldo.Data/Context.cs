using Saldo.Data.Migrations;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>()); //Ejecuta la actualizacion de la DB
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Modelo.Caja> CierreCaja { get; set; }
        public DbSet<Modelo.TipoGasto> TipoGasto { get; set; }
        public DbSet<Modelo.Gasto> Gasto { get; set; }
        public DbSet<Modelo.Pago> Pago { get; set; }
        public DbSet<Modelo.Venta> Venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Modelo.Caja>().ToTable("CierreCaja");
            modelBuilder.Entity<Modelo.Caja>().HasMany(x => x.Ventas).WithRequired(x => x.Caja).HasForeignKey(x => x.IdCaja);
            modelBuilder.Entity<Modelo.Caja>().HasMany(x => x.Gastos).WithOptional(x => x.Caja).HasForeignKey(x => x.IdCaja);

            modelBuilder.Entity<Modelo.TipoGasto>().ToTable("TipoGasto");

            modelBuilder.Entity<Modelo.Gasto>().ToTable("Gasto");
            modelBuilder.Entity<Modelo.Gasto>().Property(x => x.IdTipoGasto).HasColumnName("IdTipoGasto");
            modelBuilder.Entity<Modelo.Gasto>().HasOptional(x => x.TipoGasto).WithMany().HasForeignKey(x => x.IdTipoGasto);

            modelBuilder.Entity<Modelo.Pago>().ToTable("Pago");

            modelBuilder.Entity<Modelo.Venta>().ToTable("Venta");
            modelBuilder.Entity<Modelo.Venta>().HasRequired(x => x.Pago).WithMany().HasForeignKey(x => x.IdPago);
        }
    }
}
