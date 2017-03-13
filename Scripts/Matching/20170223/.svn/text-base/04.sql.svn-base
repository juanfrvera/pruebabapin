--+++++++++++++inicio de Proceso Matching traigo los datos del período+++++++++++++++++++
--Variable para Identificador de proyectos del tipo Marca Plan

--Declare @intIdPlanTipo as integer
--set @intIdPlanTipo = (SELECT IDPlanTipo from PlanTipo where Sigla='PLAN') 

--Declare @intIdPlanPeriodo as integer --Variable para traer los proyectos a ser considerados en el período del plan = Proyectos del año en curso es decir para año 2016 proyectos 2016, para 2017 proyectos de 2017.
--set @intIdPlanPeriodo=(Select IdPlanPeriodo from PlanPeriodo where IdPlanTipo=@intIdPlanTipo and AnioInicial=year(getdate()))

--Selección de IdProyecto  de proyectos Candidatos, con información de AperturaProgramática SAF+Programa+SubPrograma para el período en curso
DELETE FROM [Matching_tmpProyectosCandidatos]
INSERT INTO [Matching_tmpProyectosCandidatos]
SELECT pr.IdProyecto, pr.ProyectoDenominacion, pr.ProyectoDescripcion,pr.Codigo as CodigoProyectoBAPIN, jr.Codigo as CodigoJurisdiccion,jr.Nombre, 
saf.IdJurisdiccion, Saf.IdSaf,Saf.Codigo as CodigoSAF,Saf.Denominacion as SAF_Denominacion, 
pro.Codigo as CodigoPrograma ,pro.Nombre as Programa, 
sp.Codigo as CodigoSubprograma,sp.Nombre as SubPrograma, 
sp.IdPrograma as ProgramaEnSubPrograma, 
NroProyecto= CASE WHEN LEN(CAST(pr.NroProyecto  as nvarchar(10)))= 1 THEN Cast('0' + cast(pr.NroProyecto as nvarchar(10)) as nvarchar(10)) ELSE Cast(pr.NroProyecto  as nvarchar(10)) END,

(
CASE WHEN LEN(CAST(jr.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(jr.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(jr.Codigo as nvarchar(10)) END +
CASE WHEN LEN(CAST(Saf.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Saf.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Saf.Codigo as nvarchar(10)) END +
CASE WHEN LEN(CAST(pro.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(pro.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(pro.Codigo as nvarchar(10)) END +
CASE WHEN LEN(CAST(sp.Codigo  as nvarchar(10)))= 1 THEN Cast('0' + cast(sp.Codigo  as nvarchar(10)) as nvarchar(10)) ELSE Cast(sp.Codigo  as nvarchar(10)) END
) as AperturaProgramatica,
CAST(year(getdate()) as varchar(4))+CAST(month(getdate())-1 as varchar(4)) as MesAnio,
year(getdate()) as Anio, Cast(month(getdate())-1  as nvarchar(2)) as Mes,
(
CASE WHEN LEN(CAST(jr.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(jr.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(jr.Codigo as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST(Saf.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(Saf.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(Saf.Codigo as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST(pro.Codigo as nvarchar(10)))= 1 THEN Cast('0' + cast(pro.Codigo as nvarchar(10)) as nvarchar(10)) ELSE Cast(pro.Codigo as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST(sp.Codigo  as nvarchar(10)))= 1 THEN Cast('0' + cast(sp.Codigo  as nvarchar(10)) as nvarchar(10)) ELSE Cast(sp.Codigo  as nvarchar(10)) END
) as AperturaProgramaticaSeparada --Separa la APertura Presupuestaria

FROM Proyecto pr LEFT JOIN Subprograma sp on pr.IdSubPrograma = sp.IdSubPrograma 
 LEFT JOIN Programa pro on pro.IdPrograma= sp.IdPrograma 
 LEFT JOIN Saf on saf.IdSaf= pro.IdSAF 
 LEFT JOIN Jurisdiccion jr on jr.IdJurisdiccion= saf.IdJurisdiccion
where pr.IDProyecto in (Select IdProyecto from ProyectoPlan 
where IdPlanPeriodo  in (select IdPlanPeriodo from Matching_Config)) -- El plan del periodo es el elegido en la configuración del usuario


/************************************************
Generación de tabla Matching_tmpGastosBapin
Entidad que contiene los datos de Estimado y Realizado por Proyecto y Etapa de aquí surgen los datos 
de Actividad y Obra que serán luego utilizados para armar la Apertura Presupuestaria
*****************************************************
	* IMPORTANTE CONSIDERAR LOS SIGUIENTES DATOS: 		*
	*IdEtapa	IdFase	Codigo	Nombre	Orden	Activo  *
	*	5		2		OB		Obra		1	1		*
	*	6		2		AC		Actividad	2	1		*									*
	*--------------------------------------------------	*
*/

--Eliminación de Datos Temporales de Gastos Bapin
DELETE FROM	 Matching_tmpGastosBapin
INSERT INTO Matching_tmpGastosBapin
--Datos de Actividad
SELECT prEtapa.IdProyecto,prEtapa.IdProyectoEtapa,prEtapa.IdEtapa,prEtapa.NroEtapa,prEtapa.Nombre,
PEstimado.Estimado,PRealizado.Realizado,
'00' + CASE WHEN LEN(CAST(prEtapa.NroEtapa as nvarchar(10)))= 1 THEN Cast('0' + cast(prEtapa.NroEtapa as nvarchar(10)) as nvarchar(10)) ELSE Cast(prEtapa.NroEtapa as nvarchar(10)) END as ActividadObra,
'00' + '.' + CASE WHEN LEN(CAST(prEtapa.NroEtapa as nvarchar(10)))= 1 THEN Cast('0' + cast(prEtapa.NroEtapa as nvarchar(10)) as nvarchar(10)) ELSE Cast(prEtapa.NroEtapa as nvarchar(10)) END as ActividadObraSeparada,
PRealizado.Periodo as PeriodoRealizado,PEstimado.Periodo as PeriodoEstimado

FROM ProyectoEtapa prEtapa 
LEFT JOIN
--Estimado
(SELECT PE.IdProyectoEtapa, PMont.Periodo, Sum(PMont.Estimado) as Estimado
FROM proyectoEtapaEstimado PE LEFT JOIN
(SELECT IdProyectoEtapaEstimado, Periodo, sum (Monto) as Estimado
FROM  ProyectoEtapaEstimadoPeriodo
GROUP BY IdProyectoEtapaEstimado, Periodo) PMont on PE.IdProyectoEtapaEstimado=PMont.IdProyectoEtapaEstimado
GROUP BY PE.IdProyectoEtapa, PMont.Periodo) PEstimado on prEtapa.IdProyectoEtapa=PEstimado.IdProyectoEtapa
LEFT JOIN
--Realizado
(SELECT PR.IdProyectoEtapa, PMont.Periodo, Sum(PMont.Realizado) as Realizado
FROM ProyectoEtapaRealizado PR LEFT JOIN
(SELECT IdProyectoEtapaRealizado, Periodo, sum (Monto) as Realizado
FROM  ProyectoEtapaRealizadoPeriodo
GROUP BY IdProyectoEtapaRealizado, Periodo) PMont on PR.IdProyectoEtapaRealizado=PMont.IdProyectoEtapaRealizado
GROUP BY PR.IdProyectoEtapa, PMont.Periodo) PRealizado on prEtapa.IdProyectoEtapa=PRealizado.IdProyectoEtapa and PEstimado.Periodo=PRealizado.Periodo
WHERE prEtapa.IdEtapa=5 AND (PEstimado.Periodo between 
(select Min(AnioInicial)
 from Matching_Config) and (Select Max(AnioFinal) from Matching_Config) 
 OR PRealizado.Periodo Between 
 (select Min(AnioInicial) from Matching_Config) and
  (Select Max(AnioFinal) from Matching_Config))
UNION
--Incorporar datos de Obra 6
SELECT prEtapa.IdProyecto,prEtapa.IdProyectoEtapa,prEtapa.IdEtapa,prEtapa.NroEtapa,prEtapa.Nombre,
PEstimado.Estimado,PRealizado.Realizado,
CASE WHEN LEN(CAST(prEtapa.NroEtapa as nvarchar(10)))= 1 THEN Cast('0' + cast(prEtapa.NroEtapa as nvarchar(10)) as nvarchar(10)) ELSE Cast(prEtapa.NroEtapa as nvarchar(10)) END + '00' as ActividadObra,
CASE WHEN LEN(CAST(prEtapa.NroEtapa as nvarchar(10)))= 1 THEN Cast('0' + cast(prEtapa.NroEtapa as nvarchar(10)) as nvarchar(10)) ELSE Cast(prEtapa.NroEtapa as nvarchar(10)) END + '.00' as ActividadObraSeparada,
PRealizado.Periodo,PEstimado.Periodo
FROM ProyectoEtapa prEtapa 
LEFT JOIN
--Estimado
(SELECT PE.IdProyectoEtapa, PMont.Periodo, Sum(PMont.Estimado) as Estimado
FROM proyectoEtapaEstimado PE LEFT JOIN
(SELECT IdProyectoEtapaEstimado, Periodo, sum (Monto) as Estimado
FROM  ProyectoEtapaEstimadoPeriodo
GROUP BY IdProyectoEtapaEstimado, Periodo) PMont on PE.IdProyectoEtapaEstimado=PMont.IdProyectoEtapaEstimado
GROUP BY PE.IdProyectoEtapa, PMont.Periodo) PEstimado on prEtapa.IdProyectoEtapa=PEstimado.IdProyectoEtapa
LEFT JOIN
--Realizado
(SELECT PR.IdProyectoEtapa, PMont.Periodo, Sum(PMont.Realizado) as Realizado
FROM ProyectoEtapaRealizado PR LEFT JOIN
(SELECT IdProyectoEtapaRealizado, Periodo, sum (Monto) as Realizado
FROM  ProyectoEtapaRealizadoPeriodo
GROUP BY IdProyectoEtapaRealizado, Periodo) PMont on PR.IdProyectoEtapaRealizado=PMont.IdProyectoEtapaRealizado
GROUP BY PR.IdProyectoEtapa, PMont.Periodo) PRealizado on prEtapa.IdProyectoEtapa=PRealizado.IdProyectoEtapa and PEstimado.Periodo=PRealizado.Periodo
WHERE prEtapa.IdEtapa=6 AND 
(PEstimado.Periodo between 
(select Min(AnioInicial)
 from Matching_Config) and (Select Max(AnioFinal) from Matching_Config) 
 OR PRealizado.Periodo Between 
 (select Min(AnioInicial) from Matching_Config) and
  (Select Max(AnioFinal) from Matching_Config))
--(PEstimado.Periodo=year(getdate()) OR PRealizado.Periodo=year(getdate()))


