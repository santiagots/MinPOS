using Model = Producto.Core.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;

namespace Producto.Data
{
    public class Context : DbContext
    {
        public Context(): base("Conexion")
        {
            Database.Log = sql => Debug.Write(sql);
            Database.SetInitializer<Context>(null);
            var intancia = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<Model.Categoria> Categoria { get; set; }
        public DbSet<Model.Producto> Producto { get; set; }
        public DbSet<Model.Proveedor> Proveedor { get; set; }
        public DbSet<Model.Mercaderia> Mercaderia { get; set; }
        public DbSet<Model.MercaderiaItem> MercaderiaItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Model.Categoria>().ToTable("Categoria");

            modelBuilder.Entity<Model.Mercaderia>().ToTable("Mercaderia");
            modelBuilder.Entity<Model.Mercaderia>().Property(x => x.IdProveedor).HasColumnName("IdProveedor");
            modelBuilder.Entity<Model.Mercaderia>().HasRequired(x => x.Proveedor).WithMany().HasForeignKey(x => x.IdProveedor);

            modelBuilder.Entity<Model.MercaderiaItem>().ToTable("MercaderiaItem");
            modelBuilder.Entity<Model.MercaderiaItem>().Property(x => x.IdProducto).HasColumnName("IdProducto");
            modelBuilder.Entity<Model.MercaderiaItem>().Property(x => x.IdMercaderia).HasColumnName("IdMercaderia");
            modelBuilder.Entity<Model.MercaderiaItem>().HasRequired(x => x.Producto).WithMany().HasForeignKey(x => x.IdProducto);
            modelBuilder.Entity<Model.MercaderiaItem>().HasRequired(x => x.Mercaderia).WithMany(x => x.MercaderiaItems).HasForeignKey(x => x.IdMercaderia);

            modelBuilder.Entity<Model.Producto>().ToTable("Producto");
            modelBuilder.Entity<Model.Producto>().HasMany(x => x.Proveedores).WithMany().Map(m =>
            {
                m.MapLeftKey("ProveedorId");
                m.MapRightKey("ProductoId");
                m.ToTable("ProveedorXProducto");
            });
            modelBuilder.Entity<Model.Producto>().HasRequired(x => x.Categoria).WithMany().HasForeignKey(x => x.IdCategoria);

            modelBuilder.Entity<Model.Proveedor>().ToTable("Proveedor");
        }
    }
}
