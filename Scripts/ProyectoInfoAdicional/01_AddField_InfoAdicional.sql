USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'InfoAdicional'
          AND Object_ID = Object_ID(N'dbo.ProyectoEvaluacion'))
ALTER TABLE [dbo].[ProyectoEvaluacion]
	ADD [InfoAdicional] varchar(MAX) NULL
GO


