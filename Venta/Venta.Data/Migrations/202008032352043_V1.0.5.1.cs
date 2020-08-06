namespace Venta.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Common.Data.Extension;

    public partial class V1051 : DbMigration
    {
        public override void Up()
        {
            if (this.ExisteColumna("dbo.Producto", "Orden"))
                DropColumn("dbo.Producto", "Orden");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "Orden", c => c.Int(nullable: false));
        }
    }
}
