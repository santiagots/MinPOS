namespace Saldo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1040 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Egresos", "IdCierreCaja", "dbo.CierreCaja");
            DropForeignKey("dbo.Ingresos", "IdCierreCaja", "dbo.CierreCaja");
            DropIndex("dbo.Egresos", new[] { "IdCierreCaja" });
            DropIndex("dbo.Ingresos", new[] { "IdCierreCaja" });
            DropTable("dbo.Egresos");
            DropTable("dbo.Ingresos");

            AddColumn("dbo.Gasto", "IdCaja", c => c.Int());
            AddColumn("dbo.Venta", "IdCaja", c => c.Int(nullable: false));

            AddForeignKey("dbo.Gasto", "IdCaja", "dbo.CierreCaja", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Venta", "IdCaja", "dbo.CierreCaja", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingresos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCierreCaja = c.Int(nullable: false),
                        ModificaCaja = c.Boolean(nullable: false),
                        Concepto = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Egresos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCierreCaja = c.Int(nullable: false),
                        ModificaCaja = c.Boolean(nullable: false),
                        Concepto = c.String(),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ingresos", "IdCierreCaja");
            CreateIndex("dbo.Egresos", "IdCierreCaja");
            AddForeignKey("dbo.Ingresos", "IdCierreCaja", "dbo.CierreCaja", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Egresos", "IdCierreCaja", "dbo.CierreCaja", "Id", cascadeDelete: true);

            DropColumn("dbo.Gasto", "IdCaja");
            DropColumn("dbo.Venta", "IdCaja");

            DropForeignKey("dbo.Gasto", "IdCaja", "dbo.CierreCaja");
            DropForeignKey("dbo.Venta", "IdCaja", "dbo.CierreCaja");
        }
    }
}
