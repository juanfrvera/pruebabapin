USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].Etapa where nombre = 'Actividad Específica')
BEGIN
SET IDENTITY_INSERT [dbo].[Etapa] ON
INSERT INTO [BAPIN].[dbo].[Etapa] 
([IdEtapa], [IdFase], [Codigo], [Nombre], [Orden], [Activo]) 
VALUES ('9', '2', 'AE', 'Actividad Específica', '3', '1');
SET IDENTITY_INSERT [dbo].[Etapa] OFF
END
GO
 