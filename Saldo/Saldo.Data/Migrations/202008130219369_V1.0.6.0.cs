namespace Saldo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1060 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CierreCaja", "Inicio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CierreCaja", "Inicio");
        }
    }
}
