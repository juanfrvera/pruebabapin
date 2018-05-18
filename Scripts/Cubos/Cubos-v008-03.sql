USE [bapin]

GO
PRINT '------------------------------------------'
PRINT '-     Inicio - Script Cubos. v008-03     -'                                  
PRINT '------------------------------------------'
GO

-----------------------------
--Historial de versiones
-----------------------------

-----------------------------
--Cambios en la version 008--
-----------------------------
--*Se agrega, en ambos cubos, campos para monto inicial, vigente y devengado
--*Se agrega funciones fn_Cubo_MontoInicial, fn_Cubo_MontoVigente y fn_Cubo_MontoDevengado
--*Se agrega función fn_Cubo_Union_Presupuestaria que une los 3 anteriores

-----------------------------
--Cambios en la version 007--
-----------------------------
--*Se cambio, en ambos cubos, la forma en la cual se calcula los montos Estimados y Realizados, de manera que
--en la sumatoria solamente se consideren los montos asignados en la etapa "Ejecucion".
--*Se reemplaza el calculo en memoria (#) por una funcion para el cálculo de ONPDevengado en el Cubo x Total
--*Se resuelve un bug por el cual el Cubo x Objeto expandia un registro asignando al inciso el valor '00'
--*Se resuelve un bug por el cual el Cubo x Objeto combinaba en forma erronea	
-- los montos estimados y realizados generando registros invalidos para cada objeto de gasto
--*Se corrige un bug por el cual en el Cubo x Objeto no se combinaban las fuentes de financiamiento para los
-- montos estimados y realizados
--*Se mejora la eficiencia de los filtros para Cubo por Total y Cubo por Objeto

-----------------------------
--Cambios en la version 006--
-----------------------------
--*Se retira del script la eliminacion y regeneracion de la carga de la tabla "Cubo_ImportCxTBapin2"
--*Se incorpora la columna "[Com_Tecnico_ECTO]" entre "[Sectorialista] y [Estimados Anteriores]"
--Los datos presentados son "Fecha - Comentario". Luego los diferentes comentarios para un bapin estan separados 
--por el signo "/".
--*El proceso de cubos toma la informacion de ONP para el año 2016 y anteriores, desde la tabla "Cubo_ImportCxTBapin2"
--*Se incorpora la columna [Ape_PresupActEsp] entre [Tipo_Presup] y [Es_Presup]
--*Se agrego la columna Tipo_PresupActEsp, para no perder el valor de la actividad especifica en caso que el proyecto
--tenga obra y actividad. El valor de esta columna sera:
--en caso que sea proyecto y tenga actividad, sera el valor de la apertura presupuestaria de la actividad especifica 
--en caso que sea proyecto y no tenga actividad, sera '-'
--en caso que no sea proyecto y sea actividad, sera '-'
--en otro caso, sera 'No_clasificado'
--*Se corrigio bug por el cual calculaba mal la informacion de devengado de ONP para el Cubo x Total
--*Se modifica el filtro de usuarios de modo que si una persona no tiene perfil de oficina asignado
--el sistema recupera todos los proyectos y la informacion de ONP

-----------------------------
--Cambios en la version 005--
-----------------------------
--*Se corrigio un bug por el cual se repite el monto realizado en las distintas fuentes de financiemiento

-----------------------------
--Cambios en la version 004--
-----------------------------
--*Se modifico el nombre de la columna "Localizacion_detalle" por "Localizacion_Provincia"
--*Se incorporo la informacion de ONP para los años 2016 en adelante a partir de los proyectos vinculados en el proceso de matching
--*Se corrigieron las columnas "Estado_financiero" y "Estado_fisico" cuyos contenido estaban invertidos
--*Se corrigio el contenido de la columna "Localizacion_detalle" retirando los espacios iniciales y la leyenda "Provincia de"
--*Se corrigio el contenido de la columna "Localizacion_detalle" retirando las provincias duplicadas iniciales, ajustando la columna "Cantidad" al nuevo valor

-----------------------------
--Cambios en la version 003--
-----------------------------
--*Se modificaron los nombres de las columnas de los montos Estimados y Realizados para reflejar el número del año
--*Se corrigio el bug por el cual los cubos solo consideraban año actual el 2016
--*Se revisaron las columnas correspondientes a la apertura presupuestaria, de manera que
-- NroProyecto = nro de proyecto (proyecto.nro_proyecto)
-- NroActividad = nro de actividad (si etapa.Nombre='Actividad' then NroActividad = proyectoetapa.NroEtapa)
-- NroObra = nro de actividad (si etapa.Nombre='Obra' then NroObra = proyectoetapa.NroEtapa)
--*Se agrega un filtro para que en el cubo no aparezcan los proyecto en estado borrador
--*Se modifico la columna T:Tipo_Presup, de manera que
-- T = "Proyecto" si es un proyecto (proyecto.esproyecto = 1) y el nombre de la etapa es Obra (etapa.nombre = Obra)
-- T = "Actividad" si no es un proyecto (proyecto.esproyecto = 0) y el nombre de la etapa es Actividad (etapa.nombre = Actividad)
-- T = "Actividad_especifica" si es un proyecto (proyecto.esproyecto = 1) y el nombre de la etapa es Actividad (etapa.nombre = Actividad)
--* Se modificaron los nombres de las siguientes columnas del cuboxobjeto (para hacerlas homogeneas con el cuboxtotal),
-- NroProyecto (antes Proy_Cod), NroActividad (antes Activ_Cod) y NroObra (antes Obra_Cod)

-----------------------------
--Cambios en la version 002--
-----------------------------
--*Se modificaron los sp_Cubo_Filtra_CxO y sp_Cubo_Filtra_CxT, solucionando un bug por el cual
-- no se recuperaba informacion de los cubos para los usuarios sectorialistas
--*En la seccion limpieza se agrego la eliminacion de procedimientos correspondientes a versiones de prueba

GO
PRINT 'Inicio - Eliminacion (Drop) de Funciones y Procedimientos anteriores'
GO

/****** Object:  Table [dbo].[CuboxObjeto]    Script Date: 11/28/2016 17:01:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxObjeto]') AND type in (N'U'))
DROP TABLE [dbo].[CuboxObjeto]
GO

/****** Object:  Table [dbo].[CuboxTotal]    Script Date: 11/28/2016 17:01:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxTotal]') AND type in (N'U'))
DROP TABLE [dbo].[CuboxTotal]
GO

/****** Object:  Table [dbo].[CuboxONP]    Script Date: 11/28/2016 17:01:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxONP]') AND type in (N'U'))
DROP TABLE [dbo].[CuboxONP]
GO

/****** Object:  Table [dbo].[CuboxObjetoBapin3]    Script Date: 11/28/2016 17:01:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxObjetoBapin3]') AND type in (N'U'))
DROP TABLE [dbo].[CuboxObjetoBapin3]
GO

/****** Object:  Table [dbo].[CuboxTotalBapin3]    Script Date: 11/28/2016 17:02:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxTotalBapin3]') AND type in (N'U'))
DROP TABLE [dbo].[CuboxTotalBapin3]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_GetProyectoEvaluacionFactibilidad]    Script Date: 11/28/2016 17:03:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_GetProyectoEvaluacionFactibilidad]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_GetProyectoEvaluacionFactibilidad]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoEstFinancieroAgrupado]    Script Date: 11/28/2016 17:05:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoEstFinancieroAgrupado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoEstFinancieroAgrupado]
GO

/****** Object:  StoredProcedure [dbo].[CuboObjetoPorUsuario_temp]    Script Date: 11/28/2016 17:06:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboObjetoPorUsuario_temp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboObjetoPorUsuario_temp]
GO

/****** Object:  StoredProcedure [dbo].[CuboObjetoPorUsuario_v002]    Script Date: 11/28/2016 17:06:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboObjetoPorUsuario_v002]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboObjetoPorUsuario_v002]
GO

/****** Object:  StoredProcedure [dbo].[CuboTotalPorUsuario]    Script Date: 11/28/2016 17:06:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboTotalPorUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboTotalPorUsuario]
GO

/****** Object:  StoredProcedure [dbo].[CuboTotalPorUsuario_temp]    Script Date: 11/28/2016 17:07:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboTotalPorUsuario_temp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboTotalPorUsuario_temp]
GO

/****** Object:  StoredProcedure [dbo].[CuboTotalPorUsuario_v002]    Script Date: 11/28/2016 17:07:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboTotalPorUsuario_v002]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboTotalPorUsuario_v002]
GO

/****** Object:  StoredProcedure [dbo].[CuboTotalPorUsuario2]    Script Date: 11/28/2016 17:07:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboTotalPorUsuario2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboTotalPorUsuario2]
GO

/****** Object:  StoredProcedure [dbo].[spFiltroCuboxObjetoxPerfilUsuario]    Script Date: 11/28/2016 17:08:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFiltroCuboxObjetoxPerfilUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spFiltroCuboxObjetoxPerfilUsuario]
GO

/****** Object:  StoredProcedure [dbo].[spFiltroCuboxTotalxPerfilUsuario]    Script Date: 11/28/2016 17:08:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFiltroCuboxTotalxPerfilUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spFiltroCuboxTotalxPerfilUsuario]
GO

/****** Object:  StoredProcedure [dbo].[spFiltroCuboxTotalxPerfilUsuario2]    Script Date: 11/28/2016 17:09:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spFiltroCuboxTotalxPerfilUsuario2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spFiltroCuboxTotalxPerfilUsuario2]
GO

/****** Object:  StoredProcedure [dbo].[CuboxObjeto]    Script Date: 11/28/2016 17:09:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxObjeto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboxObjeto]
GO

/****** Object:  StoredProcedure [dbo].[CuboxTotal]    Script Date: 11/28/2016 17:09:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CuboxTotal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CuboxTotal]
GO

/****** Object:  StoredProcedure [dbo].[lanzador-CuboxObjeto]    Script Date: 11/28/2016 17:09:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lanzador-CuboxObjeto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[lanzador-CuboxObjeto]
GO

/****** Object:  StoredProcedure [dbo].[lanzador-CuboxTotal]    Script Date: 11/28/2016 17:09:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lanzador-CuboxTotal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[lanzador-CuboxTotal]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetAper_Presup]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetAper_Presup]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetAper_Presup]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetAperPresupAgrupado]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetAperPresupAgrupado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetAperPresupAgrupado]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetClasificacionInstitucional]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetClasificacionInstitucional]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetClasificacionInstitucional]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetMontoEstimado_temp]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetMontoEstimado_temp]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetMontoEstimado_temp]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetMontoRealizado_temp]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetMontoRealizado_temp]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetMontoRealizado_temp]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetPrioridadProyecto]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetPrioridadProyecto]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetPrioridadProyecto]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoIncisoDetallado]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoIncisoDetallado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoIncisoDetallado]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoLocalidadDetalladaOld]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoLocalidadDetalladaOld]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoLocalidadDetalladaOld]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoObjetoGastoDetallado]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoObjetoGastoDetallado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoObjetoGastoDetallado]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoObraActividadDetallada]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoObraActividadDetallada]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoObraActividadDetallada]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetProyectoPlanDetallado]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnGetProyectoPlanDetallado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnGetProyectoPlanDetallado]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Filtra_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Filtra_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Filtra_CxO]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Filtra_CxT]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Filtra_CxT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Filtra_CxT]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Inicia_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Inicia_CxO]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxO]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Genera_CxO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Genera_CxO]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_AperturaPresupuestaria]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_AperturaPresupuestaria]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_AperturaPresupuestaria]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxT]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Inicia_CxT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Inicia_CxT]
GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxT]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Cubo_Genera_CxT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Cubo_Genera_CxT]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_DictamenInversion_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_DictamenInversion_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_DictamenInversion_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EvaluacionFactibilidad_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_EvaluacionFactibilidad_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_EvaluacionFactibilidad_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EstadoFisico_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_EstadoFisico_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_EstadoFisico_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_AperturaPresupuestaria_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_AperturaPresupuestaria_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_AperturaPresupuestaria_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EstadoFinanciero_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_EstadoFinanciero_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_EstadoFinanciero_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_UltimoPlanPrioridad]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_UltimoPlanPrioridad]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_UltimoPlanPrioridad]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Plan_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Plan_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Plan_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Inciso_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Inciso_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Inciso_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_FuenteFinanciamiento_Group]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_FuenteFinanciamiento_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_FuenteFinanciamiento_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_ProyectoLocalidadDetallada]    Script Date: 11/28/2016 20:46:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_ProyectoLocalidadDetallada]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_ProyectoLocalidadDetallada]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_ECTO_Group]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_ECTO_Group]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_ECTO_Group]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoEstimado]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoEstimado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoEstimado]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoRealizado]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoRealizado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoRealizado]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_ME_MR]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Union_ME_MR]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Union_ME_MR]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoInicial]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoInicial]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoInicial]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoVigente]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoVigente]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoVigente]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoDevengado]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_MontoDevengado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_MontoDevengado]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_Presupuestaria]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Union_Presupuestaria]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Union_Presupuestaria]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_ONPDevengado]    Script Date: 03/21/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_ONPDevengado]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_ONPDevengado]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Fecha_Inicio_Estimada]    Script Date: 06/13/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Fecha_Inicio_Estimada]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_Cubo_Fecha_Inicio_Estimada]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Fecha_Fin_Estimada]    Script Date: 06/13/2017 12:22:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_Cubo_Fecha_Fin_Estimada]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].fn_Cubo_Fecha_Fin_Estimada
GO

GO
PRINT 'Fin - Eliminacion (Drop) de Funciones y Procedimientos anteriores'
PRINT ' '
GO
PRINT 'Inicio - Drop y Create tabla Cubo x Total'
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxT]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxT]

CREATE TABLE [dbo].[Cubo_CxT](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Incisos] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar] (max) NULL,
	[SAF] [varchar](max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [varchar] (max) NULL,
	[NroActividad] [varchar] (max) NULL,
	[NroObra] [varchar] (max) NULL,
	[Tipo_Presup] [varchar](max) NULL,
	[Ape_PresupActEsp] [varchar] (max) NULL,
	[Es_Presup] [varchar](max) NULL,
	[Estado_Financiero] [varchar](max) NULL,
	[Estado_Fisico] [varchar](max) NULL,
	[Est_Decision] [varchar](max) NULL,
	[PrioridadDNIP] [varchar](max) NULL,
	[Art_15] [varchar] (max) NULL,
	[Req_Dict] [varchar] (max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar] (max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar] (max) NULL,
	[Fecha_UltModificacion] [varchar] (max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar] (max) NULL,
	[Fecha_Fin_Estimada] [varchar] (max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,
	[Finalidad_Función] [varchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Fuente_Finaciamiento_Cod] [varchar](max) NULL,
	[Fuente_Financiamiento_Desc] [varchar](max) NULL,
	[Proceso] [varchar](max) NULL,
	[Sectorialista] [varchar](max) NULL,
	[Com_Tecnico_ECTO] [varchar](max) NULL,
	[Estimados Anteriores] [decimal] (18,0) NULL,
	[Estimado 2013] [decimal] (18,0) NULL,
	[Estimado 2014] [decimal] (18,0) NULL,
	[Estimado 2015] [decimal] (18,0) NULL,
	[Estimado 2016] [decimal] (18,0) NULL,
	[Estimado 2017] [decimal] (18,0) NULL,
	[Estimado 2018] [decimal] (18,0) NULL,
	[Estimado 2019] [decimal] (18,0) NULL,
	[Estimado 2020] [decimal] (18,0) NULL,
	[Estimado 2021] [decimal] (18,0) NULL,
	[Estimado Posteriores] [decimal] (18,0) NULL,
	[Estimado Total] [decimal] (18,0) NULL,
	[Realizados Anteriores] [decimal] (18,0) NULL,
	[Realizado 2013] [decimal] (18,0) NULL,
	[Realizado 2014] [decimal] (18,0) NULL,
	[Realizado 2015] [decimal] (18,0) NULL,
	[Realizado 2016] [decimal] (18,0) NULL,
	[Realizado 2017] [decimal] (18,0) NULL,
	[Realizado 2018] [decimal] (18,0) NULL,
	[Realizado 2019] [decimal] (18,0) NULL,
	[Realizado 2020] [decimal] (18,0) NULL,
	[Realizado 2021] [decimal] (18,0) NULL,
	[Realizado Posteriores] [decimal] (18,0) NULL,
	[Realizado Total] [decimal] (18,0) NULL,
	[Costo Total Actual] [decimal] (18,0) NULL,
	[ONP 2003] [decimal] (18,0) NULL,
	[ONP 2004] [decimal] (18,0) NULL,
	[ONP 2005] [decimal] (18,0) NULL,
	[ONP 2006] [decimal] (18,0) NULL,
	[ONP 2007] [decimal] (18,0) NULL,
	[ONP 2008] [decimal] (18,0) NULL,
	[ONP 2009] [decimal] (18,0) NULL,
	[ONP 2010] [decimal] (18,0) NULL,
	[ONP 2011] [decimal] (18,0) NULL,
	[ONP 2012] [decimal] (18,0) NULL,
	[ONP 2013] [decimal] (18,0) NULL,
	[ONP 2014] [decimal] (18,0) NULL,
	[ONP 2015] [decimal] (18,0) NULL,
	[ONP 2016] [decimal] (18,0) NULL,
	[ONP 2017] [decimal] (18,0) NULL,
	[ONP 2018] [decimal] (18,0) NULL,
	[ONP 2019] [decimal] (18,0) NULL,
	[ONP 2020] [decimal] (18,0) NULL,
	[ONP 2021] [decimal] (18,0) NULL,
	[ONP 2022] [decimal] (18,0) NULL,
	[ONP 2023] [decimal] (18,0) NULL,
	[ONP 2024] [decimal] (18,0) NULL,
	[ONP 2025] [decimal] (18,0) NULL,
	[MontoInicial Anteriores] [decimal] (18,0) NULL,
	[MontoInicial 2013] [decimal] (18,0) NULL,
	[MontoInicial 2014] [decimal] (18,0) NULL,
	[MontoInicial 2015] [decimal] (18,0) NULL,
	[MontoInicial 2016] [decimal] (18,0) NULL,
	[MontoInicial 2017] [decimal] (18,0) NULL,
	[MontoInicial 2018] [decimal] (18,0) NULL,
	[MontoInicial 2019] [decimal] (18,0) NULL,
	[MontoInicial 2020] [decimal] (18,0) NULL,
	[MontoInicial 2021] [decimal] (18,0) NULL,
	[MontoInicial Posteriores] [decimal] (18,0) NULL,
	[MontoInicial Total] [decimal] (18,0) NULL,
	[MontoVigente Anteriores] [decimal] (18,0) NULL,
	[MontoVigente 2013] [decimal] (18,0) NULL,
	[MontoVigente 2014] [decimal] (18,0) NULL,
	[MontoVigente 2015] [decimal] (18,0) NULL,
	[MontoVigente 2016] [decimal] (18,0) NULL,
	[MontoVigente 2017] [decimal] (18,0) NULL,
	[MontoVigente 2018] [decimal] (18,0) NULL,
	[MontoVigente 2019] [decimal] (18,0) NULL,
	[MontoVigente 2020] [decimal] (18,0) NULL,
	[MontoVigente 2021] [decimal] (18,0) NULL,
	[MontoVigente Posteriores] [decimal] (18,0) NULL,
	[MontoVigente Total] [decimal] (18,0) NULL,
	[MontoVigenteEstimativo 2013] bit NULL,
	[MontoVigenteEstimativo 2014] bit NULL,
	[MontoVigenteEstimativo 2015] bit NULL,
	[MontoVigenteEstimativo 2016] bit NULL,
	[MontoVigenteEstimativo 2017] bit NULL,
	[MontoVigenteEstimativo 2018] bit NULL,
	[MontoVigenteEstimativo 2019] bit NULL,
	[MontoVigenteEstimativo 2020] bit NULL,
	[MontoVigenteEstimativo 2021] bit NULL,
	[MontoDevengado Anteriores] [decimal] (18,0) NULL,
	[MontoDevengado 2013] [decimal] (18,0) NULL,
	[MontoDevengado 2014] [decimal] (18,0) NULL,
	[MontoDevengado 2015] [decimal] (18,0) NULL,
	[MontoDevengado 2016] [decimal] (18,0) NULL,
	[MontoDevengado 2017] [decimal] (18,0) NULL,
	[MontoDevengado 2018] [decimal] (18,0) NULL,
	[MontoDevengado 2019] [decimal] (18,0) NULL,
	[MontoDevengado 2020] [decimal] (18,0) NULL,
	[MontoDevengado 2021] [decimal] (18,0) NULL,
	[MontoDevengado Posteriores] [decimal] (18,0) NULL,
	[MontoDevengado Total] [decimal] (18,0) NULL,
	[Generado] [varchar] (max) NULL
	)
	
GO
PRINT 'Fin - Drop y Create tabla Cubo x Total'
PRINT ' '
GO
PRINT 'Inicio - Drop y Create tabla Cubo x Objeto'
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxO]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxO]

CREATE TABLE [dbo].[Cubo_CxO](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Inciso] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar](max) NULL,
	[SAF] [varchar] (max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [int] NULL,
	[NroActividad] [varchar] (max) NULL,
	[NroObra] [varchar] (max) NULL,
	[Tipo_Presup] [varchar](max) NULL,
	[Ape_PresupActEsp] [varchar] (max) NULL,
	[Es_Presup] [varchar](max) NULL,
	[Estado_Financiero] [varchar](max) NULL,
	[Estado_Fisico] [varchar](max) NULL,
	[Est_Decision] [varchar](max) NULL,
	[PrioridadDNIP] [varchar](max) NULL,
	[Art_15] [varchar] (max) NULL,
	[Req_Dict] [varchar](max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar](max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar](10) NULL,
	[Fecha_UltModificacion] [varchar](max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar](max) NULL,
	[Fecha_Fin_Estimada] [varchar](max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,	
	[Finalidad_Función] [nvarchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Objeto_Gasto_Cod] [varchar](max) NULL,
	[Objeto_Gasto_Desc] [varchar](max) NULL,
	[Fuente_Finaciamiento_Cod] [varchar](max) NULL,
	[Fuente_Financiamiento_Desc] [varchar](max) NULL,
	[Proceso] [varchar](max) NULL,
	[Sectorialista] [varchar](max) NULL,
	[Com_Tecnico_ECTO] [varchar](max) NULL,
	[Estimados Anteriores] [decimal] (18,0) NULL,
	[Estimado 2013] [decimal] (18,0) NULL,
	[Estimado 2014] [decimal] (18,0) NULL,
	[Estimado 2015] [decimal] (18,0) NULL,
	[Estimado 2016] [decimal] (18,0) NULL,
	[Estimado 2017] [decimal] (18,0) NULL,
	[Estimado 2018] [decimal] (18,0) NULL,
	[Estimado 2019] [decimal] (18,0) NULL,
	[Estimado 2020] [decimal] (18,0) NULL,
	[Estimado 2021] [decimal] (18,0) NULL,
	[Estimado Posteriores] [decimal] (18,0) NULL,
	[Estimado Total] [decimal] (18,0) NULL,
	[Realizados Anteriores] [decimal] (18,0) NULL,
	[Realizado 2013] [decimal] (18,0) NULL,
	[Realizado 2014] [decimal] (18,0) NULL,
	[Realizado 2015] [decimal] (18,0) NULL,
	[Realizado 2016] [decimal] (18,0) NULL,
	[Realizado 2017] [decimal] (18,0) NULL,
	[Realizado 2018] [decimal] (18,0) NULL,
	[Realizado 2019] [decimal] (18,0) NULL,
	[Realizado 2020] [decimal] (18,0) NULL,
	[Realizado 2021] [decimal] (18,0) NULL,
	[Realizado Posteriores] [decimal] (18,0) NULL,
	[Realizado Total] [decimal] (18,0) NULL,
	[Costo Total Actual] [decimal] (18,0) NULL,
	[ONP 2003] [decimal] (18,0) NULL,
	[ONP 2004] [decimal] (18,0) NULL,
	[ONP 2005] [decimal] (18,0) NULL,
	[ONP 2006] [decimal] (18,0) NULL,
	[ONP 2007] [decimal] (18,0) NULL,
	[ONP 2008] [decimal] (18,0) NULL,
	[ONP 2009] [decimal] (18,0) NULL,
	[ONP 2010] [decimal] (18,0) NULL,
	[ONP 2011] [decimal] (18,0) NULL,
	[ONP 2012] [decimal] (18,0) NULL,
	[ONP 2013] [decimal] (18,0) NULL,
	[ONP 2014] [decimal] (18,0) NULL,
	[ONP 2015] [decimal] (18,0) NULL,
	[ONP 2016] [decimal] (18,0) NULL,
	[ONP 2017] [decimal] (18,0) NULL,
	[ONP 2018] [decimal] (18,0) NULL,
	[ONP 2019] [decimal] (18,0) NULL,
	[ONP 2020] [decimal] (18,0) NULL,
	[ONP 2021] [decimal] (18,0) NULL,
	[ONP 2022] [decimal] (18,0) NULL,
	[ONP 2023] [decimal] (18,0) NULL,
	[ONP 2024] [decimal] (18,0) NULL,
	[ONP 2025] [decimal] (18,0) NULL,
	[MontoInicial Anteriores] [decimal] (18,0) NULL,
	[MontoInicial 2013] [decimal] (18,0) NULL,
	[MontoInicial 2014] [decimal] (18,0) NULL,
	[MontoInicial 2015] [decimal] (18,0) NULL,
	[MontoInicial 2016] [decimal] (18,0) NULL,
	[MontoInicial 2017] [decimal] (18,0) NULL,
	[MontoInicial 2018] [decimal] (18,0) NULL,
	[MontoInicial 2019] [decimal] (18,0) NULL,
	[MontoInicial 2020] [decimal] (18,0) NULL,
	[MontoInicial 2021] [decimal] (18,0) NULL,
	[MontoInicial Posteriores] [decimal] (18,0) NULL,
	[MontoInicial Total] [decimal] (18,0) NULL,
	[MontoVigente Anteriores] [decimal] (18,0) NULL,
	[MontoVigente 2013] [decimal] (18,0) NULL,
	[MontoVigente 2014] [decimal] (18,0) NULL,
	[MontoVigente 2015] [decimal] (18,0) NULL,
	[MontoVigente 2016] [decimal] (18,0) NULL,
	[MontoVigente 2017] [decimal] (18,0) NULL,
	[MontoVigente 2018] [decimal] (18,0) NULL,
	[MontoVigente 2019] [decimal] (18,0) NULL,
	[MontoVigente 2020] [decimal] (18,0) NULL,
	[MontoVigente 2021] [decimal] (18,0) NULL,
	[MontoVigente Posteriores] [decimal] (18,0) NULL,
	[MontoVigente Total] [decimal] (18,0) NULL,
	[MontoVigenteEstimativo 2013] bit NULL,
	[MontoVigenteEstimativo 2014] bit NULL,
	[MontoVigenteEstimativo 2015] bit NULL,
	[MontoVigenteEstimativo 2016] bit NULL,
	[MontoVigenteEstimativo 2017] bit NULL,
	[MontoVigenteEstimativo 2018] bit NULL,
	[MontoVigenteEstimativo 2019] bit NULL,
	[MontoVigenteEstimativo 2020] bit NULL,
	[MontoVigenteEstimativo 2021] bit NULL,
	[MontoDevengado Anteriores] [decimal] (18,0) NULL,
	[MontoDevengado 2013] [decimal] (18,0) NULL,
	[MontoDevengado 2014] [decimal] (18,0) NULL,
	[MontoDevengado 2015] [decimal] (18,0) NULL,
	[MontoDevengado 2016] [decimal] (18,0) NULL,
	[MontoDevengado 2017] [decimal] (18,0) NULL,
	[MontoDevengado 2018] [decimal] (18,0) NULL,
	[MontoDevengado 2019] [decimal] (18,0) NULL,
	[MontoDevengado 2020] [decimal] (18,0) NULL,
	[MontoDevengado 2021] [decimal] (18,0) NULL,
	[MontoDevengado Posteriores] [decimal] (18,0) NULL,
	[MontoDevengado Total] [decimal] (18,0) NULL,
	[Generado] [varchar] (max) NULL
	)
	
GO
PRINT 'Fin - Drop y Create tabla Cubo x Objeto'
PRINT ' '
GO
PRINT 'Inicio - Creacion de Nuevas Funciones y Procedimientos'
GO

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Fecha_Inicio_Estimada]    Script Date: 04/24/2017 09:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Fecha_Inicio_Estimada] (@IdProyecto int)  
RETURNS  VARCHAR(10)
AS
BEGIN
	Declare @fie varchar(10);
    SELECT @fie = (
					select top 1 
							case when pe.FechaInicioEstimada is null then '' else
							convert(varchar(10),pe.FechaInicioEstimada,103) end
					from Proyecto p
					left join ProyectoEtapa pe		on pe.IdProyecto = p.IdProyecto
					left join Etapa et				on et.IdEtapa = pe.IdEtapa
					left join Fase fa				on fa.IdFase = et.IdFase
					where	fa.IdFase = 2 /* Ejecucion */
					and		p.IdProyecto = @IdProyecto
					)
	RETURN @fie
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Fecha_Inicio_Estimada]    Script Date: 04/24/2017 09:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Fecha_Fin_Estimada] (@IdProyecto int)  
RETURNS  VARCHAR(10)
AS
BEGIN
	Declare @fie varchar(10);
    SELECT @fie = (
					select top 1 
							case when pe.FechaFinEstimada is null then '' else
							convert(varchar(10),pe.FechaFinEstimada,103) end
					from Proyecto p
					left join ProyectoEtapa pe		on pe.IdProyecto = p.IdProyecto
					left join Etapa et				on et.IdEtapa = pe.IdEtapa
					left join Fase fa				on fa.IdFase = et.IdFase
					where	fa.IdFase = 2 /* Ejecucion */
					and		p.IdProyecto = @IdProyecto
					)
	RETURN @fie
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoRealizado]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION  [dbo].[fn_Cubo_ONPDevengado] (@Year int)  
RETURNS  TABLE
AS
RETURN

(
-- Obtiene los montos devengados de la tabla Matching_ProyectosVinculados por ejercicio presupuestario --
select distinct
p.IdProyecto
,p.Codigo
--,ONP_m1=sum(case when EjercicioPresupuestario=@Year-1 then Devengado else 0 end)
,ONP=sum(case when EjercicioPresupuestario=@Year then Devengado else 0 end)
,ONP_1=sum(case when EjercicioPresupuestario=@Year+1 then Devengado else 0 end)
,ONP_2=sum(case when EjercicioPresupuestario=@Year+2 then devengado else 0 end)
,ONP_3=sum(case when EjercicioPresupuestario=@Year+3 then devengado else 0 end)
,ONP_4=sum(case when EjercicioPresupuestario=@Year+4 then devengado else 0 end)
,ONP_5=sum(case when EjercicioPresupuestario=@Year+5 then devengado else 0 end)
,ONP_6=sum(case when EjercicioPresupuestario=@Year+6 then devengado else 0 end)
,ONP_7=sum(case when EjercicioPresupuestario=@Year+7 then devengado else 0 end)
,ONP_8=sum(case when EjercicioPresupuestario=@Year+8 then devengado else 0 end)

--into #onp_devengado

from Proyecto p
left join Matching_ProyectosVinculados mpv on p.Codigo = mpv.CodigoProyectoBAPIN
group by p.idProyecto, p.Codigo
)


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoRealizado]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoEstimado] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Estimados por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,ME_Acumulado_m5=sum(case when periodo < @Year-5  then montocalculado else 0 end)
,ME_m5=sum(case when periodo=@Year-5 then montocalculado else 0 end)
,ME_m4=sum(case when periodo=@Year-4 then montocalculado else 0 end)
,ME_m3=sum(case when periodo=@Year-3 then montocalculado else 0 end) 
,ME_m2=sum(case when periodo=@Year-2 then montocalculado else 0 end) 
,ME_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end) 
,ME=sum(case when periodo=@Year  then montocalculado else 0 end)
,ME_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,ME_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,ME_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,ME_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,ME_Total=sum(montocalculado)
,ME_CostoTotal_Year=sum(case when periodo > @Year-1 then montocalculado else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode/* ,pe.IdEstado*/

--order by cg.BreadcrumbCode
)


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoRealizado]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_MontoRealizado] (@Year int )  
RETURNS  TABLE
AS
RETURN

(
select distinct 
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,perp.Fecha
--,pe.IdEstado

,MR_Acumulado_m5=sum(case when periodo< @Year-5 then montocalculado else 0 end) 
,MR_m5=sum(case when periodo=@Year-5  then montocalculado else 0 end)
,MR_m4=sum(case when periodo=@Year-4  then montocalculado else 0 end)
,MR_m3=sum(case when periodo=@Year-3  then montocalculado else 0 end)
,MR_m2=sum(case when periodo=@Year-2  then montocalculado else 0 end)
,MR_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end)
,MR=sum(case when periodo=@Year  then montocalculado else 0 end)
,MR_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,MR_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,MR_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,MR_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,MR_Total=sum(montocalculado)
,MR_CostoTotal_Year=sum(case when periodo < @Year then montocalculado else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaRealizado per on per.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaRealizadoPeriodo perp on perp.IdProyectoEtapaRealizado = per.IdProyectoEtapaRealizado
left join ClasificacionGasto cg on cg.IdClasificacionGasto = per.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = per.IdFuenteFinanciamiento

--where p.IdProyecto = 4902 and per.IdClasificacionGasto = 1646

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, /*perp.fecha,*/ fufi.BreadcrumbCode, fufi.Descripcion, 
fufi.IdFuenteFinanciamiento, cg.IdClasificacionGasto, /*pe.IdEstado,*/ cg.BreadcrumbCode, cg.Descripcion

--order by cg.BreadcrumbCode
)

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_ME_MR]    Script Date: 04/21/2017 15:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Union_ME_MR] (@Year int )  

RETURNS  TABLE
AS
RETURN

(
-- Obtiene los Montos Estimados y Monto Realizados por Objeto de Gasto--

select 

isnull(me.IdProyecto,mr.idproyecto) as IdProyecto
,isnull(me.codigo, mr.codigo) as Nro_Bapin
,isnull(me.Fuente_Financiamiento_Cod,mr.Fuente_Financiamiento_Cod) as [Fuente_Financiamiento_Cod]
,isnull(me.Fuente_Financiamiento_Desc,mr.Fuente_Financiamiento_Desc) as [Fuente_Financiamiento_Desc]
,ISNULL(substring(me.Objeto_Gasto_Cod,2,2),'00') as [Inciso]
,ISNULL(me.Objeto_Gasto_Cod,mr.Objeto_Gasto_Cod) as [Objeto_Gasto_Cod] 
,ISNULL(me.Objeto_Gasto_Desc,mr.Objeto_Gasto_Desc) as [Objeto_Gasto_Desc]
,isnull(ME_Acumulado_m5,0) as [ME_Acumulado_m5] --as [Estimados Anteriores] 
,isnull(ME_m5,0) as [ME_m5] --as [Estimado 2013]
,isnull(ME_m4,0) as [ME_m4] --as [Estimado 2014]
,isnull(ME_m3,0) as [ME_m3] --as [Estimado 2015]
,isnull(ME_m2,0) as [ME_m2] --as [Estimado 2016]
,isnull(ME_m1,0) as [ME_m1] --as [Estimado 2017]
,isnull(ME,0) as [ME] --as [Estimado 2018]
,isnull(ME_1,0) as [ME_1] --as [Estimado 2019]
,isnull(ME_2,0) as [ME_2] --as [Estimado 2020]
,isnull(ME_3,0) as [ME_3] --as [Estimado 2021]
,isnull(ME_Acumulado_3,0) as [ME_Acumulado_3] --as [Estimado Posteriores]
,isnull(ME.ME_Total,0) as [ME_Total] --as [Estimado Total]
,isnull(ME_CostoTotal_Year,0) as [ME_CostoTotal_Year]

--,isnull(convert(varchar(10),mr.Fecha,103),'') as Fecha_Gasto_Realizado
,isnull(MR_Acumulado_m5,0) as [MR_Acumulado_m5] --as [Realizados Anteriores]
,isnull(MR_m5,0) as [MR_m5] --as [Realizado 2013]
,isnull(MR_m4,0) as [MR_m4] --as [Realizado 2014]
,isnull(MR_m3,0) as [MR_m3] --as [Realizado 2015]
,isnull(MR_m2,0) as [MR_m2] --as [Realizado 2016]
,isnull(MR_m1,0) as [MR_m1] --as [Realizado 2017]
,isnull(MR,0) as [MR] --as [Realizado 2018]
,isnull(MR_1,0) as [MR_1] --as [Realizado 2019]
,isnull(MR_2,0) as [MR_2] --as [Realizado 2020]
,isnull(MR_3,0) as [MR_3] --as [Realizado 2021]
,isnull(MR_Acumulado_3,0) as [MR_Acumulado_3] --as [Realizado Posteriores]
,isnull(MR.MR_Total,0) as [MR_Total] --as [Realizado Total]
,isnull(MR_CostoTotal_Year,0) as [MR_CostoTotal_Year]

from fn_Cubo_MontoEstimado (@Year) me full join fn_Cubo_Montorealizado (@Year) mr on 
(me.Objeto_Gasto_Cod = mr.Objeto_Gasto_Cod) and
(me.Fuente_Financiamiento_Cod = mr.Fuente_Financiamiento_Cod) and
(me.IdProyecto = mr.IdProyecto)

where
me.Objeto_Gasto_Cod is not null or mr.Objeto_Gasto_Cod is not null

)

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoInicial]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoInicial] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Inicials por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,MI_Acumulado_m5=sum(case when periodo < @Year-5  then montoinicial else 0 end)
,MI_m5=sum(case when periodo=@Year-5 then montoinicial else 0 end)
,MI_m4=sum(case when periodo=@Year-4 then montoinicial else 0 end)
,MI_m3=sum(case when periodo=@Year-3 then montoinicial else 0 end) 
,MI_m2=sum(case when periodo=@Year-2 then montoinicial else 0 end) 
,MI_m1=sum(case when periodo=@Year-1 then montoinicial else 0 end) 
,MI=sum(case when periodo=@Year  then montoinicial else 0 end)
,MI_1=sum(case when periodo=@Year+1 then montoinicial else 0 end)
,MI_2=sum(case when periodo=@Year+2  then montoinicial else 0 end)
,MI_3=sum(case when periodo=@Year+3  then montoinicial else 0 end)
,MI_Acumulado_3=sum(case when periodo>@Year+3  then montoinicial else 0 end)
,MI_Total=sum(montoinicial)
,MI_CostoTotal_Year=sum(case when periodo > @Year-1 then montoinicial else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaInformacionPresupuestaria pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaInformacionPresupuestariaPeriodo peep on peep.IdProyectoEtapaInformacionPresupuestaria = pee.IdProyectoEtapaInformacionPresupuestaria
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode/* ,pe.IdEstado*/

--order by cg.BreadcrumbCode
)
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoVigente]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoVigente] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Vigentes por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,MV_Acumulado_m5=sum(case when periodo < @Year-5  then montovigente else 0 end)
,MV_m5=sum(case when periodo=@Year-5 then montovigente else 0 end)
,MV_m4=sum(case when periodo=@Year-4 then montovigente else 0 end)
,MV_m3=sum(case when periodo=@Year-3 then montovigente else 0 end) 
,MV_m2=sum(case when periodo=@Year-2 then montovigente else 0 end) 
,MV_m1=sum(case when periodo=@Year-1 then montovigente else 0 end) 
,MV=sum(case when periodo=@Year  then montovigente else 0 end)
,MV_1=sum(case when periodo=@Year+1 then montovigente else 0 end)
,MV_2=sum(case when periodo=@Year+2  then montovigente else 0 end)
,MV_3=sum(case when periodo=@Year+3  then montovigente else 0 end)
,MV_Acumulado_3=sum(case when periodo>@Year+3  then montovigente else 0 end)
,MV_Total=sum(montovigente)
,MV_CostoTotal_Year=sum(case when periodo > @Year-1 then montovigente else 0 end)

,MVE_m5=(case when periodo=@Year-5 then MontoVigenteEstimativo else 0 end)
,MVE_m4=(case when periodo=@Year-4 then MontoVigenteEstimativo else 0 end)
,MVE_m3=(case when periodo=@Year-3 then MontoVigenteEstimativo else 0 end)
,MVE_m2=(case when periodo=@Year-2 then MontoVigenteEstimativo else 0 end)
,MVE_m1=(case when periodo=@Year-1 then MontoVigenteEstimativo else 0 end)
,MVE=(case when periodo=@Year then MontoVigenteEstimativo else 0 end)
,MVE_1=(case when periodo=@Year+1 then MontoVigenteEstimativo else 0 end)
,MVE_2=(case when periodo=@Year+2 then MontoVigenteEstimativo else 0 end)
,MVE_3=(case when periodo=@Year+3 then MontoVigenteEstimativo else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaInformacionPresupuestaria pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaInformacionPresupuestariaPeriodo peep on peep.IdProyectoEtapaInformacionPresupuestaria = pee.IdProyectoEtapaInformacionPresupuestaria
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode, peep.periodo, peep.MontoVigenteEstimativo

--order by cg.BreadcrumbCode
)
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_MontoDevengado]    Script Date: 04/21/2017 15:50:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

GO
CREATE FUNCTION  [dbo].[fn_Cubo_MontoDevengado] (@Year int )  
RETURNS TABLE
AS
RETURN
(
-- Obtiene los Montos Devengados por FuenteFinanciamiento, Periodo --
select distinct
p.IdProyecto
,p.Codigo
,fufi.BreadcrumbCode as [Fuente_Financiamiento_Cod]
,fufi.Descripcion as [Fuente_Financiamiento_Desc]
,cg.BreadcrumbCode as [Objeto_Gasto_Cod]
,cg.Descripcion as [Objeto_Gasto_Desc]
--,pe.IdEstado

,MD_Acumulado_m5=sum(case when periodo < @Year-5  then montodevengado else 0 end)
,MD_m5=sum(case when periodo=@Year-5 then montodevengado else 0 end)
,MD_m4=sum(case when periodo=@Year-4 then montodevengado else 0 end)
,MD_m3=sum(case when periodo=@Year-3 then montodevengado else 0 end) 
,MD_m2=sum(case when periodo=@Year-2 then montodevengado else 0 end) 
,MD_m1=sum(case when periodo=@Year-1 then montodevengado else 0 end) 
,MD=sum(case when periodo=@Year  then montodevengado else 0 end)
,MD_1=sum(case when periodo=@Year+1 then montodevengado else 0 end)
,MD_2=sum(case when periodo=@Year+2  then montodevengado else 0 end)
,MD_3=sum(case when periodo=@Year+3  then montodevengado else 0 end)
,MD_Acumulado_3=sum(case when periodo>@Year+3  then montodevengado else 0 end)
,MD_Total=sum(montodevengado)
,MD_CostoTotal_Year=sum(case when periodo > @Year-1 then montodevengado else 0 end)

from Proyecto p
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaInformacionPresupuestaria pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaInformacionPresupuestariaPeriodo peep on peep.IdProyectoEtapaInformacionPresupuestaria = pee.IdProyectoEtapaInformacionPresupuestaria
left join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento

where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 

group by p.IdProyecto, p.codigo, fufi.Descripcion, fufi.BreadcrumbCode, fufi.IdFuenteFinanciamiento,
cg.IdClasificacionGasto, cg.Descripcion, cg.BreadcrumbCode/* ,pe.IdEstado*/

--order by cg.BreadcrumbCode
)
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Union_Presupuestaria]    Script Date: 04/21/2017 15:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Union_Presupuestaria] (@Year int )  

RETURNS  TABLE
AS
RETURN

(
-- Obtiene los Montos inicial, vigente y Devengado por Objeto de Gasto--

select 

/*isnull(isnull(MI.IdProyecto,MV.idproyecto),MD.idproyecto) as IdProyecto
,isnull(isnull(MI.codigo, MV.codigo), MD.codigo) as Nro_Bapin
,isnull(isnull(MI.Fuente_Financiamiento_Cod,MV.Fuente_Financiamiento_Cod),MD.Fuente_Financiamiento_Cod) as [Fuente_Financiamiento_Cod]
,isnull(isnull(MI.Fuente_Financiamiento_Desc,MV.Fuente_Financiamiento_Desc),MD.Fuente_Financiamiento_Desc) as [Fuente_Financiamiento_Desc]
,ISNULL(substring(MI.Objeto_Gasto_Cod,2,2),'00') as [Inciso]
,isnull(ISNULL(MI.Objeto_Gasto_Cod,MV.Objeto_Gasto_Cod),MD.Objeto_Gasto_Cod) as [Objeto_Gasto_Cod] 
,isnull(ISNULL(MI.Objeto_Gasto_Desc,MV.Objeto_Gasto_Desc),MD.Objeto_Gasto_Desc) as [Objeto_Gasto_Desc]*/

isnull(isnull(ISNULL(ISNULL(ME.IdProyecto,MR.IdProyecto), MI.IdProyecto), MV.idproyecto), MD.idproyecto) as IdProyecto
,isnull(isnull(ISNULL(ISNULL(ME.codigo, MR.codigo), MI.codigo), MV.codigo), MD.codigo) as Nro_Bapin
,isnull(isnull(ISNULL(ISNULL(ME.Fuente_Financiamiento_Cod, MR.Fuente_Financiamiento_Cod), MI.Fuente_Financiamiento_Cod), MV.Fuente_Financiamiento_Cod),MD.Fuente_Financiamiento_Cod) as [Fuente_Financiamiento_Cod]
,isnull(isnull(ISNULL(ISNULL(ME.Fuente_Financiamiento_Desc, MR.Fuente_Financiamiento_Desc), MI.Fuente_Financiamiento_Desc),MV.Fuente_Financiamiento_Desc),MD.Fuente_Financiamiento_Desc) as [Fuente_Financiamiento_Desc]
,ISNULL(ISNULL(ISNULL(ISNULL(ISNULL(substring(ME.Objeto_Gasto_Cod,2,2), substring(ME.Objeto_Gasto_Cod,2,2)), substring(MI.Objeto_Gasto_Cod,2,2)), substring(MV.Objeto_Gasto_Cod,2,2)), substring(MV.Objeto_Gasto_Cod,2,2)), '00') as [Inciso]
,isnull(ISNULL(ISNULL(ISNULL(ME.Objeto_Gasto_Cod, MR.Objeto_Gasto_Cod), MI.Objeto_Gasto_Cod), MV.Objeto_Gasto_Cod), MD.Objeto_Gasto_Cod) as [Objeto_Gasto_Cod] 
,isnull(ISNULL(ISNULL(ISNULL(ME.Objeto_Gasto_Desc, MR.Objeto_Gasto_Desc), MI.Objeto_Gasto_Desc), MV.Objeto_Gasto_Desc), MD.Objeto_Gasto_Desc) as [Objeto_Gasto_Desc]

,isnull(ME_Acumulado_m5,0) as [ME_Acumulado_m5] --as [Estimados Anteriores] 
,isnull(ME_m5,0) as [ME_m5] --as [Estimado 2013]
,isnull(ME_m4,0) as [ME_m4] --as [Estimado 2014]
,isnull(ME_m3,0) as [ME_m3] --as [Estimado 2015]
,isnull(ME_m2,0) as [ME_m2] --as [Estimado 2016]
,isnull(ME_m1,0) as [ME_m1] --as [Estimado 2017]
,isnull(ME,0) as [ME] --as [Estimado 2018]
,isnull(ME_1,0) as [ME_1] --as [Estimado 2019]
,isnull(ME_2,0) as [ME_2] --as [Estimado 2020]
,isnull(ME_3,0) as [ME_3] --as [Estimado 2021]
,isnull(ME_Acumulado_3,0) as [ME_Acumulado_3] --as [Estimado Posteriores]
,isnull(ME.ME_Total,0) as [ME_Total] --as [Estimado Total]
,isnull(ME_CostoTotal_Year,0) as [ME_CostoTotal_Year]

--,isnull(convert(varchar(10),mr.Fecha,103),'') as Fecha_Gasto_Realizado
,isnull(MR_Acumulado_m5,0) as [MR_Acumulado_m5] --as [Realizados Anteriores]
,isnull(MR_m5,0) as [MR_m5] --as [Realizado 2013]
,isnull(MR_m4,0) as [MR_m4] --as [Realizado 2014]
,isnull(MR_m3,0) as [MR_m3] --as [Realizado 2015]
,isnull(MR_m2,0) as [MR_m2] --as [Realizado 2016]
,isnull(MR_m1,0) as [MR_m1] --as [Realizado 2017]
,isnull(MR,0) as [MR] --as [Realizado 2018]
,isnull(MR_1,0) as [MR_1] --as [Realizado 2019]
,isnull(MR_2,0) as [MR_2] --as [Realizado 2020]
,isnull(MR_3,0) as [MR_3] --as [Realizado 2021]
,isnull(MR_Acumulado_3,0) as [MR_Acumulado_3] --as [Realizado Posteriores]
,isnull(MR.MR_Total,0) as [MR_Total] --as [Realizado Total]
,isnull(MR_CostoTotal_Year,0) as [MR_CostoTotal_Year]

,isnull(MI_Acumulado_m5,0) as [MI_Acumulado_m5] --as [Inicials Anteriores] 
,isnull(MI_m5,0) as [MI_m5] --as [Inicial 2012]
,isnull(MI_m4,0) as [MI_m4] --as [Inicial 2013]
,isnull(MI_m3,0) as [MI_m3] --as [Inicial 2014]
,isnull(MI_m2,0) as [MI_m2] --as [Inicial 2015]
,isnull(MI_m1,0) as [MI_m1] --as [Inicial 2016]
,isnull(MI,0) as [MI] --as [Inicial 2017]
,isnull(MI_1,0) as [MI_1] --as [Inicial 2018]
,isnull(MI_2,0) as [MI_2] --as [Inicial 2019]
,isnull(MI_3,0) as [MI_3] --as [Inicial 2020]
,isnull(MI_Acumulado_3,0) as [MI_Acumulado_3] --as [Inicial Posteriores]
,isnull(MI.MI_Total,0) as [MI_Total] --as [Inicial Total]
,isnull(MI_CostoTotal_Year,0) as [MI_CostoTotal_Year]

,isnull(MV_Acumulado_m5,0) as [MV_Acumulado_m5] --as [Vigentes Anteriores]
,isnull(MV_m5,0) as [MV_m5] --as [Vigente 2012]
,isnull(MV_m4,0) as [MV_m4] --as [Vigente 2013]
,isnull(MV_m3,0) as [MV_m3] --as [Vigente 2014]
,isnull(MV_m2,0) as [MV_m2] --as [Vigente 2015]
,isnull(MV_m1,0) as [MV_m1] --as [Vigente 2016]
,isnull(MV,0) as [MV] --as [Vigente 2017]
,isnull(MV_1,0) as [MV_1] --as [Vigente 2018]
,isnull(MV_2,0) as [MV_2] --as [Vigente 2019]
,isnull(MV_3,0) as [MV_3] --as [Vigente 2020]
,isnull(MV_Acumulado_3,0) as [MV_Acumulado_3] --as [Vigente Posteriores]
,isnull(MV.MV_Total,0) as [MV_Total] --as [Vigente Total]
,isnull(MV_CostoTotal_Year,0) as [MV_CostoTotal_Year]

,isnull(MD_Acumulado_m5,0) as [MD_Acumulado_m5] --as [Vigentes Anteriores]
,isnull(MD_m5,0) as [MD_m5] --as [Vigente 2012]
,isnull(MD_m4,0) as [MD_m4] --as [Vigente 2013]
,isnull(MD_m3,0) as [MD_m3] --as [Vigente 2014]
,isnull(MD_m2,0) as [MD_m2] --as [Vigente 2015]
,isnull(MD_m1,0) as [MD_m1] --as [Vigente 2016]
,isnull(MD,0) as [MD] --as [Vigente 2017]
,isnull(MD_1,0) as [MD_1] --as [Vigente 2018]
,isnull(MD_2,0) as [MD_2] --as [Vigente 2019]
,isnull(MD_3,0) as [MD_3] --as [Vigente 2020]
,isnull(MD_Acumulado_3,0) as [MD_Acumulado_3] --as [Vigente Posteriores]
,isnull(MD.MD_Total,0) as [MD_Total] --as [Vigente Total]
,isnull(MD_CostoTotal_Year,0) as [MD_CostoTotal_Year]

,MV.MVE_m5
,MV.MVE_m4
,MV.MVE_m3
,MV.MVE_m2
,MV.MVE_m1
,MV.MVE
,MV.MVE_1
,MV.MVE_2
,MV.MVE_3
	
from 
	fn_Cubo_MontoEstimado (@Year) me 
	full join fn_Cubo_Montorealizado (@Year) mr on 
		(me.Objeto_Gasto_Cod = mr.Objeto_Gasto_Cod) and
		(me.Fuente_Financiamiento_Cod = mr.Fuente_Financiamiento_Cod) and
		(me.IdProyecto = mr.IdProyecto)
	full join fn_Cubo_MontoInicial (@Year) MI on
		(me.Objeto_Gasto_Cod = MI.Objeto_Gasto_Cod) and
		(me.Fuente_Financiamiento_Cod = MI.Fuente_Financiamiento_Cod) and
		(me.IdProyecto = MI.IdProyecto)
	full join fn_Cubo_MontoVigente (@Year) MV on 
		(me.Objeto_Gasto_Cod = MV.Objeto_Gasto_Cod) and
		(me.Fuente_Financiamiento_Cod = MV.Fuente_Financiamiento_Cod) and
		(me.IdProyecto = MV.IdProyecto)
	full join fn_Cubo_MontoDevengado (@Year) MD on 
		(me.Objeto_Gasto_Cod = MD.Objeto_Gasto_Cod) and
		(me.Fuente_Financiamiento_Cod = MD.Fuente_Financiamiento_Cod) and
		(me.IdProyecto = MD.IdProyecto)
where
me.Objeto_Gasto_Cod is not null or mr.Objeto_Gasto_Cod is not null or
MI.Objeto_Gasto_Cod is not null or MV.Objeto_Gasto_Cod is not null or 
MD.Objeto_Gasto_Cod is not null

)


GO

/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_ECTO_Group]    Script Date: 03/21/2017 12:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_ECTO_Group] ()
RETURNS @retECTO TABLE 
(
    IdProyecto int primary key NOT NULL,
    ECTOes varchar(max)
)
-- Regresa todos los comentarios tecnicos de un proyecto cuyo tipo es ECTO
--, ordenados por fecha en forma descendente
AS
begin 
WITH ECTO_Det(IDProyecto, ECTOes, Fecha) --,orden2,orden3) 
    AS (
		select idproyecto, ECTOes=convert(varchar(10),Fecha,103) +'  -'+ observacion, Fecha 
		from ProyectoComentarioTecnico pct
		where pct.IdComentarioTecnico = 8
		)

insert into @retECTO 
SELECT p1.idproyecto,
       ( SELECT ECTOes + ' / '   FROM ECTO_Det p2
          WHERE p2.idproyecto = p1.idproyecto
          ORDER BY Fecha Desc
--          ORDER BY Orden, AnioInicial desc, ordenB
         FOR XML PATH('') ) AS ECTOes
	      FROM ECTO_Det p1
	      GROUP BY p1.Idproyecto order by idproyecto

RETURN
END


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_FuenteFinanciamiento_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_FuenteFinanciamiento_Group] ()
RETURNS @retFuenteFinan TABLE 
(
    IdProyecto int primary key NOT NULL
	,Bapin int
	,FuenteFinan varchar (max)
	,DescFuenteFinan varchar (max)
)

--Regresa las Fuentes de Financiamiento para un proyecto agrupadas

AS
begin 
WITH FuenteFinan_Det(IDProyecto, Bapin, FuenteFinan, DescFuenteFinan)
    AS (
		select distinct
		p.idproyecto													
		,p.Codigo														as bapin
		,substring(fufi.BreadcrumbCode,2,len(fufi.BreadcrumbCode)-2)	as FuenteFinan
		,fufi.Descripcion												as DescFuenteFinan

		from ProyectoEtapaEstimado pee 
			inner join ProyectoEtapa pe on pe.IdProyectoEtapa = pee.IdProyectoEtapa
			inner join Etapa et on et.IdEtapa=pe.IdEtapa and et.IdFase=2 --fase ejecucion (corresponde a Etapa Obra o Actividad)
			inner join Proyecto p on p.IdProyecto = pe.IdProyecto
			inner join ProyectoEtapaEstimadoPeriodo peep on pee.IdProyectoEtapaEstimado=peep.IdProyectoEtapaEstimado
			inner join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento
		
		where et.Nombre = 'Obra' or et.Nombre = 'Actividad'
		)
		insert into @retFuenteFinan

-- Tomando la tabla temporal (Obj_Det) agrupa por IdProyecto

Select 
		ff1.idproyecto
		,Bapin
		,( Select
			FuenteFinan + ' ' from FuenteFinan_Det ff2
			where ff2.idproyecto = ff1.idproyecto
			Order by IDProyecto, FuenteFinan
			for xml path('')
		 )																as FuenteFinan
		,( Select
			DescFuenteFinan + ' - ' from FuenteFinan_Det ff2
			where ff2.idproyecto = ff1.idproyecto
			Order by IDProyecto, FuenteFinan
			for xml path('')
		 )																as DescFuenteFinan
         from FuenteFinan_Det ff1
	     group by ff1.IDProyecto, bapin
	     order by IDProyecto

RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Inciso_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_Inciso_Group] ()
RETURNS @retInciso TABLE 
(
    IdProyecto int primary key NOT NULL,
	Bapin int,
	NroProyecto int,
	Incisos varchar (max)
	)

--Regresa los Incisos para un proyecto
-- Objeto de Gasto : Inciso / Partida Principal / Partida Parcial

AS
begin 
WITH Inciso_Det(IDProyecto, Bapin, NroProyecto, Inciso)
    AS (
		select distinct pe.idproyecto, p.Codigo,
		p.nroproyecto,
		inciso = convert(int,substring(cg.BreadcrumbCode,2,2))
		from ProyectoEtapa pe
		inner join Proyecto p on p.IdProyecto=pe.IdProyecto
		inner join Etapa et on et.IdEtapa=pe.IdEtapa
		inner join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa=pe.IdProyectoEtapa
		inner join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
		where et.Nombre = 'Obra' or et.Nombre = 'Actividad'
		)
		insert into @retInciso 

-- Tomando la tabla temporal (Obj_Det) agrupa por IdProyecto

SELECT p1.idproyecto, Bapin, nroproyecto,
       ( SELECT convert(varchar,Inciso) + '' FROM Inciso_Det p2
          WHERE p2.idproyecto = p1.idproyecto
          ORDER BY idproyecto, Inciso
         FOR XML PATH('') ) AS Incisos
         FROM Inciso_Det p1
	     GROUP BY p1.Idproyecto, bapin, NroProyecto order by idproyecto
RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_Plan_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION  [dbo].[fn_Cubo_Plan_Group] ()
RETURNS @retPlan TABLE 
(
    IdProyecto int primary key NOT NULL,
    Planes varchar(max)
)
-- Regresa todos los planes
AS
begin 
WITH Plan_Det(IDProyecto,Planes, Orden,AnioInicial, OrdenB) --,orden2,orden3) 
    AS (
		select idproyecto, planes=pt.Sigla+'-'+ppt.Sigla + '-' + ppv.Nombre,
		pt.Orden,ppt.AnioInicial, ordenB=ppv.Orden
		from ProyectoPlan pp
		inner join PlanPeriodo ppt on pp.IdPlanPeriodo=ppt.IdPlanPeriodo
		inner join PlanVersion ppv on ppv.IdPlanVersion=pp.IdPlanVersion
		inner join PlanTipo pt on pt.IdPlanTipo=ppt.IdPlanTipo
		 )


insert into @retPlan 
SELECT p1.idproyecto,
       ( SELECT Planes + ' / '   FROM Plan_Det p2
          WHERE p2.idproyecto = p1.idproyecto
          ORDER BY Orden, AnioInicial desc, ordenB
         FOR XML PATH('') ) AS Planes
	      FROM Plan_Det p1
	      GROUP BY p1.Idproyecto order by idproyecto

RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_UltimoPlanPrioridad]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_Cubo_UltimoPlanPrioridad] ()
returns @retUltPlanPrio table 
(
    IdProyecto int
    ,IdPlanPeriodo int
    ,Codigo int
    ,Prioridad varchar (max)
    ,Periodo varchar (max)
    ,ReqArt15 int
)

as
begin 
with UltimoPlan (IDProyecto, IDPlanPeriodo, Codigo, Prioridad, Periodo, ReqArt15)
    as (
		select	pp.IdProyecto
				,per.IdPlanPeriodo
				,p.Codigo
				,pd.Nombre as Prioridad
				,per.Nombre as Periodo
				,pp.ReqArt15
						
		from	ProyectoPrioridad pp
	
				left join prioridad pd on pd.IdPrioridad = pp.IdPrioridad
				left join Proyecto p on p.IdProyecto = pp.IdProyecto
				left join PlanPeriodo per on per.IdPlanPeriodo = pp.IdPlanPeriodo
				left join PlanTipo pti on pti.IdPlanTipo = per.IdPlanTipo 

		--where pti.Nombre = 'Demanda'

		--order by p.Codigo, per.IdPlanPeriodo
		
		)
		insert into @retUltPlanPrio 


		-- Tomando la tabla temporal (Prog_Det) agrupa por IdProyecto 

		select	a.IdProyecto
				,a2.IdPlanPeriodo
				,a.Codigo
				,a.Prioridad
				,a.Periodo
				,a.ReqArt15
								
		from	UltimoPlan a

				left join	(	select b.Codigo, MAX(b.IdPlanPeriodo) IdPlanPeriodo
								from UltimoPlan b 
								group by b.Codigo
							)	a2 on a2.Codigo = a.Codigo
					
		where a.IDPlanPeriodo = a2.IdPlanPeriodo

RETURN
END


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EstadoFinanciero_Group]    Script Date: 11/28/2016 20:46:28 ******/
--Estado Fisico: Corresponde al estado del proyecto (presentado en la solapa General del Bapin)

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_EstadoFinanciero_Group] ()
RETURNS @retEstFinanciero TABLE 
(
    IdProyecto int primary key NOT NULL,
--	Codigo int,
--	NroProyecto int,
	EstFinanciero varchar (max)
	)

AS
BEGIN 
WITH EstFinanciero_Det(IDProyecto, IDEstado, EstFinanciero)
    AS (
		SELECT 
			p.IdProyecto
			,eFinanciero.IdEstado
--			,pe.IdProyectoEtapa
--			,p.Codigo
			,eFinanciero.Nombre as EstFinanciero
		FROM Proyecto p
				left join Estado eFinanciero on eFinanciero.IdEstado = p.IdEstado
		)
		INSERT INTO @retEstFinanciero 

-- Tomando la tabla temporal agrupa por IdProyecto

SELECT 
		ef1.IDProyecto
--		,ef1.IDProyectoEtapa
--		,Codigo
		,(
			SELECT
				EstFinanciero + ' / ' FROM EstFinanciero_Det ef2
			WHERE ef2.idproyecto = ef1.idproyecto
			ORDER BY IDProyecto, IDEstado asc
			FOR XML PATH('')
         ) AS EstFinanciero
         FROM EstFinanciero_Det ef1
	     GROUP BY ef1.Idproyecto
	     ORDER BY IDProyecto
RETURN
END


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EstadoFisico_Group]    Script Date: 11/28/2016 20:46:28 ******/
--Estado Fisico: Corresponde al estado reflejado en el Cronograma (presentado en la solapa Cronograma del Bapin)
--Regresa los Estados fisicos para un proyecto presentados en la forma Fase-Etapa-Estado

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_EstadoFisico_Group] ()
RETURNS @retEstFisico TABLE 
(
    IdProyecto int primary key NOT NULL,
--	Codigo int,
--	NroProyecto int,
	EstFisico varchar (max)
)

AS
BEGIN 
WITH EstFisico_Det(IDProyecto, IDEtapa, Fase, Etapa, EstFisico)
    AS (
		SELECT 
			pe.IdProyecto,
			et.IdEtapa,
			fa.Nombre as Fase,
			et.Nombre as Etapa,
			eFisico.Nombre as EstFisico
		FROM	ProyectoEtapa pe
--				inner join Proyecto p on p.IdProyecto = pe.IdProyecto
				inner join Estado eFisico on eFisico.IdEstado = pe.IdEstado
				inner join Etapa et on et.IdEtapa = pe.IdEtapa
				inner join Fase fa on fa.IdFase = et.IdFase
		)
		INSERT INTO @retEstFisico 

-- Tomando la tabla temporal agrupa por IdProyecto

SELECT 
		eff1.idproyecto
		,(
			SELECT
				Fase+'-'+Etapa+'-'+EstFisico + ' / ' FROM EstFisico_Det eff2
			WHERE eff2.idproyecto = eff1.idproyecto
			ORDER BY IDProyecto, IDEtapa
			FOR XML PATH('')
         ) AS EstFisico
         FROM EstFisico_Det eff1
	     GROUP BY eff1.Idproyecto
	     ORDER BY idproyecto
RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_AperturaPresupuestaria_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_AperturaPresupuestaria_Group] ()
RETURNS @retAperPresup TABLE 
(
    IdProyecto int primary key NOT NULL
	,Codigo int
	,NroProyecto varchar (max)
	,NroActividadAgrup varchar (max)
	,NroObraAgrup varchar (max)
	,Tipo_PresupAgrup varchar (max)
	--Aper_Presup varchar (max)
)

--Regresa los datos de la Apertura Presupuestaria Agrupada por NroProyecto
-- Apertura Presupuestaria : NroProyecto / NroActividad / NroObra
-- Tipo_PresupAgrup : Proyecto / Actividad

AS
begin 
WITH AperPresup_Det
		(
			IDProyecto, Codigo, NroProyecto, NroActividad, NroObra, Tipo_Presup--, Aper_Presup
		)
    AS (
		select pe.idproyecto as IdProyecto
		, p.codigo as Codigo
		, NroProyecto = isnull(convert(varchar,p.NroProyecto),'0') 
        , NroActividad = case when et.Nombre='Actividad' then isnull(convert(varchar,NroEtapa),'0') else '0' end
		, NroObra = case when et.Nombre='Obra' then isnull(convert(varchar,NroEtapa),'0') else '0' end
		--pe.NroEtapa,
		--et.nombre as Nombre_Etapa,
		, Tipo_presup = case when p.EsProyecto = 0 and et.nombre = 'Actividad' then 'Actividad' else
				--case when p.EsProyecto = 1 and et.nombre = 'Actividad' then 'Actividad_Especifica' else
				case when p.EsProyecto = 1
				-- and et.Nombre = 'Obra'
				then 'Proyecto' else 'No_clasificado' end end
				-- end
		
		from ProyectoEtapa pe
			inner join Proyecto p on p.IdProyecto=pe.IdProyecto
			inner join Etapa et on et.IdEtapa=pe.IdEtapa
		where et.Nombre = 'Obra' or et.Nombre = 'Actividad'
		)
		insert into @retAperPresup 

-- Tomando la tabla anterior temporal agrupa por IdProyecto

SELECT ap1.IDProyecto, Codigo, isnull(NroProyecto,''), 
       NroActividadAgrup = ( SELECT NroActividad + '/' FROM AperPresup_Det ap2
          WHERE ap2.idproyecto = ap1.idproyecto
          ORDER BY idproyecto, Tipo_Presup desc 
         FOR XML PATH('') ),
       NroObraAgrup = ( SELECT NroObra + '/' FROM AperPresup_Det ap2
          WHERE ap2.idproyecto = ap1.idproyecto
          ORDER BY idproyecto, Tipo_Presup desc
         FOR XML PATH('') ),
       TipoPresupAgrup = ( SELECT Tipo_presup + '/' FROM AperPresup_Det ap2
          WHERE ap2.idproyecto = ap1.idproyecto
          ORDER BY idproyecto, Tipo_Presup desc
         FOR XML PATH('') )
         FROM AperPresup_Det ap1
	     GROUP BY ap1.Idproyecto, Codigo, NroProyecto
	     ORDER BY IDProyecto

RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_EvaluacionFactibilidad_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_EvaluacionFactibilidad_Group] ()
RETURNS @retEvalFactibilidad TABLE 
(
    IdProyecto int primary key NOT NULL,
--	Codigo int,
--	NroProyecto int,
	Eval_Fact varchar (max)
)

AS
BEGIN 
WITH EvalFactibilidad_Det(IDProyecto, Denom_Eval_Fact, Est_Eval_Fact, Fecha_Eval_Fact)
    AS (
		SELECT distinct
			p.idproyecto,
			ps.Denominacion as Denom_Eval_Fact,
			es.Nombre as Est_Eval_Fact,
			pse.Fecha as Fecha_Eval_Fact

			FROM	Proyecto p
			inner join ProyectoSeguimientoProyecto psp	on psp.IdProyecto = p.IdProyecto
			inner join proyectoseguimiento ps			on ps.IdProyectoSeguimiento = psp.IdProyectoSeguimiento
			inner join ProyectoSeguimientoEstado pse	on pse.IdProyectoSeguimientoEstado = ps.IdProyectoSeguimientoEstadoUltimo
			inner join estado es						on es.idestado = pse.idestado
		)
		INSERT INTO @retEvalFactibilidad 

-- Tomando la tabla temporal agrupa por IdProyecto

SELECT 
		ef1.IDProyecto
--		,ef1.IDProyectoEtapa
--		,Codigo
		,(
			SELECT
				Denom_Eval_Fact + '-' + Est_Eval_Fact + '-' + convert(varchar(10),Fecha_Eval_Fact,103) + ' / '
			FROM EvalFactibilidad_Det ef2
			WHERE ef2.idproyecto = ef1.idproyecto
			ORDER BY IDProyecto asc
			FOR XML PATH('')
         ) AS Eval_Fact
         FROM EvalFactibilidad_Det ef1
	     GROUP BY ef1.Idproyecto
	     ORDER BY IDProyecto
RETURN
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_DictamenInversion_Group]    Script Date: 11/28/2016 20:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_DictamenInversion_Group] ()
RETURNS @retDictInversion TABLE 
(
    IdProyecto int primary key NOT NULL,
--	Codigo int,
--	NroProyecto int,
	Dict_Inversion varchar (max)
--	Denom_Inversion varchar (max),
--	Calif_Inversion varchar (max),
--	Est_Inversion varchar (max)
)
--Regresa los Estados Fisicos para un proyecto
AS
BEGIN 
WITH DictInversion_Det(IDProyecto, Codigo, NumExpDict, Denominacion, Calificacion, Fecha_Calif, Est_inversion, Informe_Tecnico, Ejercicio)
    AS (
		SELECT distinct
				p.idproyecto,
				p.codigo,
				pd.Numero as NumExpDict,
				pd.Denominacion,
				pcal.Nombre as Calificacion,
				pd.Fecha as Fecha_Calif,
				estdic.Nombre as Est_Inversion,
				pd.InformeTecnico as Informe_Tecnico,
				pd.Ejercicio as Ejercicio
	
		FROM proyecto p
				inner join ProyectoSeguimientoProyecto psp on psp.IdProyecto = p.IdProyecto
				inner join ProyectoDictamenSeguimiento pds on pds.IdProyectoSeguimiento = psp.IdProyectoSeguimiento
				inner join ProyectoDictamen pd on pd.IdProyectoDictamen = pds.IdProyectoDictamen 
				left join ProyectoDictamenEstado pde on pde.IdProyectoDictamenEstado = pd.IdProyectoDictamenEstadoUltimo
				left join Estado estdic on estdic.IdEstado = pde.IdEstado
				left join ProyectoCalificacion pcal on pcal.IdProyectoCalificacion = pd.IdProyectoCalificacion
		)
		INSERT INTO @retDictInversion 

-- Tomando la tabla temporal agrupa por IdProyecto

SELECT 
		ef1.IDProyecto
--		,Codigo
		,(
			SELECT
				Denominacion + '-' + Calificacion + '-' + convert(varchar(10),Fecha_Calif ,103) + '-' + Est_Inversion + ' / '
			FROM DictInversion_Det ef2
			WHERE ef2.idproyecto = ef1.idproyecto
			ORDER BY IDProyecto asc
			FOR XML PATH('')
         ) AS Denom_Inversion
         
         FROM DictInversion_Det ef1
	     GROUP BY ef1.Idproyecto
	     ORDER BY IDProyecto
RETURN
END


GO
/****** Object:  UserDefinedFunction [dbo].[fn_Cubo_ProyectoLocalidadDetallada]    Script Date: 02/15/2017 14:38:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[fn_Cubo_ProyectoLocalidadDetallada] ()
RETURNS @retProv  table (IdProyecto int primary key NOT NULL
						 ,Provincia varchar(max)
						 ,Cantidad int)

AS
BEGIN
declare
@IdProyecto int
,@Provincia varchar(50)
,@Provincia_ant varchar(50)
,@antIdProyecto  int
,@Provincias varchar(max)
,@cantidad int
--declare @retProv table (IdProyecto int primary key NOT NULL,Provincias varchar(200)) 

declare @auxProv table (IdProyecto int ,Provincias varchar(max)) 
 
--se carga en una tabla en memoria los resultados para el cursor
insert into @auxProv
select pl.idproyecto,pr.Nombre 
from ProyectoLocalizacion pl 
inner join ClasificacionGeografica cl on cl.IdClasificacionGeografica =pl.IdClasificacionGeografica
inner join  (select IdClasificacionGeografica ,cg.codigo, cg.Nombre
             from ClasificacionGeografica cg
             inner join ClasificacionGeograficaTipo ct on ct.IdClasificacionGeograficaTipo=cg.IdClasificacionGeograficaTipo
             where ct.nivel  = 1 ) pr    on CHARINDEX('.'+CONVERT(varchar,pr.IdClasificacionGeografica)+'.',cl.BreadcrumbId)>= 1
order by idproyecto,pr.codigo 
DECLARE cur CURSOR FOR (select * from @auxProv )
OPEN cur;

FETCH NEXT FROM cur INTO @IdProyecto,@Provincia
set @Provincias=''
set @cantidad=0
set @Provincia_ant = ''
IF @antIdProyecto is null set @antIdProyecto = @IdProyecto 
WHILE @@FETCH_STATUS = 0
   BEGIN
      WHILE @@FETCH_STATUS = 0 and @antIdProyecto = @IdProyecto 
		BEGIN
          IF @Provincia <> @Provincia_ant
          begin
            set @Provincias = @Provincias + ' / ' + replace(ltrim(@Provincia),'Provincia de','')
			set @cantidad = @cantidad + 1
		  end
	      
	      set @Provincia_ant = @Provincia
	      FETCH NEXT FROM cur INTO @IdProyecto,@Provincia

       END
 
       insert into @retProv values (@antIdProyecto,@Provincias,@Cantidad)
       set @antIdProyecto = @IdProyecto
       set @Provincia_ant = ''
       set @Provincias=''
       set @cantidad=0
   END
CLOSE cur
DEALLOCATE cur

RETURN 
END


GO


/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxT]    Script Date: 05/10/2018 18:14:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Genera_CxT] (@Year int = null)
AS

BEGIN

-- asigno el año actual si no se ingresa año como parametro
if (@Year < 1999 or @Year is null) set @Year = Year(getdate())

-- Obtiene las provincias-----------------------------------------------------------
declare @ttProvincias table
 (	IdProyecto int
	-- primary key NOT NULL
	, Provincia varchar(max)
	, Cantidad int)
insert into @ttProvincias
select distinct * from [fn_Cubo_ProyectoLocalidadDetallada]()

-- Obtiene los Montos Presupuestarios por Periodo Realizado --
IF OBJECT_ID('tempdb..#MontoPresupuestarioRealizado') IS NOT NULL DROP TABLE #MontoPresupuestarioRealizado

select distinct
p.IdProyecto
,MR_Acumulado_m5=sum(case when periodo< @Year-5 then montocalculado else 0 end) 
,MR_m5=sum(case when periodo=@Year-5  then montocalculado else 0 end)
,MR_m4=sum(case when periodo=@Year-4  then montocalculado else 0 end)
,MR_m3=sum(case when periodo=@Year-3  then montocalculado else 0 end)
,MR_m2=sum(case when periodo=@Year-2  then montocalculado else 0 end)
,MR_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end)
,MR=sum(case when periodo=@Year  then montocalculado else 0 end)
,MR_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,MR_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,MR_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,MR_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,MR_Total=sum(montocalculado)
,MR_CostoTotal_Year=sum(case when periodo < @Year then montocalculado else 0 end)

into #MontoPresupuestarioRealizado

from Proyecto p 
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
left join ProyectoEtapaRealizado per on per.IdProyectoEtapa = pe.IdProyectoEtapa
left join ProyectoEtapaRealizadoPeriodo perp on perp.IdProyectoEtapaRealizado = per.IdProyectoEtapaRealizado
where fa.IdFase = 2 -- Fase.Nombre = Ejecución' 
group by p.IdProyecto

-- Obtiene los Montos Presupuestarios Estimados por Periodo --
IF OBJECT_ID('tempdb..#MontoPresupuestarioEstimado') IS NOT NULL DROP TABLE #MontoPresupuestarioEstimado

select distinct
p.IdProyecto
,ME_Acumulado_m5=sum(case when periodo < @Year-5  then montocalculado else 0 end)
,ME_m5=sum(case when periodo=@Year-5 then montocalculado else 0 end)
,ME_m4=sum(case when periodo=@Year-4 then montocalculado else 0 end)
,ME_m3=sum(case when periodo=@Year-3 then montocalculado else 0 end) 
,ME_m2=sum(case when periodo=@Year-2 then montocalculado else 0 end) 
,ME_m1=sum(case when periodo=@Year-1 then montocalculado else 0 end) 
,ME=sum(case when periodo=@Year  then montocalculado else 0 end)
,ME_1=sum(case when periodo=@Year+1 then montocalculado else 0 end)
,ME_2=sum(case when periodo=@Year+2  then montocalculado else 0 end)
,ME_3=sum(case when periodo=@Year+3  then montocalculado else 0 end)
,ME_Acumulado_3=sum(case when periodo>@Year+3  then montocalculado else 0 end)
,ME_Total=sum(montocalculado)
,ME_CostoTotal_Year=sum(case when periodo > @Year-1 then montocalculado else 0 end)
into #MontoPresupuestarioEstimado
from Proyecto p 
inner join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
inner join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
inner join ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
where p.Activo = 1 and fa.IdFase = 2 -- Fase.Nombre = Ejecución' 
group by p.IdProyecto

-- Obtiene los Montos Presupuestarios por Periodo --
IF OBJECT_ID('tempdb..#MontoPresupuestario') IS NOT NULL DROP TABLE #MontoPresupuestario

select distinct
p.IdProyecto

,MI_Acumulado_m5=CONVERT(decimal(18,0),sum(case when periodo < @Year-5  then montoinicial else 0 end))
,MI_m5=sum(case when periodo=@Year-5 then CONVERT(decimal(18,0),montoinicial) else 0 end)
,MI_m4=CONVERT(decimal(18,0),sum(case when periodo=@Year-4 then montoinicial else 0 end))
,MI_m3=CONVERT(decimal(18,0),sum(case when periodo=@Year-3 then montoinicial else 0 end) )
,MI_m2=CONVERT(decimal(18,0),sum(case when periodo=@Year-2 then montoinicial else 0 end) )
,MI_m1=CONVERT(decimal(18,0),sum(case when periodo=@Year-1 then montoinicial else 0 end) )
,MI=CONVERT(decimal(18,0),sum(case when periodo=@Year  then montoinicial else 0 end))
,MI_1=CONVERT(decimal(18,0),sum(case when periodo=@Year+1 then montoinicial else 0 end))
,MI_2=CONVERT(decimal(18,0),sum(case when periodo=@Year+2  then montoinicial else 0 end))
,MI_3=CONVERT(decimal(18,0),sum(case when periodo=@Year+3  then montoinicial else 0 end))
,MI_Acumulado_3=CONVERT(decimal(18,0),sum(case when periodo>@Year+3  then montoinicial else 0 end))
,MI_Total=sum(montoinicial)
,MI_CostoTotal_Year=CONVERT(decimal(18,0),sum(case when periodo > @Year-1 then montoinicial else 0 end))
,MV_Acumulado_m5=CONVERT(decimal(18,0),sum(case when periodo < @Year-5  then montovigente else 0 end))
,MV_m5=CONVERT(decimal(18,0),sum(case when periodo=@Year-5 then montovigente else 0 end))
,MV_m4=CONVERT(decimal(18,0),sum(case when periodo=@Year-4 then montovigente else 0 end))
,MV_m3=CONVERT(decimal(18,0),sum(case when periodo=@Year-3 then montovigente else 0 end) )
,MV_m2=CONVERT(decimal(18,0),sum(case when periodo=@Year-2 then montovigente else 0 end) )
,MV_m1=CONVERT(decimal(18,0),sum(case when periodo=@Year-1 then montovigente else 0 end) )
,MV=CONVERT(decimal(18,0),sum(case when periodo=@Year  then montovigente else 0 end))
,MV_1=CONVERT(decimal(18,0),sum(case when periodo=@Year+1 then montovigente else 0 end))
,MV_2=CONVERT(decimal(18,0),sum(case when periodo=@Year+2  then montovigente else 0 end))
,MV_3=CONVERT(decimal(18,0),sum(case when periodo=@Year+3  then montovigente else 0 end))
,MV_Acumulado_3=CONVERT(decimal(18,0),sum(case when periodo>@Year+3  then montovigente else 0 end))
,MV_Total=CONVERT(decimal(18,0),sum(montovigente),0)
,MV_CostoTotal_Year=CONVERT(decimal(18,0),sum(case when periodo > @Year-1 then montovigente else 0 end))
,MVE_m5=case when sum(case when periodo=@Year-5 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_m4=case when sum(case when periodo=@Year-4 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_m3=case when sum(case when periodo=@Year-3 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_m2=case when sum(case when periodo=@Year-2 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_m1=case when sum(case when periodo=@Year-1 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE=case when sum(case when periodo=@Year then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_1=case when sum(case when periodo=@Year+1 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_2=case when sum(case when periodo=@Year+2 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MVE_3=case when sum(case when periodo=@Year+3 then MontoVigenteEstimativo else 0 end)>0 then 1 else 0 end
,MD_Acumulado_m5=CONVERT(decimal(18,0),sum(case when periodo < @Year-5  then montodevengado else 0 end))
,MD_m5=CONVERT(decimal(18,0),sum(case when periodo=@Year-5 then montodevengado else 0 end))
,MD_m4=CONVERT(decimal(18,0),sum(case when periodo=@Year-4 then montodevengado else 0 end))
,MD_m3=CONVERT(decimal(18,0),sum(case when periodo=@Year-3 then montodevengado else 0 end) )
,MD_m2=CONVERT(decimal(18,0),sum(case when periodo=@Year-2 then montodevengado else 0 end) )
,MD_m1=CONVERT(decimal(18,0),sum(case when periodo=@Year-1 then montodevengado else 0 end) )
,MD=CONVERT(decimal(18,0),sum(case when periodo=@Year  then montodevengado else 0 end))
,MD_1=CONVERT(decimal(18,0),sum(case when periodo=@Year+1 then montodevengado else 0 end))
,MD_2=CONVERT(decimal(18,0),CONVERT(decimal(18,0),sum(case when periodo=@Year+2  then montodevengado else 0 end)))
,MD_3=CONVERT(decimal(18,0),sum(case when periodo=@Year+3  then montodevengado else 0 end))
,MD_Acumulado_3=CONVERT(decimal(18,0),sum(case when periodo>@Year+3  then montodevengado else 0 end))
,MD_Total=CONVERT(decimal(18,0),sum(montodevengado),0)
,MD_CostoTotal_Year=CONVERT(decimal(18,0),sum(case when periodo > @Year-1 then montodevengado else 0 end))
into #MontoPresupuestario
from Proyecto p 
inner join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
inner join etapa et on et.IdEtapa = pe.IdEtapa
inner join Fase fa on et.IdFase = fa.IdFase
inner join ProyectoEtapaInformacionPresupuestaria pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
inner join ProyectoEtapaInformacionPresupuestariaPeriodo peep on peep.IdProyectoEtapaInformacionPresupuestaria = pee.IdProyectoEtapaInformacionPresupuestaria
where p.Activo = 1 and fa.IdFase = 2 -- Fase.Nombre = Ejecución' 
group by p.IdProyecto, peep.MontoVigenteEstimativo

--------------------------------------------------
-- Incisos -- reemplaza a fn_Cubo_Inciso_Group()
--------------------------------------------------
declare @incisosTable table
 (IdProyecto int primary key NOT NULL,
	codigo int,
	NroProyecto int,
	Incisos varchar (max))
IF OBJECT_ID('tempdb..#Inciso_Det') IS NOT NULL DROP TABLE #Inciso_Det

SELECT distinct pe.idproyecto, p.Codigo,
		p.nroproyecto,
		inciso = convert(int,substring(cg.BreadcrumbCode,2,2))
into #Inciso_Det
		from ProyectoEtapa pe
		inner join Proyecto p on p.IdProyecto=pe.IdProyecto
		inner join Etapa et on et.IdEtapa=pe.IdEtapa
		inner join ProyectoEtapaEstimado pee on pee.IdProyectoEtapa=pe.IdProyectoEtapa
		inner join ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
		where p.Activo = 1 and (et.Nombre = 'Obra' or et.Nombre = 'Actividad')

INSERT into @incisosTable 
SELECT p1.idproyecto, codigo, nroproyecto,
       ( SELECT convert(varchar,Inciso) + '' FROM #Inciso_Det p2
          WHERE p2.idproyecto = p1.idproyecto
         ORDER BY idproyecto, Inciso
         FOR XML PATH('') ) AS Incisos
         FROM #Inciso_Det p1
	     GROUP BY p1.Idproyecto, codigo, NroProyecto order by idproyecto

--------------------------------------------------
-- Fuente Financiamiento -- reemplaza a fn_Cubo_FuenteFinanciamiento_Group()
--------------------------------------------------
declare @FuenteFinanTable TABLE 
(
    IdProyecto int primary key NOT NULL
	,Bapin int
	,FuenteFinan varchar (max)
	,DescFuenteFinan varchar (max)
)
IF OBJECT_ID('tempdb..#FuenteFinanTable') IS NOT NULL DROP TABLE #FuenteFinanTable
		select distinct
		p.idproyecto													
		,p.Codigo														as bapin
		,substring(fufi.BreadcrumbCode,2,len(fufi.BreadcrumbCode)-2)	as FuenteFinan
		,fufi.Descripcion												as DescFuenteFinan
		into #FuenteFinanTable
		from ProyectoEtapaEstimado pee 
			inner join ProyectoEtapa pe on pe.IdProyectoEtapa = pee.IdProyectoEtapa
			inner join Etapa et on et.IdEtapa=pe.IdEtapa and et.IdFase=2 --fase ejecucion (corresponde a Etapa Obra o Actividad)
			inner join Proyecto p on p.IdProyecto = pe.IdProyecto
			inner join ProyectoEtapaEstimadoPeriodo peep on pee.IdProyectoEtapaEstimado=peep.IdProyectoEtapaEstimado
			inner join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento		
		where p.Activo = 1 and (et.Nombre = 'Obra' or et.Nombre = 'Actividad')

insert into @FuenteFinanTable
Select 
		ff1.idproyecto
		,Bapin
		,( Select
			FuenteFinan + ' ' from #FuenteFinanTable ff2
			where ff2.idproyecto = ff1.idproyecto
			Order by IDProyecto, FuenteFinan
			for xml path('')
		 )																as FuenteFinan
		,( Select
			DescFuenteFinan + ' - ' from #FuenteFinanTable ff2
			where ff2.idproyecto = ff1.idproyecto
			Order by IDProyecto, FuenteFinan
			for xml path('')
		 )																as DescFuenteFinan
         from #FuenteFinanTable ff1
	     group by ff1.IDProyecto, bapin
	     order by IDProyecto

--------------------------------------------------
-- Devengado -- reemplaza a fn_Cubo_ONPDevengado()
--------------------------------------------------
IF OBJECT_ID('tempdb..#onp_devengado') IS NOT NULL DROP TABLE #onp_devengado
select distinct
p.IdProyecto
,p.Codigo
,ONP=sum(case when EjercicioPresupuestario=@Year then Devengado else 0 end)
,ONP_1=sum(case when EjercicioPresupuestario=@Year+1 then Devengado else 0 end)
,ONP_2=sum(case when EjercicioPresupuestario=@Year+2 then devengado else 0 end)
,ONP_3=sum(case when EjercicioPresupuestario=@Year+3 then devengado else 0 end)
,ONP_4=sum(case when EjercicioPresupuestario=@Year+4 then devengado else 0 end)
,ONP_5=sum(case when EjercicioPresupuestario=@Year+5 then devengado else 0 end)
,ONP_6=sum(case when EjercicioPresupuestario=@Year+6 then devengado else 0 end)
,ONP_7=sum(case when EjercicioPresupuestario=@Year+7 then devengado else 0 end)
,ONP_8=sum(case when EjercicioPresupuestario=@Year+8 then devengado else 0 end)

into #onp_devengado

from Proyecto p
inner join Matching_ProyectosVinculados mpv on p.Codigo = mpv.CodigoProyectoBAPIN
where p.Activo = 1
group by p.idProyecto, p.Codigo

--------------------------------------------------
-- Fecha Inicio y Fin Estimada -- reemplaza a fn_Cubo_ONPDevengado()
--------------------------------------------------
IF OBJECT_ID('tempdb..#Fechas_Estimadas') IS NOT NULL DROP TABLE #Fechas_Estimadas
select 
p.IdProyecto ,
							case when pe.FechaInicioEstimada is null then '' else
							convert(varchar(10),pe.FechaInicioEstimada,103) end as FechaInicioEstimada,
							case when pe.FechaFinEstimada is null then '' else
							convert(varchar(10),pe.FechaFinEstimada,103) end as FechaFinEstimada

into #Fechas_Estimadas

					from Proyecto p
					left join ProyectoEtapa pe		on pe.IdProyecto = p.IdProyecto
					left join Etapa et				on et.IdEtapa = pe.IdEtapa
					left join Fase fa				on fa.IdFase = et.IdFase
					where	fa.IdFase = 2 /* Ejecucion */

--------------------------------------------------
-- Resultado del Cubo --
--------------------------------------------------

select distinct --top 1001
-- Nro de Bapin del proyecto y su Denominacion --
p.Codigo																								as [Nro_Bapin]
,isnull(p.ProyectoDenominacion,'')											as [Denominacion]				
-- Identifica si el proyecto esta cargado como borrador o no --
,case when p.EsBorrador=0 then 'N' else 'S' end					as [EsBorrador]
-- Tipo de Proyecto (Ampliacion,Reposiciones,Transferencias, Inversion Real Directa) --
,case when isnull(ptipo.Sigla,'') + '-' + isnull(ptipo.Nombre,'') = '-'
	then ''
	else ptipo.Sigla + '-' + ptipo.Nombre
 end																										as [Tipo]

-- Incisos afectados al proyecto --
,isnull(pid.Incisos,'0')													as [Incisos]

-- Codigo de Clasificacion Institucional (Sector.Tipo de administracion.Tipo de entidad.Jurisdiccion.Subjurisdiccion.000)
-- Tipo entidad en las tablas contiene el codigo de Sector.TipoAdministracion.TipoEntidad)
,isnull(etipo.Codigo,'00') + '.' + isnull(juris.Codigo,'00') + '.' +
 isnull(sjuris.Codigo,'00') + '.' + '000'								as [Clasif_Instit]
-- Datos de la Jurisdicccion a la que pertence el proyecto --
,isnull(juris.Codigo,'')																as [Jur_cod]
,isnull(juris.Nombre,'')																as [Jurisdicción]

-- Codigo de Apertura Programatica --
,isnull(saf.Codigo,'00')	+ '.' + isnull(prog.Codigo,'00') + '.' +
isnull(sprog.Codigo,'00')																as [Ape_Prog]
-- Detalle de la Apertura Programatica (SAF/Programa/Subprograma)
,isnull(saf.Codigo,'0')																	as [SAF_cod]
,isnull(saf.Denominacion,'')														as [SAF]
,isnull(prog.Codigo,'0')																as [Progr_cod]
,isnull(prog.Nombre,'')																	as [Programa]
,isnull(sprog.Codigo,'0')																as [Subprog_cod]
,isnull(sprog.Nombre,'')																as [Subprograma]


-- Apertura Presupuestaria (Proyecto/Actividad/Obra)
-- Se incorpora el item Tipo_Presupuestario, indicando:
-- "Proyecto" si es un proyecto (proyecto.esproyecto = 1)
-- "Actividad" si no es un proyecto (proyecto.esproyecto =0)
-- "No_especificado" en caso que no se haya asingado un valor a proyecto.esproyecto.

-- Codigo de Apertura Presupuestaria --
,isnull(ApePres.NroProyecto,'0') 
+ '.' + 
isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
		end,'0')
+ '.' +
isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
		end,'0')																							as [Ape_Presup]
 
-- Detalle de Apertura Presupuestaria

,isnull(ApePres.NroProyecto,'0')													as [NroProyecto]

,isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
			end,'0')																						as [NroActividad]

,isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
			end,'0')																						as [NroObra]

,isnull(case when CHARINDEX('/',Tipo_PresupAgrup) > 0
			then left(Tipo_PresupAgrup,charindex('/',Tipo_PresupAgrup)-1)
			else Tipo_PresupAgrup
			end,'0')																						as [Tipo_Presup]

-- Codigo de Apertura Presupuestaria Actividad Especifica --
--Si un proyecto tiene obra y actividad entonces en la columna se refleja
--la apertura presupuestaria de la actividad; en otro caso la columna tiene '-'
,isnull(case when	charindex('/',ApePres.nroactividadagrup) is null or 
					charindex('/',ApePres.nroactividadagrup,charindex('/',ApePres.nroactividadagrup)+1) = 0
			then '-'
			else
				ApePres.nroproyecto + '.' +
				substring(ApePres.nroactividadagrup,
						charindex('/',ApePres.nroactividadagrup)+1,
						LEN(ApePres.nroactividadagrup)-charindex('/',ApePres.nroactividadagrup)-1) + '.' +	
				substring(ApePres.nroobraagrup,
						charindex('/',ApePres.nroobraagrup,1)+1,
						LEN(ApePres.nroobraagrup)-charindex('/',ApePres.nroobraagrup)-1)
			end,'0')																						as [Ape_PresupActEsp]


-- Identifica si el area a la que pertence el proyecto es presupuestaria --
,isnull(otipo.Nombre,'')																	as [Es_Presup]

-- Estado Financiero del proyecto --
,isnull(case when len(pefinan.EstFinanciero) > 2
		then left (pefinan.EstFinanciero, len(pefinan.EstFinanciero)-2)
		else pefinan.EstFinanciero
		end,'')																								as [Estado_Financiero]

-- Estado Fisico del proyecto
,isnull(case when len(pefis.EstFisico) > 2
		then left (pefis.EstFisico, len(pefis.EstFisico)-2)
		else pefis.EstFisico
		end,'')																								as [Estado_Fisico]

--Estado de Decision
--Valores posibles de los estados son: postulado, conformado, aceptado, rechazado, reiniciado
--Se encuentran en la tabla : estadodedecision
,isnull(est_decision.Nombre,'')														as [Est_Decision]

-- Datos de Calidad del Proyecto
--,isnull(proce.Nombre,'')													as [Proceso_Calidad]


--PrioridadDNIP
-- Los Planes de Priodidad DNIP no necesariamente coinciden con los planes cargados en el proyecto de Inversion
-- Los Planes de Prioridad DNIP hay que ubicarlos en la pantalla de Invervencion DNIP
,isnull(upp.Periodo + '-' + upp.Prioridad,'')							as [PrioridadDNIP]
,case when upp.ReqArt15=0 then 'N' else 'S' end						as [Art_15]

--Gestion de Calidad (Administracion -> Calidad)
--Valores posibles de los estados son : Corregido, A corregir, Revisado, Terminado, Pendiente
--Se encuentran en la tabla : Estados
-- * VER AdministracionCalidad
,case when pcalid.ReqDictamen=0 then 'N' else 'S' end			as [Req_Dict]
,isnull(est_calid.nombre,'')												as [Estado_calidad]
,case when pcalid.FechaEstado is null then '' else
 convert(varchar(10),pcalid.FechaEstado,103) end					as [Fecha_Estado_Calidad]

 --Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
--Valores posibles de los estados de situacion son : Dictaminado, En espera de CT, En espera de informacion, Pendiente)
--Se encuentran en la tabla : Estados
-- * VER ProyectoSeguimiento
-- Deberia ser una funcion porque sin el distinct trae mas registros.
,isnull(case when len(pefa.Eval_Fact) > 2
		then left (pefa.Eval_Fact, len(pefa.Eval_Fact)-2)
		else pefa.Eval_Fact
		end,'')																								as [Eval_Factibilidad]

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
--Valores posibles de los estados de "Calificacion" son : Aprobado, Aprobado con observaciones, Desaprobado
-- Valores posibles de los estados son : En espera de DNIP, En espera de respuesta, En espera de SPE,
-- Migracion, Respondido, Terminado
--Se encuentran en la tabla : Estados
-- VER * ProyectoDictamen, ProyectoDictamenEstado (pueden ser varios)
,isnull(case when len(pdia.Dict_Inversion) > 2
		then left (pdia.Dict_Inversion, len(pdia.Dict_Inversion)-2)
		else pdia.Dict_Inversion
		end,'')																								as [Dict_Inversion] 

-- Prioridad asignada al proyecto --
,isnull(op.Nombre,'')																			as [PrioridadOrganismo]
-- + '-' + convert(varchar(5),isnull(p.SubPrioridad,0)) 

,isnull(cast(p.SubPrioridad as varchar(10)), '')					as [Subprioridad]

-- Provincias en las que interviene el proyecto --
,isnull(tp.cantidad,'0')																	as [Prov_Cantidad]

,isnull(case when len(tp.provincia) > 2
		then ltrim(right (tp.provincia, len(tp.provincia)-2))
		else ltrim(tp.provincia)
		end,'')																								as [Localizacion_Provincia]

-- Fechas de alta y modificacion del proyecto --
,case when p.FechaAlta is null then '' else
 convert(varchar(10),p.FechaAlta,103) end									as [Fecha_Alta]
,case when p.FechaModificacion is null then '' else
 convert(varchar(10),p.FechaModificacion,103) end					as [Fecha_UltModificacion]

-- Identificacion del Usuario que modifico el proyecto --
,isnull(pers.nombrecompleto,'')														as [Usuario_UltModificación]

-- Fechas de inicio y fin estimada para el proyecto
,fest.FechaInicioEstimada
,fest.FechaFinEstimada

-- Planes cargados en el proyecto --
,isnull(case when len(ppd.planes) > 2
		then left (ppd.planes, len(ppd.planes)-2)
		else ''
		end,'')																								as [Planes]

-- Ultimo plan cargado en el proyecto --
,isnull(case when 
		charindex('P',ppd.Planes) > 0
		then left(ppd.Planes,charindex('/',ppd.Planes)-1)
		else ''
		end,'')																								as [Ult_Plan]

-- Ultima demanda cargada en el proyecto --
,isnull(case when 
		charindex('D',ppd.Planes) > 0
		then 
		substring(ppd.Planes,charindex('D',ppd.Planes),charindex('/',ppd.Planes,charindex('D',ppd.Planes))-charindex('D',ppd.Planes))
		else ''
		end,'')																								as [Ult_Demanda]

-- Finalidad Funcion del proyecto
,case when isnull(ff.BreadcrumbCode,'') + '-' + isnull(ff.Descripcion,'') = '-'
		then ''
	else 
		case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
			else
				isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
		end
				+ '-' + isnull(ff.Descripcion,'') 
  end																											as [Finalidad_Función]
,case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
	else isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
 end																											as [Finalidad_Funcion_Cod]
,isnull(ff.Descripcion,'')																as [Finalidad_Función_Desc]

-- Fuente de Financiamiento --
,isnull(fufi.FuenteFinan,'')												as [Fuente_Finaciamiento_Cod]
,case when fufi.DescFuenteFinan is null then ''
else left(fufi.DescFuenteFinan,LEN(fufi.DescFuenteFinan)-2) end				as [Fuente_Financiamiento_Desc]

-- Proceso del Proyecto --
,isnull(pr.Nombre,'')																			as [Proceso]
-- Identificacion del sectorialista asignado al proyecto --
,isnull(sect.NombreCompleto,'')														as [Sectorialista]	
,isnull(ecto.ECTOes,'')																		as [Com_Tecnico_ECTO]
 

-- Datos de los montos estimados del propyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),mpres.ME_Acumulado_m5),0)						as [Estimados Anteriores]
,isnull(CONVERT(decimal(18,0),mpres.ME_m5),0)									as [Estimado 2013]
,isnull(CONVERT(decimal(18,0),mpres.ME_m4),0)									as [Estimado 2014]
,isnull(CONVERT(decimal(18,0),mpres.ME_m3),0)									as [Estimado 2015]
,isnull(CONVERT(decimal(18,0),mpres.ME_m2),0)									as [Estimado 2016]
,isnull(CONVERT(decimal(18,0),mpres.ME_m1),0)									as [Estimado 2017]	
,isnull(CONVERT(decimal(18,0),mpres.ME),0)										as [Estimado 2018]
,isnull(CONVERT(decimal(18,0),mpres.ME_1),0)									as [Estimado 2019]
,isnull(CONVERT(decimal(18,0),mpres.ME_2),0)									as [Estimado 2020]
,isnull(CONVERT(decimal(18,0),mpres.ME_3),0)									as [Estimado 2021]
,isnull(CONVERT(decimal(18,0),mpres.ME_Acumulado_3),0)							as [Estimado Posteriores]
,isnull(CONVERT(decimal(18,0),mpres.ME_Total),0)								as [Estimado Total]						

,isnull(CONVERT(decimal(18,0),mprr.MR_Acumulado_m5),0)							as [Realizados Anteriores]
,isnull(CONVERT(decimal(18,0),mprr.MR_m5),0)									as [Realizado 2013]
,isnull(CONVERT(decimal(18,0),mprr.MR_m4),0)									as [Realizado 2014]
,isnull(CONVERT(decimal(18,0),mprr.MR_m3),0)									as [Realizado 2015]
,isnull(CONVERT(decimal(18,0),mprr.MR_m2),0)									as [Realizado 2016]
,isnull(CONVERT(decimal(18,0),mprr.MR_m1),0)									as [Realizado 2017]
,isnull(CONVERT(decimal(18,0),mprr.MR),0)										as [Realizado 2018]
,isnull(CONVERT(decimal(18,0),mprr.MR_1),0)										as [Realizado 2019]
,isnull(CONVERT(decimal(18,0),mprr.MR_2),0)										as [Realizado 2020]
,isnull(CONVERT(decimal(18,0),mprr.MR_3),0)										as [Realizado 2021]
,isnull(CONVERT(decimal(18,0),mprr.MR_Acumulado_3),0)							as [Realizado Posteriores]
,isnull(CONVERT(decimal(18,0),mprr.MR_Total),0)									as [Realizado Total]

-- Costo total actual =
-- Montos Realizados Acumulados desde Year-1 hacia atras +
-- Montos Estimados Acumulados desde Year hacia adelante
,isnull(CONVERT(decimal(18,0),mpres.ME_CostoTotal_Year),0) +
 isnull(CONVERT(decimal(18,0),mprr.MR_CostoTotal_Year),0)						as [Costo Total Actual]

-- Informacion de ONP
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2003]),0)							as [ONP 2003]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2004]),0)							as [ONP 2004]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2005]),0)							as [ONP 2005]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2006]),0)							as [ONP 2006]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2007]),0)							as [ONP 2007]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2008]),0)							as [ONP 2008]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2009]),0)							as [ONP 2009]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2010]),0)							as [ONP 2010]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2011]),0)							as [ONP 2011]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2012]),0)							as [ONP 2012]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2013]),0)							as [ONP 2013]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2014]),0)							as [ONP 2014]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2015]),0)							as [ONP 2015]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2016]),0)							as [ONP 2016]
,isnull(CONVERT(decimal(18,0),onpd.[ONP]),0)								as [ONP 2017]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_1]),0)								as [ONP 2018]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_2]),0)								as [ONP 2019]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_3]),0)								as [ONP 2020]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_4]),0)								as [ONP 2021]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_5]),0)								as [ONP 2022]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_6]),0)								as [ONP 2023]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_7]),0)								as [ONP 2024]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_8]),0)								as [ONP 2025]

-- Datos de los montos iniciales del proyecto, de acuerdo al año ingresado como parametro --
,mpre.MI_Acumulado_m5					as [MontoInicial Anteriores]
,mpre.MI_m5							as [MontoInicial 2013]
,mpre.MI_m4							as [MontoInicial 2014]
,mpre.MI_m3							as [MontoInicial 2015]
,mpre.MI_m2							as [MontoInicial 2016]
,mpre.MI_m1							as [MontoInicial 2017]	
,mpre.MI							as [MontoInicial 2018]
,mpre.MI_1							as [MontoInicial 2019]
,mpre.MI_2							as [MontoInicial 2020]
,mpre.MI_3							as [MontoInicial 2021]
,mpre.MI_Acumulado_3				as [MontoInicial Posteriores]
,mpre.MI_Total						as [MontoInicial Total]	
-- Datos de los montos vigentes del proyecto, de acuerdo al año ingresado como parametro --
,mpre.MV_Acumulado_m5				as [MontoVigente Anteriores]
,mpre.MV_m5							as [MontoVigente 2013]
,mpre.MV_m4							as [MontoVigente 2014]
,mpre.MV_m3							as [MontoVigente 2015]
,mpre.MV_m2							as [MontoVigente 2016]
,mpre.MV_m1							as [MontoVigente 2017]	
,mpre.MV							as [MontoVigente 2018]
,mpre.MV_1							as [MontoVigente 2019]
,mpre.MV_2							as [MontoVigente 2020]
,mpre.MV_3							as [MontoVigente 2021]
,mpre.MV_Acumulado_3				as [MontoVigente Posteriores]
,mpre.MV_Total						as [MontoVigente Total]	

-- Datos de los montos vigentes estimativos del proyecto, de acuerdo al año ingresado como parametro --
,isnull(mpre.MVE_m5,0)							as [MontoVigenteEstimativo 2013]
,isnull(mpre.MVE_m4,0)							as [MontoVigenteEstimativo 2014]
,isnull(mpre.MVE_m3,0)							as [MontoVigenteEstimativo 2015]
,isnull(mpre.MVE_m2,0)							as [MontoVigenteEstimativo 2016]
,isnull(mpre.MVE_m1,0)							as [MontoVigenteEstimativo 2017]	
,isnull(mpre.MVE,0)								as [MontoVigenteEstimativo 2018]
,isnull(mpre.MVE_1,0)							as [MontoVigenteEstimativo 2019]
,isnull(mpre.MVE_2,0)							as [MontoVigenteEstimativo 2020]
,isnull(mpre.MVE_3,0)							as [MontoVigenteEstimativo 2021]

-- Datos de los montos devengados del proyecto, de acuerdo al año ingresado como parametro --
,mpre.MD_Acumulado_m5			as [MontoDevengado Anteriores]
,mpre.MD_m5						as [MontoDevengado 2013]
,mpre.MD_m4						as [MontoDevengado 2014]
,mpre.MD_m3						as [MontoDevengado 2015]
,mpre.MD_m2						as [MontoDevengado 2016]
,mpre.MD_m1						as [MontoDevengado 2017]	
,mpre.MD						as [MontoDevengado 2018]
,mpre.MD_1						as [MontoDevengado 2019]
,mpre.MD_2						as [MontoDevengado 2020]
,mpre.MD_3						as [MontoDevengado 2021]
,mpre.MD_Acumulado_3			as [MontoDevengado Posteriores]
,mpre.MD_Total					as [MontoDevengado Total]	


-- Fecha y hora de generacion del cubo --
,CONVERT(VARCHAR(10), GETDATE(), 103) + ' ' +
 CONVERT(VARCHAR(10), GETDATE(), 108)										as [Generado]

FROM Proyecto p
inner join ProyectoTipo ptipo on ptipo.IdProyectoTipo = p.IdTipoProyecto

-- Datos para la Clasificacion Institucional
inner join SubPrograma sprog on sprog.IdSubPrograma=p.IdSubPrograma
inner join Programa prog on prog.IdPrograma=sprog.IdPrograma
-- Usuario que modifica el proyecto
inner join persona pers on pers.Idpersona=p.IdUsuarioModificacion
inner join Saf on Saf.IdSaf=prog.idsaf
-- Tipo de organismo
inner join OrganismoTipo otipo on otipo.IdOrganismoTipo=Saf.IdTipoOrganismo
inner join Jurisdiccion juris on Juris.IdJurisdiccion=Saf.IdJurisdiccion
left join EntidadTipo etipo on etipo.IdEntidadTipo=saf.IdEntidadTipo
left join SubJurisdiccion sjuris on sjuris.IdSubJuridiccion=saf.IdSubJurisdiccion

left join EstadoDeDesicion est_decision on est_decision.IdEstadoDeDesicion = p.IdEstadoDeDesicion
left join Proceso pr on pr.IdProceso = p.IdProceso

-- Sectorialista asignado a un programa
left join persona sect on sect.Idpersona=prog.IdSectorialista

-- Prioridad asignada por el organismo
left join OrganismoPrioridad op on op.IdOrganismoPrioridad=p.IdOrganismoPrioridad

--Gestion de Calidad (Administracion -> Calidad)
left join ProyectoCalidad pcalid on pcalid.IdProyecto = p.IdProyecto
left join Estado est_calid on est_calid.IdEstado = pcalid.IdEstado

left join FinalidadFuncion ff on ff.IdFinalidadFuncion=p.IdFinalidadFuncion

left join ProyectoPlan pp on pp.IdProyectoPlan=p.IdProyectoPlan
left join PlanPeriodo ppt on ppt.IdPlanPeriodo=pp.IdPlanPeriodo		/*ex inner*/
left join PlanVersion ppv on ppv.IdPlanVersion=pp.IdPlanVersion		/*ex inner*/
left join PlanTipo pt on pt.IdPlanTipo=ppt.IdPlanTipo				/*ex inner*/

-- Agrego los valores de los montos estimados y realizados
left join #MontoPresupuestario mpre on mpre.IdProyecto = p.IdProyecto
left join #MontoPresupuestarioEstimado mpres on mpres.IdProyecto = p.IdProyecto
left join #MontoPresupuestarioRealizado mprr on mprr.IdProyecto = p.IdProyecto

-- Estado Financiero, Estado Fisico y Estado de Decision
left join fn_Cubo_EstadoFinanciero_Group () pefinan on pefinan.IdProyecto = p.IdProyecto
left join fn_Cubo_EstadoFisico_Group () pefis on pefis.idproyecto = p.IdProyecto

--Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
left join fn_Cubo_EvaluacionFactibilidad_Group () pefa on pefa.IdProyecto = p.IdProyecto

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
left join fn_Cubo_DictamenInversion_Group () pdia on pdia.IdProyecto = p.IdProyecto

left join fn_Cubo_UltimoPlanPrioridad () upp on upp.IdProyecto=p.IdProyecto

left join fn_Cubo_Plan_Group () ppd on ppd.idproyecto=p.IdProyecto

 /* REEMPLAZADO POR USO DE TABLAS TEMPORALES
left join fn_Cubo_Inciso_Group () pid on pid.IdProyecto=p.IdProyecto --> TARDA MUCHO */
left join @incisosTable pid on pid.IdProyecto=p.IdProyecto

-- MEJORABLE ???
left join fn_Cubo_AperturaPresupuestaria_Group () ApePres on ApePres.IdProyecto = p.IdProyecto

/* REEMPLAZADO POR USO DE TABLAS TEMPORALES
left join fn_Cubo_FuenteFinanciamiento_Group () FuFi on FuFi.idProyecto = p.IdProyecto*/
left join @FuenteFinanTable FuFi on FuFi.idProyecto = p.IdProyecto

left join fn_Cubo_ECTO_Group () ecto on ecto.idProyecto = p.IdProyecto

left join @ttProvincias tp on tp.idproyecto=p.IdProyecto

--Incorporo informacion de ONP hasta el año 2016 a partir de la importacion del ultimo CuboxTotal del Bapin II
left join Cubo_ImportCxTBapin2 CxT on CxT.Nro_Bapin = p.Codigo

--Incorporo informacion de ONP a partir de los proyectos vinculados por matching (tabla Matching_ProyectosVinculados)
/* REEMPLAZADO POR USO DE TABLAS TEMPORALES
left join fn_Cubo_ONPDevengado(@Year) onpd on onpd.IdProyecto = p.IdProyecto --> TARDA MUCHO */
left join #onp_devengado onpd on onpd.IdProyecto = p.IdProyecto

left join #Fechas_Estimadas fest on fest.IdProyecto = p.IdProyecto

where p.Activo = 1 /*Solo Proyectos activos*/

END

GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxT]    Script Date: 11/28/2016 20:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Inicia_CxT]
AS
BEGIN

DECLARE	@return_value int

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxT]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxT]

CREATE TABLE [dbo].[Cubo_CxT](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Incisos] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar] (max) NULL,
	[SAF] [varchar](max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [varchar] (max) NULL,
	[NroActividad] [varchar] (max) NULL,
	[NroObra] [varchar] (max) NULL,
	[Tipo_Presup] [varchar](max) NULL,
	[Ape_PresupActEsp] [varchar] (max) NULL,
	[Es_Presup] [varchar](max) NULL,
	[Estado_Financiero] [varchar](max) NULL,
	[Estado_Fisico] [varchar](max) NULL,
	[Est_Decision] [varchar](max) NULL,
	[PrioridadDNIP] [varchar](max) NULL,
	[Art_15] [varchar] (max) NULL,
	[Req_Dict] [varchar] (max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar] (max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar] (max) NULL,
	[Fecha_UltModificacion] [varchar] (max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar] (max) NULL,
	[Fecha_Fin_Estimada] [varchar] (max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,
	[Finalidad_Función] [varchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Fuente_Finaciamiento_Cod] [varchar](max) NULL,
	[Fuente_Financiamiento_Desc] [varchar](max) NULL,
	[Proceso] [varchar](max) NULL,
	[Sectorialista] [varchar](max) NULL,
	[Com_Tecnico_ECTO] [varchar](max) NULL,
	[Estimados Anteriores] [decimal] (18,0) NULL,
	[Estimado 2013] [decimal] (18,0) NULL,
	[Estimado 2014] [decimal] (18,0) NULL,
	[Estimado 2015] [decimal] (18,0) NULL,
	[Estimado 2016] [decimal] (18,0) NULL,
	[Estimado 2017] [decimal] (18,0) NULL,
	[Estimado 2018] [decimal] (18,0) NULL,
	[Estimado 2019] [decimal] (18,0) NULL,
	[Estimado 2020] [decimal] (18,0) NULL,
	[Estimado 2021] [decimal] (18,0) NULL,
	[Estimado Posteriores] [decimal] (18,0) NULL,
	[Estimado Total] [decimal] (18,0) NULL,
	[Realizados Anteriores] [decimal] (18,0) NULL,
	[Realizado 2013] [decimal] (18,0) NULL,
	[Realizado 2014] [decimal] (18,0) NULL,
	[Realizado 2015] [decimal] (18,0) NULL,
	[Realizado 2016] [decimal] (18,0) NULL,
	[Realizado 2017] [decimal] (18,0) NULL,
	[Realizado 2018] [decimal] (18,0) NULL,
	[Realizado 2019] [decimal] (18,0) NULL,
	[Realizado 2020] [decimal] (18,0) NULL,
	[Realizado 2021] [decimal] (18,0) NULL,
	[Realizado Posteriores] [decimal] (18,0) NULL,
	[Realizado Total] [decimal] (18,0) NULL,
	[Costo Total Actual] [decimal] (18,0) NULL,
	[ONP 2003] [decimal] (18,0) NULL,
	[ONP 2004] [decimal] (18,0) NULL,
	[ONP 2005] [decimal] (18,0) NULL,
	[ONP 2006] [decimal] (18,0) NULL,
	[ONP 2007] [decimal] (18,0) NULL,
	[ONP 2008] [decimal] (18,0) NULL,
	[ONP 2009] [decimal] (18,0) NULL,
	[ONP 2010] [decimal] (18,0) NULL,
	[ONP 2011] [decimal] (18,0) NULL,
	[ONP 2012] [decimal] (18,0) NULL,
	[ONP 2013] [decimal] (18,0) NULL,
	[ONP 2014] [decimal] (18,0) NULL,
	[ONP 2015] [decimal] (18,0) NULL,
	[ONP 2016] [decimal] (18,0) NULL,
	[ONP 2017] [decimal] (18,0) NULL,
	[ONP 2018] [decimal] (18,0) NULL,
	[ONP 2019] [decimal] (18,0) NULL,
	[ONP 2020] [decimal] (18,0) NULL,
	[ONP 2021] [decimal] (18,0) NULL,
	[ONP 2022] [decimal] (18,0) NULL,
	[ONP 2023] [decimal] (18,0) NULL,
	[ONP 2024] [decimal] (18,0) NULL,
	[ONP 2025] [decimal] (18,0) NULL,
	[MontoInicial Anteriores] [decimal] (18,0) NULL,
	[MontoInicial 2013] [decimal] (18,0) NULL,
	[MontoInicial 2014] [decimal] (18,0) NULL,
	[MontoInicial 2015] [decimal] (18,0) NULL,
	[MontoInicial 2016] [decimal] (18,0) NULL,
	[MontoInicial 2017] [decimal] (18,0) NULL,
	[MontoInicial 2018] [decimal] (18,0) NULL,
	[MontoInicial 2019] [decimal] (18,0) NULL,
	[MontoInicial 2020] [decimal] (18,0) NULL,
	[MontoInicial 2021] [decimal] (18,0) NULL,
	[MontoInicial Posteriores] [decimal] (18,0) NULL,
	[MontoInicial Total] [decimal] (18,0) NULL,
	[MontoVigente Anteriores] [decimal] (18,0) NULL,
	[MontoVigente 2013] [decimal] (18,0) NULL,
	[MontoVigente 2014] [decimal] (18,0) NULL,
	[MontoVigente 2015] [decimal] (18,0) NULL,
	[MontoVigente 2016] [decimal] (18,0) NULL,
	[MontoVigente 2017] [decimal] (18,0) NULL,
	[MontoVigente 2018] [decimal] (18,0) NULL,
	[MontoVigente 2019] [decimal] (18,0) NULL,
	[MontoVigente 2020] [decimal] (18,0) NULL,
	[MontoVigente 2021] [decimal] (18,0) NULL,
	[MontoVigente Posteriores] [decimal] (18,0) NULL,
	[MontoVigente Total] [decimal] (18,0) NULL,
	[MontoVigenteEstimativo 2013] bit NULL,
	[MontoVigenteEstimativo 2014] bit NULL,
	[MontoVigenteEstimativo 2015] bit NULL,
	[MontoVigenteEstimativo 2016] bit NULL,
	[MontoVigenteEstimativo 2017] bit NULL,
	[MontoVigenteEstimativo 2018] bit NULL,
	[MontoVigenteEstimativo 2019] bit NULL,
	[MontoVigenteEstimativo 2020] bit NULL,
	[MontoVigenteEstimativo 2021] bit NULL,
	[MontoDevengado Anteriores] [decimal] (18,0) NULL,
	[MontoDevengado 2013] [decimal] (18,0) NULL,
	[MontoDevengado 2014] [decimal] (18,0) NULL,
	[MontoDevengado 2015] [decimal] (18,0) NULL,
	[MontoDevengado 2016] [decimal] (18,0) NULL,
	[MontoDevengado 2017] [decimal] (18,0) NULL,
	[MontoDevengado 2018] [decimal] (18,0) NULL,
	[MontoDevengado 2019] [decimal] (18,0) NULL,
	[MontoDevengado 2020] [decimal] (18,0) NULL,
	[MontoDevengado 2021] [decimal] (18,0) NULL,
	[MontoDevengado Posteriores] [decimal] (18,0) NULL,
	[MontoDevengado Total] [decimal] (18,0) NULL,
	[Generado] [varchar] (max) NULL
) ON [FG] TEXTIMAGE_ON [FG]

INSERT INTO [dbo].[Cubo_CxT] 
EXEC	@return_value = [dbo].[sp_Cubo_Genera_CxT]
SET ANSI_PADDING OFF
END


GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Genera_CxO]    Script Date: 04/21/2017 15:29:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Genera_CxO] (@Year int = null)
AS

--set @Year = Year(Getdate())
--,@textoaux varchar

BEGIN

-- asigno el año actual si no se ingresa año como parametro
if (@Year < 1999 or @Year is null) set @Year = Year(getdate())

-- Obtengo todos los proyectos del Programa
--select p.*
--into #Proyecto
--from Proyecto p

-- Obtiene las provincias-----------------------------------------------------------
declare @ttProvincias table (IdProyecto int
-- primary key NOT NULL
,Provincia varchar(max), Cantidad int)
insert into @ttProvincias
select distinct * from [fn_Cubo_ProyectoLocalidadDetallada]()

--------------------------------------------------
-- Fecha Inicio y Fin Estimada -- reemplaza a fn_Cubo_ONPDevengado()
--------------------------------------------------
IF OBJECT_ID('tempdb..#Fechas_Estimadas_CxO') IS NOT NULL DROP TABLE #Fechas_Estimadas_CxO
select 
p.IdProyecto ,
							case when pe.FechaInicioEstimada is null then '' else
							convert(varchar(10),pe.FechaInicioEstimada,103) end as FechaInicioEstimada,
							case when pe.FechaFinEstimada is null then '' else
							convert(varchar(10),pe.FechaFinEstimada,103) end as FechaFinEstimada

into #Fechas_Estimadas_CxO

					from Proyecto p
					left join ProyectoEtapa pe		on pe.IdProyecto = p.IdProyecto
					left join Etapa et				on et.IdEtapa = pe.IdEtapa
					left join Fase fa				on fa.IdFase = et.IdFase
					where	fa.IdFase = 2 /* Ejecucion */

--------------------------------------------------
-- Resultado del Cubo --
--------------------------------------------------

select --top 10
distinct

-- Nro de Bapin del proyecto y su Denominacion --
p.Codigo																	as [Nro_Bapin]
,isnull(p.ProyectoDenominacion,'')											as [Denominacion]				

-- Identifica si el proyecto esta cargado como borrador o no --
,case when p.EsBorrador=0 then 'N' else 'S' end								as [EsBorrador]

-- Tipo de Proyecto (Ampliacion,Reposiciones,Transferencias, Inversion Real Directa) --
,case when ISNULL(ptipo.Sigla,'') + '-' + ISNULL(ptipo.Nombre,'') = '-'
	then ''
	else ptipo.Sigla + '-' + ptipo.Nombre
 end																		as [Tipo]

-- Inciso al que pertenece el gasto --
,isnull(unpre.Inciso,'0')													as [Inciso]

-- Codigo de Clasificacion Institucional (Sector.Tipo de administracion.Tipo de entidad.Jurisdiccion.Subjurisdiccion.000)
-- Tipo entidad en las tablas contiene el codigo de Sector.TipoAdministracion.TipoEntidad)
,isnull(etipo.Codigo,'00') + '.' + isnull(juris.Codigo,'00') + '.' +
isnull(sjuris.Codigo,'00') + '.' + '000'									as [Clasif_Instit]

-- Datos de la Jurisdicccion a la que pertence el proyecto --
,isnull(juris.Codigo,'')													as [Jur_cod]
,isnull(juris.Nombre,'')													as [Jurisdicción]

-- Codigo de Apertura Programatica --
,isnull(saf.Codigo,'0')	+ '.' + isnull(prog.Codigo,'0') + '.' +
isnull(sprog.Codigo,'0')													as [Ape_Prog]
-- Detalle de la Apertura Programatica (SAF/Programa/Subprograma)
,isnull(saf.Codigo,'0')														as [SAF_cod]
,isnull(saf.Denominacion,'')												as [SAF]
,isnull(prog.Codigo,'0')													as [Progr_cod]
,isnull(prog.Nombre,'')														as [Programa]
,isnull(sprog.Codigo,'0')													as [Subprog_cod]
,isnull(sprog.Nombre,'')													as [Subprograma]

-- Apertura Presupuestaria (Proyecto/Actividad/Obra)
-- Se incorpora el item Tipo_Presupuestario, indicando:
-- "Proyecto" si es un proyecto (proyecto.esproyecto = 1)
-- "Actividad" si no es un proyecto (proyecto.esproyecto =0)
-- "No_especificado" en caso que no se haya asingado un valor a proyecto.esproyecto.

-- Codigo de Apertura Presupuestaria --
,isnull(ApePres.NroProyecto,'0') 
+ '.' + 
isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
		end,'0')
+ '.' +
isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
		end,'0')															as [Ape_Presup]
 
-- Detalle de Apertura Presupuestaria

,isnull(ApePres.NroProyecto,'0')											as [NroProyecto]

,isnull(case when CHARINDEX('/',NroActividadAgrup) > 0
			then left(NroActividadAgrup,charindex('/',NroActividadAgrup)-1)
			else NroActividadAgrup
			end,'0')														as [NroActividad]

,isnull(case when CHARINDEX('/',NroObraAgrup) > 0
			then left(NroObraAgrup,charindex('/',NroObraAgrup)-1)
			else NroObraAgrup
			end,'0')														as [NroObra]

,isnull(case when CHARINDEX('/',Tipo_PresupAgrup) > 0
			then left(Tipo_PresupAgrup,charindex('/',Tipo_PresupAgrup)-1)
			else Tipo_PresupAgrup
			end,'0')														as [Tipo_Presup]

-- Codigo de Apertura Presupuestaria Actividad Especifica --
--Si un proyecto tiene obra y actividad entonces en la columna se refleja
--la apertura presupuestaria de la actividad; en otro caso la columna tiene '-'
,isnull(case when	charindex('/',ApePres.nroactividadagrup) is null or 
					charindex('/',ApePres.nroactividadagrup,charindex('/',ApePres.nroactividadagrup)+1) = 0
			then '-'
			else
				ApePres.nroproyecto + '.' +
				substring(ApePres.nroactividadagrup,
						charindex('/',ApePres.nroactividadagrup)+1,
						LEN(ApePres.nroactividadagrup)-charindex('/',ApePres.nroactividadagrup)-1) + '.' +	
				substring(ApePres.nroobraagrup,
						charindex('/',ApePres.nroobraagrup,1)+1,
						LEN(ApePres.nroobraagrup)-charindex('/',ApePres.nroobraagrup)-1)
			end,'0')														as [Ape_PresupActEsp]
	
-- Identifica si el area a la que pertence el proyecto es presupuestaria --
,isnull(otipo.Nombre,'')													as [Es_Presup]

-- Estado Financiero del proyecto --
,isnull(case when len(pefinan.EstFinanciero) > 2
		then left (pefinan.EstFinanciero, len(pefinan.EstFinanciero)-2)
		else pefinan.EstFinanciero
		end,'')																as [Estado_Financiero]

-- Estado Fisico del proyecto
,isnull(case when len(pefis.EstFisico) > 2
		then left (pefis.EstFisico, len(pefis.EstFisico)-2)
		else pefis.EstFisico
		end,'')																as [Estado_Fisico]
		
-- Estado de Decision
-- Valores posibles de los estados son: postulado, conformado, aceptado, rechazado, reiniciado
-- Se encuentran en la tabla : estadodedecision
,isnull(est_decision.Nombre,'')												as [Est_Decision]

-- Datos de Calidad del Proyecto
--,isnull(proce.Nombre,'')													as [Proceso_Calidad]

-- PrioridadDNIP
-- Los Planes de Priodidad DNIP no necesariamente coinciden con los planes cargados en el proyecto de Inversion
-- Los Planes de Prioridad DNIP hay que ubicarlos en la pantalla de Intervencion DNIP
,isnull(upp.Periodo + '-' + upp.Prioridad,'')								as [PrioridadDNIP]
,case when upp.ReqArt15=0 then 'N' else 'S' end								as [Art_15]

-- Gestion de Calidad (Administracion -> Calidad)
-- Valores posibles de los estados son : Corregido, A corregir, Revisado, Terminado, Pendiente
-- Se encuentran en la tabla : Estados
-- * VER AdministracionCalidad
,case when pcalid.ReqDictamen=0 then 'N' else 'S' end						as [Req_Dict]
,isnull(est_calid.nombre,'')												as [Estado_calidad]
,case when pcalid.FechaEstado is null then '' else
 convert(varchar(10),pcalid.FechaEstado,103) end							as [Fecha_Estado_Calidad]
 
-- Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
-- Valores posibles de los estados de situacion son : Dictaminado, En espera de CT, En espera de informacion, Pendiente)
-- Se encuentran en la tabla : Estados
-- * VER ProyectoSeguimiento
,isnull(case when len(pefa.Eval_Fact) > 2
		then left (pefa.Eval_Fact, len(pefa.Eval_Fact)-2)
		else pefa.Eval_Fact
		end,'')																as [Eval_Factibilidad]

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
-- Valores posibles de los estados de "Calificacion" son : Aprobado, Aprobado con observaciones, Desaprobado
-- Valores posibles de los estados son : En espera de DNIP, En espera de respuesta, En espera de SPE,
-- Migracion, Respondido, Terminado
-- Se encuentran en la tabla : Estados
-- VER * ProyectoDictamen, ProyectoDictamenEstado
,isnull(case when len(pdia.Dict_Inversion) > 2
		then left (pdia.Dict_Inversion, len(pdia.Dict_Inversion)-2)
		else pdia.Dict_Inversion
		end,'')																as [Dict_Inversion] 
 
-- Prioridad asignada al proyecto --
,isnull(op.Nombre,'')														as [PrioridadOrganismo]
-- + '-' + convert(varchar(5),isnull(p.SubPrioridad,0)) 

,isnull(cast(p.SubPrioridad as varchar(10)), '')							as [Subprioridad]

-- Provincias en las que interviene el proyecto --
,isnull(tp.cantidad,'0')													as [Prov_Cantidad]
,isnull(case when len(tp.provincia) > 2
		then ltrim(right (tp.provincia, len(tp.provincia)-2))
		else ltrim(tp.provincia)
		end,'')																as [Localizacion_Provincia]

-- Fechas de alta y modificacion del proyecto --
,case when p.FechaAlta is null then '' else
 convert(varchar(10),p.FechaAlta,103) end									as [Fecha_Alta]
,case when p.FechaModificacion is null then '' else
 convert(varchar(10),p.FechaModificacion,103) end							as [Fecha_UltModificacion]

-- Identificacion del Usuario que modifico el proyecto --
,isnull(pers.nombrecompleto,'')												as [Usuario_UltModificación]

-- Fechas de inicio y fin estimada para el proyecto
/*,case when pe.FechaInicioEstimada is null then '' else
 convert(varchar(10),pe.FechaInicioEstimada,103) end						as [Fecha_Inicio_Estimada]*/
--,isnull(dbo.fn_Cubo_Fecha_Inicio_Estimada(p.IdProyecto), '')				as [Fecha_Inicio_Estimada]
,fest.FechaInicioEstimada as [Fecha_Inicio_Estimada]

/*,case when pe.FechaFinEstimada is null then '' else
 convert(varchar(10),pe.FechaFinEstimada,103) end							as [Fecha_Fin_Estimada]*/
--,isnull(dbo.fn_Cubo_Fecha_Fin_Estimada(p.IdProyecto), '')					as [Fecha_Fin_Estimada]
,fest.FechaFinEstimada as [Fecha_Fin_Estimada]

-- Planes cargados en el proyecto --
,isnull(case when len(ppd.planes) > 2
		then left (ppd.planes, len(ppd.planes)-2)
		else ''
		end,'')																as [Planes]

-- Ultimo plan cargado en el proyecto --
,isnull(case when 
		charindex('P',ppd.Planes) > 0
		then left(ppd.Planes,charindex('/',ppd.Planes)-1)
		else ''
		end,'')																as [Ult_Plan]

-- Ultima demanda cargada en el proyecto --
,isnull(case when 
		charindex('D',ppd.Planes) > 0
		then 
		substring(ppd.Planes,charindex('D',ppd.Planes),charindex('/',ppd.Planes,charindex('D',ppd.Planes))-charindex('D',ppd.Planes))
		else ''
		end,'')																as [Ult_Demanda]

-- Finalidad Funcion del proyecto
,case when isnull(ff.BreadcrumbCode,'') + '-' + isnull(ff.Descripcion,'') = '-'
		then ''
	else 
		case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
			else
				isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
		end
				+ '-' + isnull(ff.Descripcion,'') 
  end																		as [Finalidad_Función]
,case when len(ff.BreadcrumbCode)<5 then isnull(ff.BreadcrumbCode,'')
	else isnull(substring(ff.BreadcrumbCode,2,LEN(ff.BreadcrumbCode)-2),'')
 end																		as [Finalidad_Funcion_Cod]
,isnull(ff.Descripcion,'')													as [Finalidad_Función_Desc]

-- Objeto del Gasto o Clasificacion del Gasto
-- Inciso/Partida_Principal/Partida_Parcial/Partida SubParcial
,isnull(unpre.Objeto_Gasto_Cod,'')											as [Objeto_Gasto_Cod]
,isnull(unpre.Objeto_Gasto_Desc,'')											as [Objeto_Gasto_Desc]

-- Fuente de Financiamiento --
,isnull(unpre.Fuente_Financiamiento_Cod,'')									as [Fuente_Financiamiento_Cod]
,isnull(unpre.Fuente_Financiamiento_Desc,'')								as [Fuente_Financiamiento_Desc]

-- Proceso del Proyecto --
,isnull(pr.Nombre,'')														as [Proceso]

-- Identificacion del sectorialista asignado al proyecto --
,isnull(sect.NombreCompleto,'')												as [Sectorialista]	

-- Identificacion del Comentario Tecnico del proyecto --
,isnull(ecto.ECTOes,'')														as [Com_Tecnico_ECTO]	

-- Datos de los montos estimados del propyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.ME_Acumulado_m5),0)						as [Estimados Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.ME_m5),0)								as [Estimado 2013]
,isnull(CONVERT(decimal(18,0),unpre.ME_m4),0)								as [Estimado 2014]
,isnull(CONVERT(decimal(18,0),unpre.ME_m3),0)								as [Estimado 2015]
,isnull(CONVERT(decimal(18,0),unpre.ME_m2),0)								as [Estimado 2016]
,isnull(CONVERT(decimal(18,0),unpre.ME_m1),0)								as [Estimado 2017]	
,isnull(CONVERT(decimal(18,0),unpre.ME),0)									as [Estimado 2018]
,isnull(CONVERT(decimal(18,0),unpre.ME_1),0)								as [Estimado 2019]
,isnull(CONVERT(decimal(18,0),unpre.ME_2),0)								as [Estimado 2020]
,isnull(CONVERT(decimal(18,0),unpre.ME_3),0)								as [Estimado 2021]
,isnull(CONVERT(decimal(18,0),unpre.ME_Acumulado_3),0)						as [Estimado Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.ME_Total),0)							as [Estimado Total]						

,isnull(CONVERT(decimal(18,0),unpre.MR_Acumulado_m5),0)						as [Realizados Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MR_m5),0)								as [Realizado 2013]
,isnull(CONVERT(decimal(18,0),unpre.MR_m4),0)								as [Realizado 2014]
,isnull(CONVERT(decimal(18,0),unpre.MR_m3),0)								as [Realizado 2015]
,isnull(CONVERT(decimal(18,0),unpre.MR_m2),0)								as [Realizado 2016]
,isnull(CONVERT(decimal(18,0),unpre.MR_m1),0)								as [Realizado 2017]
,isnull(CONVERT(decimal(18,0),unpre.MR),0)				   					as [Realizado 2018]
,isnull(CONVERT(decimal(18,0),unpre.MR_1),0)								as [Realizado 2019]
,isnull(CONVERT(decimal(18,0),unpre.MR_2),0)								as [Realizado 2020]
,isnull(CONVERT(decimal(18,0),unpre.MR_3),0)								as [Realizado 2021]
,isnull(CONVERT(decimal(18,0),unpre.MR_Acumulado_3),0)						as [Realizado Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MR_Total),0)							as [Realizado Total]

-- Costo total actual =
-- Montos Realizados Acumulados desde Year-1 hacia atras +
-- Montos Estimados Acumulados desde Year hacia adelante
,isnull(CONVERT(decimal(18,0),unpre.MR_CostoTotal_Year),0) +
 isnull(CONVERT(decimal(18,0),unpre.ME_CostoTotal_Year),0)					as [Costo Total Actual]

-- Informacion de ONP
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2003]),0)							as [ONP 2003]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2004]),0)							as [ONP 2004]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2005]),0)							as [ONP 2005]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2006]),0)							as [ONP 2006]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2007]),0)							as [ONP 2007]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2008]),0)							as [ONP 2008]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2009]),0)							as [ONP 2009]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2010]),0)							as [ONP 2010]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2011]),0)							as [ONP 2011]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2012]),0)							as [ONP 2012]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2013]),0)							as [ONP 2013]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2014]),0)							as [ONP 2014]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2015]),0)							as [ONP 2015]
,isnull(CONVERT(decimal(18,0),CxT.[ONP-2016]),0)							as [ONP 2016]
,isnull(CONVERT(decimal(18,0),onpd.[ONP]),0)								as [ONP 2017]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_1]),0)								as [ONP 2018]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_2]),0)								as [ONP 2019]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_3]),0)								as [ONP 2020]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_4]),0)								as [ONP 2021]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_5]),0)								as [ONP 2022]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_6]),0)								as [ONP 2023]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_7]),0)								as [ONP 2024]
,isnull(CONVERT(decimal(18,0),onpd.[ONP_8]),0)								as [ONP 2025]

-- Año de referencia de los periodos
--,@Year																	as [Año_Referencia]

-- Datos de los montos iniciales del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MI_Acumulado_m5),0)					as [MontoInicial Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MI_m5),0)							as [MontoInicial 2013]
,isnull(CONVERT(decimal(18,0),unpre.MI_m4),0)							as [MontoInicial 2014]
,isnull(CONVERT(decimal(18,0),unpre.MI_m3),0)							as [MontoInicial 2015]
,isnull(CONVERT(decimal(18,0),unpre.MI_m2),0)							as [MontoInicial 2016]
,isnull(CONVERT(decimal(18,0),unpre.MI_m1),0)							as [MontoInicial 2017]	
,isnull(CONVERT(decimal(18,0),unpre.MI),0)								as [MontoInicial 2018]
,isnull(CONVERT(decimal(18,0),unpre.MI_1),0)							as [MontoInicial 2019]
,isnull(CONVERT(decimal(18,0),unpre.MI_2),0)							as [MontoInicial 2020]
,isnull(CONVERT(decimal(18,0),unpre.MI_3),0)							as [MontoInicial 2021]
,isnull(CONVERT(decimal(18,0),unpre.MI_Acumulado_3),0)					as [MontoInicial Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MI_Total),0)						as [MontoInicial Total]	
-- Datos de los montos vigentes del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MV_Acumulado_m5),0)					as [MontoVigente Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MV_m5),0)							as [MontoVigente 2013]
,isnull(CONVERT(decimal(18,0),unpre.MV_m4),0)							as [MontoVigente 2014]
,isnull(CONVERT(decimal(18,0),unpre.MV_m3),0)							as [MontoVigente 2015]
,isnull(CONVERT(decimal(18,0),unpre.MV_m2),0)							as [MontoVigente 2016]
,isnull(CONVERT(decimal(18,0),unpre.MV_m1),0)							as [MontoVigente 2017]	
,isnull(CONVERT(decimal(18,0),unpre.MV),0)								as [MontoVigente 2018]
,isnull(CONVERT(decimal(18,0),unpre.MV_1),0)							as [MontoVigente 2019]
,isnull(CONVERT(decimal(18,0),unpre.MV_2),0)							as [MontoVigente 2020]
,isnull(CONVERT(decimal(18,0),unpre.MV_3),0)							as [MontoVigente 2021]
,isnull(CONVERT(decimal(18,0),unpre.MV_Acumulado_3),0)					as [MontoVigente Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MV_Total),0)						as [MontoVigente Total]	
-- Datos de los montos vigentes estimativos del proyecto, de acuerdo al año ingresado como parametro --
,isnull(unpre.MVE_m5,0)							as [MontoVigenteEstimativo 2013]
,isnull(unpre.MVE_m4,0)							as [MontoVigenteEstimativo 2014]
,isnull(unpre.MVE_m3,0)							as [MontoVigenteEstimativo 2015]
,isnull(unpre.MVE_m2,0)							as [MontoVigenteEstimativo 2016]
,isnull(unpre.MVE_m1,0)							as [MontoVigenteEstimativo 2017]	
,isnull(unpre.MVE,0)							as [MontoVigenteEstimativo 2018]
,isnull(unpre.MVE_1,0)							as [MontoVigenteEstimativo 2019]
,isnull(unpre.MVE_2,0)							as [MontoVigenteEstimativo 2020]
,isnull(unpre.MVE_3,0)							as [MontoVigenteEstimativo 2021]
-- Datos de los montos devengados del proyecto, de acuerdo al año ingresado como parametro --
,isnull(CONVERT(decimal(18,0),unpre.MD_Acumulado_m5),0)					as [MontoDevengado Anteriores]
,isnull(CONVERT(decimal(18,0),unpre.MD_m5),0)							as [MontoDevengado 2013]
,isnull(CONVERT(decimal(18,0),unpre.MD_m4),0)							as [MontoDevengado 2014]
,isnull(CONVERT(decimal(18,0),unpre.MD_m3),0)							as [MontoDevengado 2015]
,isnull(CONVERT(decimal(18,0),unpre.MD_m2),0)							as [MontoDevengado 2016]
,isnull(CONVERT(decimal(18,0),unpre.MD_m1),0)							as [MontoDevengado 2017]	
,isnull(CONVERT(decimal(18,0),unpre.MD),0)								as [MontoDevengado 2018]
,isnull(CONVERT(decimal(18,0),unpre.MD_1),0)							as [MontoDevengado 2019]
,isnull(CONVERT(decimal(18,0),unpre.MD_2),0)							as [MontoDevengado 2020]
,isnull(CONVERT(decimal(18,0),unpre.MD_3),0)							as [MontoDevengado 2021]
,isnull(CONVERT(decimal(18,0),unpre.MD_Acumulado_3),0)					as [MontoDevengado Posteriores]
,isnull(CONVERT(decimal(18,0),unpre.MD_Total),0)						as [MontoDevengado Total]	

-- Fecha y hora de generacion del cubo --
,CONVERT(VARCHAR(10), GETDATE(), 103) + ' ' +
 CONVERT(VARCHAR(10), GETDATE(), 108)										as [Generado]

from Proyecto p

-- Agrego los valores de los montos estimados y realizados
--left join fn_Cubo_Union_ME_MR (@Year) unpre on p.IdProyecto = unpre.IdProyecto 
--left join #MontoEstimado me on me.IdProyecto = p.IdProyecto
--left join #MontoRealizado mr on mr.IdProyecto = p.IdProyecto
--Info presupuestaria xxxx
left join fn_Cubo_Union_Presupuestaria (@Year) unpre on p.IdProyecto = unpre.IdProyecto 

-- Estado fisico, Estado de Decision y Estado financiero
left join fn_Cubo_EstadoFinanciero_Group () pefinan on pefinan.IdProyecto = p.IdProyecto
left join EstadoDeDesicion est_decision on est_decision.IdEstadoDeDesicion = p.IdEstadoDeDesicion
left join fn_Cubo_EstadoFisico_Group () pefis on pefis.idproyecto = p.IdProyecto

-- Datos del Objeto del gasto (Inciso/PartidaPrincipal/PartidaParcial)
left join ProyectoEtapa pe on pe.IdProyecto = p.IdProyecto
--left join ClasificacionGasto cg on cg.IdClasificacionGasto = me.idClasificacionGasto
--left join FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = me.IdFuenteFinanciamiento

-- Datos de la Apertura Presupuestaria (NroProyecto.NroActividad.NroObra)
-- Tipo_ApePresup Agrupado (Proyecto/Actividad)
left join fn_Cubo_AperturaPresupuestaria_Group () apepres on apepres.IdProyecto = p.IdProyecto

left join Proceso pr on pr.IdProceso = p.IdProceso
inner join ProyectoTipo ptipo on ptipo.IdProyectoTipo = p.IdTipoProyecto

--left join dbo.fngetclasificacioninstitucional () clasinst on clasinst.idproyecto = p.IdProyecto

-- Datos para la Clasificacion Institucional
inner join SubPrograma sprog on sprog.IdSubPrograma=p.IdSubPrograma
inner join Programa prog on prog.IdPrograma=sprog.IdPrograma
left join Saf on Saf.IdSaf=prog.idsaf
left join EntidadTipo etipo on etipo.IdEntidadTipo=saf.IdEntidadTipo
inner join Jurisdiccion juris on Juris.IdJurisdiccion=Saf.IdJurisdiccion
left join SubJurisdiccion sjuris on sjuris.IdSubJuridiccion=saf.IdSubJurisdiccion

inner join OrganismoTipo otipo on otipo.IdOrganismoTipo=Saf.IdTipoOrganismo

-- Sectorialista asignado a un programa
left join persona sect on sect.Idpersona=prog.IdSectorialista

-- Usuario que modifica el proyecto
inner join persona pers on pers.Idpersona=p.IdUsuarioModificacion

left join OrganismoPrioridad op on op.IdOrganismoPrioridad=p.IdOrganismoPrioridad

--Gestion de Inversion-> Evaluacion de Factibilidad (Administracion -> Inversion -> Evaluacion de Factibilidad)
left join fn_Cubo_EvaluacionFactibilidad_Group () pefa on pefa.IdProyecto = p.IdProyecto

-- Gestion de Inversion->Dictamen de Inversion (Administracion -> Inversion -> Dictamente de Inversion)
left join fn_Cubo_DictamenInversion_Group () pdia on pdia.IdProyecto = p.IdProyecto

--Gestion de Calidad (Administracion -> Calidad)
left join proyectocalidad pcalid on pcalid.IdProyecto = p.IdProyecto
left join Estado est_calid on est_calid.IdEstado = pcalid.IdEstado

left join FinalidadFuncion ff on ff.IdFinalidadFuncion=p.IdFinalidadFuncion

left join ProyectoPlan pp on pp.IdProyectoPlan=p.IdProyectoPlan
left join PlanPeriodo ppt on ppt.IdPlanPeriodo=pp.IdPlanPeriodo
left join PlanVersion ppv on ppv.IdPlanVersion=pp.IdPlanVersion
left join PlanTipo pt on pt.IdPlanTipo=ppt.IdPlanTipo

--left join fnGetPrioridadProyecto () ppriori on ppriori.idproyecto = p.IdProyecto

--Recupero los planes vinculados al proyecto
left join fn_Cubo_UltimoPlanPrioridad () upp on upp.IdProyecto=p.IdProyecto
left join fn_Cubo_Plan_Group () ppd on ppd.idproyecto=p.IdProyecto

--Recupero los comentarios tecnicos del tipo ECTO vinculados al proyecto
left join fn_Cubo_ECTO_Group () ecto on ecto.IdProyecto=p.IdProyecto

left join @ttProvincias tp on tp.idproyecto=p.IdProyecto

--Incorporo informacion de ONP a partir de la importacion del Ultimo CuboxTotal
left join Cubo_ImportCxTBapin2 CxT on CxT.Nro_Bapin = p.Codigo

--Incorporo informacion de ONP a partir de los proyectos vinculados por matching (tabla Matching_ProyectosVinculados)
--left join #onp_devengado onpd on onpd.Codigo = p.codigo
left join fn_Cubo_ONPDevengado(@Year) onpd on onpd.IdProyecto = p.IdProyecto

left join #Fechas_Estimadas_CxO fest on fest.IdProyecto = p.IdProyecto

where p.Activo = 1 /*Solo Proyectos activos*/

END



GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Inicia_CxO]    Script Date: 11/28/2016 20:46:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Inicia_CxO]
AS
BEGIN

DECLARE	@return_value int

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cubo_CxO]') AND type in (N'U'))
DROP TABLE [dbo].[Cubo_CxO]

CREATE TABLE [dbo].[Cubo_CxO](
	[Nro_Bapin] [int] NULL,
	[Denominacion] [varchar](max) NULL,
	[EsBorrador] [varchar] (max) NULL,
	[Tipo] [varchar](max) NULL,
	[Inciso] [varchar](max) NULL,
	[Clasif_Instit] [varchar](max) NULL,
	[Jur_cod] [varchar] (max) NULL,
	[Jurisdicción] [varchar](max) NULL,
	[Ape_Prog] [varchar](max) NULL,
	[SAF_cod] [varchar](max) NULL,
	[SAF] [varchar] (max) NULL,
	[Progr_cod] [varchar] (max) NULL,
	[Programa] [varchar](max) NULL,
	[Subprog_cod] [varchar] (max) NULL,
	[Subprograma] [varchar](max) NULL,
	[Ape_Presup] [varchar](max) NULL,
	[NroProyecto] [int] NULL,
	[NroActividad] [varchar] (max) NULL,
	[NroObra] [varchar] (max) NULL,
	[Tipo_Presup] [varchar](max) NULL,
	[Ape_PresupActEsp] [varchar] (max) NULL,
	[Es_Presup] [varchar](max) NULL,
	[Estado_Financiero] [varchar](max) NULL,
	[Estado_Fisico] [varchar](max) NULL,
	[Est_Decision] [varchar](max) NULL,
	[PrioridadDNIP] [varchar](max) NULL,
	[Art_15] [varchar] (max) NULL,
	[Req_Dict] [varchar](max) NULL,
	[Estado_calidad] [varchar](max) NULL,
	[Fecha_Estado_Calidad] [varchar](max) NULL,
	[Eval_Factibilidad] [varchar](max) NULL,
	[Dict_Inversion] [varchar](max) NULL,
	[PrioridadOrganismo] [varchar](max) NULL,
	[Subprioridad] [int] NULL,
	[Prov_Cantidad] [int] NULL,
	[Localizacion_Provincia] [varchar](max) NULL,
	[Fecha_Alta] [varchar](10) NULL,
	[Fecha_UltModificacion] [varchar](max) NULL,
	[Usuario_UltModificación] [varchar](max) NULL,
	[Fecha_Inicio_Estimada] [varchar](max) NULL,
	[Fecha_Fin_Estimada] [varchar](max) NULL,
	[Planes] [varchar](max) NULL,
	[Ult_Plan] [varchar](max) NULL,
	[Ult_Demanda] [varchar](max) NULL,	
	[Finalidad_Función] [nvarchar](max) NULL,
	[Finalidad_Funcion_Cod] [varchar](max) NULL,
	[Finalidad_Función_Desc] [varchar](max) NULL,
	[Objeto_Gasto_Cod] [varchar](max) NULL,
	[Objeto_Gasto_Desc] [varchar](max) NULL,
	[Fuente_Finaciamiento_Cod] [varchar](max) NULL,
	[Fuente_Financiamiento_Desc] [varchar](max) NULL,
	[Proceso] [varchar](max) NULL,
	[Sectorialista] [varchar](max) NULL,
	[Com_Tecnico_ECTO] [varchar](max) NULL,
	[Estimados Anteriores] [decimal] (18,0) NULL,
	[Estimado 2013] [decimal] (18,0) NULL,
	[Estimado 2014] [decimal] (18,0) NULL,
	[Estimado 2015] [decimal] (18,0) NULL,
	[Estimado 2016] [decimal] (18,0) NULL,
	[Estimado 2017] [decimal] (18,0) NULL,
	[Estimado 2018] [decimal] (18,0) NULL,
	[Estimado 2019] [decimal] (18,0) NULL,
	[Estimado 2020] [decimal] (18,0) NULL,
	[Estimado 2021] [decimal] (18,0) NULL,
	[Estimado Posteriores] [decimal] (18,0) NULL,
	[Estimado Total] [decimal] (18,0) NULL,
	[Realizados Anteriores] [decimal] (18,0) NULL,
	[Realizado 2013] [decimal] (18,0) NULL,
	[Realizado 2014] [decimal] (18,0) NULL,
	[Realizado 2015] [decimal] (18,0) NULL,
	[Realizado 2016] [decimal] (18,0) NULL,
	[Realizado 2017] [decimal] (18,0) NULL,
	[Realizado 2018] [decimal] (18,0) NULL,
	[Realizado 2019] [decimal] (18,0) NULL,
	[Realizado 2020] [decimal] (18,0) NULL,
	[Realizado 2021] [decimal] (18,0) NULL,
	[Realizado Posteriores] [decimal] (18,0) NULL,
	[Realizado Total] [decimal] (18,0) NULL,
	[Costo Total Actual] [decimal] (18,0) NULL,
	[ONP 2003] [decimal] (18,0) NULL,
	[ONP 2004] [decimal] (18,0) NULL,
	[ONP 2005] [decimal] (18,0) NULL,
	[ONP 2006] [decimal] (18,0) NULL,
	[ONP 2007] [decimal] (18,0) NULL,
	[ONP 2008] [decimal] (18,0) NULL,
	[ONP 2009] [decimal] (18,0) NULL,
	[ONP 2010] [decimal] (18,0) NULL,
	[ONP 2011] [decimal] (18,0) NULL,
	[ONP 2012] [decimal] (18,0) NULL,
	[ONP 2013] [decimal] (18,0) NULL,
	[ONP 2014] [decimal] (18,0) NULL,
	[ONP 2015] [decimal] (18,0) NULL,
	[ONP 2016] [decimal] (18,0) NULL,
	[ONP 2017] [decimal] (18,0) NULL,
	[ONP 2018] [decimal] (18,0) NULL,
	[ONP 2019] [decimal] (18,0) NULL,
	[ONP 2020] [decimal] (18,0) NULL,
	[ONP 2021] [decimal] (18,0) NULL,
	[ONP 2022] [decimal] (18,0) NULL,
	[ONP 2023] [decimal] (18,0) NULL,
	[ONP 2024] [decimal] (18,0) NULL,
	[ONP 2025] [decimal] (18,0) NULL,
	[MontoInicial Anteriores] [decimal] (18,0) NULL,
	[MontoInicial 2013] [decimal] (18,0) NULL,
	[MontoInicial 2014] [decimal] (18,0) NULL,
	[MontoInicial 2015] [decimal] (18,0) NULL,
	[MontoInicial 2016] [decimal] (18,0) NULL,
	[MontoInicial 2017] [decimal] (18,0) NULL,
	[MontoInicial 2018] [decimal] (18,0) NULL,
	[MontoInicial 2019] [decimal] (18,0) NULL,
	[MontoInicial 2020] [decimal] (18,0) NULL,
	[MontoInicial 2021] [decimal] (18,0) NULL,
	[MontoInicial Posteriores] [decimal] (18,0) NULL,
	[MontoInicial Total] [decimal] (18,0) NULL,
	[MontoVigente Anteriores] [decimal] (18,0) NULL,
	[MontoVigente 2013] [decimal] (18,0) NULL,
	[MontoVigente 2014] [decimal] (18,0) NULL,
	[MontoVigente 2015] [decimal] (18,0) NULL,
	[MontoVigente 2016] [decimal] (18,0) NULL,
	[MontoVigente 2017] [decimal] (18,0) NULL,
	[MontoVigente 2018] [decimal] (18,0) NULL,
	[MontoVigente 2019] [decimal] (18,0) NULL,
	[MontoVigente 2020] [decimal] (18,0) NULL,
	[MontoVigente 2021] [decimal] (18,0) NULL,
	[MontoVigente Posteriores] [decimal] (18,0) NULL,
	[MontoVigente Total] [decimal] (18,0) NULL,
	[MontoVigenteEstimativo 2013] bit NULL,
	[MontoVigenteEstimativo 2014] bit NULL,
	[MontoVigenteEstimativo 2015] bit NULL,
	[MontoVigenteEstimativo 2016] bit NULL,
	[MontoVigenteEstimativo 2017] bit NULL,
	[MontoVigenteEstimativo 2018] bit NULL,
	[MontoVigenteEstimativo 2019] bit NULL,
	[MontoVigenteEstimativo 2020] bit NULL,
	[MontoVigenteEstimativo 2021] bit NULL,
	[MontoDevengado Anteriores] [decimal] (18,0) NULL,
	[MontoDevengado 2013] [decimal] (18,0) NULL,
	[MontoDevengado 2014] [decimal] (18,0) NULL,
	[MontoDevengado 2015] [decimal] (18,0) NULL,
	[MontoDevengado 2016] [decimal] (18,0) NULL,
	[MontoDevengado 2017] [decimal] (18,0) NULL,
	[MontoDevengado 2018] [decimal] (18,0) NULL,
	[MontoDevengado 2019] [decimal] (18,0) NULL,
	[MontoDevengado 2020] [decimal] (18,0) NULL,
	[MontoDevengado 2021] [decimal] (18,0) NULL,
	[MontoDevengado Posteriores] [decimal] (18,0) NULL,
	[MontoDevengado Total] [decimal] (18,0) NULL,
	[Generado] [varchar] (max) NULL	
) ON [FG] TEXTIMAGE_ON [FG]

INSERT INTO [dbo].[Cubo_CxO] 
EXEC	@return_value = [dbo].[sp_Cubo_Genera_CxO]
END


GO

/****** Object:  StoredProcedure [dbo].[sp_Cubo_Filtra_CxT]    Script Date: 12/03/2016 09:39:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Filtra_CxT] (@IdUsusarioLogeado int)

AS

DECLARE

@UsuarioEsDeOficinaDNIP varchar (2) = 'No'
,@UsuarioTienePerfilOficina varchar (2) = 'Si'
--@EsUsuarioAdmin varchar (2)= 'No',
--,@EsPerfilAdminInversion varchar (2) = 'No'

BEGIN

--SET @EsUsuarioAdmin =   
--        CASE  
--			-- Valida si el usuario es 'admin' 
--            WHEN EXISTS(SELECT * FROM Usuario AS u
--						WHERE u.IdUsuario = @IdUsusarioLogeado
--								and u.IdUsuario = 2711)   
--                THEN 'Si'
--END;
                
SET @UsuarioEsDeOficinaDNIP =   
        CASE                     
     		--Valida si el usuario pertenece a la 'DNIP'. IDOficina = 62
            WHEN EXISTS(SELECT ofi.IdOficina from Persona pers
						left join Oficina ofi on ofi.IdOficina = pers.IdOficina
						where pers.IdPersona = @IdUsusarioLogeado
						and ofi.IdOficina = 62)   
                THEN 'Si'
                ELSE 'No' 
END;

SET @UsuarioTienePerfilOficina =   
        CASE                     
     		--Valida si el usuario tiene un perfil de oficina asignado
            WHEN EXISTS(SELECT IdOficina FROM UsuarioOficinaPerfil
						left join perfil on perfil.IdPerfil = UsuarioOficinaPerfil.IdPerfil
						where IdUsuario = @IdUsusarioLogeado /*and IdPerfilTipo = 2*/) 						  
                THEN 'Si'
                ELSE 'No'  
END;

-- Si el Usuario pertenece a la oficina DNIP o no tiene perfil de oficina asignado
-- el procedimiento devuelve todos los proyectos,
-- y ademas incorpora la infomacion de ONP

--IF @EsUsuarioAdmin = 'Si' or @UsuarioEsDeOficinaDNIP = 'Si'
IF @UsuarioEsDeOficinaDNIP = 'Si' or @UsuarioTienePerfilOficina = 'No'
BEGIN

  SELECT distinct
  CxT.*  
  FROM Cubo_CxT CxT
  where CxT.EsBorrador = 'N' -- solo recupera los proyectos que no estan marcados como borrador
  
/*
  SELECT distinct
  CxT.*  
  FROM proyecto p
  inner join Cubo_CxT CxT on CxT.Nro_Bapin = p.Codigo
  where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador
*/
END
ELSE

-- Si el Usuario no pertenece a la oficina DNIP
-- Entonces el procedimiento deviuelve solo los proyectos que corresponden al usuario
-- de acuerdo al perfil de oficina (iniciador, ejecutor, responsable) del proyecto
-- y las oficinas vinculadas al usuario en su perfil de usuario

BEGIN
	select distinct
	
[CxT].[Nro_Bapin]
,[CxT].[Denominacion]
,[CxT].[EsBorrador]
,[CxT].[Tipo]
,[CxT].[Incisos]
,[CxT].[Clasif_Instit]
,[CxT].[Jur_cod]
,[CxT].[Jurisdicción]
,[CxT].[Ape_Prog]
,[CxT].[SAF_cod]
,[CxT].[SAF]
,[CxT].[Progr_cod]
,[CxT].[Programa]
,[CxT].[Subprog_cod]
,[CxT].[Subprograma]
,[CxT].[Ape_Presup]
,[CxT].[NroProyecto]
,[CxT].[NroActividad]
,[CxT].[NroObra]
,[CxT].[Tipo_Presup]
,[CxT].[Ape_PresupActEsp]
,[CxT].[Es_Presup]
,[CxT].[Estado_Financiero]
,[CxT].[Estado_Fisico]
,[CxT].[Est_Decision]
,[CxT].[PrioridadDNIP]
,[CxT].[Art_15]
,[CxT].[Req_Dict]
,[CxT].[Estado_calidad]
,[CxT].[Fecha_Estado_Calidad]
,[CxT].[Eval_Factibilidad]
,[CxT].[Dict_Inversion]
,[CxT].[PrioridadOrganismo]
,[CxT].[Subprioridad]
,[CxT].[Prov_Cantidad]
,[CxT].[Localizacion_Provincia]
,[CxT].[Fecha_Alta]
,[CxT].[Fecha_UltModificacion]
,[CxT].[Usuario_UltModificación]
,[CxT].[Fecha_Inicio_Estimada]
,[CxT].[Fecha_Fin_Estimada]
,[CxT].[Planes]
,[CxT].[Ult_Plan]
,[CxT].[Ult_Demanda]
,[CxT].[Finalidad_Función]
,[CxT].[Finalidad_Funcion_Cod]
,[CxT].[Finalidad_Función_Desc]
,[CxT].[Fuente_Finaciamiento_Cod]
,[CxT].[Fuente_Financiamiento_Desc]
,[CxT].[Proceso]
,[CxT].[Sectorialista]
,[CxT].[Com_Tecnico_ECTO]
,[CxT].[Estimados Anteriores]
,[CxT].[Estimado 2013]
,[CxT].[Estimado 2014]
,[CxT].[Estimado 2015]
,[CxT].[Estimado 2016]
,[CxT].[Estimado 2017]
,[CxT].[Estimado 2018]
,[CxT].[Estimado 2019]
,[CxT].[Estimado 2020]
,[CxT].[Estimado 2021]
,[CxT].[Estimado Posteriores]
,[CxT].[Estimado Total]
,[CxT].[Realizados Anteriores]
,[CxT].[Realizado 2013]
,[CxT].[Realizado 2014]
,[CxT].[Realizado 2015]
,[CxT].[Realizado 2016]
,[CxT].[Realizado 2017]
,[CxT].[Realizado 2018]
,[CxT].[Realizado 2019]
,[CxT].[Realizado 2020]
,[CxT].[Realizado 2021]
,[CxT].[Realizado Posteriores]
,[CxT].[Realizado Total]
,[CxT].[Costo Total Actual]
,
[CxT].[MontoInicial Anteriores],
[CxT].[MontoInicial 2013],
[CxT].[MontoInicial 2014],
[CxT].[MontoInicial 2015],
[CxT].[MontoInicial 2016],
[CxT].[MontoInicial 2017],
[CxT].[MontoInicial 2018],
[CxT].[MontoInicial 2019],
[CxT].[MontoInicial 2020],
[CxT].[MontoInicial 2021],
[CxT].[MontoInicial Posteriores],
[CxT].[MontoInicial Total],
[CxT].[MontoVigente Anteriores],
[CxT].[MontoVigente 2013],
[CxT].[MontoVigente 2014],
[CxT].[MontoVigente 2015],
[CxT].[MontoVigente 2016],
[CxT].[MontoVigente 2017],
[CxT].[MontoVigente 2018],
[CxT].[MontoVigente 2019],
[CxT].[MontoVigente 2020],
[CxT].[MontoVigente 2021],
[CxT].[MontoVigente Posteriores],
[CxT].[MontoVigente Total],
[CxT].[MontoVigenteEstimativo 2013],
[CxT].[MontoVigenteEstimativo 2014],
[CxT].[MontoVigenteEstimativo 2015],
[CxT].[MontoVigenteEstimativo 2016],
[CxT].[MontoVigenteEstimativo 2017],
[CxT].[MontoVigenteEstimativo 2018],
[CxT].[MontoVigenteEstimativo 2019],
[CxT].[MontoVigenteEstimativo 2020],
[CxT].[MontoVigenteEstimativo 2021],
[CxT].[MontoDevengado Anteriores],
[CxT].[MontoDevengado 2013],
[CxT].[MontoDevengado 2014],
[CxT].[MontoDevengado 2015],
[CxT].[MontoDevengado 2016],
[CxT].[MontoDevengado 2017],
[CxT].[MontoDevengado 2018],
[CxT].[MontoDevengado 2019],
[CxT].[MontoDevengado 2020],
[CxT].[MontoDevengado 2021],
[CxT].[MontoDevengado Posteriores],
[CxT].[MontoDevengado Total]
,[CxT].[Generado]

from proyecto p
inner join (select distinct pop.IdProyecto from ProyectoOficinaPerfil pop
inner join fnIdsOficinaPorUsuario (@IdUsusarioLogeado) opu on opu.IdOficina = pop.IdOficina) uop
	on uop.IdProyecto = p.IdProyecto
inner join Cubo_CxT CxT on CxT.Nro_Bapin = p.Codigo
where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador

END
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Cubo_Filtra_CxO]    Script Date: 12/03/2016 09:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Cubo_Filtra_CxO] (@IdUsusarioLogeado int)

AS

DECLARE

@UsuarioEsDeOficinaDNIP varchar (2) = 'No'
,@UsuarioTienePerfilOficina varchar (2) = 'Si'
--@EsUsuarioAdmin varchar (2)= 'No'
--,@EsPerfilAdminInversion varchar (2) = 'No'

BEGIN

--SET @EsUsuarioAdmin =   
--        CASE  
--			-- Valida si el usuario es 'admin' 
--            WHEN EXISTS(SELECT * FROM Usuario AS u
--						WHERE (u.IdUsuario = @IdUsusarioLogeado)
--								and u.NombreUsuario = 'admin')   
--                THEN 'Si'
--END;
             
SET @UsuarioEsDeOficinaDNIP =   
        CASE                     
     		--Valida si el usuario pertenece a la 'DNIP'. IDOficina = 62
            WHEN EXISTS(SELECT ofi.IdOficina from Persona pers
						left join Oficina ofi on ofi.IdOficina = pers.IdOficina
						where pers.IdPersona = @IdUsusarioLogeado
						and ofi.IdOficina = 62)   
                THEN 'Si'
                ELSE 'No' 
END;

SET @UsuarioTienePerfilOficina =   
        CASE                     
     		--Valida si el usuario tiene un perfil de oficina asignado
            WHEN EXISTS(SELECT IdOficina FROM UsuarioOficinaPerfil
						left join perfil on perfil.IdPerfil = UsuarioOficinaPerfil.IdPerfil
						where IdUsuario = @IdUsusarioLogeado and IdPerfilTipo = 2) 						  
                THEN 'Si'
                ELSE 'No' 
END;

-- Si el Usuario pertenece a la oficina DNIP  o no tiene perfil oficina asignado
-- el procedimiento devuelve todos los proyectos,
-- y ademas incorpora la infomacion de ONP

--IF @EsUsuarioAdmin = 'Si' or @UsuarioEsDeOficinaDNIP = 'Si'
IF @UsuarioEsDeOficinaDNIP = 'Si' or @UsuarioTienePerfilOficina = 'No'
BEGIN

  SELECT distinct
  CxO.*  
  FROM Cubo_CxO CxO
  where CxO.EsBorrador = 'N' -- solo recupera los proyectos que no estan marcados como borrador
  
  /*
  SELECT distinct
  CxO.*  
  FROM proyecto p
  inner join Cubo_CxO CxO on CxO.Nro_Bapin = p.Codigo
  where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador 
  */

END
ELSE

-- Si el Usuario no es Admin o la oficina del usuario no es DNIP
-- Entonces muestra los proyectos que corresponden de acuerdo al perfil de oficina
-- (iniciador, ejecutor, responsable) 

BEGIN
	select distinct

[CxO].[Nro_Bapin]
,[CxO].[Denominacion]
,[CxO].[EsBorrador]
,[CxO].[Tipo]
,[CxO].[Inciso]
,[CxO].[Clasif_Instit]
,[CxO].[Jur_cod]
,[CxO].[Jurisdicción]
,[CxO].[Ape_Prog]
,[CxO].[SAF_cod]
,[CxO].[SAF]
,[CxO].[Progr_cod]
,[CxO].[Programa]
,[CxO].[Subprog_cod]
,[CxO].[Subprograma]
,[CxO].[Ape_Presup]
,[CxO].[NroProyecto]
,[CxO].[NroActividad]
,[CxO].[NroObra]
,[CxO].[Tipo_Presup]
,[CxO].[Ape_PresupActEsp]
,[CxO].[Es_Presup]
,[CxO].[Estado_Financiero]
,[CxO].[Estado_Fisico]
,[CxO].[Est_Decision]
,[CxO].[PrioridadDNIP]
,[CxO].[Art_15]
,[CxO].[Req_Dict]
,[CxO].[Estado_calidad]
,[CxO].[Fecha_Estado_Calidad]
,[CxO].[Eval_Factibilidad]
,[CxO].[Dict_Inversion]
,[CxO].[PrioridadOrganismo]
,[CxO].[Subprioridad]
,[CxO].[Prov_Cantidad]
,[CxO].[Localizacion_Provincia]
,[CxO].[Fecha_Alta]
,[CxO].[Fecha_UltModificacion]
,[CxO].[Usuario_UltModificación]
,[CxO].[Fecha_Inicio_Estimada]
,[CxO].[Fecha_Fin_Estimada]
,[CxO].[Planes]
,[CxO].[Ult_Plan]
,[CxO].[Ult_Demanda]
,[CxO].[Finalidad_Función]
,[CxO].[Finalidad_Funcion_Cod]
,[CxO].[Finalidad_Función_Desc]
,[CxO].[Objeto_Gasto_Cod]
,[CxO].[Objeto_Gasto_Desc]
,[CxO].[Fuente_Finaciamiento_Cod]
,[CxO].[Fuente_Financiamiento_Desc]
,[CxO].[Proceso]
,[CxO].[Sectorialista]
,[CxO].[Com_Tecnico_ECTO]
,[CxO].[Estimados Anteriores]
,[CxO].[Estimado 2013]
,[CxO].[Estimado 2014]
,[CxO].[Estimado 2015]
,[CxO].[Estimado 2016]
,[CxO].[Estimado 2017]
,[CxO].[Estimado 2018]
,[CxO].[Estimado 2019]
,[CxO].[Estimado 2020]
,[CxO].[Estimado 2021]
,[CxO].[Estimado Posteriores]
,[CxO].[Estimado Total]
,[CxO].[Realizados Anteriores]
,[CxO].[Realizado 2013]
,[CxO].[Realizado 2014]
,[CxO].[Realizado 2015]
,[CxO].[Realizado 2016]
,[CxO].[Realizado 2017]
,[CxO].[Realizado 2018]
,[CxO].[Realizado 2019]
,[CxO].[Realizado 2020]
,[CxO].[Realizado 2021]
,[CxO].[Realizado Posteriores]
,[CxO].[Realizado Total]
,[CxO].[Costo Total Actual]
,
[CxO].[MontoInicial Anteriores],
[CxO].[MontoInicial 2013],
[CxO].[MontoInicial 2014],
[CxO].[MontoInicial 2015],
[CxO].[MontoInicial 2016],
[CxO].[MontoInicial 2017],
[CxO].[MontoInicial 2018],
[CxO].[MontoInicial 2019],
[CxO].[MontoInicial 2020],
[CxO].[MontoInicial 2021],
[CxO].[MontoInicial Posteriores],
[CxO].[MontoInicial Total],
[CxO].[MontoVigente Anteriores],
[CxO].[MontoVigente 2013],
[CxO].[MontoVigente 2014],
[CxO].[MontoVigente 2015],
[CxO].[MontoVigente 2016],
[CxO].[MontoVigente 2017],
[CxO].[MontoVigente 2018],
[CxO].[MontoVigente 2019],
[CxO].[MontoVigente 2020],
[CxO].[MontoVigente 2021],
[CxO].[MontoVigente Posteriores],
[CxO].[MontoVigente Total],
[CxO].[MontoVigenteEstimativo 2013],
[CxO].[MontoVigenteEstimativo 2014],
[CxO].[MontoVigenteEstimativo 2015],
[CxO].[MontoVigenteEstimativo 2016],
[CxO].[MontoVigenteEstimativo 2017],
[CxO].[MontoVigenteEstimativo 2018],
[CxO].[MontoVigenteEstimativo 2019],
[CxO].[MontoVigenteEstimativo 2020],
[CxO].[MontoVigenteEstimativo 2021],
[CxO].[MontoDevengado Anteriores],
[CxO].[MontoDevengado 2013],
[CxO].[MontoDevengado 2014],
[CxO].[MontoDevengado 2015],
[CxO].[MontoDevengado 2016],
[CxO].[MontoDevengado 2017],
[CxO].[MontoDevengado 2018],
[CxO].[MontoDevengado 2019],
[CxO].[MontoDevengado 2020],
[CxO].[MontoDevengado 2021],
[CxO].[MontoDevengado Posteriores],
[CxO].[MontoDevengado Total]
,[CxO].[Generado]

from proyecto p
inner join (select distinct pop.IdProyecto from ProyectoOficinaPerfil pop
inner join fnIdsOficinaPorUsuario (@IdUsusarioLogeado) opu on opu.IdOficina = pop.IdOficina) uop
	on uop.IdProyecto = p.IdProyecto
inner join Cubo_CxO CxO on CxO.Nro_Bapin = p.Codigo
where p.EsBorrador = 0 -- solo recupera los proyectos que no estan marcados como borrador

END

END

GO

