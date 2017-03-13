--PROCEDIMIENTO PARA EJECUTAR POST-IMPORTACION SIDIF

--SETEO LAS VARIABLES
DECLARE @EjercicioPresupuestario as int
SET @EjercicioPresupuestario=YEAR(GETDATE())-1
DECLARE @mesSidif as nvarchar(2)
SET @mesSidif= 12


-- LIMPIEZA DE LA TABLA DE PROCESADO - solo del mes que se esta procesando, es decir que si ejecuto el periodo en el mes de octubre voy a estar insertando datos del mes de septiembre.
DELETE FROM  [dbo].[Matching_InfoPresupuesto] where [EjercicioPresupuestario]=@EjercicioPresupuestario and [MesSidif]=@mesSidif
INSERT INTO [dbo].[Matching_InfoPresupuesto]
SELECT 
CAST(([Ejercicio Presupuestario]) as varchar(4)) + @mesSidif + 
CASE WHEN LEN(CAST([Cod# Jurisdicción] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Jurisdicción] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Jurisdicción] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Servicio] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Servicio] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Servicio] as nvarchar(10)) END + 
CASE WHEN LEN(CAST([Cod# Programa] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Programa] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Programa] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Subprograma] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Subprograma] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Subprograma] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Proyecto] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Proyecto] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Proyecto] as nvarchar(10)) END + 
CASE WHEN LEN(CAST([Cod# Actividad] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Actividad] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Actividad] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Obra] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Obra] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Obra] as nvarchar(10)) END
  as IdentificadorProyectoSidif,
[Ejercicio Presupuestario] as [EjercicioPresupuestario],
@mesSidif as MesSidif,
[Cod# 3 Dígitos] as [CodTipo],
[Desc# 3 Dígitos] as Tipo,
CodJurisdiccion = CASE WHEN LEN(CAST([Cod# Jurisdicción] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Jurisdicción] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Jurisdicción] as nvarchar(10)) END,
[Desc# Jurisdicción] as Jurisdiccion,
CodSAF=CASE WHEN LEN(CAST([Cod# Servicio] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Servicio] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Servicio] as nvarchar(10)) END,
[Desc# Larga Servicio] as SAF,
CodPrograma=CASE WHEN LEN(CAST([Cod# Programa] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Programa] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Programa] as nvarchar(10)) END,
[Desc# Programa] as Programa,
CodSubprograma=CASE WHEN LEN(CAST([Cod# Subprograma] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Subprograma] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Subprograma] as nvarchar(10)) END,
[Desc# Subprograma] as Subprograma,
CodProyecto=CASE WHEN LEN(CAST([Cod# Proyecto] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Proyecto] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Proyecto] as nvarchar(10)) END,
[Desc# Proyecto] as Proyecto,
CodActividad=CASE WHEN LEN(CAST([Cod# Actividad] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Actividad] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Actividad] as nvarchar(10)) END,
[Desc# Actividad] as Actividad,
CodObra=CASE WHEN LEN(CAST([Cod# Obra] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Obra] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Obra] as nvarchar(10)) END,
[Desc# Obra] as Obra,
(
CASE WHEN LEN(CAST([Cod# Jurisdicción] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Jurisdicción] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Jurisdicción] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Servicio] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Servicio] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Servicio] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Programa] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Programa] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Programa] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Subprograma] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Subprograma] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Subprograma] as nvarchar(10)) END
) as AperturaProgramatica,
(
CASE WHEN LEN(CAST([Cod# Jurisdicción] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Jurisdicción] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Jurisdicción] as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST([Cod# Servicio] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Servicio] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Servicio] as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST([Cod# Programa] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Programa] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Programa] as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST([Cod# Subprograma] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Subprograma] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Subprograma] as nvarchar(10)) END
) as AperturaProgramaticaSeparada,
(CASE WHEN LEN(CAST([Cod# Proyecto] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Proyecto] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Proyecto] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Actividad] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Actividad] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Actividad] as nvarchar(10)) END +
CASE WHEN LEN(CAST([Cod# Obra] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Obra] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Obra] as nvarchar(10)) END
) AS AperturaPresupuestaria,
(CASE WHEN LEN(CAST([Cod# Proyecto] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Proyecto] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Proyecto] as nvarchar(10)) END +
'.' + CASE WHEN LEN(CAST([Cod# Actividad] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Actividad] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Actividad] as nvarchar(10)) END +
 '.'+ CASE WHEN LEN(CAST([Cod# Obra] as nvarchar(10)))= 1 THEN Cast('0' + cast([Cod# Obra] as nvarchar(10)) as nvarchar(10)) ELSE Cast([Cod# Obra] as nvarchar(10)) END
) AS AperturaPresupuestariaSeparada,
CAST(([Ejercicio Presupuestario]) AS varchar(4)) + @mesSidif as SidifPeriodo,
[Cod# Procedencia] as [CodProcedencia],
[Desc# Procedencia] as [Procedencia],
[Cod# Fuente] as [CodFuenteFinanciamiento],
[Desc# Fuente] as [FuenteFinanciamiento],
[Cod# Inciso] as [CodInciso],
[Desc# Inciso] as [Inciso],
[Cod# Principal] as [CodPrincipal],
[Desc# Principal] as [Principal],
[Cod# Parcial] as [CodParcial],
[Desc# Parcial] as [Parcial],
[Cod# Subparcial] as [CodSubparcial],
[Desc# Subparcial] as [SubParcial],
[Desc# Finalidad] as [CodFinalidad],
[Cod# Finalidad] as [Finalidad],
[Cod# Función] as [CodFuncion],
[Desc# Función] as [Funcion],
[Cod# Ubicación Geográfica] as [CodUbiGeo],
[Desc# Ubicación Geográfica] as [UbiGeo],
[$Cred# Inicial] as CredInicial,
[$Cred# Vigente] as CredVigente,
[$Devengado] as Devengado,
[$Pagado] as Pagado

FROM Matching_ImportSidif
WHERE [Cod# 3 Dígitos]=221 --221 significa el código de Inversión Real Directa que es lo que se trabajará desde el matching


----------------------------------------------------------------------------
/*
Proceso de Agrupamiento de Datos Sidif
Ejecuta el proceso limpiando los datos de la tabla por mes y Año del periodo del Sidif Importado, 
Sí CodBapin=0 entonces borra la fila y la vuelve a insertar con la información actualizada
Sí CodigoBapin<>0 entonces hace un update por codigo de Identificador único

*/

--SELECT * FROM Matching_InfoPresupuesto




