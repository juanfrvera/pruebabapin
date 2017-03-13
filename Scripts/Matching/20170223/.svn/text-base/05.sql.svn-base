/*

 ESTE QUERY ANALIZA LOS CAMBIOS DE PROYECTOS POSTERIOR A LA ACTUALIZACIÓN DEL SIDIF Y LOS VINCULA CON BAPIN
 GENERANDO EL REGISTRO UNICO POR MES DE PROCESAMIENTO
 */
 
 --SETEO LAS VARIABLES
DECLARE @EjercicioPresupuestario as int
SET @EjercicioPresupuestario=YEAR(GETDATE())-1
DECLARE @mesProceso as int
DECLARE @mesSidif as nvarchar(2)
SET @mesSidif= 12
SET @mesProceso=12
--Elimino aquellos proyectos que no tienen vinculación

DELETE FROM Matching_ProyectosVinculados 
WHERE EjercicioPresupuestario=@EjercicioPresupuestario AND MesSidif=@mesProceso 
AND Matching_ProyectosVinculados.IdentificadorProyectoSidif NOT IN
(SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados WHERE EjercicioPresupuestario=@EjercicioPresupuestario AND MesSidif=@mesProceso )

INSERT INTO Matching_ProyectosVinculados

SELECT Sidif.IdentificadorProyectoSidif, sidif.EjercicioPresupuestario, Sidif.MesSidif,
Sidif.AperturaProgramatica, Sidif.AperturaPresupuestaria, Sidif.CreditoInicial, Sidif.CreditoVigente, Sidif.Pagado, Sidif.Devengado, 
Bapin.CodigoProyectoBAPIN, Bapin.ProyectoDenominacion, Bapin.Estimado, Bapin.Realizado,
Sidif.AperturaProgramaticaSeparada,Sidif.AperturaPresupuestariaSeparada,Sidif.CodJurisdiccion,Sidif.CodSAF, Sidif.CodPrograma,Sidif.CodSubprograma, cast(NULL as nvarchar(200)) as [ProyectoND]

FROM
	(SELECT * from Matching_InfoPresupuestoAgrupado
		  ) Sidif
		  Left Join 
		  (

SELECT pc.*,sum(ISNULL(gb.Estimado,0)) as Estimado, sum(ISNULL(gb.Realizado,0)) as Realizado,
	Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as AperturaPresupuestaria,
	Cast(pc.NroProyecto as nvarchar(10))+'.'+gb.ActividadObraSeparada as AperturaPresupuestariaSeparada,
	pc.AperturaProgramatica + Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as IdentUnico
	FROM Matching_tmpProyectosCandidatos pc INNER JOIN
	Matching_tmpGastosBapin gb on pc.IdProyecto=gb.IdProyecto
	WHERE pc.NroProyecto IS NOT NULL AND gb.ActividadObra IS NOT NULL
	GROUP BY 
	pc.IdProyecto,ProyectoDenominacion,ProyectoDescripcion,
	CodigoProyectoBAPIN,CodigoJurisdiccion,pc.Nombre,
	IdJurisdiccion,IdSaf,CodigoSAF,SAF_Denominacion,
	CodigoPrograma,Programa,
    CodigoSubprograma,SubPrograma,
	ProgramaEnSubPrograma,NroProyecto,AperturaProgramatica,MesAnio,Anio,Mes,AperturaProgramaticaSeparada,
	Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra,
	Cast(pc.NroProyecto as nvarchar(10))+'.'+gb.ActividadObraSeparada,
	pc.AperturaProgramatica + Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra
	
) Bapin ON Sidif.AperturaPresupuestaria=Bapin.AperturaPresupuestaria AND Sidif.AperturaProgramatica=bapin.AperturaProgramatica
	WHERE Bapin.CodigoProyectoBAPIN IS NOT NULL AND Sidif.EjercicioPresupuestario=@EjercicioPresupuestario and Sidif.MesSidif=@mesProceso
	AND Sidif.IdentificadorProyectoSidif NOT IN (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados WHERE EjercicioPresupuestario=@EjercicioPresupuestario AND MesSidif=@mesProceso )


--Actualizo los datos de la importación  aquellos proyectos que ya tienen vinculación
Update Matching_ProyectosVinculados
SET CreditoInicial=DAtos.CreditoInicial,
CreditoVigente=Datos.CreditoVigente,
Pagado=Datos.Pagado,
Devengado=Datos.Devengado,
Estimado=Datos.Estimado,
Realizado=Datos.Realizado
FROM
(
SELECT Sidif.IdentificadorProyectoSidif,Sidif.CreditoInicial,Sidif.CreditoVigente,Sidif.Pagado,Sidif.Devengado, Bapin.Estimado,Bapin.Realizado, Bapin.CodigoProyectoBAPIN from Matching_InfoPresupuestoAgrupado
		  Sidif
		  Left Join 
		  (
	SELECT pc.*,gb.Estimado, gb.Realizado,
	Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as AperturaPresupuestaria,
	Cast(pc.NroProyecto as nvarchar(10))+'.'+ gb.ActividadObraSeparada as AperturaPresupuestariaSeparada,

	pc.AperturaProgramatica + Cast(pc.NroProyecto as nvarchar(10))+gb.ActividadObra as IdentUnico
	FROM Matching_tmpProyectosCandidatos pc INNER JOIN
	Matching_tmpGastosBapin gb on pc.IdProyecto=gb.IdProyecto
	WHERE pc.NroProyecto IS NOT NULL AND gb.ActividadObra IS NOT NULL
	) Bapin ON Sidif.AperturaPresupuestaria=Bapin.AperturaPresupuestaria AND Sidif.AperturaProgramatica=bapin.AperturaProgramatica
	) Datos 
	WHERE Datos.IdentificadorProyectoSidif=Matching_ProyectosVinculados.IdentificadorProyectoSidif


--Proceso los proyectos ND 
--Genera proyectos ND Candidatos
DELETE FROM  Matching_tmpCandidatosND
INSERT INTO  Matching_tmpCandidatosND
select PRC.IdentificadorProyectoSidif, ND.[BapinND] 
from 
(select  IdentificadorProyectoSidif, Count(CodigoProyectoBAPIN) as ND 
from Matching_ProyectosVinculados
group by IdentificadorProyectoSidif
having Count(CodigoProyectoBAPIN) >1) PRC inner join 
(Select distinct ST2.IdentificadorProyectoSidif, 
    substring(
        (
            Select ' | '+ cast(ST1.CodigoProyectoBAPIN as nvarchar(10))  AS [text()]
            From Matching_ProyectosVinculados ST1
            Where ST1.IdentificadorProyectoSidif = ST2.IdentificadorProyectoSidif
            ORDER BY ST1.IdentificadorProyectoSidif
            For XML PATH ('')
        ), 2, 1000) [BapinND]
From dbo.Matching_ProyectosVinculados ST2 ) ND 
on PRC.IdentificadorProyectoSidif=ND.IdentificadorProyectoSidif

--Genera Tabla temporal de Proyectos Vinculados que se le aplicará la actualización del Contenido ND
DELETE FROM Matching_tmpProyectosVinculadosND
INSERT INTO Matching_tmpProyectosVinculadosND
SELECT DISTINCT
IdentificadorProyectoSidif,
EjercicioPresupuestario,
MesSidif,
AperturaProgramatica,
AperturaPresupuestaria,
CreditoInicial,
CreditoVigente,
Pagado,
Devengado,
sum(Estimado) as Estimado,
sum(Realizado) as Realizado,
AperturaProgramaticaSeparada,
AperturaPresupuestariaSeparada,
CodJurisdiccion,
CodSAF,
CodPrograma,
CodSubprograma,
ProyectoND
FROM Matching_ProyectosVinculados 
--where IdentificadorProyectoSidif IN (select IdentificadorProyectoSidif from Matching_tmpCandidatosND)
Group by 
IdentificadorProyectoSidif,
EjercicioPresupuestario,
MesSidif,
AperturaProgramatica,
AperturaPresupuestaria,
CreditoInicial,
CreditoVigente,
Pagado,
Devengado,
AperturaProgramaticaSeparada,
AperturaPresupuestariaSeparada,
CodJurisdiccion,
CodSAF,
CodPrograma,
CodSubprograma,
ProyectoND

--Modifica los valores de Identificadores ND
UPDATE Matching_tmpProyectosVinculadosND
SET ProyectoND=BapinND
FROM Matching_tmpCandidatosND INNER JOIN Matching_tmpProyectosVinculadosND ON 
Matching_tmpCandidatosND.IdentificadorProyectoSidif=Matching_tmpProyectosVinculadosND.IdentificadorProyectoSidif

--GUARDA LOS DATOS DE LOS PROYECTOS ND 
--
DELETE FROM Matching_ProyectosVinculadosND
INSERT INTO Matching_ProyectosVinculadosND
SELECT * FROM Matching_tmpProyectosVinculadosND
where ProyectoND is not null

--Elimina proyectos ND de los Proyectos Vinculados
DELETE FROM Matching_ProyectosVinculados 
WHERE IdentificadorProyectoSidif in (Select IdentificadorProyectoSidif from Matching_ProyectosVinculadosND)