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

select DISTINCT Cubo.Nro_Bapin		as bapin,
Cubo.Denominacion					as denominacion,
Cubo.Jur_cod						as juridiccion,
Cubo.SAF_cod						as saf,
Cubo.Progr_cod						as programa,
Cubo.Subprog_cod					as subprograma,
Cubo.Fecha_Inicio_Estimada			as fecha_inicio,
Cubo.Fecha_Fin_Estimada				as fecha_fin,
Cubo.[Costo Total Actual]			as costo_total,	--•	costo total (Importe) (*)
/*
Definicion para el ESTADO DE DICTAMEN
NND: Es vacío el Campo Calificación Dictamen + Sin Tilde en Requiere Dictamen
SDF: Es vacío el Campo Calificación Dictamen + Tilde en el Campo Requiere Dictamen
AOP: Campo Calificación Dictamen “APROBADO CON OBSERVACIONES” + Estado “OBSERVADO”
ADO: Campo Calificación Dictamen “APROBADO CON OBSERVACIONES” + Estado “TERMINADO”
ASO: Campo Calificación Dictamen “APROBADO” + Estado “TERMINADO”
*/
'Hay que programarlo!'				as estado_dictamen,
UltimaDemanda.AnioInicial			as último_año_demanda,
UltimoPlan.AnioInicial				as último_año_plan,
UltimoPlanSegunEjecucion.AnioInicial	as último_año_plan_segun_ejecucion

from Cubo_CxT Cubo
INNER JOIN Proyecto P on Cubo.Nro_Bapin = P.Codigo

/*
LEFT JOIN ProyectoSeguimientoProyecto PSP on PSP.IdProyecto = Y.IdProyecto
LEFT JOIN ProyectoSeguimiento PS on PS.IdProyectoSeguimiento  = PSP.IdProyectoSeguimiento
LEFT JOIN ProyectoDictamenSeguimiento PDS on PDS.IdProyectoSeguimiento = PS.IdProyectoSeguimiento
LEFT JOIN ProyectoDictamen PD on PD.IdProyectoDictamen = PDS.IdProyectoDictamen
*/

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


