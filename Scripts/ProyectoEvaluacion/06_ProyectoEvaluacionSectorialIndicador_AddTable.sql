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
