USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividad'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividad] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObra'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObra] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroProyectoEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroProyectoEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividadEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividadEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObraEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObraEjecucion] int NULL 
GO
