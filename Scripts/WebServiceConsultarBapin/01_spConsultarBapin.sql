IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES 
           WHERE ROUTINE_NAME = 'spConsultarBapines' 
             AND ROUTINE_SCHEMA = 'dbo' 
             AND ROUTINE_TYPE = 'PROCEDURE')
 EXEC ('DROP PROCEDURE dbo.spConsultarBapines')
GO

CREATE PROCEDURE [dbo].[spConsultarBapines]
 @ejercicio int					--Año
,@estado VARCHAR(MAX) --Plan estado (Enumerativo: DEMANDA, PLAN, PLAN_SEGUN_EJECUCION, PLAN_OCT-DIC)
,@jurisdiccion int				--Jurisdiccion
,@bapin int = null				--Codigo BAPIN
,@saf int = null				--SAF
,@programas VARCHAR(MAX) = null --Programa
AS

BEGIN

select DISTINCT Y.Codigo						as bapin,
Y.ProyectoDenominacion				as denominacion,
J.IdJurisdiccion					as juridiccion,
F.IdSAF								as saf,
G.IdPrograma						as programa,
S.IdSubPrograma						as subprograma,
PE.FechaInicioEstimada				as fecha_inicio,
PE.FechaFinEstimada					as fecha_fin,
0									as costo_total,	--•	costo total (Importe) (*)
case PD.IdProyectoCalificacion		/*(Enumerativo: NND,SDF,AOP, ADO,ASO (**))*/
	when 1 then	'ASO'
	when 2 then	'AOP'
	else		'NND'
end									as estado_dictamen,
2018								as último_año_demanda,
2018								as último_año_plan,
2018								as último_año_plan_segun_ejecucion

from Proyecto Y
INNER JOIN SubPrograma S on Y.IdSubPrograma = S.IdSubPrograma
INNER JOIN Programa G on S.IdPrograma = G.IdPrograma
INNER JOIN Saf F on F.IdSaf = G.IdSAF
INNER JOIN Jurisdiccion J on J.IdJurisdiccion = F.IdJurisdiccion

LEFT JOIN ProyectoSeguimientoProyecto PSP on PSP.IdProyecto = Y.IdProyecto
LEFT JOIN ProyectoSeguimiento PS on PS.IdProyectoSeguimiento  = PSP.IdProyectoSeguimiento
LEFT JOIN ProyectoDictamenSeguimiento PDS on PDS.IdProyectoSeguimiento = PS.IdProyectoSeguimiento
LEFT JOIN ProyectoDictamen PD on PD.IdProyectoDictamen = PDS.IdProyectoDictamen

LEFT JOIN (select * from dbo.fn_Split(@programas,'|')) FP on G.Codigo = FP.Data

LEFT JOIN ProyectoEtapa PE	on PE.IdProyecto = Y.IdProyecto

LEFT JOIN ProyectoPlan PP on PP.IdProyecto = Y.IdProyecto
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

where 
PPE.AnioInicial = @ejercicio --required
AND J.Codigo = @jurisdiccion --required
AND Y.Codigo = ISNULL(@bapin, Y.Codigo)
AND F.Codigo = ISNULL(@saf, F.Codigo)


END
