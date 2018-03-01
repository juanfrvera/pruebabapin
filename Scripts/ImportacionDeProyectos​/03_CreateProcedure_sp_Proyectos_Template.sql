USE [BAPIN]
GO

/****** Object:  StoredProcedure [dbo].[sp_Proyectos_Template]    Script Date: 11/28/2016 20:46:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Proyectos_Template]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Proyectos_Template]
GO

CREATE PROCEDURE [dbo].[sp_Proyectos_Template]
@IdsString VARCHAR(MAX)
AS
BEGIN

SELECT * 
into #ProjectIdSplited
FROM dbo.fn_Split(@IdsString,'|') OPTION ( MAXRECURSION 30000 )

	select
	p.IdProyecto as idProyecto,
	p.Codigo as	codigo,
	--string.Format("{0} - {1} ({2})", proyecto.Saf_Codigo, proyecto.Saf_Nombre, proyecto.IdSAF)
	Saf.Codigo + ' - ' + Saf.Denominacion + ' (' + CAST(saf.IdSaf AS VARCHAR(16)) + ')' as saf,
	--string.Format("{0} - {1} ({2})", x.Programa.Codigo, x.Programa.Nombre, x.Programa.IdPrograma.ToString().ToUpper()), 
	prog.Codigo + ' - ' + prog.Nombre + ' (' + UPPER(CAST(prog.IdPrograma AS VARCHAR(16))) + ')' as	programa,
	sprog.Codigo + ' - ' + sprog.Nombre + ' (' + UPPER(CAST(sprog.IdSubPrograma AS VARCHAR(16))) + ')' as	subPrograma,
	--"{0} ({1})", x.Nombre, x.IdProyectoTipo
	ptipo.Nombre + ' (' + UPPER(CAST(ptipo.IdProyectoTipo AS VARCHAR(16))) + ')' as	proyectoTipo,
	--"{0} ({1})", x.Nombre, x.IdProceso.ToString().ToUpper()
	pro.Nombre + ' (' + UPPER(CAST(pro.IdProceso AS VARCHAR(16))) + ')' as	proceso,
	p.ProyectoDenominacion as	proyectoDenominacion,
	--"{0} ({1})", x.Nombre, x.IdSistemaEntidadEstado.ToString().ToUpper()
	e.Nombre + ' (' + UPPER(CAST(e.IdEstado AS VARCHAR(16))) + ')' as	estadoFinanciero,
	--{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdFinalidadFuncion.ToString().ToUpper()
	ff.BreadcrumbCode + ' - ' + ff.Descripcion + ' (' + UPPER(CAST(ff.IdFinalidadFuncion AS VARCHAR(16))) + ')' as	finalidadFuncion,
	--"{0} ({1})", x.Nombre, x.IdOrganismoPrioridad.ToString().ToUpper()
	op.Nombre + ' (' + UPPER(CAST(op.IdOrganismoPrioridad AS VARCHAR(16))) + ')'  as	prioridad,
	p.SubPrioridad as	numeroPrioridad,
	--"{0} - ({1})", x.Descripcion, x.IdOficina.ToString().ToUpper()
	ofi.Descripcion + ' (' + UPPER(CAST(ofi.IdOficina AS VARCHAR(16))) + ')' as	oficina,
	--string.Format("{0} ({1})", x.Nombre, x.IdClasificacionGeografica.ToString().ToUpper())
	cgeo.Nombre + ' (' + UPPER(CAST(cgeo.IdClasificacionGeografica AS VARCHAR(16))) + ')' as	localizacion,
	pe.FechaInicioEstimada as	fechaInicioEstimada,
	pe.FechaFinEstimada as	fechaFinEstimada,
	pe.FechaInicioRealizada as	fechaInicioRealizada,
	pe.FechaFinRealizada as	fechaFinRealizada,
	--"{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdClasificacionGasto.ToString().ToUpper()
	cg.BreadcrumbCode + ' - ' + cg.Descripcion + ' (' + UPPER(CAST(cg.IdClasificacionGasto AS VARCHAR(16))) + ')' as	clasificacionGasto,
	fufi.BreadcrumbCode + ' - ' + fufi.Descripcion + ' (' + UPPER(CAST(fufi.IdFuenteFinanciamiento AS VARCHAR(16))) + ')' as	fuenteFinanciamientoGasto,
	--"{0} - ({1})", x.Nombre, x.IdMoneda.ToString().ToUpper()))
	m.Nombre + ' (' + UPPER(CAST(m.IdMoneda AS VARCHAR(16))) + ')' as	moneda,
	peep.Periodo as	anio,
	peep.MontoCalculado as	monto
	FROM Proyecto p
		INNER JOIN #ProjectIdSplited FP on p.IdProyecto = FP.Data
		INNER JOIN Estado e on e.IdEstado=p.IdEstado
		INNER JOIN ProyectoTipo ptipo on ptipo.IdProyectoTipo=p.IdTipoProyecto
		INNER JOIN SubPrograma sprog on sprog.IdSubPrograma=p.IdSubPrograma
		LEFT JOIN Programa prog on prog.IdPrograma=sprog.IdPrograma
		LEFT JOIN Saf on Saf.IdSaf=prog.idsaf

		LEFT JOIN ProyectoEtapa pe on pe.IdProyecto=p.IdProyecto
		INNER JOIN Etapa et on et.IdEtapa = pe.IdEtapa

		LEFT JOIN Proceso pro on pro.IdProceso=p.IdProceso
		LEFT JOIN FinalidadFuncion ff on ff.IdFinalidadFuncion=p.IdFinalidadFuncion
		LEFT JOIN OrganismoPrioridad op on op.IdOrganismoPrioridad=p.IdOrganismoPrioridad

		LEFT JOIN ProyectoLocalizacion pl on p.IdProyecto = pl.IdProyecto
		INNER JOIN ClasificacionGeografica cgeo on pl.IdClasificacionGeografica = cgeo.IdClasificacionGeografica

		LEFT JOIN ProyectoOficinaPerfil pop on pop.IdProyecto = p.IdProyecto 
		INNER JOIN Perfil on pop.IdPerfil = Perfil.IdPerfil
		INNER JOIN Oficina ofi on ofi.IdOficina = pop.IdOficina

		LEFT JOIN ProyectoEtapaEstimado pee on pee.IdProyectoEtapa = pe.IdProyectoEtapa
		INNER JOIN Moneda m on m.IdMoneda = pee.IdMoneda
		LEFT JOIN ProyectoEtapaEstimadoPeriodo peep on peep.IdProyectoEtapaEstimado = pee.IdProyectoEtapaEstimado
		LEFT JOIN ClasificacionGasto cg on cg.IdClasificacionGasto = pee.IdClasificacionGasto
		LEFT JOIN FuenteFinanciamiento fufi on fufi.IdFuenteFinanciamiento = pee.IdFuenteFinanciamiento
--sistemaEntidadEstado

	where 
		et.IdFase = 2 --Ejecucion
		and Perfil.Codigo = 'INIC'
END

GO