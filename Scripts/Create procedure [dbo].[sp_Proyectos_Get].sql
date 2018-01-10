
USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_Get]   Script Date: 12/06/2017 10:18:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Proyectos_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Proyectos_Get]
GO

USE [BAPINIII]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_Get]   Script Date: 12/06/2017 10:18:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--exec [sp_Proyectos_Lista] @IdSubprograma = 44869, @IdSaf = 1671,  @ProyectoDenominacion = '%ddddd%', @EsBorrador = 1, @FechaModificacionDesde = '2017-12-04 00:00:00', @FechaModificacionHasta = '2017-12-29 23:59:59', @IdEstados = '2,3,4', @Activo=1, @IdPlanTipo=5, @IdPlanPeriodo=5, @IdPlanVersion=1, @Oficina='%.127.%'
Create procedure [dbo].[sp_Proyectos_Get]
@IdProyecto int = null

as

declare 
@p1 nvarchar(4000),
@p2 nvarchar(4000),
@p3 varchar(8000),
@p4 int,
@p5 varchar(8000),
@p6 int,
@p7 int,
@p8 nchar(1),
@p9 nvarchar(4000),
@p10 int,
@p11 nchar(1),
@p12 nvarchar(4000),
@p13 int,
@p14 nchar(1),
@p15 int,
@p16 int,
@p17 int,
@p18 int,
@p19 nvarchar(4000),
@p20 nvarchar(4000),
@p21 nvarchar(4000)

SET @p1='-'
SET @p2='-'
SET @p3='AC'
SET @p4=0
SET @p5='OB'
SET @p6=0
SET @p7=2
SET @p8='0'
SET @p9='.'
SET @p10=2
SET @p11='0'
SET @p12='.'
SET @p13=2
SET @p14='0'
SET @p15=38
SET @p16=0
SET @p17=38
SET @p18=0
SET @p19=''
SET @p20=''
SET @p21=''

SELECT [t0].[IdProyecto], [t0].[IdTipoProyecto], [t0].[IdSubPrograma], [t0].[Codigo], [t0].[ProyectoDenominacion], [t0].[ProyectoSituacionActual], [t0].[ProyectoDescripcion], [t0].[ProyectoObservacion], [t0].[IdEstado], [t0].[IdProceso], [t0].[IdModalidadContratacion], [t0].[IdFinalidadFuncion], [t0].[IdOrganismoPrioridad], [t0].[SubPrioridad], [t0].[EsBorrador], [t0].[EsProyecto], [t0].[NroProyecto], [t0].[AnioCorriente], [t0].[FechaInicioEjecucionCalculada], [t0].[FechaFinEjecucionCalculada], [t0].[FechaAlta], [t0].[FechaModificacion], [t0].[IdUsuarioModificacion], [t0].[IdProyectoPlan], [t0].[EvaluarValidaciones], [t0].[Activo], [t0].[IdEstadoDeDesicion], [t1].[Nombre] AS [Estado_Nombre], 
    (CASE 
        WHEN [t5].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t5].[Nombre])
        ELSE NULL
     END) AS [Proceso_Nombre], [t8].[Nombre] AS [TipoProyecto_Nombre], [t9].[Codigo] AS [SubPrograma_Codigo], [t9].[Nombre] AS [SubPrograma_Nombre], 
    (CASE 
        WHEN [t17].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t17].[Nombre])
        ELSE NULL
     END) AS [ModalidadContratacion_Nombre], 
    (CASE 
        WHEN [t19].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t19].[DescripcionInvertida])
        ELSE NULL
     END) AS [FinalidadFuncion_DescripcionInvertida], 
    (CASE 
        WHEN [t19].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t19].[BreadcrumbCode])
        ELSE NULL
     END) AS [FinalidadFuncion_BreadcrumbCode], 
    (CASE 
        WHEN [t3].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),[t3].[Nombre])
        ELSE NULL
     END) AS [OrganismoPrioridad_Nombre], [t11].[IdSaf] AS [IdSAF], [t10].[IdPrograma], 
    (CASE 
        WHEN ([t7].[test] IS NOT NULL) AND ([t7].[ReqDictamen] = 1) THEN 1
        WHEN NOT (([t7].[test] IS NOT NULL) AND ([t7].[ReqDictamen] = 1)) THEN 0
        ELSE NULL
     END) AS [RequiereDictamen], [t10].[Nombre] AS [Programa_Nombre], [t10].[Codigo] AS [Programa_Codigo], [t11].[Denominacion] AS [Saf_Nombre], [t11].[Codigo] AS [Saf_Codigo], [t27].[Nombre] AS [Jurisdiccion_Nombre], [t27].[Codigo] AS [Jurisdiccion_Codigo], 
    (CASE 
        WHEN [t25].[test] IS NOT NULL THEN CONVERT(NVarChar(MAX),((([t25].[Sigla] + @p1) + [t23].[Nombre]) + @p2) + [t26].[Nombre])
        ELSE NULL
     END) AS [Plan_Ultimo], (
    SELECT TOP (1) [t33].[value]
    FROM (
        SELECT ((((
            (CASE 
                WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t0].[NroProyecto])) / 2)) >= @p7 THEN CONVERT(NVarChar,[t0].[NroProyecto])
                ELSE REPLICATE(@p8, @p7 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t0].[NroProyecto])) / 2))) + (CONVERT(NVarChar,[t0].[NroProyecto]))
             END)) + @p9) + (
            (CASE 
                WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value])) / 2)) >= @p10 THEN CONVERT(NVarChar,[t32].[value])
                ELSE REPLICATE(@p11, @p10 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value])) / 2))) + (CONVERT(NVarChar,[t32].[value]))
             END))) + @p12) + (
            (CASE 
                WHEN (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value2])) / 2)) >= @p13 THEN CONVERT(NVarChar,[t32].[value2])
                ELSE REPLICATE(@p14, @p13 - (CONVERT(Int,DATALENGTH(CONVERT(NVarChar,[t32].[value2])) / 2))) + (CONVERT(NVarChar,[t32].[value2]))
             END)) AS [value]
        FROM (
            SELECT MAX([t31].[value]) AS [value], MAX([t31].[value2]) AS [value2]
            FROM (
                SELECT [t28].[IdProyecto], 
                    (CASE 
                        WHEN ([t29].[Codigo] = @p3) AND ([t28].[NroEtapa] IS NOT NULL) THEN [t28].[NroEtapa]
                        ELSE @p4
                     END) AS [value], 
                    (CASE 
                        WHEN ([t29].[Codigo] = @p5) AND ([t28].[NroEtapa] IS NOT NULL) THEN [t28].[NroEtapa]
                        ELSE @p6
                     END) AS [value2]
                FROM [dbo].[ProyectoEtapa] AS [t28]
                INNER JOIN [dbo].[Etapa] AS [t29] ON [t28].[IdEtapa] = [t29].[IdEtapa]
                INNER JOIN [dbo].[Fase] AS [t30] ON [t29].[IdFase] = [t30].[IdFase]
                ) AS [t31]
            WHERE [t31].[IdProyecto] = [t0].[IdProyecto]
            GROUP BY [t31].[IdProyecto]
            ) AS [t32]
        ) AS [t33]
    ) AS [Apertura], 
    (CASE 
        WHEN ((
            SELECT COUNT(*)
            FROM [dbo].[ProyectoCalidad] AS [t35]
            WHERE ([t35].[IdProyecto] = [t0].[IdProyecto]) AND ([t35].[IdEstado] = @p15)
            )) <> @p16 THEN 1
        WHEN NOT (((
            SELECT COUNT(*)
            FROM [dbo].[ProyectoCalidad] AS [t35]
            WHERE ([t35].[IdProyecto] = [t0].[IdProyecto]) AND ([t35].[IdEstado] = @p15)
            )) <> @p16) THEN 0
        ELSE NULL
     END) AS [value], 
    (CASE 
        WHEN ((
            SELECT COUNT(*)
            FROM [dbo].[ProyectoCalidad] AS [t37]
            WHERE ([t37].[IdProyecto] = [t0].[IdProyecto]) AND ([t37].[IdEstado] = @p17)
            )) <> @p18 THEN 1
        WHEN NOT (((
            SELECT COUNT(*)
            FROM [dbo].[ProyectoCalidad] AS [t37]
            WHERE ([t37].[IdProyecto] = [t0].[IdProyecto]) AND ([t37].[IdEstado] = @p17)
            )) <> @p18) THEN 0
        ELSE NULL
     END) AS [CalidadACorregir], 
    (CASE 
        WHEN [t13].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t13].[Nombre])
        ELSE CONVERT(NVarChar(50),@p19)
     END) AS [Saf_SectorNombre], 
    (CASE 
        WHEN [t15].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t15].[Nombre])
        ELSE CONVERT(NVarChar(50),@p20)
     END) AS [Saf_AdministracionTipoNombre], 
    (CASE 
        WHEN [t21].[test] IS NOT NULL THEN CONVERT(NVarChar(50),[t21].[Nombre])
        ELSE CONVERT(NVarChar(50),@p21)
     END) AS [Saf_EntidadTipoNombre]
FROM [dbo].[Proyecto] AS [t0]
INNER JOIN [dbo].[Estado] AS [t1] ON [t0].[IdEstado] = [t1].[IdEstado]
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
WHERE ([t0].[IdProyecto]) = @IdProyecto