USE [BAPIN]
GO

--Idea/Perfil
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Idea' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Idea/Perfil' where Nombre = 'Idea' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO

--Factibilidad/Prefactibilidad
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Factibilidad' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Factibilidad/Prefactibilidad' where Nombre = 'Factibilidad' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO

--Suspendido a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Borro Suspendido
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Postergado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Borro Postergado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Desestimado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO

--Borro Desestimado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO
--En ejec y oper a En ejecucion
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejecución' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)
GO

--Borro En Ejec. & Oper.
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)

--Nuevo  estado Iniciado
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('437', '16', 'Iniciado');
GO
