USE [BAPIN]
GO

If not exists (SELECT 1 from Proyecto where nroproyectoejecucion is not null)
BEGIN

Update ProUp
set 
	ProUp.NroProyectoEjecucion = ProCurr.NroProyecto, 
	ProUp.NroActividadEjecucion = ProCurr.NroActividad, 
	ProUp.NroObraEjecucion = ProCurr.NroObra
FROM
    Proyecto AS ProUp
		INNER JOIN 
(select  --17320 records
p.Codigo,
p.IdProyecto,
p.NroProyecto, 
et.Nombre,
case pe.IdEtapa when 6 then pe.NroEtapa else 0 end as NroActividad, 
case pe.IdEtapa when 5 then pe.NroEtapa else 0 end as NroObra
from Proyecto p
inner join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join Etapa et on et.IdEtapa=pe.IdEtapa
				WHERE pe.idProyectoEtapa = (
						SELECT MIN(aux.idProyectoEtapa) 
						FROM ProyectoEtapa aux
						WHERE aux.idProyecto = p.idProyecto
				)) ProCurr
ON ProUp.IdProyecto = ProCurr.IdProyecto

update Proyecto
set NroProyecto = null, NroActividad = null, NroObra = null

END
GO