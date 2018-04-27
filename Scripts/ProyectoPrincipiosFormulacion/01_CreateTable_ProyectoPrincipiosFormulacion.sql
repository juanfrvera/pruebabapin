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
[NecesidadASatisfacer] varchar(3000) NULL ,
[ObjetivoDelProyecto] varchar(1500) NULL ,
[ProductoOServicio] varchar(1500) NULL ,
[Alternativas] varchar(3000) NULL ,
[PorqueAlternativa] varchar(3000) NULL ,
[DescripcionTecnica] varchar(3000) NULL ,
[VidaUtil] varchar(500) NULL ,

[CoberturaTerritorial] varchar(1500) NULL ,
[CoberturaPoblacional] varchar(1500) NULL ,
[CoberturaBeneficiariosDirectos] varchar(1500) NULL ,
[CoberturaBeneficiariosIndirectos] varchar(1500) NULL ,

[DificultadesRiesgos] bit NULL ,
[DificultadesRiesgosEnumeracion] varchar(3000) NULL ,

[DimensionesCostosDimensionados] bit NULL ,
[DimensionesCostosValidados] bit NULL ,
[DimensionesCostosEnte] varchar(500) NULL ,

[RequiereIntevencion] bit NULL  ,
[RequiereIntevencionAutoridad] varchar(500) NULL ,
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
