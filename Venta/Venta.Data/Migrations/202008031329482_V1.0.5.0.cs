namespace Venta.Data.Migrations
{
    using Common.Data.Extension;
    using System.Data.Entity.Migrations;

    public partial class V1050 : DbMigration
    {
        public override void Up()
        {
            if (!this.ExisteColumna("dbo.Producto", "Favorito"))
                AddColumn("dbo.Producto", "Favorito", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producto", "Favorito");
        }
    }
}
