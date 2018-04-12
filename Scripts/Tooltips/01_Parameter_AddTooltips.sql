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