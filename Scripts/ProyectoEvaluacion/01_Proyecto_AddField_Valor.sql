USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Valor'
          AND Object_ID = Object_ID(N'dbo.ProyectoBeneficioIndicador'))
ALTER TABLE [dbo].[ProyectoBeneficioIndicador]
ADD [Valor] money NULL 
GO
