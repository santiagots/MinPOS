namespace Producto.Data.Migrations
{
    using Common.Data.Extension;
    using System.Data.Entity.Migrations;
    
    public partial class V1060 : DbMigration
    {
        public override void Up()
        {
            if (!this.ExisteColumna("dbo.Producto", "Imagen"))
                AddColumn("dbo.Producto", "Imagen", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Producto", "Imagen");
        }
    }
}
