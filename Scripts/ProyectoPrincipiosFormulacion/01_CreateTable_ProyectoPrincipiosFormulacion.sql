-- ----------------------------
-- Table structure for ProyectoPrincipiosFormulacion
-- ----------------------------
USE [BAPIN]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProyectoPrincipiosFormulacion]') AND type in (N'U'))
DROP TABLE [dbo].[ProyectoPrincipiosFormulacion]
GO

CREATE TABLE [dbo].[ProyectoPrincipiosFormulacion] (
[IdProyectoPrincipiosFormulacion] int NOT NULL IDENTITY(1,1) ,
[IdProyecto] int NOT NULL ,
[NecesidadASatisfacer] varchar(2000) NULL ,
[ObjetivoDelProyecto] varchar(1000) NULL ,
[ProductoOServicio] varchar(255) NULL ,
[Alternativas] varchar(2000) NULL ,
[PorqueAlternativa] varchar(2000) NULL ,
[DescripcionTecnica] varchar(2000) NULL ,
[VidaUtil] varchar(255) NULL ,

[CoberturaTerritorial] varchar(2000) NULL ,
[CoberturaPoblacional] varchar(255) NULL ,
[CoberturaBeneficiariosDirectos] varchar(2000) NULL ,
[CoberturaBeneficiariosIndirectos] varchar(255) NULL ,

[DificultadesRiesgos] bit NULL ,
[DificultadesRiesgosEnumeracion] varchar(2000) NULL ,

[DimensionesCostosDimensionados] bit NULL ,
[DimensionesCostosValidados] bit NULL ,
[DimensionesCostosEnte] varchar(255) NULL ,

[RequiereIntevencion] bit NULL  ,
[RequiereIntevencionAutoridad] varchar(255) NULL ,
[RequiereIntevencionEstado] int NULL ,  --0 A Iniciar, 1 En Curso, 2 Terminado

[ObservacionesDNIP] varchar(MAX) NULL
)
GO

-- ----------------------------
-- Indexes structure for table ProyectoPrincipiosFormulacion
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ProyectoPrincipiosFormulacion
-- ----------------------------
ALTER TABLE [dbo].[ProyectoPrincipiosFormulacion] ADD PRIMARY KEY ([IdProyectoPrincipiosFormulacion])
GO

-- ----------------------------
-- Uniques structure for table ProyectoPrincipiosFormulacion
-- ----------------------------
ALTER TABLE [dbo].[ProyectoPrincipiosFormulacion] ADD UNIQUE ([IdProyecto] ASC)
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[ProyectoPrincipiosFormulacion]
-- ----------------------------
ALTER TABLE [dbo].[ProyectoPrincipiosFormulacion] ADD FOREIGN KEY ([IdProyecto]) REFERENCES [dbo].[Proyecto] ([IdProyecto]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
