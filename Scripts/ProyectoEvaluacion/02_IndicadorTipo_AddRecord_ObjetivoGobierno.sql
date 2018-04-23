USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].IndicadorTipo where nombre = 'Objetivo de Gobierno')
BEGIN
SET IDENTITY_INSERT [dbo].[IndicadorTipo] ON
INSERT INTO [dbo].[IndicadorTipo] 
([IdIndicadorTipo], [Nombre], [SectorRequerido], [Activo]) VALUES ('5', 'Objetivo de Gobierno', '0', '1');
SET IDENTITY_INSERT [dbo].[IndicadorTipo] OFF
END
GO
