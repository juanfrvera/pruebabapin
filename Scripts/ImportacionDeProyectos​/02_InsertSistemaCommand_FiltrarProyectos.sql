USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[SistemaCommand] WHERE CommandText='sp_Proyectos_Template'  )
DELETE FROM [dbo].[SistemaCommand] WHERE CommandText='sp_Proyectos_Template'
GO

INSERT INTO [BAPIN].[dbo].[SistemaCommand] 
([Nombre], [Descripcion], [IdsistemaEntidad], [CommandText], [CommandType], [Activo]) 
VALUES (
	'Proyectos Template', 
	'Permite filtrar los proyectos para el template de importación', 
	'437', 
	'sp_Proyectos_Template', 
	'1', 
	'1')
GO