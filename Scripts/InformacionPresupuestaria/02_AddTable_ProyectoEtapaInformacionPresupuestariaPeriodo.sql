USE [BAPIN]
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
