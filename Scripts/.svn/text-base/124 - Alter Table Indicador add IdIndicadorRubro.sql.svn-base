/*
select * from indicador
select * from indicadorRubro
select * from indicadorRelacionRubro
*/

IF NOT EXISTS ( 
SELECT * FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Indicador' AND COLUMN_NAME = 'IdIndicadorRubro' )
BEGIN
	ALTER TABLE [dbo].[Indicador] ADD [IdIndicadorRubro] int NULL
END

GO
