USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].ProyectoIndicadorObjetivosGobierno)
BEGIN
SET IDENTITY_INSERT [dbo].[ProyectoIndicadorObjetivosGobierno] ON

INSERT INTO [BAPIN].[dbo].[ProyectoIndicadorObjetivosGobierno] ([IdProyectoIndicadorObjetivosGobierno], [IdProyecto], [IdIndicadorClase], [Valor], [Anio], [Observacion])
Select * FROM [dbo].ProyectoIndicadorPriorizacion
where IdIndicadorClase in 
(SELECT IdIndicadorClase FROM [dbo].IndicadorClase
WHERE IdIndicadorTipo = 
	(SELECT IdIndicadorTipo from [dbo].IndicadorTipo where  Nombre like 'Objetivo de Gobierno%')
)

SET IDENTITY_INSERT [dbo].[ProyectoIndicadorObjetivosGobierno] OFF
END

GO