USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoIncisos]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoIncisos]
GO

Select * INTO ProyectoIncisos
FROM
(
SELECT distinct pe.idproyecto, p.Codigo, nroproyecto,
		inciso = convert(int,substring(cg.BreadcrumbCode,2,2))
		from ProyectoEtapa pe
		inner join Proyecto p on p.IdProyecto=pe.IdProyecto
		inner join Etapa et on et.IdEtapa=pe.IdEtapa
		inner join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa=pe.IdProyectoEtapa
		inner join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
		where p.Activo = 1 and (et.Nombre = 'Obra' or et.Nombre = 'Actividad')
--and p.Codigo = 67872    
UNION
SELECT distinct pe.idproyecto, p.Codigo, nroproyecto,
		inciso = convert(int,substring(cg.BreadcrumbCode,2,2))
		from ProyectoEtapa pe
		inner join Proyecto p on p.IdProyecto=pe.IdProyecto
		inner join Etapa et on et.IdEtapa=pe.IdEtapa
		inner join ProyectoEtapaRealizado pee on pee.IdProyectoEtapa=pe.IdProyectoEtapa
		inner join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
		where p.Activo = 1 and (et.Nombre = 'Obra' or et.Nombre = 'Actividad')) i
GO

/************00-Indefinido************/
Update Proyecto set idTipoProyecto = 19
GO
/************01-Proyectos sin gastos imputados************/
--1581
Update Proyecto set idTipoProyecto = 17 WHERE idProyecto in (
Select idproyecto from proyecto p
Where NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto
))
GO
/************02-IRDInvRealDirecta************/
-- 4 y no 5 ni 6
-- 12754
Update Proyecto set idTipoProyecto = 10 WHERE idProyecto in (
Select idproyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 4
)
and NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And (inciso = 5 or inciso = 6)
))
GO
/************03-Transferencia************/
--2819
Update Proyecto set idTipoProyecto = 11 WHERE idProyecto in (
Select idproyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 5
)
and NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And (inciso = 4 or inciso = 6)
))
GO
/************04-Combinados************/
Update Proyecto set idTipoProyecto = 12 WHERE idProyecto in (
--103
Select idproyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 4
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And (inciso = 5 or inciso = 6)
)
UNION -- 8
Select idproyecto from proyecto p
Where NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 4
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 5
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 6
)
UNION -- 0
Select idproyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 6
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 7
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 8
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso != 6 And inciso != 7 And inciso != 8
))
GO
/************05-InversionesFinancieras************/
Update Proyecto set idTipoProyecto = 15 WHERE idProyecto in (
Select idProyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 6
)
and NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And (inciso = 4 or inciso = 5)
))
GO
/************06-Adelanto a proveedores************/
Update Proyecto set idTipoProyecto = 16 WHERE idProyecto in (
Select idproyecto from proyecto p
Where EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 6
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 7
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso = 8
)
and NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso != 6 And inciso != 7 And inciso != 8
))
GO
/************07-Gasto Corriente************/
Update Proyecto set idTipoProyecto = 18 WHERE idProyecto in (
Select idproyecto from proyecto p 
Where NOT EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And inciso >= 4
)
and EXISTS
(
Select 1 from ProyectoIncisos pi
WHERE pi.idproyecto = p.idproyecto And (NroProyecto is Null or NroProyecto = 0)
))
GO