USE [BAPIN]
GO

update t1
set IdProyectoPlan = t2.MaxIdProyectoPlan
from Proyecto as t1
join (select IdProyecto, max(IdProyectoPlan) as MaxIdProyectoPlan from ProyectoPlan group by IdProyecto) as t2
on t1.IdProyecto = t2.IdProyecto
GO
