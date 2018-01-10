USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_Count]    Script Date: 12/06/2017 10:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Proyectos_Count]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Proyectos_Count]
GO

USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_Count]    Script Date: 12/06/2017 10:18:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--exec sp_Proyectos_Cantidad @IdSubprograma = 44869, @IdSaf = 1671,  @ProyectoDenominacion = '%ddddd%', @EsBorrador = 1, @FechaModificacionDesde = '2017-12-04 00:00:00', @FechaModificacionHasta = '2017-12-29 23:59:59', @IdEstados = '2,3,4', @Activo=1, @IdPlanTipo=5, @IdPlanPeriodo=5, @IdPlanVersion=1, @Oficina='%.127.%'
Create procedure [dbo].[sp_Proyectos_Count]
@CodigoBapin int = null,
@IdJurisdiccion int = NULL,
@IdSaf int = NULL,
@IdPrograma int = NULL,
@IdSubprograma int = NULL,
@ProyectoDenominacion varchar(8000) = NULL,
@EsBorrador int = NULL,
@FechaModificacionDesde datetime = NULL,
@FechaModificacionHasta datetime = NULL,
@IdEstados varchar(255) = NULL,
@Activo int = NULL,
@IdPlanTipo int = NULL,
@IdPlanPeriodo int = NULL,
@IdPlanVersion int = NULL,
@IdOficina int = null,
@Oficina varchar(8000)  = NULL,
@RETURN_VALUE int output

as
/*
Prueba 1 -> por saf
exec sp_Proyectos_Cantidad @IdSaf = 1671, @Activo = 1 -> 253 OK

Prueba 2 -> por jurisdiccion
exec sp_Proyectos_Cantidad @IdJurisdiccion = 44 , @Activo = 1 -> 542 OK

Prueba 3 -> por programa
exec sp_Proyectos_Cantidad @IdPrograma = 266 , @Activo = 1 -> 141 OK

Prueba 4 -> por subprpgrama 
exec sp_Proyectos_Cantidad @IdSubPrograma = 44868 , @Activo = 1 -> 141 OK

Prueba 5 -> por codigo bapin
exec sp_Proyectos_Cantidad @CodigoBapin = 30250 OK

Prueba 6 -> por denominacion
exec sp_Proyectos_Cantidad @ProyectoDenominacion = 'ser' , @Activo = 1 731 OK


Prueba 7 -> por borrador SI
exec sp_Proyectos_Cantidad @EsBorrador = 1 , @Activo = 1  100 OK

Prueba 8 -> por borrador NO
exec sp_Proyectos_Cantidad @EsBorrador = 0 , @Activo = 1  15716 OK	

Prueba 9 -> por Activo NO
exec sp_Proyectos_Cantidad  @Activo = 0  546 OK	

Prueba 10 -> por tipo 
exec sp_Proyectos_Cantidad @IdPlanTipo = 5 , @Activo = 1 12866 OK

Prueba 11 -> por periodo
exec sp_Proyectos_Cantidad @IdPlanTipo = 5 , @IdPlanPeriodo = 14,  @Activo = 1 1156 OK

Prueba 12 -> por version
exec sp_Proyectos_Cantidad @IdPlanTipo = 5 , @IdPlanPeriodo = 14, @IdPlanVersion = 1,  @Activo = 1 1156 OK

Prueba 13 -> por estados 
exec sp_Proyectos_Cantidad @IdEstados = '1,2,3' , @Activo = 1 5786 OK

Prueba 14 -> fecha mod desde
exec sp_Proyectos_Cantidad @FechaModificacionDesde = '2017-04-02 00:00:00' , @Activo = 1 10632 OK

Prueba 15 -> fecha mod hsta
exec sp_Proyectos_Cantidad @FechaModificacionHasta = '2016-12-05 23:59:59' , @Activo = 1 4120 OK

Prueba 16 -> fecha mod desde y hasta
exec sp_Proyectos_Cantidad @FechaModificacionDesde = '2017-04-03 00:00:00',@FechaModificacionHasta ='2017-05-31 23:59:59' , @Activo = 1 1922 OK

Prueba 17 -> por oficina 
exec sp_Proyectos_Cantidad @IdOficina = 1386 , @Activo = 1 7 OK

Prueba 17 -> por oficina incluir sub items
exec sp_Proyectos_Cantidad @Oficina = '%.1386.%' , @Activo = 1 7 OK







*/

SET NOCOUNT ON;

SET @RETURN_VALUE = (SELECT COUNT(1) AS [value]

FROM [dbo].[Proyecto] AS [t0]
INNER JOIN [dbo].[Estado] AS [t1] ON [t0].[IdEstado] = [t1].[IdEstado]
LEFT OUTER JOIN [dbo].[OrganismoPrioridad] AS [t2] ON [t0].[IdOrganismoPrioridad] = ([t2].[IdOrganismoPrioridad])
LEFT OUTER JOIN [dbo].[Proceso] AS [t3] ON [t0].[IdProceso] = ([t3].[IdProceso])
LEFT OUTER JOIN [dbo].[ProyectoCalidad] AS [t4] ON [t0].[IdProyecto] = [t4].[IdProyecto]
INNER JOIN [dbo].[ProyectoTipo] AS [t5] ON [t0].[IdTipoProyecto] = [t5].[IdProyectoTipo]
INNER JOIN [dbo].[SubPrograma] AS [t6] ON [t0].[IdSubPrograma] = [t6].[IdSubPrograma]
INNER JOIN [dbo].[Programa] AS [t7] ON [t6].[IdPrograma] = [t7].[IdPrograma]
INNER JOIN [dbo].[Saf] AS [t8] ON [t7].[IdSAF] = [t8].[IdSaf]
LEFT OUTER JOIN [dbo].[Sector] AS [t9] ON [t8].[IdSector] = ([t9].[IdSector])
LEFT OUTER JOIN [dbo].[AdministracionTipo] AS [t10] ON [t8].[IdAdministracionTipo] = ([t10].[IdAdministracionTipo])
LEFT OUTER JOIN [dbo].[ModalidadContratacion] AS [t11] ON [t0].[IdModalidadContratacion] = ([t11].[IdModalidadContratacion])
LEFT OUTER JOIN [dbo].[FinalidadFuncion] AS [t12] ON [t0].[IdFinalidadFuncion] = ([t12].[IdFinalidadFuncion])
LEFT OUTER JOIN [dbo].[EntidadTipo] AS [t13] ON [t8].[IdEntidadTipo] = ([t13].[IdEntidadTipo])
LEFT OUTER JOIN [dbo].[ProyectoPlan] AS [t14] ON [t0].[IdProyectoPlan] = ([t14].[IdProyectoPlan])
LEFT OUTER JOIN [dbo].[PlanPeriodo] AS [t15] ON [t14].[IdPlanPeriodo] = [t15].[IdPlanPeriodo]
LEFT OUTER JOIN [dbo].[PlanTipo] AS [t16] ON [t15].[IdPlanTipo] = [t16].[IdPlanTipo]
LEFT OUTER JOIN [dbo].[PlanVersion] AS [t17] ON [t14].[IdPlanVersion] = [t17].[IdPlanVersion]
LEFT OUTER JOIN [dbo].[Jurisdiccion] AS [t18] ON [t18].[IdJurisdiccion] = [t8].[IdJurisdiccion]

WHERE 
	(@CodigoBapin is null AND
		(@IdSubprograma is null or [t0].[IdSubPrograma] = @IdSubprograma) 
		AND (@ProyectoDenominacion is null or [t0].[ProyectoDenominacion] LIKE '%' + @ProyectoDenominacion + '%') 
		AND (@EsBorrador is null or [t0].[EsBorrador] = @EsBorrador) 
		AND ((@FechaModificacionDesde is null and @FechaModificacionHasta is null) or 
		(@FechaModificacionHasta is null and [t0].[FechaModificacion] >= @FechaModificacionDesde) or
		(@FechaModificacionDesde is null and [t0].[FechaModificacion] <= @FechaModificacionHasta) or
		([t0].[FechaModificacion] >= @FechaModificacionDesde AND [t0].[FechaModificacion] <= @FechaModificacionHasta)) 
		AND (@IdEstados is null or [t0].[IdEstado] IN (select valor from dbo.parser(@IdEstados))) 
		AND (@Activo is null or @Activo = [t0].[Activo])
		AND (@IdJurisdiccion is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t19]
			WHERE ([t19].[IdSubPrograma] = [t0].[IdSubPrograma]) AND (EXISTS(
				SELECT NULL AS [EMPTY]
				FROM [dbo].[Programa] AS [t20]
				WHERE ([t20].[IdPrograma] = [t19].[IdPrograma]) AND (EXISTS(
					SELECT NULL AS [EMPTY]
					FROM [dbo].[Saf] AS [t21]
					WHERE ([t21].[IdSaf] = [t20].[IdSAF]) AND ([t21].[IdJurisdiccion] = @IdJurisdiccion)
					))
				))))
		AND (@IdSaf is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t19]
			WHERE ([t19].[IdSubPrograma] = [t0].[IdSubPrograma]) AND (EXISTS(
				SELECT NULL AS [EMPTY]
				FROM [dbo].[Programa] AS [t20]
				WHERE ([t20].[IdPrograma] = [t19].[IdPrograma]) AND (([t20].[IdSAF]) = @IdSaf)
				))))
		AND (@IdPrograma is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t19]
			WHERE ([t19].[IdSubPrograma] = [t0].[IdSubPrograma]) AND (([t19].[IdPrograma]) = @IdPrograma)
			))
		AND (@IdPlanTipo is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanVersion] AS [t20]
			INNER JOIN [dbo].[ProyectoPlan] AS [t21] ON [t20].[IdPlanVersion] = [t21].[IdPlanVersion]
			WHERE ([t21].[IdProyecto] = [t0].[IdProyecto]) AND (([t20].[IdPlanTipo]) = @IdPlanTipo)
			)) 
		AND (@IdPlanPeriodo is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanPeriodo] AS [t22]
			INNER JOIN [dbo].[ProyectoPlan] AS [t23] ON [t22].[IdPlanPeriodo] = [t23].[IdPlanPeriodo]
			WHERE ([t23].[IdProyecto] = [t0].[IdProyecto]) AND (([t22].[IdPlanTipo]) = @IdPlanTipo) AND (([t23].[IdPlanPeriodo]) = @IdPlanPeriodo)
			)) 
		AND (@IdPlanVersion is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanVersion] AS [t24]
			INNER JOIN [dbo].[ProyectoPlan] AS [t25] ON [t24].[IdPlanVersion] = [t25].[IdPlanVersion]
			WHERE ([t25].[IdProyecto] = [t0].[IdProyecto]) AND (([t24].[IdPlanTipo]) = @IdPlanTipo) AND (([t25].[IdPlanPeriodo]) = @IdPlanPeriodo) AND (([t24].[IdPlanVersion]) = @IdPlanVersion)
			)) 
		AND (@IdOficina is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[ProyectoOficinaPerfil] AS [t19]
			WHERE ([t19].[IdProyecto] = [t0].[IdProyecto]) AND (@IdOficina = ([t19].[IdOficina]))
			))
		AND (@Oficina is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[ProyectoOficinaPerfil] AS [t26]
			INNER JOIN [dbo].[Oficina] AS [t27] ON [t26].[IdOficina] = [t27].[IdOficina]
			WHERE ([t26].[IdProyecto] = [t0].[IdProyecto]) AND ([t27].[BreadcrumbId] LIKE @Oficina)
			))
    ) OR 
    ([t0].[Codigo] = @CodigoBapin))
GO


