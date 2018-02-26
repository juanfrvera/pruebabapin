/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxT]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Inicia_CxT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Inicia_CxT]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxT]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Genera_CxT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Genera_CxT]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxT]    Script Date: 11/28/2016 20:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Inicia_CxT]
AS
BEGIN

DECLARE	@return_value int

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxT]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxT]

CREATE TABLE [dbo].[Cubo_CxT](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Incisos] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar] (max) NULL,
	[SAF] [varchar](max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [varchar] (max) NULL,
	[NroActividad] [varchar] (max) NULL,
	[NroObra] [varchar] (max) NULL,
	[Tipo_Presup] [varchar](max) NULL,
	[Ape_PresupActEsp] [varchar] (max) NULL,
	[Es_Presup] [varchar](max) NULL,
	[Estado_Financiero] [varchar](max) NULL,
	[Estado_Fisico] [varchar](max) NULL,
	[Est_Decision] [varchar](max) NULL,
	[PrioridadDNIP] [varchar](max) NULL,
	[Art_15] [varchar] (max) NULL,
	[Req_Dict] [varchar] (max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar] (max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar] (max) NULL,
	[Fecha_UltModificacion] [varchar] (max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar] (max) NULL,
	[Fecha_Fin_Estimada] [varchar] (max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,
	[Finalidad_Función] [varchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Fuente_Finaciamiento_Cod] [varchar](max) NULL,
	[Fuente_Financiamiento_Desc] [varchar](max) NULL,
	[Proceso] [varchar](max) NULL,
	[Sectorialista] [varchar](max) NULL,
	[Com_Tecnico_ECTO] [varchar](max) NULL,
	[Estimados Anteriores] [decimal] (18,0) NULL,
	[Estimado 2012] [decimal] (18,0) NULL,
	[Estimado 2013] [decimal] (18,0) NULL,
	[Estimado 2014] [decimal] (18,0) NULL,
	[Estimado 2015] [decimal] (18,0) NULL,
	[Estimado 2016] [decimal] (18,0) NULL,
	[Estimado 2017] [decimal] (18,0) NULL,
	[Estimado 2018] [decimal] (18,0) NULL,
	[Estimado 2019] [decimal] (18,0) NULL,
	[Estimado 2020] [decimal] (18,0) NULL,
	[Estimado Posteriores] [decimal] (18,0) NULL,
	[Estimado Total] [decimal] (18,0) NULL,
	[Realizados Anteriores] [decimal] (18,0) NULL,
	[Realizado 2012] [decimal] (18,0) NULL,
	[Realizado 2013] [decimal] (18,0) NULL,
	[Realizado 2014] [decimal] (18,0) NULL,
	[Realizado 2015] [decimal] (18,0) NULL,
	[Realizado 2016] [decimal] (18,0) NULL,
	[Realizado 2017] [decimal] (18,0) NULL,
	[Realizado 2018] [decimal] (18,0) NULL,
	[Realizado 2019] [decimal] (18,0) NULL,
	[Realizado 2020] [decimal] (18,0) NULL,
	[Realizado Posteriores] [decimal] (18,0) NULL,
	[Realizado Total] [decimal] (18,0) NULL,
	[Costo Total Actual] [decimal] (18,0) NULL,
	[ONP 2003] [decimal] (18,0) NULL,
	[ONP 2004] [decimal] (18,0) NULL,
	[ONP 2005] [decimal] (18,0) NULL,
	[ONP 2006] [decimal] (18,0) NULL,
	[ONP 2007] [decimal] (18,0) NULL,
	[ONP 2008] [decimal] (18,0) NULL,
	[ONP 2009] [decimal] (18,0) NULL,
	[ONP 2010] [decimal] (18,0) NULL,
	[ONP 2011] [decimal] (18,0) NULL,
	[ONP 2012] [decimal] (18,0) NULL,
	[ONP 2013] [decimal] (18,0) NULL,
	[ONP 2014] [decimal] (18,0) NULL,
	[ONP 2015] [decimal] (18,0) NULL,
	[ONP 2016] [decimal] (18,0) NULL,
	[ONP 2017] [decimal] (18,0) NULL,
	[ONP 2018] [decimal] (18,0) NULL,
	[ONP 2019] [decimal] (18,0) NULL,
	[ONP 2020] [decimal] (18,0) NULL,
	[ONP 2021] [decimal] (18,0) NULL,
	[ONP 2022] [decimal] (18,0) NULL,
	[ONP 2023] [decimal] (18,0) NULL,
	[ONP 2024] [decimal] (18,0) NULL,
	[ONP 2025] [decimal] (18,0) NULL,
	[Generado] [varchar] (max) NULL,	
	[MontoInicial Anteriores] [decimal] (18,0) NULL,
	[MontoInicial 2012] [decimal] (18,0) NULL,
	[MontoInicial 2013] [decimal] (18,0) NULL,
	[MontoInicial 2014] [decimal] (18,0) NULL,
	[MontoInicial 2015] [decimal] (18,0) NULL,
	[MontoInicial 2016] [decimal] (18,0) NULL,
	[MontoInicial 2017] [decimal] (18,0) NULL,
	[MontoInicial 2018] [decimal] (18,0) NULL,
	[MontoInicial 2019] [decimal] (18,0) NULL,
	[MontoInicial 2020] [decimal] (18,0) NULL,
	[MontoInicial Posteriores] [decimal] (18,0) NULL,
	[MontoInicial Total] [decimal] (18,0) NULL,
	[MontoVigente Anteriores] [decimal] (18,0) NULL,
	[MontoVigente 2012] [decimal] (18,0) NULL,
	[MontoVigente 2013] [decimal] (18,0) NULL,
	[MontoVigente 2014] [decimal] (18,0) NULL,
	[MontoVigente 2015] [decimal] (18,0) NULL,
	[MontoVigente 2016] [decimal] (18,0) NULL,
	[MontoVigente 2017] [decimal] (18,0) NULL,
	[MontoVigente 2018] [decimal] (18,0) NULL,
	[MontoVigente 2019] [decimal] (18,0) NULL,
	[MontoVigente 2020] [decimal] (18,0) NULL,
	[MontoVigente Posteriores] [decimal] (18,0) NULL,
	[MontoVigente Total] [decimal] (18,0) NULL,
	[MontoVigenteEstimativo 2012] bit NULL,
	[MontoVigenteEstimativo 2013] bit NULL,
	[MontoVigenteEstimativo 2014] bit NULL,
	[MontoVigenteEstimativo 2015] bit NULL,
	[MontoVigenteEstimativo 2016] bit NULL,
	[MontoVigenteEstimativo 2017] bit NULL,
	[MontoVigenteEstimativo 2018] bit NULL,
	[MontoVigenteEstimativo 2019] bit NULL,
	[MontoVigenteEstimativo 2020] bit NULL,
	[MontoDevengado Anteriores] [decimal] (18,0) NULL,
	[MontoDevengado 2012] [decimal] (18,0) NULL,
	[MontoDevengado 2013] [decimal] (18,0) NULL,
	[MontoDevengado 2014] [decimal] (18,0) NULL,
	[MontoDevengado 2015] [decimal] (18,0) NULL,
	[MontoDevengado 2016] [decimal] (18,0) NULL,
	[MontoDevengado 2017] [decimal] (18,0) NULL,
	[MontoDevengado 2018] [decimal] (18,0) NULL,
	[MontoDevengado 2019] [decimal] (18,0) NULL,
	[MontoDevengado 2020] [decimal] (18,0) NULL,
	[MontoDevengado Posteriores] [decimal] (18,0) NULL,
	[MontoDevengado Total] [decimal] (18,0) NULL
) ON [FG] TEXTIMAGE_ON [FG]

INSERT INTO [dbo].[Cubo_CxT] 
EXEC	@return_value = [dbo].[sp_Cubo_Genera_CxT]
SET ANSI_PADDING OFF
END

GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxT]    Script Date: 11/28/2016 20:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Genera_CxT] (@Year int = 2017)

AS

--DECLARE
--@YTD int = Year(getdate())

BEGIN

-- asigno el año actual si no se ingresa año como parametro
if (@Year < 1999 or @Year = null) set @Year = Year(getdate())

-- Obtengo todos los proyectos del Programa
--select p.*
--into #Proyecto
--from Proyecto p

-- Obtiene las provincias-----------------------------------------------------------
--declare @ttProvincias table
CREATE TABLE #ttProvincias
 (	IdProyecto int not null
	-- primary key NOT NULL
	, Provincia varchar(max)
	, Cantidad int)
ALTER TABLE #ttProvincias ADD PRIMARY KEY(IdProyecto)
insert into #ttProvincias
select distinct * from [fn_Cubo_ProyectoLocalidadDetallada]()

CREATE TABLE #MontosProyecto
(
IdProyecto int not null
/*Other Columns*/
,ME_Acumulado_m5 money
,ME_m5 money
,ME_m4 money
,ME_m3 money
,ME_m2 money
,ME_m1 money
,ME money
,ME_1 money
,ME_2 money
,ME_3 money
,ME_Acumulado_3 money
,ME_Total money
,ME_CostoTotal_Year money

,MR_Acumulado_m5 money
,MR_m5 money
,MR_m4 money
,MR_m3 money
,MR_m2 money
,MR_m1 money
,MR money
,MR_1 money
,MR_2 money
,MR_3 money
,MR_Acumulado_3 money
,MR_Total money
,MR_CostoTotal_Year money

,MI_Acumulado_m5 money
,MI_m5 money
,MI_m4 money
,MI_m3 money
,MI_m2 money
,MI_m1 money
,MI money
,MI_1 money
,MI_2 money
,MI_3 money
,MI_Acumulado_3 money
,MI_Total money
,MI_CostoTotal_Year money
,MV_Acumulado_m5 money
,MV_m5 money
,MV_m4 money
,MV_m3 money
,MV_m2 money
,MV_m1 money
,MV money
,MV_1 money
,MV_2 money
,MV_3 money
,MV_Acumulado_3 money
,MV_Total money
,MV_CostoTotal_Year money
,MVE_m5 bit
,MVE_m4 bit
,MVE_m3 bit
,MVE_m2 bit
,MVE_m1 bit
,MVE bit
,MVE_1 bit
,MVE_2 bit
,MVE_3 bit
,MD_Acumulado_m5 money
,MD_m5 money
,MD_m4 money
,MD_m3 money
,MD_m2 money
,MD_m1 money
,MD money
,MD_1 money
,MD_2 money
,MD_3 money
,MD_Acumulado_3 money
,MD_Total money
,MD_CostoTotal_Year money
)
ALTER TABLE #MontosProyecto ADD PRIMARY KEY(IdProyecto)

-- Obtiene los Montos por peridodo--
insert into #MontosProyecto
select distinct 
p.IdProyecto
,ME_Acumulado_m5=sum(case when periodo < @Year-5  then montocalculado else 0 end)
,ME_m5=sum(case when periodo=@Year-5 then montocalculado else 0 end)
,ME_m4=sum(case when periodo=@Year-4 then montocalculado else 0 end)
,ME_m3=sum(case when periodo=@Year-3 then montocalculado else 0 end) 
,ME_m2=sum(case when periodo=@Year-2 then montocalculado else 0 end) 
,ME_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end) 
,ME=sum(case when periodo=@Year  then montocalculado else 0 end)
,ME_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,ME_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,ME_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,ME_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,ME_Total=sum(montocalculado)
,ME_CostoTotal_Year=sum(case when periodo > @Year-1 then montocalculado else 0 end)

,MR_Acumulado_m5=sum(case when periodo< @Year-5 then montocalculado else 0 end) 
,MR_m5=sum(case when periodo=@Year-5  then montocalculado else 0 end)
,MR_m4=sum(case when periodo=@Year-4  then montocalculado else 0 end)
,MR_m3=sum(case when periodo=@Year-3  then montocalculado else 0 end)
,MR_m2=sum(case when periodo=@Year-2  then montocalculado else 0 end)
,MR_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end)
,MR=sum(case when periodo=@Year  then montocalculado else 0 end)
,MR_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,MR_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,MR_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,MR_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,MR_Total=sum(montocalculado)
,MR_CostoTotal_Year=sum(case when periodo < @Year then montocalculado else 0 end)

,MI_Acumulado_m5=sum(case when periodo < @Year-5  then montoinicial else 0 end)
,MI_m5=sum(case when periodo=@Year-5 then montoinicial else 0 end)
,MI_m4=sum(case when periodo=@Year-4 then montoinicial else 0 end)
,MI_m3=sum(case when periodo=@Year-3 then montoinicial else 0 end) 
,MI_m2=sum(case when periodo=@Year-2 then montoinicial else 0 end) 
,MI_m1=sum(case when periodo=@Year-1 then montoinicial else 0 end) 
,MI=sum(case when periodo=@Year  then montoinicial else 0 end)
,MI_1=sum(case when periodo=@Year+1 then montoinicial else 0 end)
,MI_2=sum(case when periodo=@Year+2  then montoinicial else 0 end)
,MI_3=sum(case when periodo=@Year+3  then montoinicial else 0 end)
,MI_Acumulado_3=sum(case when periodo>@Year+3  then montoinicial else 0 end)
,MI_Total=sum(montoinicial)
,MI_CostoTotal_Year=sum(case when periodo > @Year-1 then montoinicial else 0 end)
,MV_Acumulado_m5=sum(case when periodo < @Year-5  then montovigente else 0 end)
,MV_m5=sum(case when periodo=@Year-5 then montovigente else 0 end)
,MV_m4=sum(case when periodo=@Year-4 then montovigente else 0 end)
,MV_m3=sum(case when periodo=@Year-3 then montovigente else 0 end) 
,MV_m2=sum(case when periodo=@Year-2 then montovigente else 0 end) 
,MV_m1=sum(case when periodo=@Year-1 then montovigente else 0 end) 
,MV=sum(case when periodo=@Year  then montovigente else 0 end)
,MV_1=sum(case when periodo=@Year+1 then montovigente else 0 end)
,MV_2=sum(case when periodo=@Year+2  then montovigente else 0 end)
,MV_3=sum(case when periodo=@Year+3  then montovigente else 0 end)
,MV_Acumulado_3=sum(case when periodo>@Year+3  then montovigente else 0 end)
,MV_Total=sum(montovigente)
,MV_CostoTotal_Year=sum(case when periodo > @Year-1 then montovigente else 0 end)

,MVE_m5=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year-5 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_m4=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year-4 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_m3=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year-3 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_m2=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year-2 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_m1=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year-1 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_1=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year+1 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_2=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year+2 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end
,MVE_3=case when ((SELECT COUNT(*) FROM ProyectoEtapaEstimadoPeriodo WHERE periodo=@Year+3 and MontoVigenteEstimativo = 1)>0) then 1 else 0 end

,MD_Acumulado_m5=sum(case when periodo < @Year-5  then montodevengado else 0 end)
,MD_m5=sum(case when periodo=@Year-5 then montodevengado else 0 end)
,MD_m4=sum(case when periodo=@Year-4 then montodevengado else 0 end)
,MD_m3=sum(case when periodo=@Year-3 then montodevengado else 0 end) 
,MD_m2=sum(case when periodo=@Year-2 then montodevengado else 0 end) 
,MD_m1=sum(case when periodo=@Year-1 then montodevengado else 0 end) 
,MD=sum(case when periodo=@Year  then montodevengado else 0 end)
,MD_1=sum(case when periodo=@Year+1 then montodevengado else 0 end)
,MD_2=sum(case when periodo=@Year+2  then montodevengado else 0 end)
,MD_3=sum(case when periodo=@Year+3  then montodevengado else 0 end)
,MD_Acumulado_3=sum(case when periodo>@Year+3  then montodevengado else 0 end)
,MD_Total=sum(montodevengado)
,MD_CostoTotal_Year=sum(case when periodo > @Year-1 then montodevengado else 0 end)

--into #MontosProyecto

from Proyecto p 
inner join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 
and p.Activo = 1
group by p.IdProyecto

--------------------------------------------------
-- Resultado del Cubo --
--------------------------------------------------

select distinct
-- Nro de Bapin del proyecto y su Denominacion --
p.Codigo																	as [Nro_Bapin]
,isnull(p.ProyectoDenominacion,'')											as [Denominacion]				

-- Identifica si el proyecto esta cargado como borrador o no --
,case when p.EsBorrador=0 then 'N' else 'S' end								as [EsBorrador]

-- Tipo de Proyecto (Ampliacion,Reposiciones,Transferencias, Inversion Real Directa) --
,case when isnull(ptipo.Sigla,'') + '-' + isnull(ptipo.Nombre,'') = '-'
	then ''
	else ptipo.Sigla + '-' + ptipo.Nombre
 end																		as [Tipo]

-- Incisos afectados al proyecto --
,isnull(pid.Incisos,'0')													as [Incisos]

-- Codigo de Clasificacion Institucional (Sector.Tipo de administracion.Tipo de entidad.Jurisdiccion.Subjurisdiccion.000)
-- Tipo entidad en las tablas contiene el codigo de Sector.TipoAdministracion.TipoEntidad)
,isnull(etipo.Codigo,'00') + '.' + isnull(juris.Codigo,'00') + '.' +
isnull(sjuris.Codigo,'00') + '.' + '000'									as [Clasif_Instit]

-- Datos de la Jurisdicccion a la que pertence el proyecto --
,isnull(juris.Codigo,'')													as [Jur_cod]
,isnull(juris.Nombre,'')													as [Jurisdicción]

-- Codigo de Apertura Programatica --
,isnull(saf.Codigo,'00')	+ '.' + isnull(prog.Codigo,'00') + '.' +
isnull(sprog.Codigo,'00')													as [Ape_Prog]
-- Detalle de la Apertura Programatica (SAF/Programa/Subprograma)
,isnull(saf.Codigo,'0')														as [SAF_cod]
,isnull(saf.Denominacion,'')												as [SAF]
,isnull(prog.Codigo,'0')													as [Progr_cod]
,isnull(prog.Nombre,'')														as [Programa]
,isnull(sprog.Codigo,'0')													as [Subprog_cod]
,isnull(sprog.Nombre,'')													as [Subprograma]

-- Apertura Presupuestaria (Proyecto/Actividad/Obra)
-- Se incorpora el item Tipo_Presupuestario, indicando:
-- "Proyecto" si es un proyecto (proyecto.esproyecto = 1)
-- "Actividad" si no es un proyecto (proyecto.esproyecto =0)
-- "No_especificado" en caso que no se haya asingado un valor a proyecto.esproyecto.

-- Codigo de Apertura Presupuestaria --
,isnull(ApePres.NroProyecto,'0') 
+ '.' + 
isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
		end,'0')
+ '.' +
isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
		end,'0')															as [Ape_Presup]
 
-- Detalle de Apertura Presupuestaria

,isnull(ApePres.NroProyecto,'0')											as [NroProyecto]

,isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
			end,'0')														as [NroActividad]

,isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
			end,'0')														as [NroObra]

,isnull(case when CHARINDEX('/',Tipo_PresupAgrup) > 0
			then left(Tipo_PresupAgrup,charindex('/',Tipo_PresupAgrup)-1)
			else Tipo_PresupAgrup
			end,'0')														as [Tipo_Presup]

-- Codigo de Apertura Presupuestaria Actividad Especifica --
--Si un proyecto tiene obra y actividad entonces en la columna se refleja
--la apertura presupuestaria de la actividad; en otro caso la columna tiene '-'
,isnull(case when	charindex('/',ApePres.nroactividadagrup) is null or 
					charindex('/',ApePres.nroactividadagrup,charindex('/',ApePres.nroactividadagrup)+1) = 0
			then '-'
			else
				ApePres.nroproyecto + '.' +
				substring(ApePres.nroactividadagrup,
						charindex('/',ApePres.nroactividadagrup)+1,
						LEN(ApePres.nroactividadagrup)-charindex('/',ApePres.nroactividadagrup)-1) + '.' +	
				substring(ApePres.nroobraagrup,
						charindex('/',ApePres.nroobraagrup,1)+1,
						LEN(ApePres.nroobraagrup)-charindex('/',ApePres.nroobraagrup)-1)
			end,'0')														as [Ape_PresupActEsp]

-- Identifica si el area a la que pertence el proyecto es presupuestaria --
,isnull(otipo.Nombre,'')													as [Es_Presup]

-- Estado Financiero del proyecto --
,isnull(case when len(pefinan.EstFinanciero) > 2
		then left (pefinan.EstFinanciero, len(pefinan.EstFinanciero)-2)
		else pefinan.EstFinanciero
		end,'')																as [Estado_Financiero]

-- Estado Fisico del proyecto
,isnull(case when len(pefis.EstFisico) > 2
		then left (pefis.EstFisico, len(pefis.EstFisico)-2)
		else pefis.EstFisico
		end,'')																as [Estado_Fisico]
		
--Estado de Decision
--Valores posibles de los estados son: postulado, conformado, aceptado, rechazado, reiniciado
--Se encuentran en la tabla : estadodedecision
,isnull(est_decision.Nombre,'')												as [Est_Decision]

-- Datos de Calidad del Proyecto
--,isnull(proce.Nombre,'')													as [Proceso_Calidad]

--PrioridadDNIP
-- Los Planes de Priodidad DNIP no necesariamente coinciden con los planes cargados en el proyecto de Inversion
-- Los Planes de Prioridad DNIP hay que ubicarlos en la pantalla de Invervencion DNIP
,isnull(upp.Periodo + '-' + upp.Prioridad,'')								as [PrioridadDNIP]
,case when upp.ReqArt15=0 then 'N' else 'S' end								as [Art_15]

--Gestion de Calidad (Administracion -> Calidad)
--Valores posibles de los estados son : Corregido, A corregir, Revisado, Terminado, Pendiente
--Se encuentran en la tabla : Estados
-- * VER AdministracionCalidad
,case when pcalid.ReqDictamen=0 then 'N' else 'S' end						as [Req_Dict]
,isnull(est_calid.nombre,'')												as [Estado_calidad]
,case when pcalid.FechaEstado is null then '' else
 convert(varchar(10),pcalid.FechaEstado,103) end							as [Fecha_Estado_Calidad]
 
 --Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
--Valores posibles de los estados de situacion son : Dictaminado, En espera de CT, En espera de informacion, Pendiente)
--Se encuentran en la tabla : Estados
-- * VER ProyectoSeguimiento
-- Deberia ser una funcion porque sin el distinct trae mas registros.
,isnull(case when len(pefa.Eval_Fact) > 2
		then left (pefa.Eval_Fact, len(pefa.Eval_Fact)-2)
		else pefa.Eval_Fact
		end,'')																as [Eval_Factibilidad]

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
--Valores posibles de los estados de "Calificacion" son : Aprobado, Aprobado con observaciones, Desaprobado
-- Valores posibles de los estados son : En espera de DNIP, En espera de respuesta, En espera de SPE,
-- Migracion, Respondido, Terminado
--Se encuentran en la tabla : Estados
-- VER * ProyectoDictamen, ProyectoDictamenEstado (pueden ser varios)
,isnull(case when len(pdia.Dict_Inversion) > 2
		then left (pdia.Dict_Inversion, len(pdia.Dict_Inversion)-2)
		else pdia.Dict_Inversion
		end,'')																as [Dict_Inversion] 
 
-- Prioridad asignada al proyecto --
,isnull(op.Nombre,'')														as [PrioridadOrganismo]
-- + '-' + convert(varchar(5),isnull(p.SubPrioridad,0)) 

,isnull(cast(p.SubPrioridad as varchar(10)), '')							as [Subprioridad]

-- Provincias en las que interviene el proyecto --
,isnull(tp.cantidad,'0')													as [Prov_Cantidad]

,isnull(case when len(tp.provincia) > 2
		then ltrim(right (tp.provincia, len(tp.provincia)-2))
		else ltrim(tp.provincia)
		end,'')																as [Localizacion_Provincia]

-- Fechas de alta y modificacion del proyecto --
,case when p.FechaAlta is null then '' else
 convert(varchar(10),p.FechaAlta,103) end									as [Fecha_Alta]
,case when p.FechaModificacion is null then '' else
 convert(varchar(10),p.FechaModificacion,103) end							as [Fecha_UltModificacion]

-- Identificacion del Usuario que modifico el proyecto --
,isnull(pers.nombrecompleto,'')												as [Usuario_UltModificación]

-- Fechas de inicio y fin estimada para el proyecto
/*,case when pe.FechaInicioEstimada is null then '' else
 convert(varchar(10),pe.FechaInicioEstimada,103) end						as [Fecha_Inicio_Estimada]*/
,isnull(dbo.fn_Cubo_Fecha_Inicio_Estimada(p.IdProyecto), '')				as [Fecha_Inicio_Estimada]

/*,case when pe.FechaFinEstimada is null then '' else
 convert(varchar(10),pe.FechaFinEstimada,103) end							as [Fecha_Fin_Estimada]*/
,isnull(dbo.fn_Cubo_Fecha_Fin_Estimada(p.IdProyecto), '')					as [Fecha_Fin_Estimada]

-- Planes cargados en el proyecto --
,isnull(case when len(ppd.planes) > 2
		then left (ppd.planes, len(ppd.planes)-2)
		else ''
		end,'')																as [Planes]

-- Ultimo plan cargado en el proyecto --
,isnull(case when 
		charindex('P',ppd.Planes) > 0
		then left(ppd.Planes,charindex('/',ppd.Planes)-1)
		else ''
		end,'')																as [Ult_Plan]

-- Ultima demanda cargada en el proyecto --
,isnull(case when 
		charindex('D',ppd.Planes) > 0
		then 
		substring(ppd.Planes,charindex('D',ppd.Planes),charindex('/',ppd.Planes,charindex('D',ppd.Planes))-charindex('D',ppd.Planes))
		else ''
		end,'')																as [Ult_Demanda]

-- Finalidad Funcion del proyecto
,case when isnull(ff.BreadcrumbCode,'') + '-' + isnull(ff.Descripcion,'') = '-'
		then ''
	else 
		case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
			else
				isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
		end
				+ '-' + isnull(ff.Descripcion,'') 
  end																		as [Finalidad_Función]
,case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
	else isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
 end																		as [Finalidad_Funcion_Cod]
,isnull(ff.Descripcion,'')													as [Finalidad_Función_Desc]

-- Fuente de Financiamiento --
,isnull(fufi.FuenteFinan,'')												as [Fuente_Finaciamiento_Cod]
,case when fufi.DescFuenteFinan is null then ''
else left(fufi.DescFuenteFinan,LEN(fufi.DescFuenteFinan)-2) end				as [Fuente_Financiamiento_Desc]

-- Proceso del Proyecto --
,isnull(pr.Nombre,'')														as [Proceso]

-- Identificacion del sectorialista asignado al proyecto --
,isnull(sect.NombreCompleto,'')												as [Sectorialista]	

,isnull(ecto.ECTOes,'')														as [Com_Tecnico_ECTO]
-- Datos de los montos estimados del propyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),mpre.ME_Acumulado_m5),0)						as [Estimados Anteriores]
,isnull(CONVERT(decimal(18,0),mpre.ME_m5),0)									as [Estimado 2012]
,isnull(CONVERT(decimal(18,0),mpre.ME_m4),0)									as [Estimado 2013]
,isnull(CONVERT(decimal(18,0),mpre.ME_m3),0)									as [Estimado 2014]
,isnull(CONVERT(decimal(18,0),mpre.ME_m2),0)									as [Estimado 2015]
,isnull(CONVERT(decimal(18,0),mpre.ME_m1),0)									as [Estimado 2016]	
,isnull(CONVERT(decimal(18,0),mpre.ME),0)										as [Estimado 2017]
,isnull(CONVERT(decimal(18,0),mpre.ME_1),0)									as [Estimado 2018]
,isnull(CONVERT(decimal(18,0),mpre.ME_2),0)									as [Estimado 2019]
,isnull(CONVERT(decimal(18,0),mpre.ME_3),0)									as [Estimado 2020]
,isnull(CONVERT(decimal(18,0),mpre.ME_Acumulado_3),0)							as [Estimado Posteriores]
,isnull(CONVERT(decimal(18,0),mpre.ME_Total),0)								as [Estimado Total]						

,isnull(CONVERT(decimal(18,0),mpre.MR_Acumulado_m5),0)						as [Realizados Anteriores]
,isnull(CONVERT(decimal(18,0),mpre.MR_m5),0)									as [Realizado 2012]
,isnull(CONVERT(decimal(18,0),mpre.MR_m4),0)									as [Realizado 2013]
,isnull(CONVERT(decimal(18,0),mpre.MR_m3),0)									as [Realizado 2014]
,isnull(CONVERT(decimal(18,0),mpre.MR_m2),0)									as [Realizado 2015]
,isnull(CONVERT(decimal(18,0),mpre.MR_m1),0)									as [Realizado 2016]
,isnull(CONVERT(decimal(18,0),mpre.MR),0)										as [Realizado 2017]
,isnull(CONVERT(decimal(18,0),mpre.MR_1),0)									as [Realizado 2018]
,isnull(CONVERT(decimal(18,0),mpre.MR_2),0)									as [Realizado 2019]
,isnull(CONVERT(decimal(18,0),mpre.MR_3),0)									as [Realizado 2020]
,isnull(CONVERT(decimal(18,0),mpre.MR_Acumulado_3),0)							as [Realizado Posteriores]
,isnull(CONVERT(decimal(18,0),mpre.MR_Total),0)								as [Realizado Total]

-- Costo total actual =
-- Montos Realizados Acumulados desde Year-1 hacia atras +
-- Montos Estimados Acumulados desde Year hacia adelante
,isnull(CONVERT(decimal(18,0),mpre.MR_CostoTotal_Year),0) +
 isnull(CONVERT(decimal(18,0),mpre.ME_CostoTotal_Year),0)						as [Costo Total Actual]

-- Informacion de ONP
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2003]),0)							as [ONP 2003]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2004]),0)							as [ONP 2004]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2005]),0)							as [ONP 2005]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2006]),0)							as [ONP 2006]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2007]),0)							as [ONP 2007]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2008]),0)							as [ONP 2008]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2009]),0)							as [ONP 2009]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2010]),0)							as [ONP 2010]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2011]),0)							as [ONP 2011]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2012]),0)							as [ONP 2012]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2013]),0)							as [ONP 2013]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2014]),0)							as [ONP 2014]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2015]),0)							as [ONP 2015]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2016]),0)							as [ONP 2016]
,isnull(CONVERT(decimal(18,0),onpd.[ONP]),0)								as [ONP 2017]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_1]),0)								as [ONP 2018]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_2]),0)								as [ONP 2019]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_3]),0)								as [ONP 2020]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_4]),0)								as [ONP 2021]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_5]),0)								as [ONP 2022]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_6]),0)								as [ONP 2023]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_7]),0)								as [ONP 2024]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_8]),0)								as [ONP 2025]

-- Fecha y hora de generacion del cubo --
,CONVERT(VARCHAR(10), GETDATE(), 103) + ' ' +
 CONVERT(VARCHAR(10), GETDATE(), 108)										as [Generado]

-- Datos de los montos iniciales del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),mpre.MI_Acumulado_m5),0)					as [MontoInicial Anteriores]
,isnull(CONVERT(decimal(18,0),mpre.MI_m5),0)							as [MontoInicial 2012]
,isnull(CONVERT(decimal(18,0),mpre.MI_m4),0)							as [MontoInicial 2013]
,isnull(CONVERT(decimal(18,0),mpre.MI_m3),0)							as [MontoInicial 2014]
,isnull(CONVERT(decimal(18,0),mpre.MI_m2),0)							as [MontoInicial 2015]
,isnull(CONVERT(decimal(18,0),mpre.MI_m1),0)						as [MontoInicial 2016]	
,isnull(CONVERT(decimal(18,0),mpre.MI),0)							as [MontoInicial 2017]
,isnull(CONVERT(decimal(18,0),mpre.MI_1),0)							as [MontoInicial 2018]
,isnull(CONVERT(decimal(18,0),mpre.MI_2),0)							as [MontoInicial 2019]
,isnull(CONVERT(decimal(18,0),mpre.MI_3),0)							as [MontoInicial 2020]
,isnull(CONVERT(decimal(18,0),mpre.MI_Acumulado_3),0)				as [MontoInicial Posteriores]
,isnull(CONVERT(decimal(18,0),mpre.MI_Total),0)						as [MontoInicial Total]	
-- Datos de los montos vigentes del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),mpre.MV_Acumulado_m5),0)				as [MontoVigente Anteriores]
,isnull(CONVERT(decimal(18,0),mpre.MV_m5),0)						as [MontoVigente 2012]
,isnull(CONVERT(decimal(18,0),mpre.MV_m4),0)						as [MontoVigente 2013]
,isnull(CONVERT(decimal(18,0),mpre.MV_m3),0)						as [MontoVigente 2014]
,isnull(CONVERT(decimal(18,0),mpre.MV_m2),0)						as [MontoVigente 2015]
,isnull(CONVERT(decimal(18,0),mpre.MV_m1),0)						as [MontoVigente 2016]	
,isnull(CONVERT(decimal(18,0),mpre.MV),0)							as [MontoVigente 2017]
,isnull(CONVERT(decimal(18,0),mpre.MV_1),0)							as [MontoVigente 2018]
,isnull(CONVERT(decimal(18,0),mpre.MV_2),0)							as [MontoVigente 2019]
,isnull(CONVERT(decimal(18,0),mpre.MV_3),0)							as [MontoVigente 2020]
,isnull(CONVERT(decimal(18,0),mpre.MV_Acumulado_3),0)				as [MontoVigente Posteriores]
,isnull(CONVERT(decimal(18,0),mpre.MV_Total),0)						as [MontoVigente Total]	
-- Datos de los montos vigentes estimativos del proyecto, de acuerdo al año ingresado como parametro --
,isnull(mpre.MVE_m5,0)							as [MontoVigenteEstimativo 2012]
,isnull(mpre.MVE_m4,0)							as [MontoVigenteEstimativo 2013]
,isnull(mpre.MVE_m3,0)							as [MontoVigenteEstimativo 2014]
,isnull(mpre.MVE_m2,0)							as [MontoVigenteEstimativo 2015]
,isnull(mpre.MVE_m1,0)							as [MontoVigenteEstimativo 2016]	
,isnull(mpre.MVE,0)								as [MontoVigenteEstimativo 2017]
,isnull(mpre.MVE_1,0)							as [MontoVigenteEstimativo 2018]
,isnull(mpre.MVE_2,0)							as [MontoVigenteEstimativo 2019]
,isnull(mpre.MVE_3,0)							as [MontoVigenteEstimativo 2020]
-- Datos de los montos devengados del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),mpre.MD_Acumulado_m5),0)				as [MontoDevengado Anteriores]
,isnull(CONVERT(decimal(18,0),mpre.MD_m5),0)						as [MontoDevengado 2012]
,isnull(CONVERT(decimal(18,0),mpre.MD_m4),0)						as [MontoDevengado 2013]
,isnull(CONVERT(decimal(18,0),mpre.MD_m3),0)						as [MontoDevengado 2014]
,isnull(CONVERT(decimal(18,0),mpre.MD_m2),0)						as [MontoDevengado 2015]
,isnull(CONVERT(decimal(18,0),mpre.MD_m1),0)						as [MontoDevengado 2016]	
,isnull(CONVERT(decimal(18,0),mpre.MD),0)							as [MontoDevengado 2017]
,isnull(CONVERT(decimal(18,0),mpre.MD_1),0)							as [MontoDevengado 2018]
,isnull(CONVERT(decimal(18,0),mpre.MD_2),0)							as [MontoDevengado 2019]
,isnull(CONVERT(decimal(18,0),mpre.MD_3),0)							as [MontoDevengado 2020]
,isnull(CONVERT(decimal(18,0),mpre.MD_Acumulado_3),0)				as [MontoDevengado Posteriores]
,isnull(CONVERT(decimal(18,0),mpre.MD_Total),0)						as [MontoDevengado Total]	

-- Año de referencia de los periodos
--,@Year																	as [Año_Referencia]

from Proyecto p

-- Datos para la Clasificacion Institucional
inner join SubPrograma sprog on sprog.IdSubPrograma=p.IdSubPrograma
inner join Programa prog on prog.IdPrograma=sprog.IdPrograma
inner join Saf on Saf.IdSaf=prog.idsaf
left join EntidadTipo etipo on etipo.IdEntidadTipo=saf.IdEntidadTipo
left join Jurisdiccion juris on Juris.IdJurisdiccion=Saf.IdJurisdiccion
left join SubJurisdiccion sjuris on sjuris.IdSubJuridiccion=saf.IdSubJurisdiccion

-- Agrego los valores de los montos estimados y realizados
--left join fn_Cubo_Union_ME_MR (@Year) umemr on p.IdProyecto = umemr.IdProyecto 
--left join #MontoEstimado me on me.IdProyecto = p.IdProyecto
--left join #MontoRealizado mr on mr.IdProyecto = p.IdProyecto
left join #MontosProyecto mpre on p.IdProyecto = mpre.IdProyecto

-- Estado Financiero, Estado Fisico y Estado de Decision
left join fn_Cubo_EstadoFinanciero_Group () pefinan on pefinan.IdProyecto = p.IdProyecto
left join fn_Cubo_EstadoFisico_Group () pefis on pefis.idproyecto = p.IdProyecto
left join EstadoDeDesicion est_decision on est_decision.IdEstadoDeDesicion = p.IdEstadoDeDesicion

left join Proceso pr on pr.IdProceso = p.IdProceso
left join ProyectoTipo ptipo on ptipo.IdProyectoTipo = p.IdTipoProyecto

--Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
left join fn_Cubo_EvaluacionFactibilidad_Group () pefa on pefa.IdProyecto = p.IdProyecto

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
left join fn_Cubo_DictamenInversion_Group () pdia on pdia.IdProyecto = p.IdProyecto

--aca

-- Tipo de organismo
left join OrganismoTipo otipo on otipo.IdOrganismoTipo=Saf.IdTipoOrganismo

-- Sectorialista asignado a un programa
left join persona sect on sect.Idpersona=prog.IdSectorialista

-- Usuario que modifica el proyecto
left join persona pers on pers.Idpersona=p.IdUsuarioModificacion

-- Prioridad asignada por el organismo
left join OrganismoPrioridad op on op.IdOrganismoPrioridad=p.IdOrganismoPrioridad

--Gestion de Calidad (Administracion -> Calidad)
left join ProyectoCalidad pcalid on pcalid.IdProyecto = p.IdProyecto
left join Estado est_calid on est_calid.IdEstado = pcalid.IdEstado

left join FinalidadFuncion ff on ff.IdFinalidadFuncion=p.IdFinalidadFuncion

left join ProyectoPlan pp on pp.IdProyectoPlan=p.IdProyectoPlan
left join PlanPeriodo ppt on ppt.IdPlanPeriodo=pp.IdPlanPeriodo
left join PlanVersion ppv on ppv.IdPlanVersion=pp.IdPlanVersion
left join PlanTipo pt on pt.IdPlanTipo=ppt.IdPlanTipo

left join fn_Cubo_UltimoPlanPrioridad () upp on upp.IdProyecto=p.IdProyecto
left join fn_Cubo_Plan_Group () ppd on ppd.idproyecto=p.IdProyecto
left join fn_Cubo_Inciso_Group () pid on pid.IdProyecto=p.IdProyecto

left join fn_Cubo_AperturaPresupuestaria_Group () ApePres on ApePres.IdProyecto = p.IdProyecto

left join fn_Cubo_FuenteFinanciamiento_Group () FuFi on FuFi.idProyecto = p.IdProyecto

left join fn_Cubo_ECTO_Group () ecto on ecto.idProyecto = p.IdProyecto

left join #ttProvincias tp on tp.idproyecto=p.IdProyecto

--Incorporo informacion de ONP hasta el año 2016 a partir de la importacion del ultimo CuboxTotal del Bapin II
left join Cubo_ImportCxTBapin2 CxT on CxT.Nro_Bapin = p.Codigo

--Incorporo informacion de ONP a partir de los proyectos vinculados por matching (tabla Matching_ProyectosVinculados)
--left join #onp_devengado onpd on onpd.Codigo = p.codigo
left join fn_Cubo_ONPDevengado(@Year) onpd on onpd.IdProyecto = p.IdProyecto

where p.Activo = 1 /*Solo Proyectos activos*/

END

GO