USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetProyectoTipoIndefinido]') AND type in (N'FN'))
BEGIN

--Remove Unique
ALTER TABLE [dbo].[Proceso] DROP CONSTRAINT [UK_Proceso_Nombre] 

--Unify idproyectotipo (deprecated)
Update Proceso set IdProyectoTipo = (Select IdProyectoTipo from ProyectoTipo where nombre = 'Indefinido')

--Update proceso to new names
Update Proceso set nombre='Ampliación' where nombre like 'Ampliación%' --23
Update Proceso set nombre='Equipamiento básico' where nombre like 'Equipamiento básico%' --5
Update Proceso set nombre='Reposición' where nombre like 'Reposición%'

--Update proyecto to new proceso
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')

--Update proyectocalidad to new proceso
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')

--remove old proceso items
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Ampliación'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Reposición'))

END

--Debo borrar el constraint y volver a generarlo luego de la funcion
if exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proceso'
      and c.name = 'IdProyectoTipo'
      and s.name = 'dbo')
--Si tenemos que borrar la constraint
DECLARE @table_id AS INT
DECLARE @name_column_id AS INT
DECLARE @sql nvarchar(255) 

-- Find table id
SET @table_id = OBJECT_ID('Proceso')

-- Find name column id
SELECT @name_column_id = column_id
FROM sys.columns
WHERE object_id = @table_id
AND name = 'IdProyectoTipo'

-- Remove default constraint from name column
SELECT @sql = 'ALTER TABLE Proceso DROP CONSTRAINT ' + D.name
FROM sys.default_constraints AS D
WHERE D.parent_object_id = @table_id
AND D.parent_column_id = @name_column_id
EXECUTE sp_executesql @sql
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetProyectoTipoIndefinido]') AND type in (N'FN'))
DROP FUNCTION [dbo].[fn_GetProyectoTipoIndefinido]
GO
--Create scalar to get indefinido
CREATE FUNCTION fn_GetProyectoTipoIndefinido ()
RETURNS INT
AS
BEGIN
		Declare @ret int;
    SELECT @ret = (Select idProyectoTipo from ProyectoTipo where nombre='Indefinido')
		return @ret
END

GO

if not exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proceso'
      and c.name = 'IdProyectoTipo'
      and s.name = 'dbo')
--Add default to proceso on proyecto
ALTER TABLE [dbo].[Proceso] ADD DEFAULT ([dbo].[fn_GetProyectoTipoIndefinido]()) FOR [IdProyectoTipo]
GO

--Add comment
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Proceso', 
'COLUMN', N'IdProceso')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'deprecated'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Proceso'
, @level2type = 'COLUMN', @level2name = N'IdProceso'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'deprecated'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Proceso'
, @level2type = 'COLUMN', @level2name = N'IdProceso'
GO

END
