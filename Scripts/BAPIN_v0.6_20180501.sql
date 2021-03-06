--*01*
USE [BD_BAPIN]
GO

-- select * from SistemaEntidadEstado where  IdSistemaEntidad = 437 order by IdEstado

update SistemaEntidadEstado set Nombre = '1 - Idea/Perfil'
where  IdSistemaEntidad = 437 and IdEstado = 1

update SistemaEntidadEstado set Nombre = '2 - Prefact/Factib'
where  IdSistemaEntidad = 437 and IdEstado = 3

update SistemaEntidadEstado set Nombre = '5 - Cancelado'
where  IdSistemaEntidad = 437 and IdEstado = 9

update SistemaEntidadEstado set Nombre = '3 - Iniciado'
where  IdSistemaEntidad = 437 and IdEstado = 16

update SistemaEntidadEstado set Nombre = '4 - Finalizado'
where  IdSistemaEntidad = 437 and IdEstado = 50

update Proceso set Nombre = '2 - Ampliaci�n' where IdProceso = 2
update Proceso set Nombre = '1 - Reposici�n' where IdProceso = 7
update Proceso set Nombre = '3 - Equipamiento B�sico de Oficina' where IdProceso = 23

--*02*
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados', N'BLOQUEAR_GASTOS_REALIZADOS', N'Bloquear la edici�n de los gastos realizados', N'3', N'N', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_PLANES'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_PLANES'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados Planes', N'BLOQUEAR_GASTOS_REALIZADOS_PLANES', N'Bloquear la edici�n de los gastos realizados para un conjunto de planes [Nombre planes separados por coma]', N'3', N'', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados Tipo Organismos', N'BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS', N'bloquear la edici�n de los gastos realizados para los organismos presupuestarios definidos [Ids separados por coma]', N'3', N'', null, null, N'');
GO

--*03*
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='URL_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='URL_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Url Esidif', N'URL_ESIDIF', N'URL root a los servicios web esidif', N'3', N'https://ws-si.mecon.gov.ar/SD_Core/ws/', null, null, N'')
GO

USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='USERNAME_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='USERNAME_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Username Esidif', N'USERNAME_ESIDIF', N'Username para los servicios web esidif', N'3', N'BAPIN', null, null, N'')
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='PASSWORD_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='PASSWORD_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Password Esidif', N'PASSWORD_ESIDIF', N'Password para los servicios web esidif', N'3', N'BapinEsidif2018', null, null, N'')
GO

--*04*
-- ----------------------------
-- Table structure for wsONPConsultaAPG
-- ----------------------------
USE [BD_BAPIN]
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

--*05*
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ONPConsultaAPG]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ONPConsultaAPG]
GO

CREATE PROCEDURE [dbo].[sp_ONPConsultaAPG]
@MyXML xml
AS
BEGIN

INSERT INTO [BD_BAPIN].[dbo].[wsONPConsultaAPG] 
		([codigoBapin], [jurisdiccion], [saf], [programa], [subprograma], 
		[jurisdiccionEsidif], [subjurisdiccionEsidif], [entidadEsidif], [safEsidif], [programaEsidif], [subprogramaEsidif], 
		[proyectoEsidif], [actividadEsidif], [obraEsidif], [ubicacionGeograficaEsidif], [ejecucionAcumulada])
select Bapin.detail.value('(codigoBapin/text())[1]','varchar(100)') as codigoBapin, 
       Bapin.detail.value('(jurisdiccion/text())[1]','bigint') as jurisdiccion, 
       Bapin.detail.value('(saf/text())[1]','varchar(100)') as saf, 
       Bapin.detail.value('(programa/text())[1]','varchar(100)') as programa, 
       Bapin.detail.value('(subprograma/text())[1]','varchar(100)') as subprograma,
			 Bapin.detail.value('(datosEsidif/jurisdiccionEsidif/text())[1]','varchar(100)') as jurisdiccionEsidif,
			 Bapin.detail.value('(datosEsidif/subjurisdiccionEsidif/text())[1]','varchar(100)') as subjurisdiccionEsidif,
 			 Bapin.detail.value('(datosEsidif/entidadEsidif/text())[1]','varchar(100)') as entidadEsidif,
	 		 Bapin.detail.value('(datosEsidif/safEsidif/text())[1]','varchar(100)') as safEsidif,
		   Bapin.detail.value('(datosEsidif/programaEsidif/text())[1]','varchar(100)') as programaEsidif,
			 Bapin.detail.value('(datosEsidif/subprogramaEsidif/text())[1]','varchar(100)') as subprogramaEsidif,
			 Bapin.detail.value('(datosEsidif/proyectoEsidif/text())[1]','varchar(100)') as proyectoEsidif,
			 Bapin.detail.value('(datosEsidif/actividadEsidif/text())[1]','varchar(100)') as actividadEsidif,
			 Bapin.detail.value('(datosEsidif/obraEsidif/text())[1]','varchar(100)') as obraEsidif,
			 Bapin.detail.value('(datosEsidif/ubicacionGeograficaEsidif/text())[1]','varchar(100)') as ubicacionGeograficaEsidif ,
			 Bapin.detail.value('(datosEsidif/ejecucionAcumulada/text())[1]','decimal') as ejecucionAcumulada 
    from @MyXML.nodes('/bapin') as Bapin(detail)

END

GO

--*06*
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_ONPConsultaAPG_UpdateProyectos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_ONPConsultaAPG_UpdateProyectos]
GO

CREATE PROCEDURE [dbo].[sp_ONPConsultaAPG_UpdateProyectos]
AS
BEGIN

Update P
Set 
	P.NroProyecto = W.proyectoEsidif,
	P.NroActividad = W.actividadEsidif,
	P.NroObra = W.obraEsidif
FROM
    Proyecto AS P
    INNER JOIN wsONPConsultaAPG AS W
        ON P.Codigo = W.codigoBapin

END

GO

--*07*
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados', N'BLOQUEAR_GASTOS_REALIZADOS', N'Bloquear la edici�n de los gastos realizados', N'3', N'N', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_ANIOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_ANIOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados A�os', N'BLOQUEAR_GASTOS_REALIZADOS_ANIOS', N'Bloquear la edici�n de los gastos realizados para un conjunto de a�os [A�os separados por coma]', N'3', N'', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados Tipo Organismos', N'BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS', N'bloquear la edici�n de los gastos realizados para los organismos presupuestarios definidos [Ids separados por coma]', N'3', N'', null, null, N'');
GO

--*08* Fix datos mal cargados
USE [BD_BAPIN]
GO

Update ProyectoEtapa set idetapa = 5 where IdProyecto in
(SELECT IdProyecto FROM Proyecto p where FechaAlta > '2018-05-02' and FechaAlta < '2018-05-09')
AND IdProyectoEtapa in (select min(IdProyectoEtapa) from ProyectoEtapa group by IdProyecto)
GO

Update ProyectoEtapa set idestado = 16 where IdProyecto in
(SELECT IdProyecto FROM Proyecto p where FechaAlta > '2018-05-08' and FechaAlta < '2018-05-09')
And IdEstado is null
GO

--*09* Trienio
USE [BD_BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_MARCA_TRIENIO'  )
DELETE FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_MARCA_TRIENIO'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Validar proyecto marca trienio', N'VALIDAR_PROYECTO_MARCA_TRIENIO', N'Validar la asignaci�n de marcas a los proyectos seg�n si tienen gastos estimados dentro del trienio', N'3', N'N', null, null, N'');
GO

--*10* Estado financiero suspendido
IF NOT EXISTS(SELECT 1 from SistemaEntidadEstado where [idestado] = '18' and idsistemaentidad=458 )
insert into SistemaEntidadEstado values (458, 18, 'Suspendido')
GO

