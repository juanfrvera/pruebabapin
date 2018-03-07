USE [BAPIN]
GO

/*
Perfil 
8 Usuario BAPIN

Actividades
45	Opciones Básicas Generales
46	Administración Básica Inversión
56	Administración Total Inversión
*/

/*
Permisos
5319	ProgramaObjetivo_Ver
5333	Programa_Ver
5487	Programa_Listar
5502	ProgramaObjetivo_Listar
*/

Delete ActividadPermiso 
where idactividad in (45,46)
and idpermiso in (5319,5333,5487,5502)
--Estaba los 4 permisos en las 2 actividades
GO

/*
Permisos
5298	FuenteFinanciamiento_Ver
5525	FuenteFinanciamiento_Listar
5860	FuenteFinanciamiento_Imprimir
5278	FinalidadFuncion_Ver
5545	FinalidadFuncion_Listar
5322	ClasificacionGeografica_Ver
5499	ClasificacionGeografica_Listar
5306	CaracterEconomico_Ver
5517	CaracterEconomico_Listar
5303	ClasificacionGasto_Ver
5520	ClasificacionGasto_Listar
*/
Delete ActividadPermiso 
where idactividad in (45,46)
and idpermiso in (5298,5525,5860,5278,5545,5322,5499,5306,5517,5303,5520)
GO