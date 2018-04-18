
USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'IdSubProgramaEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [IdSubProgramaEjecucion] int NULL 
GO

IF NOT EXISTS
(SELECT OBJECT_NAME(OBJECT_ID) AS NameofConstraint,
SCHEMA_NAME(schema_id) AS SchemaName,
OBJECT_NAME(parent_object_id) AS TableName,
type_desc AS ConstraintType
FROM sys.objects
WHERE type_desc LIKE '%CONSTRAINT' and OBJECT_NAME(OBJECT_ID) = 'FK_Proyecto_SubProgramaEjecucion')

ALTER TABLE [dbo].[Proyecto] ADD CONSTRAINT [FK_Proyecto_SubProgramaEjecucion] FOREIGN KEY ([IdSubPrograma]) REFERENCES [dbo].[SubPrograma] ([IdSubPrograma]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO