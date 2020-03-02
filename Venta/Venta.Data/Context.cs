using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Model = Venta.Core.Model;

namespace Venta.Data
{
    public class Context : DbContext
    {
        public Context() : base("Conexion")
        {
            Database.Log = sql => Debug.Write(sql);
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Model.Pago> Pago { get; set; }
        public DbSet<Model.Producto> Producto { get; set; }
        public DbSet<Model.Venta> Venta { get; set; }
        public DbSet<Model.VentaItem> VentaItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Model.Pago>().ToTable("Pago");
            modelBuilder.Entity<Model.Pago>().Ignore(x => x.MontoPago);

            modelBuilder.Entity<Model.Producto>().ToTable("Producto");

            modelBuilder.Entity<Model.Venta>().ToTable("Venta");
            modelBuilder.Entity<Model.Venta>().HasRequired(x => x.Pago).WithMany().HasForeignKey(x => x.IdPago);

            modelBuilder.Entity<Model.VentaItem>().ToTable("VentaItem");
            modelBuilder.Entity<Model.VentaItem>().HasRequired<Model.Venta>(x => x.Venta).WithMany(x => x.VentaItems).HasForeignKey(x => x.IdVenta);
            modelBuilder.Entity<Model.VentaItem>().HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.IdProducto);
        }
    }
}
