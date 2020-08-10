namespace Saldo.Data.Migrations
{
    using Common.Data.Extension;
    using System.Data.Entity.Migrations;
    
    public partial class V1050 : DbMigration
    {
        public override void Up()
        {
            if (!this.ExisteColumna("dbo.Venta", "Descuento"))
                AddColumn("dbo.Venta", "Descuento", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venta", "Descuento");
        }
    }
}
