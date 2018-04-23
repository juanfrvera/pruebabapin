USE [BAPIN]
GO

UPDATE IndicadorClase 
SET IdIndicadorTipo = (SELECT IdIndicadorTipo FROM [dbo].[IndicadorTipo] WHERE Nombre = 'Objetivo de Gobierno')
WHERE IdIndicadorTipo = 4 and Nombre like 'Objetivos de Gobierno%' 
GO
