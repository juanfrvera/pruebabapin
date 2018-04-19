USE [BD_BAPIN]
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

USE [BD_BAPIN]
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

USE [BD_BAPIN]
GO

-- ----------------------------
-- Table structure for ProyectoEtapaInformacionPresupuestaria
-- ----------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoEtapaInformacionPresupuestaria]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria]
GO

CREATE TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] (
[IdProyectoEtapaInformacionPresupuestaria] int NOT NULL IDENTITY(1,1) ,
[IdProyectoEtapa] int NOT NULL ,
[IdClasificacionGasto] int NOT NULL ,
[IdFuenteFinanciamiento] int NOT NULL ,
[IdMoneda] int NOT NULL 
)
GO

-- ----------------------------
-- Primary Key structure for table ProyectoEtapaInformacionPresupuestaria
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] ADD PRIMARY KEY ([IdProyectoEtapaInformacionPresupuestaria])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[ProyectoEtapaInformacionPresupuestaria]
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] ADD FOREIGN KEY ([IdClasificacionGasto]) REFERENCES [dbo].[ClasificacionGasto] ([IdClasificacionGasto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] ADD FOREIGN KEY ([IdFuenteFinanciamiento]) REFERENCES [dbo].[FuenteFinanciamiento] ([IdFuenteFinanciamiento]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] ADD FOREIGN KEY ([IdMoneda]) REFERENCES [dbo].[Moneda] ([IdMoneda]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestaria] ADD FOREIGN KEY ([IdProyectoEtapa]) REFERENCES [dbo].[ProyectoEtapa] ([IdProyectoEtapa]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

USE [BD_BAPIN]
GO

-- ----------------------------
-- Table structure for ProyectoEtapaInformacionPresupuestariaPeriodo
-- ----------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo]
GO

CREATE TABLE [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo] (
[IdProyectoEtapaInformacionPresupuestariaPeriodo] int NOT NULL IDENTITY(1,1) ,
[IdProyectoEtapaInformacionPresupuestaria] int NOT NULL ,
[Periodo] int NOT NULL ,
[MontoInicial] money NOT NULL DEFAULT ((0)) ,
[MontoVigente] money NOT NULL DEFAULT ((0)) ,
[MontoDevengado] money NOT NULL DEFAULT ((0)) ,
[MontoVigenteEstimativo] bit NOT NULL DEFAULT ((0)) 
)
GO

-- ----------------------------
-- Indexes structure for table ProyectoEtapaInformacionPresupuestariaPeriodo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ProyectoEtapaInformacionPresupuestariaPeriodo
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo] ADD PRIMARY KEY ([IdProyectoEtapaInformacionPresupuestariaPeriodo])
GO

-- ----------------------------
-- Uniques structure for table ProyectoEtapaInformacionPresupuestariaPeriodo
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo] ADD UNIQUE ([IdProyectoEtapaInformacionPresupuestaria] ASC, [Periodo] ASC)
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo]
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEtapaInformacionPresupuestariaPeriodo] ADD FOREIGN KEY ([IdProyectoEtapaInformacionPresupuestaria]) REFERENCES [dbo].[ProyectoEtapaInformacionPresupuestaria] ([IdProyectoEtapaInformacionPresupuestaria]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

