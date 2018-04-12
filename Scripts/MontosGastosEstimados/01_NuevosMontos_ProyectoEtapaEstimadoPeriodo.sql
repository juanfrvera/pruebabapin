USE [BAPIN]
GO

SELECT 1 FROM sys.columns 
          WHERE Name = N'MontoInicial'
          AND Object_ID = Object_ID(N'dbo.ProyectoEtapaEstimadoPeriodo')
		  
ALTER TABLE [dbo].[ProyectoEtapaEstimadoPeriodo]
ADD [MontoInicial] money NOT NULL DEFAULT 0 ,
[MontoVigente] money NOT NULL  DEFAULT 0  ,
[MontoDevengado] money NOT NULL  DEFAULT 0   ,
[MontoVigenteEstimativo] bit NOT NULL  DEFAULT 0 
GO

