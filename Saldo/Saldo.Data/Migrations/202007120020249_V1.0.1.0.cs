namespace Saldo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1010 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CierreCaja", "FechaApertura", c => c.DateTime(nullable: false));
            AddColumn("dbo.CierreCaja", "FechaCierre", c => c.DateTime());
            AddColumn("dbo.CierreCaja", "UsuarioApertura", c => c.String());
            AddColumn("dbo.CierreCaja", "UsuarioCierre", c => c.String());
            AddColumn("dbo.Egresos", "ModificaCaja", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ingresos", "ModificaCaja", c => c.Boolean(nullable: false));
            DropColumn("dbo.CierreCaja", "FechaAlta");
            DropColumn("dbo.CierreCaja", "UsuarioAlta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CierreCaja", "UsuarioAlta", c => c.String());
            AddColumn("dbo.CierreCaja", "FechaAlta", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ingresos", "ModificaCaja");
            DropColumn("dbo.Egresos", "ModificaCaja");
            DropColumn("dbo.CierreCaja", "UsuarioCierre");
            DropColumn("dbo.CierreCaja", "UsuarioApertura");
            DropColumn("dbo.CierreCaja", "FechaCierre");
            DropColumn("dbo.CierreCaja", "FechaApertura");
        }
    }
}
