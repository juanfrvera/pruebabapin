-- ----------------------------
-- Table structure for wsONPConsultaAPG
-- ----------------------------
USE [BAPIN]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wsONPConsultaAPG]') AND type in (N'U'))
DROP TABLE [dbo].[wsONPConsultaAPG]
GO

CREATE TABLE [dbo].[wsONPConsultaAPG] (
[IdwsONPConsultaAPG] int NOT NULL IDENTITY(1,1) ,
[codigoBapin] VARCHAR(50) NULL ,
[jurisdiccion] bigint NULL ,
[saf] bigint NULL ,
[programa] bigint NULL ,
[subprograma] bigint NULL ,
[jurisdiccionEsidif] bigint NULL ,
[subjurisdiccionEsidif] bigint NULL ,
[entidadEsidif] bigint NULL ,
[safEsidif] bigint NULL ,
[programaEsidif] bit NULL ,
[subprogramaEsidif] bigint NULL ,
[proyectoEsidif] bigint NULL ,
[actividadEsidif] bigint NULL ,
[obraEsidif] bigint NULL ,
[ubicacionGeograficaEsidif] bigint NULL ,
[ejecucionAcumulada] decimal NULL ,
)
GO

-- ----------------------------
-- Indexes structure for table wsONPConsultaAPG
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table wsONPConsultaAPG
-- ----------------------------
ALTER TABLE [dbo].[wsONPConsultaAPG] ADD PRIMARY KEY ([IdwsONPConsultaAPG])
GO