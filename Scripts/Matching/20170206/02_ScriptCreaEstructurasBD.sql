USE [bapin]
GO
/****** Object:  Table [dbo].[Matching_Config]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_Config]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_Config](
	[Activo] [bit] NOT NULL,
	[IdPlanPeriodo] [int] NOT NULL,
	[Sigla] [varchar](20) NOT NULL,
	[AnioInicial] [int] NOT NULL,
	[AnioFinal] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_InfoPresupuestoAgrupado]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_InfoPresupuestoAgrupado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_InfoPresupuestoAgrupado](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[EjercicioPresupuestario] [int] NULL,
	[MesSidif] [nvarchar](2) NULL,
	[CodJurisdiccion] [nvarchar](10) NULL,
	[Jurisdiccion] [nvarchar](255) NULL,
	[CodSAF] [nvarchar](10) NULL,
	[SAF] [nvarchar](255) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[Programa] [nvarchar](255) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[Subprograma] [nvarchar](255) NULL,
	[CodProyecto] [nvarchar](10) NULL,
	[Proyecto] [nvarchar](255) NULL,
	[CodActividad] [nvarchar](10) NULL,
	[Actividad] [nvarchar](255) NULL,
	[CodObra] [nvarchar](10) NULL,
	[Obra] [nvarchar](255) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL,
	[AperturaPresupuestariaSeparada] [nvarchar](32) NULL,
	[CreditoInicial] [float] NULL,
	[CreditoVigente] [float] NULL,
	[Devengado] [float] NULL,
	[Pagado] [float] NULL
) ON [FG]
END
GO
/****** Object:  View [dbo].[vw_Matching_ProyectosBapinesMarcaPlan_SinSidif]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_Matching_ProyectosBapinesMarcaPlan_SinSidif]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vw_Matching_ProyectosBapinesMarcaPlan_SinSidif]
AS
SELECT        IdProyecto, ProyectoDenominacion, ProyectoDescripcion, CodigoProyectoBAPIN, CodigoJurisdiccion, Nombre, IdJurisdiccion, IdSaf, CodigoSAF, SAF_Denominacion, CodigoPrograma, Programa, 
                         CodigoSubprograma, SubPrograma, ProgramaEnSubPrograma, NroProyecto, AperturaProgramatica, MesAnio, Anio, Mes, AperturaProgramaticaSeparada
FROM            (SELECT        pr.IdProyecto, pr.ProyectoDenominacion, pr.ProyectoDescripcion, pr.Codigo AS CodigoProyectoBAPIN, jr.Codigo AS CodigoJurisdiccion, jr.Nombre, dbo.Saf.IdJurisdiccion, dbo.Saf.IdSaf, 
                                                    dbo.Saf.Codigo AS CodigoSAF, dbo.Saf.Denominacion AS SAF_Denominacion, pro.Codigo AS CodigoPrograma, pro.Nombre AS Programa, sp.Codigo AS CodigoSubprograma, 
                                                    sp.Nombre AS SubPrograma, sp.IdPrograma AS ProgramaEnSubPrograma, CASE WHEN LEN(CAST(pr.NroProyecto AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(pr.NroProyecto AS nvarchar(10)) 
                                                    AS nvarchar(10)) ELSE CAST(pr.NroProyecto AS nvarchar(10)) END AS NroProyecto, CASE WHEN LEN(CAST(jr.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(jr.Codigo AS nvarchar(10)) 
                                                    AS nvarchar(10)) ELSE CAST(jr.Codigo AS nvarchar(10)) END + CASE WHEN LEN(CAST(Saf.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(Saf.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(Saf.Codigo AS nvarchar(10)) END + CASE WHEN LEN(CAST(pro.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(pro.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(pro.Codigo AS nvarchar(10)) END + CASE WHEN LEN(CAST(sp.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(sp.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(sp.Codigo AS nvarchar(10)) END AS AperturaProgramatica, CAST(YEAR(GETDATE()) AS varchar(4)) + CAST(MONTH(GETDATE()) - 1 AS varchar(4)) AS MesAnio, YEAR(GETDATE()) AS Anio, 
                                                    CAST(MONTH(GETDATE()) - 1 AS nvarchar(2)) AS Mes, CASE WHEN LEN(CAST(jr.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(jr.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(jr.Codigo AS nvarchar(10)) END + ''.'' + CASE WHEN LEN(CAST(Saf.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(Saf.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(Saf.Codigo AS nvarchar(10)) END + ''.'' + CASE WHEN LEN(CAST(pro.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(pro.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(pro.Codigo AS nvarchar(10)) END + ''.'' + CASE WHEN LEN(CAST(sp.Codigo AS nvarchar(10))) = 1 THEN CAST(''0'' + CAST(sp.Codigo AS nvarchar(10)) AS nvarchar(10)) 
                                                    ELSE CAST(sp.Codigo AS nvarchar(10)) END AS AperturaProgramaticaSeparada
                          FROM            dbo.Proyecto AS pr LEFT OUTER JOIN
                                                    dbo.SubPrograma AS sp ON pr.IdSubPrograma = sp.IdSubPrograma LEFT OUTER JOIN
                                                    dbo.Programa AS pro ON pro.IdPrograma = sp.IdPrograma LEFT OUTER JOIN
                                                    dbo.Saf ON dbo.Saf.IdSaf = pro.IdSAF LEFT OUTER JOIN
                                                    dbo.Jurisdiccion AS jr ON jr.IdJurisdiccion = dbo.Saf.IdJurisdiccion
                          WHERE        (pr.IdProyecto IN
                                                        (SELECT        IdProyecto
                                                          FROM            dbo.ProyectoPlan
                                                          WHERE        (IdPlanPeriodo IN
                                                                                        (SELECT        IdPlanPeriodo
                                                                                          FROM            dbo.Matching_Config))))) AS T
WHERE        (AperturaProgramatica NOT IN
                             (SELECT DISTINCT AperturaProgramatica
                               FROM            dbo.Matching_InfoPresupuestoAgrupado))
' 
GO
/****** Object:  Table [dbo].[Matching_ImportSidif]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_ImportSidif]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_ImportSidif](
	[Ejercicio Presupuestario] [int] NULL,
	[Cod# 3 Dígitos] [int] NULL,
	[Desc# 3 Dígitos] [nvarchar](255) NULL,
	[Cod# Jurisdicción] [int] NULL,
	[Desc# Jurisdicción] [nvarchar](255) NULL,
	[Cod# Servicio] [int] NULL,
	[Desc# Larga Servicio] [nvarchar](255) NULL,
	[Cod# Programa] [int] NULL,
	[Desc# Programa] [nvarchar](255) NULL,
	[Cod# Subprograma] [int] NULL,
	[Desc# Subprograma] [nvarchar](255) NULL,
	[Cod# Proyecto] [int] NULL,
	[Desc# Proyecto] [nvarchar](255) NULL,
	[Cod# Actividad] [int] NULL,
	[Desc# Actividad] [nvarchar](255) NULL,
	[Cod# Obra] [int] NULL,
	[Desc# Obra] [nvarchar](255) NULL,
	[Cod# Procedencia] [int] NULL,
	[Desc# Procedencia] [nvarchar](255) NULL,
	[Cod# Fuente] [int] NULL,
	[Desc# Fuente] [nvarchar](255) NULL,
	[Cod# Inciso] [int] NULL,
	[Desc# Inciso] [nvarchar](255) NULL,
	[Cod# Principal] [int] NULL,
	[Desc# Principal] [nvarchar](255) NULL,
	[Cod# Parcial] [int] NULL,
	[Desc# Parcial] [nvarchar](255) NULL,
	[Cod# Subparcial] [int] NULL,
	[Desc# Subparcial] [nvarchar](255) NULL,
	[Desc# Finalidad] [nvarchar](255) NULL,
	[Cod# Finalidad] [int] NULL,
	[Cod# Función] [int] NULL,
	[Desc# Función] [nvarchar](255) NULL,
	[Cod# Ubicación Geográfica] [int] NULL,
	[Desc# Ubicación Geográfica] [nvarchar](255) NULL,
	[$Cred# Inicial] [float] NULL,
	[$Cred# Vigente] [float] NULL,
	[$Devengado] [float] NULL,
	[$Pagado] [float] NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_InfoPresupuesto]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_InfoPresupuesto]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_InfoPresupuesto](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[EjercicioPresupuestario] [int] NULL,
	[MesSidif] [nvarchar](2) NULL,
	[CodTipo] [int] NULL,
	[Tipo] [nvarchar](255) NULL,
	[CodJurisdiccion] [nvarchar](10) NULL,
	[Jurisdiccion] [nvarchar](255) NULL,
	[CodSAF] [nvarchar](10) NULL,
	[SAF] [nvarchar](255) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[Programa] [nvarchar](255) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[Subprograma] [nvarchar](255) NULL,
	[CodProyecto] [nvarchar](10) NULL,
	[Proyecto] [nvarchar](255) NULL,
	[CodActividad] [nvarchar](10) NULL,
	[Actividad] [nvarchar](255) NULL,
	[CodObra] [nvarchar](10) NULL,
	[Obra] [nvarchar](255) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[AperturaPresupuestariaSeparada] [nvarchar](32) NULL,
	[SidifPeriodo] [nvarchar](6) NULL,
	[CodProcedencia] [int] NULL,
	[Procedencia] [nvarchar](255) NULL,
	[CodFuenteFinanciamiento] [int] NULL,
	[FuenteFinanciamiento] [nvarchar](255) NULL,
	[CodInciso] [int] NULL,
	[Inciso] [nvarchar](255) NULL,
	[CodPrincipal] [int] NULL,
	[Principal] [nvarchar](255) NULL,
	[CodParcial] [int] NULL,
	[Parcial] [nvarchar](255) NULL,
	[CodSubparcial] [int] NULL,
	[SubParcial] [nvarchar](255) NULL,
	[CodFinalidad] [nvarchar](255) NULL,
	[Finalidad] [int] NULL,
	[CodFuncion] [int] NULL,
	[Funcion] [nvarchar](255) NULL,
	[CodUbiGeo] [int] NULL,
	[UbiGeo] [nvarchar](255) NULL,
	[CredInicial] [float] NULL,
	[CredVigente] [float] NULL,
	[Devengado] [float] NULL,
	[Pagado] [float] NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_Log]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_Log](
	[IDOperacion] [uniqueidentifier] NOT NULL,
	[Descripcion] [nvarchar](200) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Matching_Log] PRIMARY KEY CLUSTERED 
(
	[IDOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FG]
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_ProyectosVinculados]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_ProyectosVinculados]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_ProyectosVinculados](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[EjercicioPresupuestario] [int] NULL,
	[MesSidif] [nvarchar](2) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[CreditoInicial] [float] NULL,
	[CreditoVigente] [float] NULL,
	[Pagado] [float] NULL,
	[Devengado] [float] NULL,
	[CodigoProyectoBAPIN] [int] NULL,
	[ProyectoDenominacion] [varchar](500) NULL,
	[Estimado] [money] NULL,
	[Realizado] [money] NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL,
	[AperturaPresupuestariaSeparada] [nvarchar](32) NULL,
	[CodJurisdiccion] [nvarchar](10) NULL,
	[CodSAF] [nvarchar](10) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[ProyectoND] [nvarchar](200) NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_ProyectosVinculadosND]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_ProyectosVinculadosND]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_ProyectosVinculadosND](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[EjercicioPresupuestario] [int] NULL,
	[MesSidif] [nvarchar](2) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[CreditoInicial] [float] NULL,
	[CreditoVigente] [float] NULL,
	[Pagado] [float] NULL,
	[Devengado] [float] NULL,
	[Estimado] [money] NULL,
	[Realizado] [money] NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL,
	[AperturaPresupuestariaSeparada] [nvarchar](32) NULL,
	[CodJurisdiccion] [nvarchar](10) NULL,
	[CodSAF] [nvarchar](10) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[ProyectoND] [nvarchar](200) NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_RegistroActualizacionProceso]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_RegistroActualizacionProceso]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_RegistroActualizacionProceso](
	[IDOperacion] [uniqueidentifier] NOT NULL,
	[Observaciones] [nvarchar](300) NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Matching_RegistroActualizacionProceso] PRIMARY KEY CLUSTERED 
(
	[IDOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [FG]
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_SidifProcesado]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_SidifProcesado]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_SidifProcesado](
	[CodJurisdiccion] [nvarchar](10) NULL,
	[Jurisdiccion] [nvarchar](255) NULL,
	[CodSaf] [nvarchar](10) NULL,
	[SAF] [nvarchar](255) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[Programa] [nvarchar](255) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[Subprograma] [nvarchar](255) NULL,
	[CodProyecto] [nvarchar](10) NULL,
	[Proyecto] [nvarchar](255) NULL,
	[CodActividad] [nvarchar](10) NULL,
	[Actividad] [nvarchar](255) NULL,
	[CodObra] [nvarchar](10) NULL,
	[Obra] [nvarchar](255) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[SidifDevengado] [float] NULL,
	[SidifPagado] [float] NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_tmpCandidatosND]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_tmpCandidatosND]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_tmpCandidatosND](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[BapinND] [nvarchar](max) NULL
) ON [FG] TEXTIMAGE_ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_tmpGastosBapin]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_tmpGastosBapin]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_tmpGastosBapin](
	[IdProyecto] [int] NOT NULL,
	[IdProyectoEtapa] [int] NOT NULL,
	[IdEtapa] [int] NOT NULL,
	[NroEtapa] [int] NULL,
	[Nombre] [varchar](500) NOT NULL,
	[Estimado] [money] NULL,
	[Realizado] [money] NULL,
	[ActividadObra] [nvarchar](12) NULL,
	[ActividadObraSeparada] [nvarchar](13) NULL,
	[PeriodoRealizado] [int] NULL,
	[PeriodoEstimado] [int] NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_tmpImportSidif]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_tmpImportSidif]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_tmpImportSidif](
	[Ejercicio Presupuestario] [int] NULL,
	[Cod# 3 Dígitos] [int] NULL,
	[Desc# 3 Dígitos] [nvarchar](255) NULL,
	[Cod# Jurisdicción] [int] NULL,
	[Desc# Jurisdicción] [nvarchar](255) NULL,
	[Cod# Servicio] [int] NULL,
	[Desc# Larga Servicio] [nvarchar](255) NULL,
	[Cod# Programa] [int] NULL,
	[Desc# Programa] [nvarchar](255) NULL,
	[Cod# Subprograma] [int] NULL,
	[Desc# Subprograma] [nvarchar](255) NULL,
	[Cod# Proyecto] [int] NULL,
	[Desc# Proyecto] [nvarchar](255) NULL,
	[Cod# Actividad] [int] NULL,
	[Desc# Actividad] [nvarchar](255) NULL,
	[Cod# Obra] [int] NULL,
	[Desc# Obra] [nvarchar](255) NULL,
	[Cod# Procedencia] [int] NULL,
	[Desc# Procedencia] [nvarchar](255) NULL,
	[Cod# Fuente] [int] NULL,
	[Desc# Fuente] [nvarchar](255) NULL,
	[Cod# Inciso] [int] NULL,
	[Desc# Inciso] [nvarchar](255) NULL,
	[Cod# Principal] [int] NULL,
	[Desc# Principal] [nvarchar](255) NULL,
	[Cod# Parcial] [int] NULL,
	[Desc# Parcial] [nvarchar](255) NULL,
	[Cod# Subparcial] [int] NULL,
	[Desc# Subparcial] [nvarchar](255) NULL,
	[Desc# Finalidad] [nvarchar](255) NULL,
	[Cod# Finalidad] [int] NULL,
	[Cod# Función] [int] NULL,
	[Desc# Función] [nvarchar](255) NULL,
	[Cod# Ubicación Geográfica] [int] NULL,
	[Desc# Ubicación Geográfica] [nvarchar](255) NULL,
	[$Cred# Inicial] [float] NULL,
	[$Cred# Vigente] [float] NULL,
	[$Devengado] [float] NULL,
	[$Pagado] [float] NULL
) ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_tmpProyectosCandidatos]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_tmpProyectosCandidatos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_tmpProyectosCandidatos](
	[IdProyecto] [int] NOT NULL,
	[ProyectoDenominacion] [varchar](500) NOT NULL,
	[ProyectoDescripcion] [varchar](max) NULL,
	[CodigoProyectoBAPIN] [int] NOT NULL,
	[CodigoJurisdiccion] [varchar](15) NULL,
	[Nombre] [varchar](120) NULL,
	[IdJurisdiccion] [int] NULL,
	[IdSaf] [int] NULL,
	[CodigoSAF] [varchar](5) NULL,
	[SAF_Denominacion] [varchar](255) NULL,
	[CodigoPrograma] [varchar](3) NULL,
	[Programa] [varchar](255) NULL,
	[CodigoSubprograma] [varchar](3) NULL,
	[SubPrograma] [varchar](255) NULL,
	[ProgramaEnSubPrograma] [int] NULL,
	[NroProyecto] [nvarchar](10) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[MesAnio] [varchar](8) NULL,
	[Anio] [int] NULL,
	[Mes] [nvarchar](2) NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL
) ON [FG] TEXTIMAGE_ON [FG]
END
GO
/****** Object:  Table [dbo].[Matching_tmpProyectosVinculadosND]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matching_tmpProyectosVinculadosND]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Matching_tmpProyectosVinculadosND](
	[IdentificadorProyectoSidif] [nvarchar](76) NULL,
	[EjercicioPresupuestario] [int] NULL,
	[MesSidif] [nvarchar](2) NULL,
	[AperturaProgramatica] [nvarchar](40) NULL,
	[AperturaPresupuestaria] [nvarchar](30) NULL,
	[CreditoInicial] [float] NULL,
	[CreditoVigente] [float] NULL,
	[Pagado] [float] NULL,
	[Devengado] [float] NULL,
	[Estimado] [money] NULL,
	[Realizado] [money] NULL,
	[AperturaProgramaticaSeparada] [nvarchar](43) NULL,
	[AperturaPresupuestariaSeparada] [nvarchar](32) NULL,
	[CodJurisdiccion] [nvarchar](10) NULL,
	[CodSAF] [nvarchar](10) NULL,
	[CodPrograma] [nvarchar](10) NULL,
	[CodSubprograma] [nvarchar](10) NULL,
	[ProyectoND] [nvarchar](200) NULL
) ON [FG]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF__Matching___Fecha__66361833]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Matching_RegistroActualizacionProceso] ADD  DEFAULT (getdate()) FOR [FechaActualizacion]
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Config_AgregarPeriodo]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Config_AgregarPeriodo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Config_AgregarPeriodo] AS' 
END
GO


ALTER PROCEDURE [dbo].[sp_Matching_Config_AgregarPeriodo] @intIdPlanPeriodo integer
/*Procedimiento  que permite agregar un plan periodo al configurador para ser considerasao en el procesamiento de datos de Matching */
as
INSERT INTO Matching_Config
select pp.Activo,pp.IdPlanPeriodo,pp.Sigla,pp.AnioInicial,pp.AnioFinal,pt.Nombre from PlanPeriodo pp inner join PlanTipo pt on pp.IdPlanTipo=pt.IdPlanTipo where pp.IdPlanPeriodo not in (select IdPlanPeriodo from Matching_Config)
and pp.IdPlanPeriodo=@intIdPlanPeriodo


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Config_QuitarPeriodo]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Config_QuitarPeriodo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Config_QuitarPeriodo] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_Config_QuitarPeriodo] @intIdPlanPeriodo integer
/*Procedimiento  que permite quitar un plan periodo del configurador y que no será considerado en el procesamiento de datos de Matching */
as
DELETE FROM Matching_Config 
WHERE IdPlanPeriodo=@intIdPlanPeriodo
GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_DesvincularProyecto]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_DesvincularProyecto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_DesvincularProyecto] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_DesvincularProyecto]  @IdentificadorUnico nvarchar(100), @intIdUsuario int 
/*
Procedimiento para realizar la desvinculación manual de un proyecto
Para ello elimina el registro de la tabla Matching_ProyectosVinculados
Y luego indica quién ha sido el usuario que ha realizado la operación
*/
AS

--Elimina el proyecto de MatchingVinculado
BEGIN TRAN
Delete from Matching_ProyectosVinculados where IdentificadorProyectoSidif=@IdentificadorUnico;

--Relizo la búsqueda del usuario
DECLARE @Usuario nvarchar(100)
SET @Usuario= (Select NombreUsuario from Usuario where IdUsuario=@intIdUsuario)
DECLARE @Observaciones nvarchar(200)
SET @Observaciones= 'Desvinculación Proyecto: ' + @IdentificadorUnico 


--Guardo la acción del usuario
Exec [sp_Matching_LogAccionesUsuario] @Observaciones, @intIdUsuario,@Usuario
COMMIT TRAN


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_AperturaPresupuestaria]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_AperturaPresupuestaria]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_AperturaPresupuestaria] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_Filtro_AperturaPresupuestaria] @intIdJurisdic int, @intIdSAF int, @intIdPro int, @intIdSubPro int
AS
/*Proceso para la genearación de AperturaPresupuestaria de acuerdo a los valores del filtro selectados en la pantalla Principal*/
DECLARE @CodJurisdiccion nvarchar(10), @CodSaf nvarchar(10), @CodPrograma nvarchar(10), @CodSubprograma nvarchar(10), @AperturaProgramatica nvarchar(100)

SET @CodJurisdiccion=(SELECT CASE WHEN LEN(CAST(Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Codigo as nvarchar(10)) END FROM Jurisdiccion WHERE IdJurisdiccion=@intIdJurisdic)
SET @CodSaf=(SELECT CASE WHEN LEN(CAST(Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Codigo as nvarchar(10)) END FROM Saf WHERE IdSaf=@intIdSAF)
SET @CodPrograma=(SELECT CASE WHEN LEN(CAST(Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Codigo as nvarchar(10)) END FROM Programa WHERE IdPrograma=@intIdPro)
SET @CodSubprograma=(SELECT CASE WHEN LEN(CAST(Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Codigo as nvarchar(10)) END FROM SubPrograma WHERE IdSubPrograma=@intIdSubPro)

SET @AperturaProgramatica=ISNULL(@CodJurisdiccion,'')+ISnull(@CodSaf,'')+ISNULL(@CodPrograma,'')+ISNULL(@CodSubprograma,'')
SELECT @AperturaProgramatica as AperturaPresupuestaria



GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_Jurisdiccion]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_Jurisdiccion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_Jurisdiccion] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_Matching_Filtro_Jurisdiccion] 
AS
SELECT IdJurisdiccion, Codigo, (cast (Codigo as nvarchar (100) ) + ' - ' + Nombre) as Descripcion  
FROM Jurisdiccion WHERE Activo=1



GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_NoVinculado_Jurisdiccion]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_NoVinculado_Jurisdiccion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_NoVinculado_Jurisdiccion] AS' 
END
GO
ALTER PROCEDURE  [dbo].[sp_Matching_Filtro_NoVinculado_Jurisdiccion]
/*Filtro de Jurisdicción para la sección Proyectos No Vinculados*/
AS
SELECT Distinct  CodJurisdiccion, CodJurisdiccion + ' - ' + Jurisdiccion as Descripcion from Matching_InfoPresupuestoAgrupado order by 1


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_NoVinculado_Programa]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_NoVinculado_Programa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_NoVinculado_Programa] AS' 
END
GO
ALTER PROCEDURE  [dbo].[sp_Matching_Filtro_NoVinculado_Programa] @CodSAF nvarchar(10)
/*Filtro de Programa para la sección Proyectos No Vinculados*/
AS

SELECT Distinct  CodPrograma, CodPrograma + ' - ' + Programa as Descripcion from Matching_InfoPresupuestoAgrupado 
WHERE CodSAF=@CodSAF 
ORDER BY 1


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_NoVinculado_SAF]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_NoVinculado_SAF]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_NoVinculado_SAF] AS' 
END
GO
ALTER PROCEDURE  [dbo].[sp_Matching_Filtro_NoVinculado_SAF] @CodJurisdiccion nvarchar(10)
/*Filtro de Jurisdicción para la sección Proyectos No Vinculados*/
AS
SELECT Distinct  CodSAF, CodSAF + ' - ' + SAF as Descripcion from Matching_InfoPresupuestoAgrupado 
where CodJurisdiccion=@CodJurisdiccion
order by 1


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_NoVinculado_SubPrograma]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_NoVinculado_SubPrograma]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_NoVinculado_SubPrograma] AS' 
END
GO
ALTER PROCEDURE  [dbo].[sp_Matching_Filtro_NoVinculado_SubPrograma] @CodPrograma nvarchar(10)
/*Filtro de SubPrograma para la sección Proyectos No Vinculados*/
AS

SELECT Distinct  CodSubprograma, CodSubprograma + ' - ' + Subprograma as Descripcion from Matching_InfoPresupuestoAgrupado 
WHERE CodPrograma=@CodPrograma
ORDER BY 1


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_Programa]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_Programa]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_Programa] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_Filtro_Programa] @CodSaf nvarchar(10)
AS
--Procedimiento para Traer los datos de Programa de acuerdo al SAF
DECLARE @intIDSaf integer
SET @intIDSaf=(select IdSaf from SAF where Codigo=@CodSaf)


SELECT IdPrograma, Codigo, (CAST (Codigo as nvarchar(100)) + ' - ' + Nombre) as Descripcion FROM PROGRAMA 
WHERE IdSaf =@intIDSaf and Activo=1



GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_SAF]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_SAF]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_SAF] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_Matching_Filtro_SAF] @intIdJurisdiccion nvarchar(10)
AS
--Procedimiento para Traer los datos de SAF de acuerdo a la jursidicción
SELECT IdSaf,Codigo, (CAST (Codigo as nvarchar (100) )+ ' - ' +  Denominacion) as Descripcion FROM SAF 
WHERE IdJurisdiccion in (SELECT IdJurisdiccion from Jurisdiccion
 where Codigo=@intIdJurisdiccion) and Activo=1





GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_Filtro_SubPrograma]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_Filtro_SubPrograma]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_Filtro_SubPrograma] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_Filtro_SubPrograma] @CodPrograma nvarchar(10), @CodSAF nvarchar(10)
AS
--Procedimiento para Traer los datos de Subprograma de acuerdo al Programa
DECLARE @intIdSAF integer
DECLARE @intPrograma integer
SET @intIdSAF=(select IdSaf from SAF where Codigo=@CodSaf)
SET @intPrograma=(Select IdPrograma from Programa where Codigo=@CodPrograma and IdSAF=@intIdSAF)

Select IdSubPrograma, Codigo, (Cast (Codigo as nvarchar(100) ) + ' - ' + Nombre) as Descripcion from SubPrograma where 
IdPrograma=@intPrograma and Activo=1




GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_LogAccionesUsuario]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_LogAccionesUsuario]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_LogAccionesUsuario] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_Matching_LogAccionesUsuario] 
/****************************************
Proceso que permite la creación del log de acciones por usuario
*/
@observacion nvarchar(400),@intIdUsuario int, @usuario as nvarchar(50)
AS

INSERT INTO [Matching_Log] VALUES
(NEWID(),@observacion, @intIdUsuario,  @usuario, GETDATE())



GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_LogProceso]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_LogProceso]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_LogProceso] AS' 
END
GO

ALTER PROCEDURE [dbo].[sp_Matching_LogProceso]
/* Proceso de registración de actualizaciones de los datos para utilizar en el cálculo de Matching */
@Estado nvarchar(40)
AS
INSERT INTO  [Matching_RegistroActualizacionProceso] (IDOperacion, Observaciones) values (newid(),@Estado)




GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_ProyectosNoVinculados]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_ProyectosNoVinculados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_ProyectosNoVinculados] AS' 
END
GO
 ALTER PROCEDURE [dbo].[sp_Matching_ProyectosNoVinculados]  @Ejercicio int, @Mes int, @CodJurisdiccion nvarchar(10), @CodSaf nvarchar(10), @CodPrograma  nvarchar(10), @CodSubPrograma nvarchar(10)
/*--Procedimiento que retorna los proyectos que No tienen Matching Automático */
AS
  SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in 
(SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados)
AND MesSidif=@Mes AND EjercicioPresupuestario=@Ejercicio AND CodJurisdiccion=@CodJurisdiccion AND CodSAF=@CodSaf AND CodPrograma=@CodPrograma and CodSubprograma=@CodSubPrograma

GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_ProyectosVinculados]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_ProyectosVinculados]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_ProyectosVinculados] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_ProyectosVinculados]  @Ejercicio int, @Mes int, @AperturaProgramatica nvarchar(40)
/*--Procedimiento que retorna los proyectos que tienen Matching Automático */
AS
SELECT * FROM Matching_ProyectosVinculados
WHERE EjercicioPresupuestario=@Ejercicio AND MesSidif=@Mes
 AND AperturaProgramatica=@AperturaProgramatica


GO
/****** Object:  StoredProcedure [dbo].[sp_Matching_VincularProyecto]    Script Date: 06/02/2017 22:53:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Matching_VincularProyecto]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[sp_Matching_VincularProyecto] AS' 
END
GO
ALTER PROCEDURE [dbo].[sp_Matching_VincularProyecto] @IdentificadorProyectoSidif nvarchar(100), @CodBapin int, @intIdUsuario int
AS
/*Proceso que realiza la vinculación Manual del proyecto por usuario*/
BEGIN TRAN
INSERT INTO Matching_ProyectosVinculados
SELECT Sidif.IdentificadorProyectoSidif, sidif.EjercicioPresupuestario, Sidif.MesSidif,
Sidif.AperturaProgramatica, Sidif.AperturaPresupuestaria, Sidif.CreditoInicial, Sidif.CreditoVigente, Sidif.Pagado, Sidif.Devengado, 
Bapin.CodigoProyectoBAPIN, Bapin.ProyectoDenominacion, Bapin.Estimado, Bapin.Realizado
FROM
	(SELECT * from Matching_InfoPresupuestoAgrupado
		  ) Sidif
		  ,
		  (
	SELECT pc.*,gb.Estimado, gb.Realizado,
	Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as AperturaPresupuestaria,
	pc.AperturaProgramatica + Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as IdentUnico
	FROM Matching_tmpProyectosCandidatos pc INNER JOIN
	Matching_tmpGastosBapin gb on pc.IdProyecto=gb.IdProyecto
	WHERE pc.NroProyecto IS NOT NULL AND gb.ActividadObra IS NOT NULL
	) Bapin 
	WHERE Bapin.CodigoProyectoBAPIN = @CodBapin
	AND Sidif.IdentificadorProyectoSidif=@IdentificadorProyectoSidif


	--Relizo la búsqueda del usuario
DECLARE @Usuario nvarchar(100)
SET @Usuario= (Select NombreUsuario from Usuario where IdUsuario=@intIdUsuario)
DECLARE @Observaciones nvarchar(200)
SET @Observaciones= 'Vincula Proyecto:' + @IdentificadorProyectoSidif + '- Bapin: ' + @Usuario
--Guardo la acción del usuario
Exec [sp_Matching_LogAccionesUsuario] @Observaciones, @intIdUsuario,@Usuario
COMMIT TRAN 


GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vw_Matching_ProyectosBapinesMarcaPlan_SinSidif', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Matching_ProyectosBapinesMarcaPlan_SinSidif'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vw_Matching_ProyectosBapinesMarcaPlan_SinSidif', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Matching_ProyectosBapinesMarcaPlan_SinSidif'
GO
