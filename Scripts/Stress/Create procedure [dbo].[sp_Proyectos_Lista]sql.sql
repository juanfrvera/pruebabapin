
USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_List]   Script Date: 12/06/2017 10:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Proyectos_List]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Proyectos_List]
GO

USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_List]   Script Date: 12/06/2017 10:18:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--exec [sp_Proyectos_List] @IdSubprograma = 44869, @IdSaf = 1671,  @ProyectoDenominacion = '%ddddd%', @EsBorrador = 1, @FechaModificacionDesde = '2017-12-04 00:00:00', @FechaModificacionHasta = '2017-12-29 23:59:59', @IdEstados = '2,3,4', @Activo=1, @IdPlanTipo=5, @IdPlanPeriodo=5, @IdPlanVersion=1, @Oficina='%.127.%'
Create procedure [dbo].[sp_Proyectos_List]
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
@Desde int = NULL,
@Hasta int = NULL

as

SET NOCOUNT ON;

declare
@p0 nvarchar(4000),
@p1 nvarchar(4000),
@p2 varchar(8000),
@p3 int,
@p4 varchar(8000),
@p5 int,
@p6 int,
@p7 nchar(1),
@p8 nvarchar(4000),
@p9 int,
@p10 nchar(1),
@p11 nvarchar(4000),
@p12 int,
@p13 nchar(1),
@p14 int,
@p15 int,
@p16 int,
@p17 int,
@p18 nvarchar(4000),
@p19 nvarchar(4000),
@p20 nvarchar(4000)

SET @p0='-'
SET @p1='-'
SET @p2='AC'
SET @p3=0
SET @p4='OB'
SET @p5=0
SET @p6=2
SET @p7='0'
SET @p8='.'
SET @p9=2
SET @p10='0'
SET @p11='.'
SET @p12=2
SET @p13='0'
SET @p14=38
SET @p15=0
SET @p16=38
SET @p17=0
SET @p18=''
SET @p19=''
SET @p20=''


/*
Prueba 1 -> por saf
exec sp_Proyectos_Lista @IdSaf = 1671, @Activo = 1 , @Desde=0, @Hasta= 100 -> 253 OK

Prueba 2 -> por jurisdiccion
exec sp_Proyectos_Lista @IdJurisdiccion = 44 , @Activo = 1 -> 542 OK

Prueba 3 -> por programa
exec sp_Proyectos_Lista @IdPrograma = 266 , @Activo = 1 -> 141 OK

Prueba 4 -> por subprpgrama 
exec sp_Proyectos_Lista @IdSubPrograma = 44868 , @Activo = 1 -> 141 OK

Prueba 5 -> por codigo bapin
exec sp_Proyectos_Lista @CodigoBapin = 30250 OK

Prueba 6 -> por denominacion
exec sp_Proyectos_Lista @ProyectoDenominacion = 'ser' , @Activo = 1 731 OK


Prueba 7 -> por borrador SI
exec sp_Proyectos_Lista @EsBorrador = 1 , @Activo = 1  100 OK

Prueba 8 -> por borrador NO
exec sp_Proyectos_Lista @EsBorrador = 0 , @Activo = 1  15716 OK	

Prueba 9 -> por Activo NO
exec sp_Proyectos_Lista  @Activo = 0  546 OK	

Prueba 10 -> por tipo 
exec sp_Proyectos_Lista @IdPlanTipo = 5 , @Activo = 1 12866 OK

Prueba 11 -> por periodo
exec sp_Proyectos_Lista @IdPlanTipo = 5 , @IdPlanPeriodo = 14,  @Activo = 1 1156 OK

Prueba 12 -> por version
exec sp_Proyectos_Lista @IdPlanTipo = 5 , @IdPlanPeriodo = 14, @IdPlanVersion = 1,  @Activo = 1 1156 OK

Prueba 13 -> por estados 
exec sp_Proyectos_Lista @IdEstados = '1,2,3' , @Activo = 1 5786 OK

Prueba 14 -> fecha mod desde
exec sp_Proyectos_Lista @FechaModificacionDesde = '2017-04-02 00:00:00' , @Activo = 1 10632 OK

Prueba 15 -> fecha mod hsta
exec sp_Proyectos_Lista @FechaModificacionHasta = '2016-12-05 23:59:59' , @Activo = 1 4120 OK

Prueba 16 -> fecha mod desde y hasta
exec sp_Proyectos_Lista @FechaModificacionDesde = '2017-04-03 00:00:00',@FechaModificacionHasta ='2017-05-31 23:59:59' , @Activo = 1 1922 OK

Prueba 17 -> por oficina 
exec sp_Proyectos_Lista @IdOficina = 1386 , @Activo = 1 7 OK

Prueba 18 -> por oficina incluir sub items
exec sp_Proyectos_Lista @Oficina = '%.1386.%' , @Activo = 1 7 OK
*/





SELECT [t41].[IdProyecto], [t41].[IdTipoProyecto], [t41].[IdSubPrograma], [t41].[Codigo], [t41].[ProyectoDenominacion], [t41].[ProyectoSituacionActual], [t41].[ProyectoDescripcion], [t41].[ProyectoObservacion], [t41].[IdEstado], [t41].[IdProceso], [t41].[IdModalidadContratacion], [t41].[IdFinalidadFuncion], [t41].[IdOrganismoPrioridad], [t41].[SubPrioridad], [t41].[EsBorrador], [t41].[EsProyecto], [t41].[NroProyecto], [t41].[AnioCorriente], [t41].[FechaInicioEjecucionCalculada], [t41].[FechaFinEjecucionCalculada], [t41].[FechaAlta], [t41].[FechaModificacion], [t41].[IdUsuarioModificacion], [t41].[IdProyectoPlan], [t41].[EvaluarValidaciones], [t41].[Activo], [t41].[IdEstadoDeDesicion], [t41].[Nombre] AS [Estado_Nombre], [t41].[value] AS [Proceso_Nombre], [t41].[Nombre2] AS [TipoProyecto_Nombre], [t41].[Codigo2] AS [SubPrograma_Codigo], [t41].[Nombre3] AS [SubPrograma_Nombre], [t41].[value2] AS [ModalidadContratacion_Nombre], [t41].[value3] AS [FinalidadFuncion_DescripcionInvertida], [t41].[value4] AS [FinalidadFuncion_BreadcrumbCode], [t41].[value5] AS [OrganismoPrioridad_Nombre], [t41].[IdSaf] AS [IdSAF], [t41].[IdPrograma], [t41].[value6] AS [RequiereDictamen], [t41].[Nombre4] AS [Programa_Nombre], [t41].[Codigo3] AS [Programa_Codigo], [t41].[Denominacion] AS [Saf_Nombre], [t41].[Codigo4] AS [Saf_Codigo], [t41].[Nombre5] AS [Jurisdiccion_Nombre], [t41].[Codigo5] AS [Jurisdiccion_Codigo], [t41].[value7] AS [Plan_Ultimo], [t41].[value8] AS [Apertura], [t41].[value9], [t41].[value10] AS [CalidadACorregir], [t41].[value11] AS [Saf_SectorNombre], [t41].[value12] AS [Saf_AdministracionTipoNombre], [t41].[value13] AS [Saf_EntidadTipoNombre]
FROM (
    SELECT ROW_NUMBER() OVER (ORDER BY [t38].[Codigo5], [t38].[Codigo4], [t38].[Codigo3], [t38].[Codigo2], [t38].[Codigo], [t38].[IdProyecto]) AS [ROW_NUMBER], [t38].[IdProyecto], [t38].[IdTipoProyecto], [t38].[IdSubPrograma], [t38].[Codigo], [t38].[ProyectoDenominacion], [t38].[ProyectoSituacionActual], [t38].[ProyectoDescripcion], [t38].[ProyectoObservacion], [t38].[IdEstado], [t38].[IdProceso], [t38].[IdModalidadContratacion], [t38].[IdFinalidadFuncion], [t38].[IdOrganismoPrioridad], [t38].[SubPrioridad], [t38].[EsBorrador], [t38].[EsProyecto], [t38].[NroProyecto], [t38].[AnioCorriente], [t38].[FechaInicioEjecucionCalculada], [t38].[FechaFinEjecucionCalculada], [t38].[FechaAlta], [t38].[FechaModificacion], [t38].[IdUsuarioModificacion], [t38].[IdProyectoPlan], [t38].[EvaluarValidaciones], [t38].[Activo], [t38].[IdEstadoDeDesicion], [t38].[Nombre], [t38].[value], [t38].[Nombre2], [t38].[Codigo2], [t38].[Nombre3], [t38].[value2], [t38].[value3], [t38].[value4], [t38].[value5], [t38].[IdSaf], [t38].[IdPrograma], [t38].[value6], [t38].[Nombre4], [t38].[Codigo3], [t38].[Denominacion], [t38].[Codigo4], [t38].[Nombre5], [t38].[Codigo5], [t38].[value7], [t38].[value8], [t38].[value9], [t38].[value10], [t38].[value11], [t38].[value12], [t38].[value13]
    FROM (
        SELECT [t0].[IdProyecto], [t0].[IdTipoProyecto], [t0].[IdSubPrograma], [t0].[Codigo], [t0].[ProyectoDenominacion], [t0].[ProyectoSituacionActual], [t0].[ProyectoDescripcion], [t0].[ProyectoObservacion], [t0].[IdEstado], [t0].[IdProceso], [t0].[IdModalidadContratacion], [t0].[IdFinalidadFuncion], [t0].[IdOrganismoPrioridad], [t0].[SubPrioridad], [t0].[EsBorrador], [t0].[EsProyecto], [t0].[NroProyecto], [t0].[AnioCorriente], [t0].[FechaInicioEjecucionCalculada], [t0].[FechaFinEjecucionCalculada], [t0].[FechaAlta], [t0].[FechaModificacion], [t0].[IdUsuarioModificacion], [t0].[IdProyectoPlan], [t0].[EvaluarValidaciones], [t0].[Activo], [t0].[IdEstadoDeDesicion], [t1].[Nombre], 
            (CASE 
                WHEN [t5].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t5].[Nombre])
                ELSE NULL
             END) AS [value], [t8].[Nombre] AS [Nombre2], [t9].[Codigo] AS [Codigo2], [t9].[Nombre] AS [Nombre3], 
            (CASE 
                WHEN [t17].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t17].[Nombre])
                ELSE NULL
             END) AS [value2], 
            (CASE 
                WHEN [t19].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t19].[DescripcionInvertida])
                ELSE NULL
             END) AS [value3], 
            (CASE 
                WHEN [t19].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t19].[BreadcrumbCode])
                ELSE NULL
             END) AS [value4], 
            (CASE 
                WHEN [t3].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t3].[Nombre])
                ELSE NULL
             END) AS [value5], [t11].[IdSaf], [t10].[IdPrograma], 
            (CASE 
                WHEN ([t7].[test] IS NOT NULL) AND ([t7].[ReqDictamen] = 1) THEN 1
                WHEN NOT (([t7].[test] IS NOT NULL) AND ([t7].[ReqDictamen] = 1)) THEN 0
                ELSE NULL
             END) AS [value6], [t10].[Nombre] AS [Nombre4], [t10].[Codigo] AS [Codigo3], [t11].[Denominacion], [t11].[Codigo] AS [Codigo4], [t27].[Nombre] AS [Nombre5], [t27].[Codigo] AS [Codigo5], 
            (CASE 
                WHEN [t25].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),((([t25].[Sigla] + @p0) + [t23].[Nombre]) + @p1) + [t26].[Nombre])
                ELSE NULL
             END) AS [value7], (
            SELECT TOP (1) [t33].[value]
            FROM (
                SELECT ((((
                    (CASE 
                        WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t0].[NroProyecto])) / 2)) >= @p6 THEN CONVERT(NVarChar,[t0].[NroProyecto])
                        ELSE REPLICATE(@p7, @p6 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t0].[NroProyecto])) / 2))) + (CONVERT(NVarChar,[t0].[NroProyecto]))
                     END)) + @p8) + (
                    (CASE 
                        WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value])) / 2)) >= @p9 THEN CONVERT(NVarChar,[t32].[value])
                        ELSE REPLICATE(@p10, @p9 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value])) / 2))) + (CONVERT(NVarChar,[t32].[value]))
                     END))) + @p11) + (
                    (CASE 
                        WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value2])) / 2)) >= @p12 THEN CONVERT(NVarChar,[t32].[value2])
                        ELSE REPLICATE(@p13, @p12 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value2])) / 2))) + (CONVERT(NVarChar,[t32].[value2]))
                     END)) AS [value]
                FROM (
                    SELECT MAX([t31].[value]) AS [value], MAX([t31].[value2]) AS [value2]
                    FROM (
                        SELECT [t28].[IdProyecto], 
                            (CASE 
                                WHEN ([t29].[Codigo] = @p2) AND ([t28].[NroEtapa] IS NOT NULL) THEN [t28].[NroEtapa]
                                ELSE @p3
                             END) AS [value], 
                            (CASE 
                                WHEN ([t29].[Codigo] = @p4) AND ([t28].[NroEtapa] IS NOT NULL) THEN [t28].[NroEtapa]
                                ELSE @p5
                             END) AS [value2]
                        FROM [dbo].[ProyectoEtapa] AS [t28]
                        INNER JOIN [dbo].[Etapa] AS [t29] ON [t28].[IdEtapa] = [t29].[IdEtapa]
                        INNER JOIN [dbo].[Fase] AS [t30] ON [t29].[IdFase] = [t30].[IdFase]
                        ) AS [t31]
                    WHERE [t31].[IdProyecto] = [t0].[IdProyecto]
                    GROUP BY [t31].[IdProyecto]
                    ) AS [t32]
                ) AS [t33]
            ) AS [value8], 
            (CASE 
                WHEN ((
                    SELECT COUNT(*)
                    FROM [dbo].[ProyectoCalidad] AS [t35]
                    WHERE ([t35].[IdProyecto] = [t0].[IdProyecto]) AND ([t35].[IdEstado] = @p14)
                    )) <> @p15 THEN 1
                WHEN NOT (((
                    SELECT COUNT(*)
                    FROM [dbo].[ProyectoCalidad] AS [t35]
                    WHERE ([t35].[IdProyecto] = [t0].[IdProyecto]) AND ([t35].[IdEstado] = @p14)
                    )) <> @p15) THEN 0
                ELSE NULL
             END) AS [value9], 
            (CASE 
                WHEN ((
                    SELECT COUNT(*)
                    FROM [dbo].[ProyectoCalidad] AS [t37]
                    WHERE ([t37].[IdProyecto] = [t0].[IdProyecto]) AND ([t37].[IdEstado] = @p16)
                    )) <> @p17 THEN 1
                WHEN NOT (((
                    SELECT COUNT(*)
                    FROM [dbo].[ProyectoCalidad] AS [t37]
                    WHERE ([t37].[IdProyecto] = [t0].[IdProyecto]) AND ([t37].[IdEstado] = @p16)
                    )) <> @p17) THEN 0
                ELSE NULL
             END) AS [value10], 
            (CASE 
                WHEN [t13].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t13].[Nombre])
                ELSE CONVERT(NVarChar(50),@p18)
             END) AS [value11], 
            (CASE 
                WHEN [t15].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t15].[Nombre])
                ELSE CONVERT(NVarChar(50),@p19)
             END) AS [value12], 
            (CASE 
                WHEN [t21].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t21].[Nombre])
                ELSE CONVERT(NVarChar(50),@p20)
             END) AS [value13]
        FROM [dbo].[Proyecto] AS [t0]
        INNER JOIN [dbo].[Estado] AS [t1] ON [t0].[IdEstado] = [t1].[IdEstado]
		INNER JOIN [dbo].[SistemaEntidadEstado] AS [t1] ON [t0].[IdEstado] = [t1].[IdEstado]
							AND [t1].idsistemaentidad = (Select idsistemaentidad from SistemaEntidad where nombre = 'Proyecto')
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t2].[IdOrganismoPrioridad], [t2].[Nombre]
            FROM [dbo].[OrganismoPrioridad] AS [t2]
            ) AS [t3] ON [t0].[IdOrganismoPrioridad] = ([t3].[IdOrganismoPrioridad])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t4].[IdProceso], [t4].[Nombre]
            FROM [dbo].[Proceso] AS [t4]
            ) AS [t5] ON [t0].[IdProceso] = ([t5].[IdProceso])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t6].[IdProyecto], [t6].[ReqDictamen]
            FROM [dbo].[ProyectoCalidad] AS [t6]
            ) AS [t7] ON [t0].[IdProyecto] = [t7].[IdProyecto]
        INNER JOIN [dbo].[ProyectoTipo] AS [t8] ON [t0].[IdTipoProyecto] = [t8].[IdProyectoTipo]
        INNER JOIN [dbo].[SubPrograma] AS [t9] ON [t0].[IdSubPrograma] = [t9].[IdSubPrograma]
        INNER JOIN [dbo].[Programa] AS [t10] ON [t9].[IdPrograma] = [t10].[IdPrograma]
        INNER JOIN [dbo].[Saf] AS [t11] ON [t10].[IdSAF] = [t11].[IdSaf]
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t12].[IdSector], [t12].[Nombre]
            FROM [dbo].[Sector] AS [t12]
            ) AS [t13] ON [t11].[IdSector] = ([t13].[IdSector])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t14].[IdAdministracionTipo], [t14].[Nombre]
            FROM [dbo].[AdministracionTipo] AS [t14]
            ) AS [t15] ON [t11].[IdAdministracionTipo] = ([t15].[IdAdministracionTipo])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t16].[IdModalidadContratacion], [t16].[Nombre]
            FROM [dbo].[ModalidadContratacion] AS [t16]
            ) AS [t17] ON [t0].[IdModalidadContratacion] = ([t17].[IdModalidadContratacion])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t18].[IdFinalidadFuncion], [t18].[DescripcionInvertida], [t18].[BreadcrumbCode]
            FROM [dbo].[FinalidadFuncion] AS [t18]
            ) AS [t19] ON [t0].[IdFinalidadFuncion] = ([t19].[IdFinalidadFuncion])
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t20].[IdEntidadTipo], [t20].[Nombre]
            FROM [dbo].[EntidadTipo] AS [t20]
            ) AS [t21] ON [t11].[IdEntidadTipo] = ([t21].[IdEntidadTipo])
        LEFT OUTER JOIN [dbo].[ProyectoPlan] AS [t22] ON [t0].[IdProyectoPlan] = ([t22].[IdProyectoPlan])
        LEFT OUTER JOIN [dbo].[PlanPeriodo] AS [t23] ON [t22].[IdPlanPeriodo] = [t23].[IdPlanPeriodo]
        LEFT OUTER JOIN (
            SELECT 1 AS [test], [t24].[IdPlanTipo], [t24].[Sigla]
            FROM [dbo].[PlanTipo] AS [t24]
            ) AS [t25] ON [t23].[IdPlanTipo] = [t25].[IdPlanTipo]
        LEFT OUTER JOIN [dbo].[PlanVersion] AS [t26] ON [t22].[IdPlanVersion] = [t26].[IdPlanVersion]
        LEFT OUTER JOIN [dbo].[Jurisdiccion] AS [t27] ON [t27].[IdJurisdiccion] = [t11].[IdJurisdiccion]
        ) AS [t38]
    WHERE (@CodigoBapin is null AND
		(@IdSubprograma is null or [t38].[IdSubPrograma] = @IdSubprograma) 
		AND (@ProyectoDenominacion is null or [t38].[ProyectoDenominacion] LIKE '%' + @ProyectoDenominacion + '%') 
		AND (@EsBorrador is null or [t38].[EsBorrador] = @EsBorrador) 
		AND ((@FechaModificacionDesde is null and @FechaModificacionHasta is null) or 
		(@FechaModificacionHasta is null and [t38].[FechaModificacion] >= @FechaModificacionDesde) or
		(@FechaModificacionDesde is null and [t38].[FechaModificacion] <= @FechaModificacionHasta) or
		([t38].[FechaModificacion] >= @FechaModificacionDesde AND [t38].[FechaModificacion] <= @FechaModificacionHasta)) 
		AND (@IdEstados is null or [t38].[IdEstado] IN (select valor from dbo.parser(@IdEstados))) 
		AND (@Activo is null or @Activo = [t38].[Activo])
		AND (@IdJurisdiccion is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t119]
			WHERE ([t119].[IdSubPrograma] = [t38].[IdSubPrograma]) AND (EXISTS(
				SELECT NULL AS [EMPTY]
				FROM [dbo].[Programa] AS [t120]
				WHERE ([t120].[IdPrograma] = [t119].[IdPrograma]) AND (EXISTS(
					SELECT NULL AS [EMPTY]
					FROM [dbo].[Saf] AS [t121]
					WHERE ([t121].[IdSaf] = [t120].[IdSAF]) AND ([t121].[IdJurisdiccion] = @IdJurisdiccion)
					))
				))))
		AND (@IdSaf is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t119]
			WHERE ([t119].[IdSubPrograma] = [t38].[IdSubPrograma]) AND (EXISTS(
				SELECT NULL AS [EMPTY]
				FROM [dbo].[Programa] AS [t120]
				WHERE ([t120].[IdPrograma] = [t119].[IdPrograma]) AND (([t120].[IdSAF]) = @IdSaf)
				))))
		AND (@IdPrograma is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[SubPrograma] AS [t119]
			WHERE ([t119].[IdSubPrograma] = [t38].[IdSubPrograma]) AND (([t119].[IdPrograma]) = @IdPrograma)
			))
		AND (@IdPlanTipo is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanVersion] AS [t120]
			INNER JOIN [dbo].[ProyectoPlan] AS [t121] ON [t120].[IdPlanVersion] = [t121].[IdPlanVersion]
			WHERE ([t121].[IdProyecto] = [t38].[IdProyecto]) AND (([t120].[IdPlanTipo]) = @IdPlanTipo)
			)) 
		AND (@IdPlanPeriodo is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanPeriodo] AS [t122]
			INNER JOIN [dbo].[ProyectoPlan] AS [t123] ON [t122].[IdPlanPeriodo] = [t123].[IdPlanPeriodo]
			WHERE ([t123].[IdProyecto] = [t38].[IdProyecto]) AND (([t122].[IdPlanTipo]) = @IdPlanTipo) AND (([t123].[IdPlanPeriodo]) = @IdPlanPeriodo)
			)) 
		AND (@IdPlanVersion is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[PlanVersion] AS [t124]
			INNER JOIN [dbo].[ProyectoPlan] AS [t125] ON [t124].[IdPlanVersion] = [t125].[IdPlanVersion]
			WHERE ([t125].[IdProyecto] = [t38].[IdProyecto]) AND (([t124].[IdPlanTipo]) = @IdPlanTipo) AND (([t125].[IdPlanPeriodo]) = @IdPlanPeriodo) AND (([t124].[IdPlanVersion]) = @IdPlanVersion)
			)) 
		AND (@IdOficina is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[ProyectoOficinaPerfil] AS [t119]
			WHERE ([t119].[IdProyecto] = [t38].[IdProyecto]) AND (@IdOficina = ([t119].[IdOficina]))
			))
		AND (@Oficina is null or EXISTS(
			SELECT NULL AS [EMPTY]
			FROM [dbo].[ProyectoOficinaPerfil] AS [t126]
			INNER JOIN [dbo].[Oficina] AS [t127] ON [t126].[IdOficina] = [t127].[IdOficina]
			WHERE ([t126].[IdProyecto] = [t38].[IdProyecto]) AND ([t127].[BreadcrumbId] LIKE @Oficina)
			))
		) OR 
		([t38].[Codigo] = @CodigoBapin)
    ) AS [t41]
WHERE (@Desde is null and @Hasta is null ) or ([t41].[ROW_NUMBER] BETWEEN @Desde + 1 AND @Desde + @Hasta)
ORDER BY [t41].[Codigo5],
[t41].[Codigo4] ,
[t41].[Codigo3],
[t41].[Codigo2],
[t41].Codigo

--',N'@p0 nvarchar(4000),@p1 nvarchar(4000),@p2 varchar(8000),@p3 int,@p4 varchar(8000),@p5 int,@p6 int,@p7 nchar(1),@p8 nvarchar(4000),@p9 int,@p10 nchar(1),@p11 nvarchar(4000),@p12 int,@p13 nchar(1),@p14 int,@p15 int,@p16 int,@p17 int,@p18 nvarchar(4000),@p19 nvarchar(4000),@p20 nvarchar(4000),@p21 int,@p22 varchar(8000),@p23 int,@p24 int',

GO