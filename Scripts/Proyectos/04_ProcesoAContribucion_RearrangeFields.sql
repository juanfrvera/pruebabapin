USE [BAPIN]
GO

--Remove Unique
ALTER TABLE [dbo].[Proceso] DROP CONSTRAINT [UK_Proceso_Nombre] 
GO

--Unify idproyectotipo (deprecated)
Update Proceso set IdProyectoTipo = (Select IdProyectoTipo from ProyectoTipo where nombre = 'Indefinido')
GO

--Update proceso to new names
Update Proceso set nombre='Ampliación' where nombre like 'Ampliación%' --23
GO
Update Proceso set nombre='Equipamiento básico' where nombre like 'Equipamiento básico%' --5
GO
Update Proceso set nombre='Reposición' where nombre like 'Reposición%'
GO

--Update proyecto to new proceso
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
GO
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
GO
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')
GO

--Update proyectocalidad to new proceso
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
GO
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
GO
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')
GO

--remove old proceso items
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Ampliación'))
GO
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico'))
GO
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Reposición'))
GO

--Add default to proceso on proyecto
ALTER TABLE [dbo].[Proceso] ADD DEFAULT Select idProyectoTipo from ProyectoTipo where nombre='Indefinido' FOR [IdProceso]
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