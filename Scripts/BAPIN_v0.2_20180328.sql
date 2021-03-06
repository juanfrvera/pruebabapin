USE [BD_BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EsPPP'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [EsPPP] bit NULL 
GO

--Add default to EsPPP on proyecto
if not exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proyecto'
      and c.name = 'EsPPP'
      and s.name = 'dbo')
ALTER TABLE [dbo].[Proyecto] ADD DEFAULT 0 FOR [EsPPP]
GO

UPDATE [dbo].[Proyecto]  SET [EsPPP] = 0 where EsPPP is null
GO

USE [BD_BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ModalidadContratacion] 
          WHERE [Nombre] = 'No definido a�n')
INSERT INTO [dbo].[ModalidadContratacion] 
([Nombre], [Activo]) 
VALUES ('No definido a�n', '1')
GO

Update Proyecto set IdModalidadContratacion = 
(SELECT IdModalidadContratacion from ModalidadContratacion where nombre = 'No definido a�n')
Where IdModalidadContratacion is null
GO

USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].[ProyectoTipo] WHERE Nombre='Indefinido'  )
BEGIN
Update ProyectoTipo set Nombre = 'IRD � Inv. Real Directa' where Nombre = '1 Inversi�n Real Directa'
Update ProyectoTipo set Nombre = 'Transferencia' where Nombre = '2 Transferencias'
Update ProyectoTipo set Nombre = 'Combinados' where Nombre = '3 Combinado'
Update ProyectoTipo set Nombre = 'Inversiones Financieras' where Nombre = '4 Inversiones Financieras'
Update ProyectoTipo set Nombre = 'Adelanto  a proveedores' where Nombre = '5 Adelanto a Proveedores'
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('SGC', 'Sin gastos imputados', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('GC', 'Gasto Corriente', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('IND', 'Indefinido', '1', '');
END;

GO

USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetProyectoTipoIndefinido]') AND type in (N'FN'))
BEGIN

--Remove Unique
ALTER TABLE [dbo].[Proceso] DROP CONSTRAINT [UK_Proceso_Nombre] 

--Unify idproyectotipo (deprecated)
Update Proceso set IdProyectoTipo = (Select IdProyectoTipo from ProyectoTipo where nombre = 'Indefinido')

--Update proceso to new names
Update Proceso set nombre='Ampliaci�n' where nombre like 'Ampliaci�n%' --23
Update Proceso set nombre='Equipamiento b�sico' where nombre like 'Equipamiento b�sico%' --5
Update Proceso set nombre='Reposici�n' where nombre like 'Reposici�n%'

--Update proyecto to new proceso
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliaci�n')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliaci�n')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento b�sico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento b�sico')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposici�n')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposici�n')

--Update proyectocalidad to new proceso
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliaci�n')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliaci�n')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento b�sico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento b�sico')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposici�n')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposici�n')

--remove old proceso items
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliaci�n' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Ampliaci�n'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento b�sico' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento b�sico'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposici�n' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Reposici�n'))

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


USE [BD_BAPIN]
GO

/*
Nuevos estados:
1) Solapa "Generales" - campo "Etapa" (en este orden!):
- Idea/Perfil. Ya esta! Unir Idea y Perfil en un solo estado.
- Prefact/Fact. Ya esta! Editar "Factibilidad/Prefactibilidad" a "Prefact/Fact".
- Iniciado. Asociar estado a SistemaEntidadEstado
- Finalizado. Agregar!
- Cancelado. Ya esta!

2) Solapa "Cronograma" - campo "Estado Financiero" (en este orden!); dentro del popup (editar) de Cronograma de Gastos:
- A Iniciar. ya esta! Editar "Iniciado" a "A Iniciar".
- En Ejecucion. Agregar!
- Terminado. Ya esta!
- Suspendido. Ya esta!
- Sin Presupuesto. Agregar!

select * from Estado order by IdEstado
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 437 -- Etapa en generales 
ORDER BY nombre
select * from Estado order by Nombre
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 458 -- Estado financiero en cronograma
ORDER BY nombre

*/

-- 1) Primero creo los nuevas ETAPAS (E) y ESTADOS FINANCIEROS (EF)

-- 1.1) Nuevas ETAPAS
-- Nueva ETAPA "Iniciado"
DELETE from SistemaEntidadEstado where ([IdSistemaEntidad] = '437' and [Nombre] = N'Iniciado')
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [IdEstado] = '16' and [Nombre] = N'Iniciado')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('437', '16', 'Iniciado');
GO

-- Nueva ETAPA "Finalizado"
DELETE from SistemaEntidadEstado where ([IdSistemaEntidad] = '437' and [Nombre] = N'Finalizado')
GO

SET IDENTITY_INSERT [Estado] ON
IF NOT EXISTS(SELECT 1 FROM [dbo].[Estado]
          WHERE [IdEstado] = '50' and [Nombre] = 'Finalizado')
INSERT INTO [dbo].[Estado] 
([IdEstado], [Nombre], Activo, Codigo, Orden) 
VALUES ('50', 'Finalizado', 1, 'FI', 50);
SET IDENTITY_INSERT [Estado] OFF

IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [IdEstado] = '50' and [Nombre] = N'Finalizado')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('437', '50', 'Finalizado');
GO

-- 1.2) Nuevos ESTADOS FINANCIEROS
-- Nuevo EF "Iniciado"
IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '458' and [IdEstado] = '5' and [Nombre] = N'En Ejecuci�n')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('458', '5', 'En Ejecuci�n');
GO

-- Nueva EF "Sin Presupuesto"
SET IDENTITY_INSERT [Estado] ON
IF NOT EXISTS(SELECT 1 FROM [dbo].[Estado]
          WHERE [IdEstado] = '51' and [Nombre] = 'Sin Presupuesto')
INSERT INTO [dbo].[Estado] 
([IdEstado], [Nombre], Activo, Codigo, Orden) 
VALUES ('51', 'Sin Presupuesto', 1, 'SP', 51);
SET IDENTITY_INSERT [Estado] OFF
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '458' and [IdEstado] = '51' and [Nombre] = N'Sin Presupuesto')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('458', '51', 'Sin Presupuesto');
GO

-- 2) Actualizo los estados existentes.
delete	from SistemaEntidadEstado 
where	idsistemaentidad=437 and Nombre = 'Idea/Perfil'
GO

IF EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [Nombre] = N'Idea')
	Update SistemaEntidadEstado set Nombre = 'Idea/Perfil' where Nombre = 'Idea' and idsistemaentidad=437
ELSE
	IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [Nombre] = N'Idea/Perfil')

				INSERT INTO [dbo].[SistemaEntidadEstado] 
				([IdSistemaEntidad], [IdEstado], [Nombre]) 
				VALUES ('437', '1', 'Idea/Perfil');
GO

delete	from SistemaEntidadEstado 
where	idsistemaentidad=437 and Nombre = 'Prefactibilidad/Factibilidad'
GO

IF EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [Nombre] = N'PreFactibilidad')
	Update SistemaEntidadEstado set Nombre = 'Prefactibilidad/Factibilidad' where Nombre = 'PreFactibilidad' and idsistemaentidad=437
ELSE
	IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [Nombre] = N'Prefactibilidad/Factibilidad')

				INSERT INTO [dbo].[SistemaEntidadEstado] 
				([IdSistemaEntidad], [IdEstado], [Nombre]) 
				VALUES ('437', '3', 'Prefactibilidad/Factibilidad');
GO

delete	from SistemaEntidadEstado 
where	idsistemaentidad=458 and Nombre = 'A Iniciar'
GO

IF EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '458' and [Nombre] = N'Iniciado')
	Update SistemaEntidadEstado set Nombre = 'A Iniciar' where Nombre = 'Iniciado' and idsistemaentidad=458
ELSE
	IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '458' and [Nombre] = N'A Iniciar')

				INSERT INTO [dbo].[SistemaEntidadEstado] 
				([IdSistemaEntidad], [IdEstado], [Nombre]) 
				VALUES ('458', '16', 'A Iniciar');
GO

-- 3) Migro E y EF.
-- 3.1) Idea/Perfil, Perfil, Desestimado y Postergado ==> nuevo ETAPA: "Idea/Perfil"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Idea/Perfil' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('Idea/Perfil', 'Perfil', 'Desestimado', 'Postergado') and idsistemaentidad=437)
GO

-- 3.2) Prefactibilidad/Factibilidad y Factibilidad ==> nuevo ETAPA: "Prefactibilidad/Factibilidad"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad/Factibilidad' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('Prefactibilidad/Factibilidad', 'Factibilidad') and idsistemaentidad=437)
GO

-- 3.3) En Ejecucion y En ejec. y Opraci�n ==> nuevo ETAPA: "Iniciado"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Iniciado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('En Ejecuci�n', 'En Ejec. & Oper.') and idsistemaentidad=437)
GO

-- 3.4) Suspendido y Cancelado ==> nuevo ETAPA: "Cancelado"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('Suspendido', 'Cancelado') and idsistemaentidad=437)
GO

-- 3.5) Terminado ==> nuevo ETAPA: "Finalizado"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Finalizado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('Terminado') and idsistemaentidad=437)
GO

-- 4) Migro EF.
-- Estado Financiero "A Iniciar"
declare @idEstadoIDEA int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Idea/Perfil' and idsistemaentidad=437)
declare @idEstadoPREFA int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad/Factibilidad' and idsistemaentidad=437)

update	ProyectoEtapa set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'A Iniciar' and idsistemaentidad=458)
where IdProyecto in ( select IdProyecto from Proyecto where IdEstado = @idEstadoIDEA or IdEstado = @idEstadoPREFA  )

-- Estado Financiero "En Ejecuci�n"
declare @idEstadoINICIADO int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Iniciado' and idsistemaentidad=437)

update	ProyectoEtapa set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejecuci�n' and idsistemaentidad=458)
where IdProyecto in ( select IdProyecto from Proyecto where IdEstado = @idEstadoINICIADO  )

-- Estado Financiero "Sin Presupuesto"
declare @idEstadoCANCELADO int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)

update	ProyectoEtapa set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Sin Presupuesto' and idsistemaentidad=458)
where IdProyecto in ( select IdProyecto from Proyecto where IdEstado = @idEstadoCANCELADO  )

-- Estado Financiero "Terminado"
declare @idEstadoFINALIZADO int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Finalizado' and idsistemaentidad=437)

update	ProyectoEtapa set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Terminado' and idsistemaentidad=458)
where IdProyecto in ( select IdProyecto from Proyecto where IdEstado = @idEstadoFINALIZADO )


-- 5) Elimino E y EF innecesarios.

delete	from SistemaEntidadEstado 
where	idsistemaentidad=437 
and		Nombre not in ('Idea/Perfil', 'Prefactibilidad/Factibilidad', 'Iniciado', 'Cancelado', 'Finalizado')

delete	from SistemaEntidadEstado 
where	idsistemaentidad=458
and		Nombre not in ('A Iniciar', 'En Ejecuci�n', 'Terminado', 'Sin Presupuesto')

-------------------------------
/*
select * from Estado order by IdEstado
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 437 -- Etapa en generales 
ORDER BY nombre

select * from Estado order by Nombre
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 458 -- Estado financiero en cronograma
ORDER BY nombre
*/
--------------------- Finalizado 50 copia de 8 en ejecucion
IF NOT EXISTS(SELECT 1 from Permiso where [IdSistemaEstado] = '50')
INSERT INTO [dbo].[Permiso] 
([Nombre], [Codigo], [IdSistemaEntidad], [IdSistemaAccion], [IdSistemaEstado], [Activo]) 
Select [Nombre], [Codigo], [IdSistemaEntidad], [IdSistemaAccion], 50, [Activo] from permiso p
where idsistemaentidad = 437 and idsistemaestado = 8
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ActividadPermiso]
          WHERE idPermiso in (select idPermiso from Permiso where [IdSistemaEstado] = '50'))
INSERT INTO [dbo].[ActividadPermiso] 
([IdPermiso],[IdActividad]) 
Select p.idPermiso, ap.IdActividad--, pe.idPermiso as idPermisoViejo 
from Permiso p
Inner Join Permiso pe on 
		p.idsistemaaccion = pe.idsistemaaccion 
		and p.idsistemaentidad = pe.idsistemaentidad 
		and pe.idsistemaestado = 8 and pe.idsistemaentidad = 437
Inner join ActividadPermiso ap on pe.idpermiso = ap.idpermiso
where p.IdSistemaEstado = 50
ORDER BY pe.idPermiso
GO

--------------------- Iniciado 16 copia de 5 en ejecucion
IF NOT EXISTS(SELECT 1 from Permiso where [IdSistemaEstado] = '16' and idsistemaentidad = 437)
INSERT INTO [dbo].[Permiso] 
([Nombre], [Codigo], [IdSistemaEntidad], [IdSistemaAccion], [IdSistemaEstado], [Activo]) 
Select [Nombre], [Codigo], [IdSistemaEntidad], [IdSistemaAccion], 16, [Activo] from permiso p
where idsistemaentidad = 437 and idsistemaestado = 5
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ActividadPermiso]
          WHERE idPermiso in (select idPermiso from Permiso where [IdSistemaEstado] = '16' and idsistemaentidad = 437))
INSERT INTO [dbo].[ActividadPermiso] 
([IdPermiso],[IdActividad]) 
Select p.idPermiso, ap.IdActividad--, pe.idPermiso as idPermisoViejo 
from Permiso p
Inner Join Permiso pe on 
		p.idsistemaaccion = pe.idsistemaaccion 
		and p.idsistemaentidad = pe.idsistemaentidad 
		and pe.idsistemaestado = 5 and pe.idsistemaentidad = 437
Inner join ActividadPermiso ap on pe.idpermiso = ap.idpermiso
where p.IdSistemaEstado = 16
ORDER BY pe.idPermiso
GO

USE [BD_BAPIN]
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

USE [BD_BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Text] 
          WHERE [Code] = 'TooltipProyectoEliminado')

INSERT INTO [Text] (
	[Code], [Description], [IdTextCategory], 
	[IsAutomaticLoad], [StartDate], 
	[Checked], [CheckedDate], [IdUsuarioChecked]) 
VALUES 
--('TooltipEtapa', 'Refleja la etapa del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL);
('TooltipProyectoEliminado', 'Campo no editable. En caso de eliminar el proyecto aparecer� la leyenda "ELIMINADO".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoBorrador', 'R�tulo que se�ala que el proyecto est� en proceso de carga. Si la casilla se encuentra tildada la ficha s�lo ser� visible para los usuarios de las oficinas con permiso de edici�n.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoDatosGenerales', 'Bloque que contiene campos obligatorios para obtener el alta de una ficha.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoPresupuestario', 'C�digo de proyecto presupuestario al que pertenece la construcci�n del bien de capital y/o la adqusici�n espec�fica correspondiente a tal obra.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoActividad', 'C�digo de actividad presupuestaria al que pertenece la adquisici�n de uno o m�s bien/es de capital.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoObra', 'C�digo presupuestario de obra por la cual se producir� el o los bien/es de capital.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoDenominacion', 'Nombre del proyecto sin abreviaturas o siglas (salvo las de uso habitual y generalizado). Se debe estructurar respetando la secuencia: "Acci�n, Objeto, Lugar"; cuando se trate de una adquisici�n se deber� agregar el a�o correspondiente: "Acci�n, Objeto, Lugar, A�o".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoEjecucionPresupuestaria', 'Car�cter econ�mico de los gastos p�blicos comprendidos en el proyecto de inversi�n. Surge de manera autom�tica a partir de los c�digos presupuestarios por objeto de gasto informados en la solapa "Cronograma de gastos".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoCostototal', 'Corresponde al Monto Estimado Actual de la solapa "Cronograma de gastos", se actualiza con cada modificaci�n al mismo.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoMontoTotalEstimadoInicial', 'Suma de los gastos estimados al momento de colocar la primer marca de Demanda. Se mantiene fijo a lo largo del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipRequiereDictamen', 'A completar por la DNIP (proyectos que requieren dictamen de calificaci�n t�cnica seg�n Ley 24.354)', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoContribucion', 'Contribuci�n a la capacidad de prestaci�n del servicio seg�n la caracter�stica de la inversi�n.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoEtapa', 'Refleja la etapa del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipModalidaddeContratacion', 'Tipo de contatraci�n de las obras o adquisiciones del proyecto. En caso de no conocer a�n la modalidad se completar� con la opci�n "no definido a�n".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPPP', 'Indica si la obra a ejecutar corresponde a un contrato de participaci�n p�blico privada.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipFinalidadFuncion', 'Debe completarse hasta el tercer nivel de detalle: finalidad, funci�n y subfunci�n', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipLocalizacion', 'Ubicaci�n espec�fica (Localidad/es, Partido/s o Departamento/s y Provincia/s) de las construcciones o equipamientos incorporados por el proyecto. Se deber� identificar como m�nimo la localizaci�n provincial.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIniciador', 'Oficina donde se origina el proyecto. Sus usuarios no podr�n incorporar informaci�n referida al cronograma de gastos.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipEjecutor', 'Oficina que ejecuta el proyecto. Sus usuarios podr�n cargar y/o modificar los campos de texto y de informaci�n financiera (cronograma de gastos, evoluci�n de indicadores).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipResponsable', 'Oficina responsable del proyecto ante la DNIP. Sus usuarios podr�n cargar y/o modificar todos los campos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoAgregar', 'Habilita a colocar marca de solicitud al Presupuesto Nacional (Demanda) y/o la incorporaci�n del proyecto a otros planes de inversi�n (sectoriales, provinciales, regionales u otros).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoHistorial', 'Muestra el historial de marcas de solicitud presupuestaria (Demanda), incorporaci�n al Presupuesto Nacional y/o a otros planes de inversi�n (sectoriales, provinciales,regionales u otros) del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipUltimaSolicitudRegistrada', '�ltimo registro de solicitud o de incorporaci�n efectiva del proyecto al presupuesto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPrioridad', 'Nivel de prioridad asignado al proyecto; editable s�lo por la autoridad de la jurisdicci�n responsable del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipSubprioridad', 'Campo num�rico que informa el orden asignado al proyecto dentro de la prioridad seleccionada precedentemente; editable s�lo por la autoridad de la jurisdicci�n responsable del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipFinanciamientoExterno', 'N�mero de ficha Bapin de cada programa de financiamiento externo vinculado al proyecto (campo obligatorio para todo proyecto que contemple fuente externa en su cronograma de gastos).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectosRelacionados', 'N�mero de ficha Bapin de los proyectos de inversi�n que mantienen alguna relaci�n con el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoObservaciones', 'Informaci�n adicional relevante respecto a alg�n/os campo/s de esta solapa. Si el proyecto surge de una reformulaci�n integral o de una sustituci�n de un proyecto anterior, consignar esta circunstancia aqu�.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPrincipiosConceptualesDeFormulacion', 'Componentes fundamentales que hacen a una adecuada formulaci�n de un proyecto de inversi�n p�blica.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObjetivoDelProyecto', 'Es la descripci�n de la soluci�n (situaci�n que se desea alcanzar) al problema diagnosticado. Ejemplo: si el problema principal en el sector de salud es una alta tasa de mortalidad infantil en la poblaci�n de menores ingresos, el objetivo ser�a reducir en un X% la tasa de mortalidad infantil en esa poblaci�n al cabo de X a�os.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProductoServicioDelProyecto', 'Prestaci�n a brindar mediante la cual se alcanzar� el objetivo del proyecto. Ejemplos: provisi�n de agua potable; ense�anza de nivel medio doble turno.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipDescripcionTecnica', 'Principales caracter�sticas y/o especificaciones que den cuenta de las dimensiones y la capacidad productiva del bien que ser� adquirido o la obra a ejecutar.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipVidaUtil', 'Es la duraci�n estimada que un bien podr� tener, cumpliendo correctamente con la funci�n para la cual ha sido concebido y/o adquirido. Debe ser expresada en una unidad de tiempo (ej: a�os, meses, d�as, horas).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCoberturaTerritorial', '�rea geogr�fica donde se encuentra la poblaci�n beneficiaria del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCoberturaPoblacional', 'Beneficiarios directos sobre poblaci�n con necesidades a satisfacer (ratio).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipBeneficiariosDirectos', 'Destinarios directos de los productos que generara el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipBeneficiariosIndirectos', 'Terceras personas que son beneficiadas con el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipDificultadesRiesgos', 'Informar cualquier hecho cierto o contingente que genere perjuicios sociales, ambientales o dificultades para llevar adelante el proyecto en cualquier etapa de su ciclo de vida.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObservacionesDNIP', 'Comentarios t�cnicos emitidos por la DNIP respecto a la formulaci�n del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCronogramasAgregar', 'Crea una l�nea para cada c�digo presupuestario del proyecto (actividad, obra, actividad espec�fica).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTotalEstimadoActual', 'Campo autom�tico que muesta la suma de los gastos realizados de los a�os anteriores, el gasto estimado para el a�o en curso y los gastos estimados futuros.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTotalRealizado', 'Campo autom�tico que muesta la suma de los gastos devengados de los a�os anteriores y los correspondientes al a�o en curso (hasta la �ltima actualizaci�n de la ficha del proyecto).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipEjecucionPresupuestaria', 'Bloque de campos autom�ticos, no editable. Informa para cada c�digo presupuestario del proyecto: el cr�dito inicial, el cr�dito vigente y el gasto devengado, seg�n la base de datos del SIDIF de fines del �ltimo mes y para el a�o en curso.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipGastosEstimados', 'Bloque de campos a cargo de la oficina responsable. Informar para cada c�digo presupuestario los gastos estimados de cada objeto de gasto, fuente de financiamiento y a�o.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipGastosRealizados', 'Bloque de campos a cargo de la oficina responsable. Informar para cada c�digo presupuestario los gastos realizados (seg�n el criterio de lo devengado) de cada objeto de gasto, fuente de financiamiento y a�o.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIndicadoresEvaluacion', 'Bloque de campos que presenta los indicadores utilizados en la evaluaci�n socioecon�mica del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCriteriosEvaluacion', 'Especificar el o los criterios de evaluaci�n utilizados, en relaci�n al indicador de evaluaci�n adoptado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipHorizonteEvaluacion', 'Cantidad de a�os que abarca las fases de ejecuci�n y de operaci�n del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTasaReferencia', 'Tasa de inter�s de referencia utilizada para descontar los flujos netos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipOtrosIndicadores', 'Indicadores adicionales, que permiten realizar un monitoreo del cumplimiento de los objetivos del proyecto (referidos al objetivo directo, prestaciones brindadas e inversiones)', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipContribucionObjetivoGobierno', 'Objetivo de gobierno que guarda mayor relaci�n con el proyecto de inversi�n.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipSector', 'Seleccionar el sector o actividad econ�mica del proyecto. En caso de no existir la que corresponde, se sugiere consultar los indicadores de la categor�a "general".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIndicador', 'Seleccionar las unidades de medidas del indicador.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipMedioVerificacion', 'Identificar el tipo de registro que permite verificar las metas de acuerdo al indicador seleccionado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObservacionesEvaluacion', 'De ser necesario, detallar las caracter�sticas y/o especificaciones del indicador seleccionado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipArchivosAdjuntos', 'Adjuntar documentaci�n significativa del proyecto (mapas, planos, gr�ficos, informes, etc.).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipMarcoLegal', 'Registrar la normativa que rige el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipOtraInformacionAdicional', 'Indicar cualquier dato o informaci�n relevante sobre aspectos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL)
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[TextLanguage] 
          WHERE IdText = (Select IdText from [Text] where Code = 'TooltipProyectoEliminado'))

INSERT INTO TextLanguage 
--(IdText, IdTextLanguage,[TranslateText], [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]) 
Select IdText, (Select [IdLanguage] from [Language] where Name = 'Espa�ol'), Description, [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]
from [Text]
where IdText >= (Select IdText from [Text] where Code = 'TooltipProyectoEliminado')
GO
