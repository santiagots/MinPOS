namespace Venta.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1030 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venta", "Descuento", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venta", "Descuento");
        }
    }
}
