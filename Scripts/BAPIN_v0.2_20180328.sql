USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EsPPP'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [EsPPP] bit NULL 
GO

--Add default to EsPPP on proyecto
if not exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proyecto'
      and c.name = 'EsPPP'
      and s.name = 'dbo')
ALTER TABLE [dbo].[Proyecto] ADD DEFAULT 0 FOR [EsPPP]
GO

UPDATE [dbo].[Proyecto]  SET [EsPPP] = 0 where EsPPP is null
GO

USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ModalidadContratacion] 
          WHERE [Nombre] = 'No definido aún')
INSERT INTO [dbo].[ModalidadContratacion] 
([Nombre], [Activo]) 
VALUES ('No definido aún', '1')
GO

Update Proyecto set IdModalidadContratacion = 
(SELECT IdModalidadContratacion from ModalidadContratacion where nombre = 'No definido aún')
Where IdModalidadContratacion is null
GO

USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].[ProyectoTipo] WHERE Nombre='Indefinido'  )
BEGIN
Update ProyectoTipo set Nombre = 'IRD – Inv. Real Directa' where Nombre = '1 Inversión Real Directa'
Update ProyectoTipo set Nombre = 'Transferencia' where Nombre = '2 Transferencias'
Update ProyectoTipo set Nombre = 'Combinados' where Nombre = '3 Combinado'
Update ProyectoTipo set Nombre = 'Inversiones Financieras' where Nombre = '4 Inversiones Financieras'
Update ProyectoTipo set Nombre = 'Adelanto  a proveedores' where Nombre = '5 Adelanto a Proveedores'
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('SGC', 'Sin gastos imputados', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('GC', 'Gasto Corriente', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('IND', 'Indefinido', '1', '');
END;

GO

USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetProyectoTipoIndefinido]') AND type in (N'FN'))
BEGIN

--Remove Unique
ALTER TABLE [dbo].[Proceso] DROP CONSTRAINT [UK_Proceso_Nombre] 

--Unify idproyectotipo (deprecated)
Update Proceso set IdProyectoTipo = (Select IdProyectoTipo from ProyectoTipo where nombre = 'Indefinido')

--Update proceso to new names
Update Proceso set nombre='Ampliación' where nombre like 'Ampliación%' --23
Update Proceso set nombre='Equipamiento básico' where nombre like 'Equipamiento básico%' --5
Update Proceso set nombre='Reposición' where nombre like 'Reposición%'

--Update proyecto to new proceso
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
Update Proyecto set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')

--Update proyectocalidad to new proceso
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Ampliación')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico')
Update ProyectoCalidad set IdProceso = (SELECT min(IdProceso) from Proceso where nombre = 'Reposición')
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición')

--remove old proceso items
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Ampliación' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Ampliación'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Equipamiento básico' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Equipamiento básico'))
DELETE FROM Proceso 
WHERE IdProceso in (SELECT IdProceso from Proceso where nombre = 'Reposición' AND
									IdProceso!=(SELECT min(IdProceso) from Proceso where nombre = 'Reposición'))

END

--Debo borrar el constraint y volver a generarlo luego de la funcion
if exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proceso'
      and c.name = 'IdProyectoTipo'
      and s.name = 'dbo')
--Si tenemos que borrar la constraint
DECLARE @table_id AS INT
DECLARE @name_column_id AS INT
DECLARE @sql nvarchar(255) 

-- Find table id
SET @table_id = OBJECT_ID('Proceso')

-- Find name column id
SELECT @name_column_id = column_id
FROM sys.columns
WHERE object_id = @table_id
AND name = 'IdProyectoTipo'

-- Remove default constraint from name column
SELECT @sql = 'ALTER TABLE Proceso DROP CONSTRAINT ' + D.name
FROM sys.default_constraints AS D
WHERE D.parent_object_id = @table_id
AND D.parent_column_id = @name_column_id
EXECUTE sp_executesql @sql
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_GetProyectoTipoIndefinido]') AND type in (N'FN'))
DROP FUNCTION [dbo].[fn_GetProyectoTipoIndefinido]
GO
--Create scalar to get indefinido
CREATE FUNCTION fn_GetProyectoTipoIndefinido ()
RETURNS INT
AS
BEGIN
		Declare @ret int;
    SELECT @ret = (Select idProyectoTipo from ProyectoTipo where nombre='Indefinido')
		return @ret
END

GO

if not exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proceso'
      and c.name = 'IdProyectoTipo'
      and s.name = 'dbo')
--Add default to proceso on proyecto
ALTER TABLE [dbo].[Proceso] ADD DEFAULT ([dbo].[fn_GetProyectoTipoIndefinido]()) FOR [IdProyectoTipo]
GO

--Add comment
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Proceso', 
'COLUMN', N'IdProceso')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'deprecated'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Proceso'
, @level2type = 'COLUMN', @level2name = N'IdProceso'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'deprecated'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Proceso'
, @level2type = 'COLUMN', @level2name = N'IdProceso'
GO


USE [BAPIN]
GO

--Idea/Perfil
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Idea' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Idea/Perfil' where Nombre = 'Idea' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Perfil' and idsistemaentidad=437)
GO

--Factibilidad/Prefactibilidad
-- Muevo Proyectos de Perfil a Idea
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Factibilidad' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO
-- Actualizo Idea a Idea/Perfil
Update SistemaEntidadEstado set Nombre = 'Factibilidad/Prefactibilidad' where Nombre = 'Factibilidad' and idsistemaentidad=437
GO
-- Borro Perfil
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Prefactibilidad' and idsistemaentidad=437)
GO

--Suspendido a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Borro Suspendido
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Suspendido' and idsistemaentidad=437)
GO

--Postergado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Borro Postergado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Postergado' and idsistemaentidad=437)
GO

--Desestimado a Cancelado
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Cancelado' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO

--Borro Desestimado
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'Desestimado' and idsistemaentidad=437)
GO
--En ejec y oper a En ejecucion
Update Proyecto set IdEstado = 
(SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejecución' and idsistemaentidad=437)
Where IdEstado in (SELECT IdEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)
GO

--Borro En Ejec. & Oper.
Delete from SistemaEntidadEstado where idSistemaEntidadEstado = (SELECT idSistemaEntidadEstado from SistemaEntidadEstado where Nombre = 'En Ejec. & Oper.' and idsistemaentidad=437)

--Nuevo  estado Iniciado
IF NOT EXISTS(SELECT 1 FROM [dbo].[SistemaEntidadEstado]
          WHERE [IdSistemaEntidad] = '437' and [IdEstado] = '16' and [Nombre] = N'Iniciado')
INSERT INTO [dbo].[SistemaEntidadEstado] 
([IdSistemaEntidad], [IdEstado], [Nombre]) 
VALUES ('437', '16', 'Iniciado');
GO

USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividad'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividad] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObra'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObra] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroProyectoEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroProyectoEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroActividadEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroActividadEjecucion] int NULL 
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'NroObraEjecucion'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [NroObraEjecucion] int NULL 
GO

USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Text] 
          WHERE [Code] = 'TooltipProyectoEliminado')

INSERT INTO [Text] (
	[Code], [Description], [IdTextCategory], 
	[IsAutomaticLoad], [StartDate], 
	[Checked], [CheckedDate], [IdUsuarioChecked]) 
VALUES 
--('TooltipEtapa', 'Refleja la etapa del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL);
('TooltipProyectoEliminado', 'Campo no editable. En caso de eliminar el proyecto aparecerá la leyenda "ELIMINADO".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoBorrador', 'Rótulo que señala que el proyecto está en proceso de carga. Si la casilla se encuentra tildada la ficha sólo será visible para los usuarios de las oficinas con permiso de edición.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoDatosGenerales', 'Bloque que contiene campos obligatorios para obtener el alta de una ficha.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoPresupuestario', 'Código de proyecto presupuestario al que pertenece la construcción del bien de capital y/o la adqusición específica correspondiente a tal obra.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoActividad', 'Código de actividad presupuestaria al que pertenece la adquisición de uno o más bien/es de capital.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoObra', 'Código presupuestario de obra por la cual se producirá el o los bien/es de capital.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoDenominacion', 'Nombre del proyecto sin abreviaturas o siglas (salvo las de uso habitual y generalizado). Se debe estructurar respetando la secuencia: "Acción, Objeto, Lugar"; cuando se trate de una adquisición se deberá agregar el año correspondiente: "Acción, Objeto, Lugar, Año".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoEjecucionPresupuestaria', 'Carácter económico de los gastos públicos comprendidos en el proyecto de inversión. Surge de manera automática a partir de los códigos presupuestarios por objeto de gasto informados en la solapa "Cronograma de gastos".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoCostototal', 'Corresponde al Monto Estimado Actual de la solapa "Cronograma de gastos", se actualiza con cada modificación al mismo.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTipoMontoTotalEstimadoInicial', 'Suma de los gastos estimados al momento de colocar la primer marca de Demanda. Se mantiene fijo a lo largo del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipRequiereDictamen', 'A completar por la DNIP (proyectos que requieren dictamen de calificación técnica según Ley 24.354)', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoContribucion', 'Contribución a la capacidad de prestación del servicio según la característica de la inversión.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoEtapa', 'Refleja la etapa del ciclo de vida del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipModalidaddeContratacion', 'Tipo de contatración de las obras o adquisiciones del proyecto. En caso de no conocer aún la modalidad se completará con la opción "no definido aún".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPPP', 'Indica si la obra a ejecutar corresponde a un contrato de participación público privada.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipFinalidadFuncion', 'Debe completarse hasta el tercer nivel de detalle: finalidad, función y subfunción', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipLocalizacion', 'Ubicación específica (Localidad/es, Partido/s o Departamento/s y Provincia/s) de las construcciones o equipamientos incorporados por el proyecto. Se deberá identificar como mínimo la localización provincial.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIniciador', 'Oficina donde se origina el proyecto. Sus usuarios no podrán incorporar información referida al cronograma de gastos.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipEjecutor', 'Oficina que ejecuta el proyecto. Sus usuarios podrán cargar y/o modificar los campos de texto y de información financiera (cronograma de gastos, evolución de indicadores).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipResponsable', 'Oficina responsable del proyecto ante la DNIP. Sus usuarios podrán cargar y/o modificar todos los campos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoAgregar', 'Habilita a colocar marca de solicitud al Presupuesto Nacional (Demanda) y/o la incorporación del proyecto a otros planes de inversión (sectoriales, provinciales, regionales u otros).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoHistorial', 'Muestra el historial de marcas de solicitud presupuestaria (Demanda), incorporación al Presupuesto Nacional y/o a otros planes de inversión (sectoriales, provinciales,regionales u otros) del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipUltimaSolicitudRegistrada', 'Último registro de solicitud o de incorporación efectiva del proyecto al presupuesto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPrioridad', 'Nivel de prioridad asignado al proyecto; editable sólo por la autoridad de la jurisdicción responsable del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipSubprioridad', 'Campo numérico que informa el orden asignado al proyecto dentro de la prioridad seleccionada precedentemente; editable sólo por la autoridad de la jurisdicción responsable del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipFinanciamientoExterno', 'Número de ficha Bapin de cada programa de financiamiento externo vinculado al proyecto (campo obligatorio para todo proyecto que contemple fuente externa en su cronograma de gastos).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectosRelacionados', 'Número de ficha Bapin de los proyectos de inversión que mantienen alguna relación con el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProyectoObservaciones', 'Información adicional relevante respecto a algún/os campo/s de esta solapa. Si el proyecto surge de una reformulación integral o de una sustitución de un proyecto anterior, consignar esta circunstancia aquí.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipPrincipiosConceptualesDeFormulacion', 'Componentes fundamentales que hacen a una adecuada formulación de un proyecto de inversión pública.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObjetivoDelProyecto', 'Es la descripción de la solución (situación que se desea alcanzar) al problema diagnosticado. Ejemplo: si el problema principal en el sector de salud es una alta tasa de mortalidad infantil en la población de menores ingresos, el objetivo sería reducir en un X% la tasa de mortalidad infantil en esa población al cabo de X años.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipProductoServicioDelProyecto', 'Prestación a brindar mediante la cual se alcanzará el objetivo del proyecto. Ejemplos: provisión de agua potable; enseñanza de nivel medio doble turno.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipDescripcionTecnica', 'Principales características y/o especificaciones que den cuenta de las dimensiones y la capacidad productiva del bien que será adquirido o la obra a ejecutar.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipVidaUtil', 'Es la duración estimada que un bien podrá tener, cumpliendo correctamente con la función para la cual ha sido concebido y/o adquirido. Debe ser expresada en una unidad de tiempo (ej: años, meses, días, horas).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCoberturaTerritorial', 'Área geográfica donde se encuentra la población beneficiaria del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCoberturaPoblacional', 'Beneficiarios directos sobre población con necesidades a satisfacer (ratio).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipBeneficiariosDirectos', 'Destinarios directos de los productos que generara el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipBeneficiariosIndirectos', 'Terceras personas que son beneficiadas con el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipDificultadesRiesgos', 'Informar cualquier hecho cierto o contingente que genere perjuicios sociales, ambientales o dificultades para llevar adelante el proyecto en cualquier etapa de su ciclo de vida.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObservacionesDNIP', 'Comentarios técnicos emitidos por la DNIP respecto a la formulación del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCronogramasAgregar', 'Crea una línea para cada código presupuestario del proyecto (actividad, obra, actividad específica).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTotalEstimadoActual', 'Campo automático que muesta la suma de los gastos realizados de los años anteriores, el gasto estimado para el año en curso y los gastos estimados futuros.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTotalRealizado', 'Campo automático que muesta la suma de los gastos devengados de los años anteriores y los correspondientes al año en curso (hasta la última actualización de la ficha del proyecto).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipEjecucionPresupuestaria', 'Bloque de campos automáticos, no editable. Informa para cada código presupuestario del proyecto: el crédito inicial, el crédito vigente y el gasto devengado, según la base de datos del SIDIF de fines del último mes y para el año en curso.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipGastosEstimados', 'Bloque de campos a cargo de la oficina responsable. Informar para cada código presupuestario los gastos estimados de cada objeto de gasto, fuente de financiamiento y año.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipGastosRealizados', 'Bloque de campos a cargo de la oficina responsable. Informar para cada código presupuestario los gastos realizados (según el criterio de lo devengado) de cada objeto de gasto, fuente de financiamiento y año.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIndicadoresEvaluacion', 'Bloque de campos que presenta los indicadores utilizados en la evaluación socioeconómica del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipCriteriosEvaluacion', 'Especificar el o los criterios de evaluación utilizados, en relación al indicador de evaluación adoptado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipHorizonteEvaluacion', 'Cantidad de años que abarca las fases de ejecución y de operación del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipTasaReferencia', 'Tasa de interés de referencia utilizada para descontar los flujos netos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipOtrosIndicadores', 'Indicadores adicionales, que permiten realizar un monitoreo del cumplimiento de los objetivos del proyecto (referidos al objetivo directo, prestaciones brindadas e inversiones)', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipContribucionObjetivoGobierno', 'Objetivo de gobierno que guarda mayor relación con el proyecto de inversión.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipSector', 'Seleccionar el sector o actividad económica del proyecto. En caso de no existir la que corresponde, se sugiere consultar los indicadores de la categoría "general".', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipIndicador', 'Seleccionar las unidades de medidas del indicador.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipMedioVerificacion', 'Identificar el tipo de registro que permite verificar las metas de acuerdo al indicador seleccionado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipObservacionesEvaluacion', 'De ser necesario, detallar las características y/o especificaciones del indicador seleccionado.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipArchivosAdjuntos', 'Adjuntar documentación significativa del proyecto (mapas, planos, gráficos, informes, etc.).', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipMarcoLegal', 'Registrar la normativa que rige el proyecto.', '1', '1', GETDATE(), '0', NULL, NULL),
('TooltipOtraInformacionAdicional', 'Indicar cualquier dato o información relevante sobre aspectos del proyecto.', '1', '1', GETDATE(), '0', NULL, NULL)
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[TextLanguage] 
          WHERE IdText = (Select IdText from [Text] where Code = 'TooltipProyectoEliminado'))

INSERT INTO TextLanguage 
--(IdText, IdTextLanguage,[TranslateText], [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]) 
Select IdText, (Select [IdLanguage] from [Language] where Name = 'Español'), Description, [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]
from [Text]
where IdText >= (Select IdText from [Text] where Code = 'TooltipProyectoEliminado')
GO
