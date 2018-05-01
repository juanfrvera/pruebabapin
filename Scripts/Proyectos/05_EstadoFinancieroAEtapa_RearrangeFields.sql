USE [BAPIN]
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
          WHERE [IdSistemaEntidad] = '458' and [IdEstado] = '5' and [Nombre] = N'En Ejecución')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('458', '5', 'En Ejecución');
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

-- 3.3) En Ejecucion y En ejec. y Opración ==> nuevo ETAPA: "Iniciado"
Update Proyecto set IdEstado = 
(SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Iniciado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre in ('En Ejecución', 'En Ejec. & Oper.') and idsistemaentidad=437)
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

-- Estado Financiero "En Ejecución"
declare @idEstadoINICIADO int = (SELECT top 1 IdEstado from SistemaEntidadEstado where Nombre = 'Iniciado' and idsistemaentidad=437)

update	ProyectoEtapa set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejecución' and idsistemaentidad=458)
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
and		Nombre not in ('A Iniciar', 'En Ejecución', 'Terminado', 'Sin Presupuesto')
GO

-------------------------------
/*
select * from Estado order by IdEstado
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 437 -- Etapa en generales 
ORDER BY nombre

select * from Estado order by Nombre
Select * from SistemaEntidadEstado WHERE idsistemaentidad = 458 -- Estado financiero en cronograma
ORDER BY nombre
*/

-------------------------------

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
