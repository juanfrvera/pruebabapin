USE [BAPIN]
GO

ALTER TABLE [dbo].[ProyectoEtapaEstimadoPeriodo]
ADD [MontoInicial] money NOT NULL DEFAULT 0 ,
[MontoVigente] money NOT NULL  DEFAULT 0  ,
[MontoDevengado] money NOT NULL  DEFAULT 0   ,
[MontoVigenteEstimativo] bit NOT NULL  DEFAULT 0 
GO

