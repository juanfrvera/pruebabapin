USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'AnioCorrienteEstimado'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [AnioCorrienteEstimado] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'AnioCorrienteRealizado'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [AnioCorrienteRealizado] int NULL 
GO
