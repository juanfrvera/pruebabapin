USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].IndicadorTipo where nombre = 'Evaluacion Sectorial')
BEGIN
SET IDENTITY_INSERT [dbo].[IndicadorTipo] ON
INSERT INTO [dbo].[IndicadorTipo] 
([IdIndicadorTipo], [Nombre], [SectorRequerido], [Activo]) VALUES ('6', 'Evaluacion Sectorial', '0', '1');
SET IDENTITY_INSERT [dbo].[IndicadorTipo] OFF
END
GO
