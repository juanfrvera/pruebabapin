USE [BAPIN]
GO

-- ----------------------------
-- Table structure for ProyectoIndicadorObjetivosGobierno
-- ----------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoIndicadorObjetivosGobierno]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoIndicadorObjetivosGobierno]
GO

CREATE TABLE [dbo].[ProyectoIndicadorObjetivosGobierno] (
[IdProyectoIndicadorObjetivosGobierno] int NOT NULL IDENTITY(1,1) ,
[IdProyecto] int NOT NULL ,
[IdIndicadorClase] int NOT NULL ,
[Valor] money NULL ,
[Anio] int NULL ,
[Observacion] varchar(500) NULL 
)
GO

DBCC CHECKIDENT(N'[dbo].[ProyectoIndicadorObjetivosGobierno]', RESEED, 11000)
GO

-- ----------------------------
-- Primary Key structure for table ProyectoIndicadorObjetivosGobierno
-- ----------------------------
ALTER TABLE [dbo].[ProyectoIndicadorObjetivosGobierno] ADD PRIMARY KEY ([IdProyectoIndicadorObjetivosGobierno])
GO

-- ----------------------------
-- Uniques structure for table ProyectoIndicadorObjetivosGobierno
-- ----------------------------
ALTER TABLE [dbo].[ProyectoIndicadorObjetivosGobierno] ADD UNIQUE ([IdProyecto] ASC, [IdIndicadorClase] ASC)
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[ProyectoIndicadorObjetivosGobierno]
-- ----------------------------
ALTER TABLE [dbo].[ProyectoIndicadorObjetivosGobierno] ADD FOREIGN KEY ([IdIndicadorClase]) REFERENCES [dbo].[IndicadorClase] ([IdIndicadorClase]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoIndicadorObjetivosGobierno] ADD FOREIGN KEY ([IdProyecto]) REFERENCES [dbo].[Proyecto] ([IdProyecto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
