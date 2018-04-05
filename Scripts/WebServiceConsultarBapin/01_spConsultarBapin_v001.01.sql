-- select top 1000 * from Cubo_CxT
--exec [spConsultarBapines] 2018, 'DEMANDA', 57, null, null, null

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES 
           WHERE ROUTINE_NAME = 'spConsultarBapines' 
             AND ROUTINE_SCHEMA = 'dbo' 
             AND ROUTINE_TYPE = 'PROCEDURE')
 EXEC ('DROP PROCEDURE dbo.spConsultarBapines')
GO

CREATE PROCEDURE [dbo].[spConsultarBapines]
 @ejercicio int					--Año
,@estado VARCHAR(MAX)			--Plan estado (Enumerativo: DEMANDA, PLAN, PLAN_SEGUN_EJECUCION, PLAN_OCT-DIC)
,@jurisdiccion int				--Jurisdiccion
,@bapin int = null				--Codigo BAPIN
,@saf int = null				--SAF
,@programas VARCHAR(MAX) = null --Programa
AS

BEGIN

select DISTINCT 
CAST(Cubo.Nro_Bapin AS bigint) 		as bapin,
Cubo.Denominacion					as denominacion,
CAST(Cubo.Jur_cod AS bigint) as jurisdiccion,
CAST(Cubo.SAF_cod AS bigint) 						as saf,
CAST(Cubo.Progr_cod AS bigint) 						as programa,
CAST(Cubo.Subprog_cod AS bigint) 					as subprograma,
Cubo.Fecha_Inicio_Estimada,
Cubo.Fecha_Fin_Estimada,
CONVERT(datetime, Cubo.Fecha_Inicio_Estimada, 103)			as fecha_inicio,
CONVERT(datetime, Cubo.Fecha_Fin_Estimada, 103)				as fecha_fin,
Cubo.[Costo Total Actual]			as costo_total,	--•	costo total (Importe) (*)
/*
Definicion para el ESTADO DE DICTAMEN
ASO: ("ASO", "Aprobado sin observaciones"),
ACO: ("ACO", "Aprobado con observaciones"), donde ACO = "calificacion de dictamen"= "Aprobado c/ observaciones" y "estado de dictamen" = TERMINADO
SDF: ("SDF", "Sin dictamen firme"), donde SDF = requiere dictamen y "calificacion de dictamen"= "vacio" o requiere dictamen y "estado de dictamen" = OBSERVADO
SDF: ("SDF", "Sin dictamen firme"), donde SDF = "Aprobado c/ observaciones" y "estado de dictamen" = OBSERVADO
NND: ("NND", "No necesita dictamen")
*/
estado_dictamen = case 
when Cubo.Req_Dict like 'N' then 'NND'
when Cubo.Req_Dict like 'S' then
	CASE 
		when Cubo.Dict_Inversion like '%APROBADO CON OBSERVACIONES%' and Cubo.Dict_Inversion like '%Terminado' then 'ACO'
		when Cubo.Dict_Inversion like '%APROBADO%' and Cubo.Dict_Inversion not like '%APROBADO CON OBSERVACIONES%' then 'ASO'
		when Cubo.Dict_Inversion like '%APROBADO CON OBSERVACIONES%' and Cubo.Dict_Inversion like '%Observado' then 'ACO'
		when Cubo.Dict_Inversion = '' or Cubo.Dict_Inversion like '%OBSERVADO%' then 'SDF'
		else 'NND'
	END
else 'NND'
end,
CAST(ISNULL(UltimaDemanda.AnioInicial,0) AS bigint)				as ultimo_anio_demanda,
CAST(ISNULL(UltimoPlan.AnioInicial,0) AS bigint)					as ultimo_anio_plan,
CAST(ISNULL(UltimoPlanSegunEjecucion.AnioInicial,0) AS bigint)	as ultimo_anio_plan_segun_ejecucion

from Cubo_CxT Cubo
INNER JOIN Proyecto P on Cubo.Nro_Bapin = P.Codigo
LEFT JOIN (select * from dbo.fn_Split(@programas,'|')) FP on Cubo.Progr_cod = FP.Data
-- Cruzo con los planes.
LEFT JOIN ProyectoPlan PP on PP.IdProyecto = P.IdProyecto
INNER JOIN PlanPeriodo PPE on PPE.IdPlanPeriodo = PP.IdPlanPeriodo
INNER JOIN PlanVersion PV on PV.IdPlanVersion = PP.IdPlanVersion
INNER JOIN (select * from dbo.fn_Split(@estado,'|')) ES on 
	(	(ES.Data = 'DEMANDA' and PPE.IdPlanTipo = 5) --Incluye toda la DEMANDA indepte de la version.
		OR 
		(ES.Data = 'PLAN' and PPE.IdPlanTipo = 4 and PV.IdPlanVersion = 2 /*Presupuesto Nacional*/)
		OR 
		(REPLACE(ES.Data,' ','_') = 'PLAN_SEGUN_EJECUCION' and PPE.IdPlanTipo = 4 and PV.IdPlanVersion = 3 /*Alta durante la ejecución del Presupuesto*/)
		OR 
		(REPLACE(ES.Data,' ','_') = 'PLAN_OCT-DIC' and PPE.IdPlanTipo = 4 and PV.IdPlanVersion = 37 /*Octubre - Diciembre*/) ) --required

LEFT JOIN	(
			select		Pint.IdProyecto, max(ppe.AnioInicial) as AnioInicial
			from		Proyecto Pint
			INNER JOIN	ProyectoPlan PP on PP.IdProyecto = Pint.IdProyecto
			INNER JOIN	PlanPeriodo PPE on PPE.IdPlanPeriodo = PP.IdPlanPeriodo
			INNER JOIN	PlanVersion PV on PV.IdPlanVersion = PP.IdPlanVersion
			where		PPE.IdPlanTipo = 5 --Demanda
			group by	Pint.IdProyecto
			) as UltimaDemanda on UltimaDemanda.IdProyecto = P.IdProyecto

LEFT JOIN	(
			select		Pint.IdProyecto, max(ppe.AnioInicial) as AnioInicial
			from		Proyecto Pint
			INNER JOIN	ProyectoPlan PP on PP.IdProyecto = Pint.IdProyecto
			INNER JOIN	PlanPeriodo PPE on PPE.IdPlanPeriodo = PP.IdPlanPeriodo
			INNER JOIN	PlanVersion PV on PV.IdPlanVersion = PP.IdPlanVersion
			where		PPE.IdPlanTipo = 4 and PV.IdPlanVersion = 2 --Plan Nacional Presupuestario
			group by	Pint.IdProyecto
			) as UltimoPlan on UltimoPlan.IdProyecto = P.IdProyecto

LEFT JOIN	(
			select		Pint.IdProyecto, max(ppe.AnioInicial) as AnioInicial
			from		Proyecto Pint
			INNER JOIN	ProyectoPlan PP on PP.IdProyecto = Pint.IdProyecto
			INNER JOIN	PlanPeriodo PPE on PPE.IdPlanPeriodo = PP.IdPlanPeriodo
			INNER JOIN	PlanVersion PV on PV.IdPlanVersion = PP.IdPlanVersion
			where		PPE.IdPlanTipo = 4 and PV.IdPlanVersion = 3 --Plan Nacional Presupuestario
			group by	Pint.IdProyecto
			) as UltimoPlanSegunEjecucion on UltimoPlanSegunEjecucion.IdProyecto = P.IdProyecto

where 
PPE.AnioInicial		= @ejercicio	--required
AND Cubo.Jur_cod	= @jurisdiccion --required
AND Cubo.Nro_Bapin	= ISNULL(@bapin, Cubo.Nro_Bapin)
AND Cubo.SAF_cod	= ISNULL(@saf, Cubo.SAF_cod)


END

GO


