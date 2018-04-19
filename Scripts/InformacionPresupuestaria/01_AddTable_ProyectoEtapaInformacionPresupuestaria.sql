USE [BAPIN]
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
