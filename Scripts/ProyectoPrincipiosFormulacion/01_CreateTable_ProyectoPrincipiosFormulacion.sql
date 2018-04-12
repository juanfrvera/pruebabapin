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
[NecesidadASatisfacer] varchar(MAX) NULL ,
[ObjetivoDelProyecto] varchar(255) NULL ,
[ProductoOServicio] varchar(255) NULL ,
[Alternativas] varchar(MAX) NULL ,
[PorqueAlternativa] varchar(255) NULL ,
[DescripcionTecnica] varchar(MAX) NULL ,
[VidaUtil] varchar(255) NULL ,

[CoberturaTerritorial] varchar(MAX) NULL ,
[CoberturaPoblacional] varchar(MAX) NULL ,
[CoberturaBeneficiariosDirectos] varchar(MAX) NULL ,
[CoberturaBeneficiariosIndirectos] varchar(MAX) NULL ,

[DificultadesRiesgos] bit NULL ,
[DificultadesRiesgosEnumeracion] varchar(MAX) NULL ,

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
