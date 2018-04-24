-- *01*
USE [BD_BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'Valor'
          AND Object_ID = Object_ID(N'dbo.ProyectoBeneficioIndicador'))
ALTER TABLE [dbo].[ProyectoBeneficioIndicador]
ADD [Valor] money NULL 
GO

-- *02*
USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].IndicadorTipo where nombre = 'Objetivo de Gobierno')
BEGIN
SET IDENTITY_INSERT [dbo].[IndicadorTipo] ON
INSERT INTO [dbo].[IndicadorTipo] 
([IdIndicadorTipo], [Nombre], [SectorRequerido], [Activo]) VALUES ('5', 'Objetivo de Gobierno', '0', '1');
SET IDENTITY_INSERT [dbo].[IndicadorTipo] OFF
END
GO

-- *03*
USE [BD_BAPIN]
GO

UPDATE IndicadorClase 
SET IdIndicadorTipo = (SELECT IdIndicadorTipo FROM [dbo].[IndicadorTipo] WHERE Nombre = 'Objetivo de Gobierno')
WHERE IdIndicadorTipo = 4 and Nombre like 'Objetivos de Gobierno%' 
GO

-- *04*
USE [BD_BAPIN]
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

-- *05*
USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].ProyectoIndicadorObjetivosGobierno)
BEGIN
SET IDENTITY_INSERT [dbo].[ProyectoIndicadorObjetivosGobierno] ON

INSERT INTO [BAPIN].[dbo].[ProyectoIndicadorObjetivosGobierno] ([IdProyectoIndicadorObjetivosGobierno], [IdProyecto], [IdIndicadorClase], [Valor], [Anio], [Observacion])
Select * FROM [dbo].ProyectoIndicadorPriorizacion
where IdIndicadorClase in 
(SELECT IdIndicadorClase FROM [dbo].IndicadorClase
WHERE IdIndicadorTipo = 
	(SELECT IdIndicadorTipo from [dbo].IndicadorTipo where  Nombre like 'Objetivo de Gobierno%')
)

SET IDENTITY_INSERT [dbo].[ProyectoIndicadorObjetivosGobierno] OFF
END
GO

-- *06*
USE [BD_BAPIN]
GO

-- ----------------------------
-- Table structure for ProyectoEvaluacionSectorialIndicador
-- ----------------------------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoEvaluacionSectorialIndicador]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoEvaluacionSectorialIndicador]
GO
CREATE TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] (
[IdProyectoEvaluacionSectorialIndicador] int NOT NULL IDENTITY(1,1) ,
[IdProyecto] int NOT NULL ,
[IdIndicadorClase] int NOT NULL ,
[Indirecto] bit NOT NULL ,
[IdIndicador] int NOT NULL ,
[Valor] money NULL 
)
GO

-- ----------------------------
-- Indexes structure for table ProyectoEvaluacionSectorialIndicador
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ProyectoEvaluacionSectorialIndicador
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD PRIMARY KEY ([IdProyectoEvaluacionSectorialIndicador])
GO

-- ----------------------------
-- Uniques structure for table ProyectoEvaluacionSectorialIndicador
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD UNIQUE ([IdProyecto] ASC, [IdIndicadorClase] ASC)
GO
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD UNIQUE ([IdIndicador] ASC)
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[ProyectoEvaluacionSectorialIndicador]
-- ----------------------------
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD FOREIGN KEY ([IdIndicadorClase]) REFERENCES [dbo].[IndicadorClase] ([IdIndicadorClase]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD FOREIGN KEY ([IdIndicador]) REFERENCES [dbo].[Indicador] ([IdIndicador]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[ProyectoEvaluacionSectorialIndicador] ADD FOREIGN KEY ([IdProyecto]) REFERENCES [dbo].[Proyecto] ([IdProyecto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- *07*
USE [BD_BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].IndicadorTipo where nombre = 'Evaluacion Sectorial')
BEGIN
SET IDENTITY_INSERT [dbo].[IndicadorTipo] ON
INSERT INTO [dbo].[IndicadorTipo] 
([IdIndicadorTipo], [Nombre], [SectorRequerido], [Activo]) VALUES ('6', 'Evaluacion Sectorial', '0', '1');
SET IDENTITY_INSERT [dbo].[IndicadorTipo] OFF
END
GO