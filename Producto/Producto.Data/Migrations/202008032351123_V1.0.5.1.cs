namespace Producto.Data.Migrations
{
    using Common.Data.Extension;
    using System.Data.Entity.Migrations;

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
