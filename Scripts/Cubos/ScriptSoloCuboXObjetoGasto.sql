
/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Inicia_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Inicia_CxO]
GO	
/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Genera_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Genera_CxO]
GO
/****** Object:  StoredProcedure [dbo].[sp_Cubo_Filtra_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Filtra_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Filtra_CxO]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoInicial]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoInicial]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoInicial]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoVigente]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoVigente]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoVigente]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoDevengado]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoDevengado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoDevengado]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_Presupuestaria]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Union_Presupuestaria]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Union_Presupuestaria]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxO]    Script Date: 04/21/2017 15:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Genera_CxO] (@Year int = 2017)
AS

--set @Year = Year(Getdate())
--,@textoaux varchar

BEGIN

-- asigno el año actual si no se ingresa año como parametro
if (@Year < 1999 or @Year = null) set @Year = Year(getdate())

-- Obtengo todos los proyectos del Programa
--select p.*
--into #Proyecto
--from Proyecto p

-- Obtiene las provincias-----------------------------------------------------------
declare @ttProvincias table (IdProyecto int
-- primary key NOT NULL
,Provincia varchar(max), Cantidad int)
insert into @ttProvincias
select distinct * from [fn_Cubo_ProyectoLocalidadDetallada]()

/*
-- Obtiene los montos devengados por ejercicio presupuestario ---------------------
select distinct
Codigo
--,ONP_m1=sum(case when EjercicioPresupuestario=@Year-1 then Devengado else 0 end)
,ONP=sum(case when EjercicioPresupuestario=@Year then Devengado else 0 end)
,ONP_1=sum(case when EjercicioPresupuestario=@Year+1 then Devengado else 0 end)
,ONP_2=sum(case when EjercicioPresupuestario=@Year+2 then devengado else 0 end)
,ONP_3=sum(case when EjercicioPresupuestario=@Year+3 then devengado else 0 end)
,ONP_4=sum(case when EjercicioPresupuestario=@Year+4 then devengado else 0 end)
,ONP_5=sum(case when EjercicioPresupuestario=@Year+5 then devengado else 0 end)
,ONP_6=sum(case when EjercicioPresupuestario=@Year+6 then devengado else 0 end)
,ONP_7=sum(case when EjercicioPresupuestario=@Year+7 then devengado else 0 end)
,ONP_8=sum(case when EjercicioPresupuestario=@Year+8 then devengado else 0 end)

into #onp_devengado

from Proyecto p
left join Matching_ProyectosVinculados mpv on p.Codigo = mpv.CodigoProyectoBAPIN
group by p.Codigo

-- Obtiene los Montos Estimados por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,fufi.IdFuenteFinanciamiento
,cg.IdClasificacionGasto
,pe.IdEstado

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
,Total=sum(montocalculado)
,ME_CostoTotal_Year=sum(case when periodo > @Year-1 then montocalculado else 0 end)

into #MontoEstimado

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

group by p.IdProyecto, fufi.IdFuenteFinanciamiento, cg.IdClasificacionGasto, pe.IdEstado

-- Obtiene los Montos Realizados por peridodo--
select distinct 
p.IdProyecto
,fufi.IdFuenteFinanciamiento
,cg.IdClasificacionGasto
,pe.IdEstado

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
,Total=sum(montocalculado)
,MR_CostoTotal_Year=sum(case when periodo < @Year then montocalculado else 0 end)

into #MontoRealizado

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
left join ProyectoEtapaRealizado per on per.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaRealizadoPeriodo perp on perp.IdProyectoEtapaRealizado = per.IdProyectoEtapaRealizado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = per.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = per.IdFuenteFinanciamiento
group by p.IdProyecto, perp.fecha, fufi.IdFuenteFinanciamiento, cg.IdClasificacionGasto, pe.IdEstado
*/

--------------------------------------------------
-- Resultado del Cubo --
--------------------------------------------------

select 
--distinct

-- Nro de Bapin del proyecto y su Denominacion --
p.Codigo																	as [Nro_Bapin]
,isnull(p.ProyectoDenominacion,'')											as [Denominacion]				

-- Identifica si el proyecto esta cargado como borrador o no --
,case when p.EsBorrador=0 then 'N' else 'S' end								as [EsBorrador]

-- Tipo de Proyecto (Ampliacion,Reposiciones,Transferencias, Inversion Real Directa) --
,case when ISNULL(ptipo.Sigla,'') + '-' + ISNULL(ptipo.Nombre,'') = '-'
	then ''
	else ptipo.Sigla + '-' + ptipo.Nombre
 end																		as [Tipo]

-- Inciso al que pertenece el gasto --
,isnull(umemr.Inciso,'0')													as [Inciso]

-- Codigo de Clasificacion Institucional (Sector.Tipo de administracion.Tipo de entidad.Jurisdiccion.Subjurisdiccion.000)
-- Tipo entidad en las tablas contiene el codigo de Sector.TipoAdministracion.TipoEntidad)
,isnull(etipo.Codigo,'00') + '.' + isnull(juris.Codigo,'00') + '.' +
isnull(sjuris.Codigo,'00') + '.' + '000'									as [Clasif_Instit]

-- Datos de la Jurisdicccion a la que pertence el proyecto --
,isnull(juris.Codigo,'')													as [Jur_cod]
,isnull(juris.Nombre,'')													as [Jurisdicción]

-- Codigo de Apertura Programatica --
,isnull(saf.Codigo,'0')	+ '.' + isnull(prog.Codigo,'0') + '.' +
isnull(sprog.Codigo,'0')													as [Ape_Prog]
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
		
-- Estado de Decision
-- Valores posibles de los estados son: postulado, conformado, aceptado, rechazado, reiniciado
-- Se encuentran en la tabla : estadodedecision
,isnull(est_decision.Nombre,'')												as [Est_Decision]

-- Datos de Calidad del Proyecto
--,isnull(proce.Nombre,'')													as [Proceso_Calidad]

-- PrioridadDNIP
-- Los Planes de Priodidad DNIP no necesariamente coinciden con los planes cargados en el proyecto de Inversion
-- Los Planes de Prioridad DNIP hay que ubicarlos en la pantalla de Intervencion DNIP
,isnull(upp.Periodo + '-' + upp.Prioridad,'')								as [PrioridadDNIP]
,case when upp.ReqArt15=0 then 'N' else 'S' end								as [Art_15]

-- Gestion de Calidad (Administracion -> Calidad)
-- Valores posibles de los estados son : Corregido, A corregir, Revisado, Terminado, Pendiente
-- Se encuentran en la tabla : Estados
-- * VER AdministracionCalidad
,case when pcalid.ReqDictamen=0 then 'N' else 'S' end						as [Req_Dict]
,isnull(est_calid.nombre,'')												as [Estado_calidad]
,case when pcalid.FechaEstado is null then '' else
 convert(varchar(10),pcalid.FechaEstado,103) end							as [Fecha_Estado_Calidad]
 
-- Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
-- Valores posibles de los estados de situacion son : Dictaminado, En espera de CT, En espera de informacion, Pendiente)
-- Se encuentran en la tabla : Estados
-- * VER ProyectoSeguimiento
,isnull(case when len(pefa.Eval_Fact) > 2
		then left (pefa.Eval_Fact, len(pefa.Eval_Fact)-2)
		else pefa.Eval_Fact
		end,'')																as [Eval_Factibilidad]

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
-- Valores posibles de los estados de "Calificacion" son : Aprobado, Aprobado con observaciones, Desaprobado
-- Valores posibles de los estados son : En espera de DNIP, En espera de respuesta, En espera de SPE,
-- Migracion, Respondido, Terminado
-- Se encuentran en la tabla : Estados
-- VER * ProyectoDictamen, ProyectoDictamenEstado
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

-- Objeto del Gasto o Clasificacion del Gasto
-- Inciso/Partida_Principal/Partida_Parcial/Partida SubParcial
,isnull(umemr.Objeto_Gasto_Cod,'')											as [Objeto_Gasto_Cod]
,isnull(umemr.Objeto_Gasto_Desc,'')											as [Objeto_Gasto_Desc]

-- Fuente de Financiamiento --
,isnull(umemr.Fuente_Financiamiento_Cod,'')									as [Fuente_Financiamiento_Cod]
,isnull(umemr.Fuente_Financiamiento_Desc,'')								as [Fuente_Financiamiento_Desc]

-- Proceso del Proyecto --
,isnull(pr.Nombre,'')														as [Proceso]

-- Identificacion del sectorialista asignado al proyecto --
,isnull(sect.NombreCompleto,'')												as [Sectorialista]	

-- Identificacion del Comentario Tecnico del proyecto --
,isnull(ecto.ECTOes,'')														as [Com_Tecnico_ECTO]	

-- Datos de los montos estimados del propyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),umemr.ME_Acumulado_m5),0)						as [Estimados Anteriores]
,isnull(CONVERT(decimal(18,0),umemr.ME_m5),0)								as [Estimado 2012]
,isnull(CONVERT(decimal(18,0),umemr.ME_m4),0)								as [Estimado 2013]
,isnull(CONVERT(decimal(18,0),umemr.ME_m3),0)								as [Estimado 2014]
,isnull(CONVERT(decimal(18,0),umemr.ME_m2),0)								as [Estimado 2015]
,isnull(CONVERT(decimal(18,0),umemr.ME_m1),0)								as [Estimado 2016]	
,isnull(CONVERT(decimal(18,0),umemr.ME),0)									as [Estimado 2017]
,isnull(CONVERT(decimal(18,0),umemr.ME_1),0)								as [Estimado 2018]
,isnull(CONVERT(decimal(18,0),umemr.ME_2),0)								as [Estimado 2019]
,isnull(CONVERT(decimal(18,0),umemr.ME_3),0)								as [Estimado 2020]
,isnull(CONVERT(decimal(18,0),umemr.ME_Acumulado_3),0)						as [Estimado Posteriores]
,isnull(CONVERT(decimal(18,0),umemr.ME_Total),0)							as [Estimado Total]						

,isnull(CONVERT(decimal(18,0),umemr.MR_Acumulado_m5),0)						as [Realizados Anteriores]
,isnull(CONVERT(decimal(18,0),umemr.MR_m5),0)								as [Realizado 2012]
,isnull(CONVERT(decimal(18,0),umemr.MR_m4),0)								as [Realizado 2013]
,isnull(CONVERT(decimal(18,0),umemr.MR_m3),0)								as [Realizado 2014]
,isnull(CONVERT(decimal(18,0),umemr.MR_m2),0)								as [Realizado 2015]
,isnull(CONVERT(decimal(18,0),umemr.MR_m1),0)								as [Realizado 2016]
,isnull(CONVERT(decimal(18,0),umemr.MR),0)				   					as [Realizado 2017]
,isnull(CONVERT(decimal(18,0),umemr.MR_1),0)								as [Realizado 2018]
,isnull(CONVERT(decimal(18,0),umemr.MR_2),0)								as [Realizado 2019]
,isnull(CONVERT(decimal(18,0),umemr.MR_3),0)								as [Realizado 2020]
,isnull(CONVERT(decimal(18,0),umemr.MR_Acumulado_3),0)						as [Realizado Posteriores]
,isnull(CONVERT(decimal(18,0),umemr.MR_Total),0)							as [Realizado Total]

-- Costo total actual =
-- Montos Realizados Acumulados desde Year-1 hacia atras +
-- Montos Estimados Acumulados desde Year hacia adelante
,isnull(CONVERT(decimal(18,0),umemr.MR_CostoTotal_Year),0) +
 isnull(CONVERT(decimal(18,0),umemr.ME_CostoTotal_Year),0)					as [Costo Total Actual]

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

-- Año de referencia de los periodos
--,@Year																	as [Año_Referencia]

-- Datos de los montos iniciales del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MI_Acumulado_m5),0)					as [MontoInicial Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MI_m5),0)							as [MontoInicial 2012]
,isnull(CONVERT(decimal(18,0),unpre.MI_m4),0)							as [MontoInicial 2013]
,isnull(CONVERT(decimal(18,0),unpre.MI_m3),0)							as [MontoInicial 2014]
,isnull(CONVERT(decimal(18,0),unpre.MI_m2),0)							as [MontoInicial 2015]
,isnull(CONVERT(decimal(18,0),unpre.MI_m1),0)							as [MontoInicial 2016]	
,isnull(CONVERT(decimal(18,0),unpre.MI),0)								as [MontoInicial 2017]
,isnull(CONVERT(decimal(18,0),unpre.MI_1),0)							as [MontoInicial 2018]
,isnull(CONVERT(decimal(18,0),unpre.MI_2),0)							as [MontoInicial 2019]
,isnull(CONVERT(decimal(18,0),unpre.MI_3),0)							as [MontoInicial 2020]
,isnull(CONVERT(decimal(18,0),unpre.MI_Acumulado_3),0)					as [MontoInicial Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MI_Total),0)						as [MontoInicial Total]	
-- Datos de los montos vigentes del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MV_Acumulado_m5),0)					as [MontoVigente Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MV_m5),0)							as [MontoVigente 2012]
,isnull(CONVERT(decimal(18,0),unpre.MV_m4),0)							as [MontoVigente 2013]
,isnull(CONVERT(decimal(18,0),unpre.MV_m3),0)							as [MontoVigente 2014]
,isnull(CONVERT(decimal(18,0),unpre.MV_m2),0)							as [MontoVigente 2015]
,isnull(CONVERT(decimal(18,0),unpre.MV_m1),0)							as [MontoVigente 2016]	
,isnull(CONVERT(decimal(18,0),unpre.MV),0)								as [MontoVigente 2017]
,isnull(CONVERT(decimal(18,0),unpre.MV_1),0)							as [MontoVigente 2018]
,isnull(CONVERT(decimal(18,0),unpre.MV_2),0)							as [MontoVigente 2019]
,isnull(CONVERT(decimal(18,0),unpre.MV_3),0)							as [MontoVigente 2020]
,isnull(CONVERT(decimal(18,0),unpre.MV_Acumulado_3),0)					as [MontoVigente Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MV_Total),0)						as [MontoVigente Total]	
-- Datos de los montos vigentes estimativos del proyecto, de acuerdo al año ingresado como parametro --
,isnull(unpre.MVE_m5,false)							as [MontoVigenteEstimativo 2012]
,isnull(unpre.MVE_m4,false)							as [MontoVigenteEstimativo 2013]
,isnull(unpre.MVE_m3,false)							as [MontoVigenteEstimativo 2014]
,isnull(unpre.MVE_m2,false)							as [MontoVigenteEstimativo 2015]
,isnull(unpre.MVE_m1,false)							as [MontoVigenteEstimativo 2016]	
,isnull(unpre.MVE,false)							as [MontoVigenteEstimativo 2017]
,isnull(unpre.MVE_1,false)							as [MontoVigenteEstimativo 2018]
,isnull(unpre.MVE_2,false)							as [MontoVigenteEstimativo 2019]
,isnull(unpre.MVE_3,false)							as [MontoVigenteEstimativo 2020]
-- Datos de los montos devengados del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MD_Acumulado_m5),0)					as [MontoDevengado Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MD_m5),0)							as [MontoDevengado 2012]
,isnull(CONVERT(decimal(18,0),unpre.MD_m4),0)							as [MontoDevengado 2013]
,isnull(CONVERT(decimal(18,0),unpre.MD_m3),0)							as [MontoDevengado 2014]
,isnull(CONVERT(decimal(18,0),unpre.MD_m2),0)							as [MontoDevengado 2015]
,isnull(CONVERT(decimal(18,0),unpre.MD_m1),0)							as [MontoDevengado 2016]	
,isnull(CONVERT(decimal(18,0),unpre.MD),0)								as [MontoDevengado 2017]
,isnull(CONVERT(decimal(18,0),unpre.MD_1),0)							as [MontoDevengado 2018]
,isnull(CONVERT(decimal(18,0),unpre.MD_2),0)							as [MontoDevengado 2019]
,isnull(CONVERT(decimal(18,0),unpre.MD_3),0)							as [MontoDevengado 2020]
,isnull(CONVERT(decimal(18,0),unpre.MD_Acumulado_3),0)					as [MontoDevengado Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MD_Total),0)						as [MontoDevengado Total]	

from Proyecto p

-- Agrego los valores de los montos estimados y realizados
left join fn_Cubo_Union_ME_MR (@Year) umemr on p.IdProyecto = umemr.IdProyecto 
--left join #MontoEstimado me on me.IdProyecto = p.IdProyecto
--left join #MontoRealizado mr on mr.IdProyecto = p.IdProyecto
--Info presupuestaria xxxx
left join fn_Cubo_Union_Presupuestaria (@Year) unpre on p.IdProyecto = umemr.IdProyecto 

-- Estado fisico, Estado de Decision y Estado financiero
left join fn_Cubo_EstadoFinanciero_Group () pefinan on pefinan.IdProyecto = p.IdProyecto
left join EstadoDeDesicion est_decision on est_decision.IdEstadoDeDesicion = p.IdEstadoDeDesicion
left join fn_Cubo_EstadoFisico_Group () pefis on pefis.idproyecto = p.IdProyecto

-- Datos del Objeto del gasto (Inciso/PartidaPrincipal/PartidaParcial)
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
--left join ClasificacionGasto cg on cg.IdClasificacionGasto = me.idClasificacionGasto
--left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = me.IdFuenteFinanciamiento

-- Datos de la Apertura Presupuestaria (NroProyecto.NroActividad.NroObra)
-- Tipo_ApePresup Agrupado (Proyecto/Actividad)
left join fn_Cubo_AperturaPresupuestaria_Group () apepres on apepres.IdProyecto = p.IdProyecto

left join Proceso pr on pr.IdProceso = p.IdProceso
left join ProyectoTipo ptipo on ptipo.IdProyectoTipo = p.IdTipoProyecto

--left join dbo.fngetclasificacioninstitucional () clasinst on clasinst.idproyecto = p.IdProyecto

-- Datos para la Clasificacion Institucional
left join SubPrograma sprog on sprog.IdSubPrograma=p.IdSubPrograma
left join Programa prog on prog.IdPrograma=sprog.IdPrograma
left join Saf on Saf.IdSaf=prog.idsaf
left join EntidadTipo etipo on etipo.IdEntidadTipo=saf.IdEntidadTipo
left join Jurisdiccion juris on Juris.IdJurisdiccion=Saf.IdJurisdiccion
left join SubJurisdiccion sjuris on sjuris.IdSubJuridiccion=saf.IdSubJurisdiccion

left join OrganismoTipo otipo on otipo.IdOrganismoTipo=Saf.IdTipoOrganismo

-- Sectorialista asignado a un programa
left join persona sect on sect.Idpersona=prog.IdSectorialista

-- Usuario que modifica el proyecto
left join persona pers on pers.Idpersona=p.IdUsuarioModificacion

left join OrganismoPrioridad op on op.IdOrganismoPrioridad=p.IdOrganismoPrioridad

--Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
left join fn_Cubo_EvaluacionFactibilidad_Group () pefa on pefa.IdProyecto = p.IdProyecto

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
left join fn_Cubo_DictamenInversion_Group () pdia on pdia.IdProyecto = p.IdProyecto

--Gestion de Calidad (Administracion -> Calidad)
left join proyectocalidad pcalid on pcalid.IdProyecto = p.IdProyecto
left join Estado est_calid on est_calid.IdEstado = pcalid.IdEstado

left join FinalidadFuncion ff on ff.IdFinalidadFuncion=p.IdFinalidadFuncion

left join ProyectoPlan pp on pp.IdProyectoPlan=p.IdProyectoPlan
left join PlanPeriodo ppt on ppt.IdPlanPeriodo=pp.IdPlanPeriodo
left join PlanVersion ppv on ppv.IdPlanVersion=pp.IdPlanVersion
left join PlanTipo pt on pt.IdPlanTipo=ppt.IdPlanTipo

--left join fnGetPrioridadProyecto () ppriori on ppriori.idproyecto = p.IdProyecto

--Recupero los planes vinculados al proyecto
left join fn_Cubo_UltimoPlanPrioridad () upp on upp.IdProyecto=p.IdProyecto
left join fn_Cubo_Plan_Group () ppd on ppd.idproyecto=p.IdProyecto

--Recupero los comentarios tecnicos del tipo ECTO vinculados al proyecto
left join fn_Cubo_ECTO_Group () ecto on ecto.IdProyecto=p.IdProyecto

left join @ttProvincias tp on tp.idproyecto=p.IdProyecto

--Incorporo informacion de ONP a partir de la importacion del Ultimo CuboxTotal
left join Cubo_ImportCxTBapin2 CxT on CxT.Nro_Bapin = p.Codigo

--Incorporo informacion de ONP a partir de los proyectos vinculados por matching (tabla Matching_ProyectosVinculados)
--left join #onp_devengado onpd on onpd.Codigo = p.codigo
left join fn_Cubo_ONPDevengado(@Year) onpd on onpd.IdProyecto = p.IdProyecto

where p.Activo = 1 /*Solo Proyectos activos*/

END

GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxO]    Script Date: 11/28/2016 20:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Inicia_CxO]
AS
BEGIN

DECLARE	@return_value int

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxO]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxO]

CREATE TABLE [dbo].[Cubo_CxO](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Inciso] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar](max) NULL,
	[SAF] [varchar] (max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [int] NULL,
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
	[Req_Dict] [varchar](max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar](max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar](10) NULL,
	[Fecha_UltModificacion] [varchar](max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar](max) NULL,
	[Fecha_Fin_Estimada] [varchar](max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,	
	[Finalidad_Función] [nvarchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Objeto_Gasto_Cod] [varchar](max) NULL,
	[Objeto_Gasto_Desc] [varchar](max) NULL,
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

INSERT INTO [dbo].[Cubo_CxO] 
EXEC	@return_value = [dbo].[sp_Cubo_Genera_CxO]
END

GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoInicial]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoInicial] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Inicials por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,MI_Acumulado_m5=sum(case when periodo < @Year-5  then montoinicial else 0 end)
,MI_m5=sum(case when periodo=@Year-5 then montoinicial else 0 end)
,MI_m4=sum(case when periodo=@Year-4 then montoinicial else 0 end)
,MI_m3=sum(case when periodo=@Year-3 then montoinicial else 0 end) 
,MI_m2=sum(case when periodo=@Year-2 then montoinicial else 0 end) 
,MI_m1=sum(case when periodo=@Year-1 then montoinicial else 0 end) 
,ME=sum(case when periodo=@Year  then montoinicial else 0 end)
,MI_1=sum(case when periodo=@Year+1 then montoinicial else 0 end)
,MI_2=sum(case when periodo=@Year+2  then montoinicial else 0 end)
,MI_3=sum(case when periodo=@Year+3  then montoinicial else 0 end)
,MI_Acumulado_3=sum(case when periodo>@Year+3  then montoinicial else 0 end)
,MI_Total=sum(montoinicial)
,MI_CostoTotal_Year=sum(case when periodo > @Year-1 then montoinicial else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode/* ,pe.IdEstado*/

--order by cg.BreadcrumbCode
)


GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoVigente] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Vigentes por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

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

,MVE_m5=(case when periodo=@Year-5 then MontoVigenteEstimativo else 0 end)
,MVE_m4=(case when periodo=@Year-4 then MontoVigenteEstimativo else 0 end)
,MVE_m3=(case when periodo=@Year-3 then MontoVigenteEstimativo else 0 end)
,MVE_m2=(case when periodo=@Year-2 then MontoVigenteEstimativo else 0 end)
,MVE_m1=(case when periodo=@Year-1 then MontoVigenteEstimativo else 0 end)
,MVE=(case when periodo=@Year then MontoVigenteEstimativo else 0 end)
,MVE_1=(case when periodo=@Year+1 then MontoVigenteEstimativo else 0 end)
,MVE_2=(case when periodo=@Year+2 then MontoVigenteEstimativo else 0 end)
,MVE_3=(case when periodo=@Year+3 then MontoVigenteEstimativo else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode, peep.periodo, peep.MontoVigenteEstimativo

--order by cg.BreadcrumbCode
)
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoDevengado]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoDevengado] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Devengados por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,MI_Acumulado_m5=sum(case when periodo < @Year-5  then montodevengado else 0 end)
,MI_m5=sum(case when periodo=@Year-5 then montodevengado else 0 end)
,MI_m4=sum(case when periodo=@Year-4 then montodevengado else 0 end)
,MI_m3=sum(case when periodo=@Year-3 then montodevengado else 0 end) 
,MI_m2=sum(case when periodo=@Year-2 then montodevengado else 0 end) 
,MI_m1=sum(case when periodo=@Year-1 then montodevengado else 0 end) 
,ME=sum(case when periodo=@Year  then montodevengado else 0 end)
,MI_1=sum(case when periodo=@Year+1 then montodevengado else 0 end)
,MI_2=sum(case when periodo=@Year+2  then montodevengado else 0 end)
,MI_3=sum(case when periodo=@Year+3  then montodevengado else 0 end)
,MI_Acumulado_3=sum(case when periodo>@Year+3  then montodevengado else 0 end)
,MI_Total=sum(montodevengado)
,MI_CostoTotal_Year=sum(case when periodo > @Year-1 then montodevengado else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode/* ,pe.IdEstado*/

--order by cg.BreadcrumbCode
)
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_Presupuestaria]    Script Date: 04/21/2017 15:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Union_Presupuestaria] (@Year int )  

RETURNS  TABLE
AS
RETURN

(
-- Obtiene los Montos inicial, vigente y Devengado por Objeto de Gasto--

select 

isnull(isnull(MI.IdProyecto,MV_idproyecto),MD_idproyecto) as IdProyecto
,isnull(isnull(MI.codigo, MV_codigo), MD_codigo) as Nro_Bapin
,isnull(isnull(MI.Fuente_Financiamiento_Cod,MV_Fuente_Financiamiento_Cod),MD_Fuente_Financiamiento_Cod) as [Fuente_Financiamiento_Cod]
,isnull(isnull(MI.Fuente_Financiamiento_Desc,MV_Fuente_Financiamiento_Desc),MD_Fuente_Financiamiento_Desc) as [Fuente_Financiamiento_Desc]
,ISNULL(substring(MI.Objeto_Gasto_Cod,2,2),'00') as [Inciso]
,isnull(ISNULL(MI.Objeto_Gasto_Cod,MV_Objeto_Gasto_Cod),MD_Objeto_Gasto_Cod) as [Objeto_Gasto_Cod] 
,isnull(ISNULL(MI.Objeto_Gasto_Desc,MV_Objeto_Gasto_Desc),MD_Objeto_Gasto_Desc) as [Objeto_Gasto_Desc]

,isnull(MI_Acumulado_m5,0) as [MI_Acumulado_m5] --as [Inicials Anteriores] 
,isnull(MI_m5,0) as [MI_m5] --as [Inicial 2012]
,isnull(MI_m4,0) as [MI_m4] --as [Inicial 2013]
,isnull(MI_m3,0) as [MI_m3] --as [Inicial 2014]
,isnull(MI_m2,0) as [MI_m2] --as [Inicial 2015]
,isnull(MI_m1,0) as [MI_m1] --as [Inicial 2016]
,isnull(MI,0) as [MI] --as [Inicial 2017]
,isnull(MI_1,0) as [MI_1] --as [Inicial 2018]
,isnull(MI_2,0) as [MI_2] --as [Inicial 2019]
,isnull(MI_3,0) as [MI_3] --as [Inicial 2020]
,isnull(MI_Acumulado_3,0) as [MI_Acumulado_3] --as [Inicial Posteriores]
,isnull(MI.MI_Total,0) as [MI_Total] --as [Inicial Total]
,isnull(MI_CostoTotal_Year,0) as [MI_CostoTotal_Year]

,isnull(MV_Acumulado_m5,0) as [MV_Acumulado_m5] --as [Vigentes Anteriores]
,isnull(MV_m5,0) as [MV_m5] --as [Vigente 2012]
,isnull(MV_m4,0) as [MV_m4] --as [Vigente 2013]
,isnull(MV_m3,0) as [MV_m3] --as [Vigente 2014]
,isnull(MV_m2,0) as [MV_m2] --as [Vigente 2015]
,isnull(MV_m1,0) as [MV_m1] --as [Vigente 2016]
,isnull(MV,0) as [MV] --as [Vigente 2017]
,isnull(MV_1,0) as [MV_1] --as [Vigente 2018]
,isnull(MV_2,0) as [MV_2] --as [Vigente 2019]
,isnull(MV_3,0) as [MV_3] --as [Vigente 2020]
,isnull(MV_Acumulado_3,0) as [MV_Acumulado_3] --as [Vigente Posteriores]
,isnull(MV.MV_Total,0) as [MV_Total] --as [Vigente Total]
,isnull(MV_CostoTotal_Year,0) as [MV_CostoTotal_Year]

,isnull(MD_Acumulado_m5,0) as [MD_Acumulado_m5] --as [Vigentes Anteriores]
,isnull(MD_m5,0) as [MD_m5] --as [Vigente 2012]
,isnull(MD_m4,0) as [MD_m4] --as [Vigente 2013]
,isnull(MD_m3,0) as [MD_m3] --as [Vigente 2014]
,isnull(MD_m2,0) as [MD_m2] --as [Vigente 2015]
,isnull(MD_m1,0) as [MD_m1] --as [Vigente 2016]
,isnull(MD,0) as [MD] --as [Vigente 2017]
,isnull(MD_1,0) as [MD_1] --as [Vigente 2018]
,isnull(MD_2,0) as [MD_2] --as [Vigente 2019]
,isnull(MD_3,0) as [MD_3] --as [Vigente 2020]
,isnull(MD_Acumulado_3,0) as [MD_Acumulado_3] --as [Vigente Posteriores]
,isnull(MD.MD_Total,0) as [MD_Total] --as [Vigente Total]
,isnull(MD_CostoTotal_Year,0) as [MD_CostoTotal_Year]

,MV.MVE_m5
,MV.MVE_m4
,MV.MVE_m3
,MV.MVE_m2
,MV.MVE_m1
,MV.MVE
,MV.MVE_1
,MV.MVE_2
,MV.MVE_3
	
from 
	fn_Cubo_MontoInicial (@Year) MI 
	full join fn_Cubo_MontoVigente (@Year) MV on 
		(MI.Objeto_Gasto_Cod = MV_Objeto_Gasto_Cod) and
		(MI.Fuente_Financiamiento_Cod = MV_Fuente_Financiamiento_Cod) and
		(MI.IdProyecto = MV_IdProyecto)
	full join fn_Cubo_MontoDevengado (@Year) MD on 
		(MI.Objeto_Gasto_Cod = MD_Objeto_Gasto_Cod) and
		(MI.Fuente_Financiamiento_Cod = MD_Fuente_Financiamiento_Cod) and
		(MI.IdProyecto = MD_IdProyecto)
where
MI.Objeto_Gasto_Cod is not null or MV_Objeto_Gasto_Cod is not null or MD_Objeto_Gasto_Cod is not null

)

GO

CREATE PROCEDURE [dbo].[sp_Cubo_Filtra_CxO] (@IdUsusarioLogeado int)

AS

DECLARE

@UsuarioEsDeOficinaDNIP varchar (2) = 'No'
,@UsuarioTienePerfilOficina varchar (2) = 'Si'
--@EsUsuarioAdmin varchar (2)= 'No'
--,@EsPerfilAdminInversion varchar (2) = 'No'

BEGIN

--SET @EsUsuarioAdmin =   
--        CASE  
--			-- Valida si el usuario es 'admin' 
--            WHEN EXISTS(SELECT * FROM Usuario AS u
--						WHERE (u.IdUsuario = @IdUsusarioLogeado)
--								and u.NombreUsuario = 'admin')   
--                THEN 'Si'
--END;
             
SET @UsuarioEsDeOficinaDNIP =   
        CASE                     
     		--Valida si el usuario pertenece a la 'DNIP'. IDOficina = 62
            WHEN EXISTS(SELECT ofi.IdOficina from Persona pers
						left join Oficina ofi on ofi.IdOficina = pers.IdOficina
						where pers.IdPersona = @IdUsusarioLogeado
						and ofi.IdOficina = 62)   
                THEN 'Si'
                ELSE 'No' 
END;

SET @UsuarioTienePerfilOficina =   
        CASE                     
     		--Valida si el usuario tiene un perfil de oficina asignado
            WHEN EXISTS(SELECT IdOficina FROM UsuarioOficinaPerfil
						left join perfil on perfil.IdPerfil = UsuarioOficinaPerfil.IdPerfil
						where IdUsuario = @IdUsusarioLogeado and IdPerfilTipo = 2) 						  
                THEN 'Si'
                ELSE 'No' 
END;

-- Si el Usuario pertenece a la oficina DNIP  o no tiene perfil oficina asignado
-- el procedimiento devuelve todos los proyectos,
-- y ademas incorpora la infomacion de ONP

--IF @EsUsuarioAdmin = 'Si' or @UsuarioEsDeOficinaDNIP = 'Si'
IF @UsuarioEsDeOficinaDNIP = 'Si' or @UsuarioTienePerfilOficina = 'No'
BEGIN

  SELECT distinct
  CxO.*  
  FROM Cubo_CxO CxO
  where CxO.EsBorrador = 'N' -- solo recupera los proyectos que no estan marcados como borrador
  
  /*
  SELECT distinct
  CxO.*  
  FROM proyecto p
  inner join Cubo_CxO CxO on CxO.Nro_Bapin = p.Codigo
  where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador 
  */

END
ELSE

-- Si el Usuario no es Admin o la oficina del usuario no es DNIP
-- Entonces muestra los proyectos que corresponden de acuerdo al perfil de oficina
-- (iniciador, ejecutor, responsable) 

BEGIN
	select distinct

[CxO].[Nro_Bapin]
,[CxO].[Denominacion]
,[CxO].[EsBorrador]
,[CxO].[Tipo]
,[CxO].[Inciso]
,[CxO].[Clasif_Instit]
,[CxO].[Jur_cod]
,[CxO].[Jurisdicción]
,[CxO].[Ape_Prog]
,[CxO].[SAF_cod]
,[CxO].[SAF]
,[CxO].[Progr_cod]
,[CxO].[Programa]
,[CxO].[Subprog_cod]
,[CxO].[Subprograma]
,[CxO].[Ape_Presup]
,[CxO].[NroProyecto]
,[CxO].[NroActividad]
,[CxO].[NroObra]
,[CxO].[Tipo_Presup]
,[CxO].[Ape_PresupActEsp]
,[CxO].[Es_Presup]
,[CxO].[Estado_Financiero]
,[CxO].[Estado_Fisico]
,[CxO].[Est_Decision]
,[CxO].[PrioridadDNIP]
,[CxO].[Art_15]
,[CxO].[Req_Dict]
,[CxO].[Estado_calidad]
,[CxO].[Fecha_Estado_Calidad]
,[CxO].[Eval_Factibilidad]
,[CxO].[Dict_Inversion]
,[CxO].[PrioridadOrganismo]
,[CxO].[Subprioridad]
,[CxO].[Prov_Cantidad]
,[CxO].[Localizacion_Provincia]
,[CxO].[Fecha_Alta]
,[CxO].[Fecha_UltModificacion]
,[CxO].[Usuario_UltModificación]
,[CxO].[Fecha_Inicio_Estimada]
,[CxO].[Fecha_Fin_Estimada]
,[CxO].[Planes]
,[CxO].[Ult_Plan]
,[CxO].[Ult_Demanda]
,[CxO].[Finalidad_Función]
,[CxO].[Finalidad_Funcion_Cod]
,[CxO].[Finalidad_Función_Desc]
,[CxO].[Objeto_Gasto_Cod]
,[CxO].[Objeto_Gasto_Desc]
,[CxO].[Fuente_Finaciamiento_Cod]
,[CxO].[Fuente_Financiamiento_Desc]
,[CxO].[Proceso]
,[CxO].[Sectorialista]
,[CxO].[Com_Tecnico_ECTO]
,[CxO].[Estimados Anteriores]
,[CxO].[Estimado 2012]
,[CxO].[Estimado 2013]
,[CxO].[Estimado 2014]
,[CxO].[Estimado 2015]
,[CxO].[Estimado 2016]
,[CxO].[Estimado 2017]
,[CxO].[Estimado 2018]
,[CxO].[Estimado 2019]
,[CxO].[Estimado 2020]
,[CxO].[Estimado Posteriores]
,[CxO].[Estimado Total]
,[CxO].[Realizados Anteriores]
,[CxO].[Realizado 2012]
,[CxO].[Realizado 2013]
,[CxO].[Realizado 2014]
,[CxO].[Realizado 2015]
,[CxO].[Realizado 2016]
,[CxO].[Realizado 2017]
,[CxO].[Realizado 2018]
,[CxO].[Realizado 2019]
,[CxO].[Realizado 2020]
,[CxO].[Realizado Posteriores]
,[CxO].[Realizado Total]
,[CxO].[Costo Total Actual]
,[CxO].[Generado]
,
[CxO].[MontoInicial Anteriores],
[CxO].[MontoInicial 2012],
[CxO].[MontoInicial 2013],
[CxO].[MontoInicial 2014],
[CxO].[MontoInicial 2015],
[CxO].[MontoInicial 2016],
[CxO].[MontoInicial 2017],
[CxO].[MontoInicial 2018],
[CxO].[MontoInicial 2019],
[CxO].[MontoInicial 2020],
[CxO].[MontoInicial Posteriores],
[CxO].[MontoInicial Total],
[CxO].[MontoVigente Anteriores],
[CxO].[MontoVigente 2012],
[CxO].[MontoVigente 2013],
[CxO].[MontoVigente 2014],
[CxO].[MontoVigente 2015],
[CxO].[MontoVigente 2016],
[CxO].[MontoVigente 2017],
[CxO].[MontoVigente 2018],
[CxO].[MontoVigente 2019],
[CxO].[MontoVigente 2020],
[CxO].[MontoVigente Posteriores],
[CxO].[MontoVigente Total],
[CxO].[MontoVigenteEstimativo 2012],
[CxO].[MontoVigenteEstimativo 2013],
[CxO].[MontoVigenteEstimativo 2014],
[CxO].[MontoVigenteEstimativo 2015],
[CxO].[MontoVigenteEstimativo 2016],
[CxO].[MontoVigenteEstimativo 2017],
[CxO].[MontoVigenteEstimativo 2018],
[CxO].[MontoVigenteEstimativo 2019],
[CxO].[MontoVigenteEstimativo 2020],
[CxO].[MontoDevengado Anteriores],
[CxO].[MontoDevengado 2012],
[CxO].[MontoDevengado 2013],
[CxO].[MontoDevengado 2014],
[CxO].[MontoDevengado 2015],
[CxO].[MontoDevengado 2016],
[CxO].[MontoDevengado 2017],
[CxO].[MontoDevengado 2018],
[CxO].[MontoDevengado 2019],
[CxO].[MontoDevengado 2020],
[CxO].[MontoDevengado Posteriores],
[CxO].[MontoDevengado Total]

from proyecto p
inner join (select distinct pop.IdProyecto from ProyectoOficinaPerfil pop
inner join fnIdsOficinaPorUsuario (@IdUsusarioLogeado) opu on opu.IdOficina = pop.IdOficina) uop
	on uop.IdProyecto = p.IdProyecto
inner join Cubo_CxO CxO on CxO.Nro_Bapin = p.Codigo
where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador

END
END

