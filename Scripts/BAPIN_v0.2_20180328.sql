USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EsPPP'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [EsPPP] bit NULL 
GO

--Add default to EsPPP on proyecto
ALTER TABLE [dbo].[Proyecto] ADD DEFAULT 0 FOR [EsPPP]
GO

UPDATE [dbo].[Proyecto]  SET [EsPPP] = 0 where EsPPP is null
GO

USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ModalidadContratacion] 
          WHERE [Nombre] = 'No definido aún')
INSERT INTO [dbo].[ModalidadContratacion] 
([Nombre], [Activo]) 
VALUES ('No definido aún', '1')
GO

Update Proyecto set IdModalidadContratacion = 
(SELECT IdModalidadContratacion from ModalidadContratacion where nombre = 'No definido aún')
Where IdModalidadContratacion is null
GO

USE [BAPIN]
GO

Update ProyectoTipo set Nombre = 'IRD – Inv. Real Directa' where Nombre = '1 Inversión Real Directa'
GO
Update ProyectoTipo set Nombre = 'Transferencia' where Nombre = '2 Transferencias'
GO
Update ProyectoTipo set Nombre = 'Combinados' where Nombre = '3 Combinado'
GO
Update ProyectoTipo set Nombre = 'Inversiones Financieras' where Nombre = '4 Inversiones Financieras'
GO
Update ProyectoTipo set Nombre = 'Adelanto  a proveedores' where Nombre = '5 Adelanto a Proveedores'
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('SGC', 'Sin gastos imputados', '1', '');
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('GC', 'Gasto Corriente', '1', '');
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('IND', 'Indefinido', '1', '');
GO

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

USE [BAPIN]
GO

--Idea/Perfil
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Idea' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Idea/Perfil' where Nombre = 'Idea' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO

--Factibilidad/Prefactibilidad
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Factibilidad' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Factibilidad/Prefactibilidad' where Nombre = 'Factibilidad' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO

--Suspendido a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Borro Suspendido
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Postergado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Borro Postergado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Desestimado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO

--Borro Desestimado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO
--En ejec y oper a En ejecucion
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejecución' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)
GO

--Borro En Ejec. & Oper.
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)

--Nuevo  estado Iniciado
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('437', '16', 'Iniciado');
GO

USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividad'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividad] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObra'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObra] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroProyectoEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroProyectoEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividadEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividadEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObraEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObraEjecucion] int NULL 
GO
