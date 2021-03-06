/*
   miércoles, 6 de mayo de 202014:41:51
   User: 
   Server: AR-CNU434BG8X
   Database: MiniPOS
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Producto ADD
	Borrado bit NULL,
	FechaBorrado datetime NULL,
	UsuarioBorrado varchar(25) NULL
GO
ALTER TABLE dbo.Producto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Producto', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Producto', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Producto', 'Object', 'CONTROL') as Contr_Per 