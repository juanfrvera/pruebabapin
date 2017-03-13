using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoData : _PrestamoData
    {
	   #region Singleton
	   private static volatile PrestamoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoData() {}
	   public static PrestamoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamo"; } }

       protected override IQueryable<Prestamo> Query(PrestamoFilter filter)
       {
           string strIdOfic = filter.IdOficinaResponsable.HasValue ? filter.IdOficinaResponsable.Value.ToString() : string.Empty;

           string strIdFinalidadFuncion = filter.IdFinalidadFuncion.HasValue ? "." + filter.IdFinalidadFuncion.Value.ToString() + "." : string.Empty;

           IQueryable<Prestamo> query =(from o in this.Table
                   where

                    (filter.Numero != null && filter.UnicamentePorCodigo != null && filter.UnicamentePorCodigo == true && o.Numero == filter.Numero)
                    ||
                    (
                       #region Filter
                       (filter.Numero == null || filter.Numero == 0 || filter.Numero == o.Numero)
                       && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo == filter.IdPrestamo)
                       && (filter.IdPrograma == null || filter.IdPrograma == 0 || o.IdPrograma == filter.IdPrograma)
                       && (filter.Activo == null || filter.Activo == o.Activo)
                       && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                       && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                       && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%" || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%", ""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%", ""))) || o.Observacion == filter.Observacion)
                       && (filter.CodigoVinculacion1 == null || filter.CodigoVinculacion1.Trim() == string.Empty || filter.CodigoVinculacion1.Trim() == "%" || (filter.CodigoVinculacion1.EndsWith("%") && filter.CodigoVinculacion1.StartsWith("%") && (o.CodigoVinculacion1.Contains(filter.CodigoVinculacion1.Replace("%", "")))) || (filter.CodigoVinculacion1.EndsWith("%") && o.CodigoVinculacion1.StartsWith(filter.CodigoVinculacion1.Replace("%", ""))) || (filter.CodigoVinculacion1.StartsWith("%") && o.CodigoVinculacion1.EndsWith(filter.CodigoVinculacion1.Replace("%", ""))) || o.CodigoVinculacion1 == filter.CodigoVinculacion1)
                       && (filter.CodigoVinculacion2 == null || filter.CodigoVinculacion2.Trim() == string.Empty || filter.CodigoVinculacion2.Trim() == "%" || (filter.CodigoVinculacion2.EndsWith("%") && filter.CodigoVinculacion2.StartsWith("%") && (o.CodigoVinculacion2.Contains(filter.CodigoVinculacion2.Replace("%", "")))) || (filter.CodigoVinculacion2.EndsWith("%") && o.CodigoVinculacion2.StartsWith(filter.CodigoVinculacion2.Replace("%", ""))) || (filter.CodigoVinculacion2.StartsWith("%") && o.CodigoVinculacion2.EndsWith(filter.CodigoVinculacion2.Replace("%", ""))) || o.CodigoVinculacion2 == filter.CodigoVinculacion2)
                       && (filter.ResponsablePolitico == null || filter.ResponsablePolitico.Trim() == string.Empty || filter.ResponsablePolitico.Trim() == "%" || (filter.ResponsablePolitico.EndsWith("%") && filter.ResponsablePolitico.StartsWith("%") && (o.ResponsablePolitico.Contains(filter.ResponsablePolitico.Replace("%", "")))) || (filter.ResponsablePolitico.EndsWith("%") && o.ResponsablePolitico.StartsWith(filter.ResponsablePolitico.Replace("%", ""))) || (filter.ResponsablePolitico.StartsWith("%") && o.ResponsablePolitico.EndsWith(filter.ResponsablePolitico.Replace("%", ""))) || o.ResponsablePolitico == filter.ResponsablePolitico)
                       && (filter.ResponsableTecnico == null || filter.ResponsableTecnico.Trim() == string.Empty || filter.ResponsableTecnico.Trim() == "%" || (filter.ResponsableTecnico.EndsWith("%") && filter.ResponsableTecnico.StartsWith("%") && (o.ResponsableTecnico.Contains(filter.ResponsableTecnico.Replace("%", "")))) || (filter.ResponsableTecnico.EndsWith("%") && o.ResponsableTecnico.StartsWith(filter.ResponsableTecnico.Replace("%", ""))) || (filter.ResponsableTecnico.StartsWith("%") && o.ResponsableTecnico.EndsWith(filter.ResponsableTecnico.Replace("%", ""))) || o.ResponsableTecnico == filter.ResponsableTecnico)
                       && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >= filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
                       && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >= filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
                       && (filter.IdUsuarioModificacion == null || o.IdUsuarioModificacion >= filter.IdUsuarioModificacion) && (filter.IdUsuarioModificacion_To == null || o.IdUsuarioModificacion <= filter.IdUsuarioModificacion_To)
                       //Agregados
                       && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || (filter.IdSaf != null && filter.IdSaf != 0) || (from p in this.Context.Programas where (from s in this.Context.Safs where s.IdJurisdiccion == filter.IdJurisdiccion select s.IdSaf).Contains(p.IdSAF) select p.IdPrograma).Contains(o.IdPrograma))
                       && (filter.IdSaf == null || filter.IdSaf == 0 || (filter.IdPrograma != null && filter.IdPrograma != 0) || (from p in this.Context.Programas where p.IdSAF == filter.IdSaf select p.IdPrograma).Contains(o.IdPrograma))
                       && (filter.IdPrograma == null || filter.IdPrograma == 0 || (from p in this.Context.Prestamos where p.IdPrograma == filter.IdPrograma select p.IdPrestamo).Contains(o.IdPrestamo))
                       && (filter.IdOrganismoFinanciero == null || filter.IdOrganismoFinanciero == 0 || (from pc in this.Context.PrestamoConvenios where pc.IdOrganismoFinanciero == filter.IdOrganismoFinanciero select pc.IdPrestamo).Contains(o.IdPrestamo))
                       && (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || filter.IncluirFinalidadFuncionInteriores == true || (from pff in this.Context.PrestamoFinalidadFuncions where pff.IdFinalidadFuncion == filter.IdFinalidadFuncion select pff.IdPrestamo).Contains(o.IdPrestamo))
                       && (filter.IdOficinaResponsable == null || filter.IdOficinaResponsable == 0 || filter.IncluirOficinasInteriores == true || (from po in this.Context.PrestamoOficinaPerfils where po.IdOficina == filter.IdOficinaResponsable select po.IdPrestamo).Contains(o.IdPrestamo))
                       && (filter.IncluirOficinasInteriores == null || filter.IncluirOficinasInteriores == false || filter.IdOficinaResponsable == null || strIdOfic == string.Empty
                              || (from pop in this.Context.PrestamoOficinaPerfils join of in this.Context.Oficinas on pop.IdOficina equals of.IdOficina where of.BreadcrumbId.Contains(strIdOfic) select pop.IdPrestamo).Contains(o.IdPrestamo))
                       && (filter.CodBapinAsociado == null || filter.CodBapinAsociado == 0 
                           || (
                               (from pc in this.Context.PrestamoComponentes 
                                join pp in this.Context.PrestamoProductos on pc.IdPrestamoComponente equals pp.IdPrestamoComponente
                                join p in this.Context.Proyectos on pp.IdProyecto equals p.IdProyecto
                                where p.Codigo == filter.CodBapinAsociado 
                                select pc.IdPrestamo).Contains(o.IdPrestamo)
                               )
                           )
                       && (filter.IncluirFinalidadFuncionInteriores == null || filter.IncluirFinalidadFuncionInteriores == false || filter.IdFinalidadFuncion == null || strIdFinalidadFuncion == string.Empty
                              || (from pf in this.Context.PrestamoFinalidadFuncions where (from ff in this.Context.FinalidadFuncions where ff.BreadcrumbId.Contains(strIdFinalidadFuncion) select ff.IdFinalidadFuncion).Contains(pf.IdFinalidadFuncion) select pf.IdPrestamo).Contains(o.IdPrestamo))
                    #endregion   
                    )
                   select o
                   ).AsQueryable();
              return query;
       }	
       protected override IQueryable<PrestamoResult> QueryResult(PrestamoFilter filter)
       {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Programas on o.IdPrograma equals t1.IdPrograma
                  join t2 in this.Context.Safs on t1.IdSAF equals t2.IdSaf
                  join t3 in this.Context.Jurisdiccions on t2.IdJurisdiccion equals t3.IdJurisdiccion
                  join _t5 in this.Context.PrestamoConvenios on o.IdPrestamo equals _t5.IdPrestamo into t5 from tt5 in t5.DefaultIfEmpty()
                  join _t6 in this.Context.OrganismoFinancieros on tt5.IdOrganismoFinanciero equals _t6.IdOrganismoFinanciero into t6 from tt6 in t6.DefaultIfEmpty()
                  join _t4 in this.Context.Estados on o.IdEstadoActual equals _t4.IdEstado into t4
                  from tt4 in t4.DefaultIfEmpty()
                  join _sector in this.Context.Sectors on t2.IdSector  equals _sector.IdSector into tsector from sector in tsector.DefaultIfEmpty()
                  join _at in this.Context.AdministracionTipos on t2.IdAdministracionTipo equals _at.IdAdministracionTipo into tat from at in tat.DefaultIfEmpty()
                  join _et in this.Context.EntidadTipos on t2.IdEntidadTipo equals _et.IdEntidadTipo into tet from et in tet.DefaultIfEmpty()
                  where(filter.IdsOficinaByUsuario == null || filter.IdsOficinaByUsuario.Count == 0 || (from pop in this.Context.PrestamoOficinaPerfils where filter.IdsOficinaByUsuario.Contains(pop.IdOficina) select pop.IdPrestamo).Contains(o.IdPrestamo))
                    && (filter.IdOficina == null || filter.IdOficina == 0 || (from pop in this.Context.PrestamoOficinaPerfils where filter.IdOficina == pop.IdOficina select pop.IdPrestamo).Contains(o.IdPrestamo))
                  select new PrestamoResult(){
					 IdPrestamo=o.IdPrestamo
					 ,IdPrograma=o.IdPrograma
					 ,Numero=o.Numero
					 ,Denominacion=o.Denominacion
					 ,Descripcion=o.Descripcion
					 ,Observacion=o.Observacion
					 ,CodigoVinculacion1=o.CodigoVinculacion1
                     ,CodigoVinculacion2 = o.CodigoVinculacion2
                     ,ResponsablePolitico = o.ResponsablePolitico
                     ,ResponsableTecnico = o.ResponsableTecnico
					 ,FechaAlta=o.FechaAlta
					 ,FechaModificacion=o.FechaModificacion
					 ,IdUsuarioModificacion=o.IdUsuarioModificacion
                     ,Activo=o.Activo
					,Programa_IdSAF= t1.IdSAF	
						,Programa_Codigo= t1.Codigo	
						,Programa_Nombre= t1.Nombre	
						,Programa_FechaAlta= t1.FechaAlta	
						,Programa_FechaBaja= t1.FechaBaja	
						,Programa_Activo= t1.Activo
                        ,Saf_Jurisdiccion = t3.Codigo
                        ,Saf_Nombre = t2.Denominacion
                        ,Saf_Codigo = t2.Codigo
                        ,Saf_Id = t2.IdSaf
                        ,Estado_Nombre = tt4!=null?(string)tt4.Nombre:null	
                        ,Monto = tt5!=null?(decimal?)tt5.MontoPrestamo:null
                        ,MontoTotal = tt5!=null?(decimal?)tt5.MontoTotal:null
	                    ,Nro_Bnc = tt5!=null? (string)tt5.Numero:null
                        ,Sigla = tt5!=null? (string)tt5.Sigla:null
                        ,OrganismoFinanciero_Nombre = tt6!=null?(string)tt6.Nombre:null	
                        ,Saf_SectorNombre = sector!=null? sector.Nombre:""
                        ,Saf_AdministracionTipoNombre =at!=null? at.Nombre:""
                        ,Saf_EntidadTipoNombre = et!=null? et.Nombre:""
						}
                    ).AsQueryable();
        }
        /// <summary>
        /// Retorna el result de los Prestamos con sus PerfilesPorOficina
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>     
       public virtual ListPaged<PrestamoResult> GetResultWithOfficePerfil(PrestamoFilter filter)
        {
            ListPaged<PrestamoResult> result = GetResult(filter);
            List<int> ids = (from o in result select o.IdPrestamo).ToList();
            List<PrestamoOficinaPerfilResult> PrestamoOficinaPerfiles = PrestamoOficinaPerfilData.Current.GetResult(new PrestamoOficinaPerfilFilter() { IdsPrestamo = ids });
            result.ForEach(p => p.PerfilOficinas = (from o in PrestamoOficinaPerfiles where o.IdPrestamo == p.IdPrestamo select new PerfilOficina() { IdOficina = o.IdOficina, IdPerfil = o.IdPerfil, Oficina_BreadcrumbId = o.Oficina_BreadcrumbId }).ToList());
            return result;
        }

       public List<PrestamoObjetivoReportResult> GetPrestamoObjetivo2(PrestamoFilter filter)
        {
            var query=(
                from o in (
                      from p in Query(filter)
                      join pp in this.Context.PrestamoObjetivos on p.IdPrestamo equals pp.IdPrestamo
                      join o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
                      join os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals os.IdObjetivo 
                      //obligo a que no encuentre nada, comparando el idobjetivo a 0
                      //porque no me permite campos definidos en el select en blanco 
                      join _oi in this.Context.ObjetivoIndicadors on 0 equals _oi.IdObjetivo into toi
                      from oi in toi.DefaultIfEmpty()
                      join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
                      from ic in tic.DefaultIfEmpty()
                      join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
                      from um in tum.DefaultIfEmpty()
                      join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
                      from i in ti.DefaultIfEmpty()
                      join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                      from mv in tmv.DefaultIfEmpty()
                      join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                      from ie in tie.DefaultIfEmpty()
                      join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                      from iei in tiei.DefaultIfEmpty()
                      join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                      from cg in tcg.DefaultIfEmpty()
                      select new PrestamoObjetivoReportResult()
                      {
                          PrestamoObjetivo_ID = o.IdObjetivo
                          ,ProyectoObjetivo_Nombre=o.Nombre
                          ,ObjetivoSupuesto_Id =  os.IdObjetivoSupuesto 
                          ,ObjetivoSupuesto_Descripcion =  os.Descripcion 
                          ,IdIndicador = oi!= null ? oi.IdObjetivoIndicador :0
                          ,Indicador_Sigla=ic!= null ? ic.Sigla  : string.Empty
                          ,Indicador_Descripcion =ic!= null ? ic.Nombre  : string.Empty
                          ,Unidad_Sigla = um!= null ? um.Sigla : string.Empty
                          ,Unidad_Descripcion=um!= null ? um.Nombre : string.Empty
                          ,MedioVerificacion_Sigla = mv!= null ?  mv.Sigla : string.Empty
                          ,MedioVerificacion_Nombre = mv!= null ? mv.Nombre : string.Empty
                          ,Indicador_Observacion =i!= null ?  i.Observacion : string.Empty
                          ,ClasificacionGeografica_ID=cg!= null ? cg.IdClasificacionGeografica :0 
                          ,ClasificacionGeografica_Descripcion =cg!= null ?   cg.Descripcion  : string.Empty
                          ,IndicadorEvolucionInstancia_Nombre = iei!= null ? iei.Nombre  : string.Empty
                          ,FechaEstimada = ie.FechaEstimada 
                          ,CantidadEstimada = ie!= null ? ie.CantidadEstimada :0
                          ,FechaReal = ie.FechaReal
                          ,CantidadReal = ie!= null ?   ie.CantidadReal : 0
                      }
                    ).Union (
                     from  p in this.Query (filter)
                     join pp in this.Context.PrestamoObjetivos on p.IdPrestamo equals pp.IdPrestamo
                     join  o in this.Context.Objetivos on pp.IdObjetivo equals o.IdObjetivo
                     //obligo a que no encuentre supuestos, comparando el idobjetivosupuesto a 0
                     //porque no me permite campos definidos en el select en blanco 
                     join _os in this.Context.ObjetivoSupuestos on 0 equals _os.IdObjetivo into tos from os in tos.DefaultIfEmpty()
                     join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo equals _oi.IdObjetivo into toi
                      from oi in toi.DefaultIfEmpty()
                      join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic
                      from ic in tic.DefaultIfEmpty()
                      join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum
                      from um in tum.DefaultIfEmpty()
                      join _i in this.Context.Indicadors on oi.IdIndicador equals _i.IdIndicador into ti
                      from i in ti.DefaultIfEmpty()
                      join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion equals _mv.IdMedioVerificacion into tmv
                      from mv in tmv.DefaultIfEmpty()
                      join _ie in this.Context.IndicadorEvolucions on i.IdIndicador equals _ie.IdIndicador into tie
                      from ie in tie.DefaultIfEmpty()
                      join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia into tiei
                      from iei in tiei.DefaultIfEmpty()
                      join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg
                      from cg in tcg.DefaultIfEmpty()
                     select new PrestamoObjetivoReportResult()
                     {
                          PrestamoObjetivo_ID=o.IdObjetivo
                          ,ProyectoObjetivo_Nombre=o.Nombre
                          ,ObjetivoSupuesto_Id = os!=null ? os.IdObjetivoSupuesto : 999999999
                          ,ObjetivoSupuesto_Descripcion =  os!=null ? os.Descripcion : string.Empty	
                          ,IdIndicador = oi!= null ? oi.IdObjetivoIndicador :0 
                          ,Indicador_Sigla=ic!= null ? ic.Sigla  : string.Empty
                          ,Indicador_Descripcion =ic!= null ? ic.Nombre  : string.Empty
                          ,Unidad_Sigla = um!= null ? um.Sigla : string.Empty
                          ,Unidad_Descripcion=um!= null ? um.Nombre : string.Empty
                          ,MedioVerificacion_Sigla = mv!= null ?  mv.Sigla : string.Empty
                          ,MedioVerificacion_Nombre = mv!= null ? mv.Nombre : string.Empty
                          ,Indicador_Observacion =i!= null ?  i.Observacion : string.Empty
                          ,ClasificacionGeografica_ID=cg!= null ? cg.IdClasificacionGeografica :0 
                          ,ClasificacionGeografica_Descripcion =cg!= null ?   cg.Descripcion  : string.Empty
                          ,IndicadorEvolucionInstancia_Nombre = iei!= null ? iei.Nombre  : string.Empty
                          ,FechaEstimada = ie.FechaEstimada 
                          ,CantidadEstimada = ie!= null ? ie.CantidadEstimada :0
                          ,FechaReal = ie.FechaReal
                          ,CantidadReal = ie!= null ?   ie.CantidadReal : 0 
                      }
                    )
                orderby o.PrestamoObjetivo_ID, o.ObjetivoSupuesto_Id, o.IdIndicador, o.ClasificacionGeografica_ID, o.FechaEstimada
                select o
                ).AsQueryable ();

            return query.ToList();
                      
        }


       public List<PrestamoObjetivoReportResult> GetPrestamoObjetivo(PrestamoFilter filter)
       { 
           var query= (
                from p in this.Context.Prestamos  
                join po in Context.PrestamoObjetivos   on p.IdPrestamo  equals po.IdPrestamo  
                join o in this.Context.Objetivos on po.IdObjetivo equals  o.IdObjetivo 
                join _os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals  _os.IdObjetivo into tos from os in tos.DefaultIfEmpty()
                join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo  equals  _oi.IdObjetivo into toi from oi in toi.DefaultIfEmpty()
                join _i in this.Context.Indicadors on  oi.IdIndicador equals _i.IdIndicador into ti from i in ti.DefaultIfEmpty()
                join _ie in this.Context.IndicadorEvolucions on i.IdIndicador  equals _ie.IdIndicador into tie from ie in tie.DefaultIfEmpty()
                join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion  equals _mv.IdMedioVerificacion into tmv from mv in tmv.DefaultIfEmpty()
                join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg from cg in tcg.DefaultIfEmpty()
                join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia   into tiei from iei in tiei.DefaultIfEmpty()
                join _ic in this.Context.IndicadorClases on oi.IdIndicadorClase equals _ic.IdIndicadorClase into tic from ic in tic.DefaultIfEmpty()
                join _um in this.Context.UnidadMedidas on ic.IdUnidad equals _um.IdUnidadMedida into tum from um in tum.DefaultIfEmpty()
                where filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == p.IdPrestamo
                select new PrestamoObjetivoReportResult()
                {
                    ProyectoObjetivo_Nombre = o.Nombre 
                    , ObjetivoSupuesto_Descripcion  = os!=null? os.Descripcion:String.Empty 
                    , Indicador_Observacion = i!=null?i.Observacion :String.Empty 
                    , MedioVerificacion_Sigla  =mv!=null? mv.Sigla :String.Empty 
                    , MedioVerificacion_Nombre = mv!=null? mv.Nombre :String.Empty 
                    , ClasificacionGeografica_Descripcion= cg!=null?cg.Descripcion:String.Empty 
                    , IndicadorEvolucionInstancia_Nombre= iei!=null?iei.Nombre	:String.Empty 
                    , FechaEstimada = ie.FechaEstimada 
                    , CantidadEstimada=ie!=null?ie.CantidadEstimada:0 
                    , FechaReal = ie.FechaReal 
                    , CantidadReal = ie.CantidadReal
                    , IdIndicadorEvolucion = ie!=null?ie.IdIndicadorEvolucion:0
                    , IdIndicador = i!=null?i.IdIndicador:0
                    , Indicador_Sigla = ic != null ? ic.Sigla : string.Empty
                    , Indicador_Descripcion = ic != null ? ic.Nombre : string.Empty
                    , Unidad_Sigla = um != null ? um.Sigla : string.Empty
                    , Unidad_Descripcion = um != null ? um.Nombre : string.Empty
                }
            );
           return query.ToList(); 
        } 
       public List<PrestamoObjetivoReportResult> GetPrestamoObjetivosEspecificos(PrestamoFilter filter)
        { 
           var query= (
                from p in this.Context.Prestamos  
                join po in Context.PrestamoObjetivoEspecificos   on p.IdPrestamo  equals po.IdPrestamo  
                join o in this.Context.Objetivos on po.IdObjetivo equals  o.IdObjetivo 
                join _os in this.Context.ObjetivoSupuestos on o.IdObjetivo equals  _os.IdObjetivo into tos from os in tos.DefaultIfEmpty()
                join _oi in this.Context.ObjetivoIndicadors on o.IdObjetivo  equals  _oi.IdObjetivo into toi from oi in toi.DefaultIfEmpty()
                join _i in this.Context.Indicadors on  oi.IdIndicador equals _i.IdIndicador into ti from i in ti.DefaultIfEmpty()
                join _ie in this.Context.IndicadorEvolucions on i.IdIndicador  equals _ie.IdIndicador into tie from ie in tie.DefaultIfEmpty()
                join _mv in this.Context.MedioVerificacions on i.IdMedioVerificacion  equals _mv.IdMedioVerificacion into tmv from mv in tmv.DefaultIfEmpty()
                join _cg in this.Context.ClasificacionGeograficas on ie.IdClasificacionGeografica equals _cg.IdClasificacionGeografica into tcg from cg in tcg.DefaultIfEmpty()
                join _iei in this.Context.IndicadorEvolucionInstancias on ie.IdIndicadorEvolucionInstancia equals _iei.IdIndicadorEvolucionInstancia   into tiei from iei in tiei.DefaultIfEmpty()

                where filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == p.IdPrestamo
                select new PrestamoObjetivoReportResult()
                {
                    ProyectoObjetivo_Nombre = o.Nombre 
                    , ObjetivoSupuesto_Descripcion  = os!=null? os.Descripcion:String.Empty 
                    , Indicador_Observacion = i!=null?i.Observacion :String.Empty 
                    , MedioVerificacion_Sigla  =mv!=null? mv.Sigla :String.Empty 
                    , MedioVerificacion_Nombre = mv!=null? mv.Nombre :String.Empty 
                    , ClasificacionGeografica_Descripcion= cg!=null?cg.Descripcion:String.Empty 
                    , IndicadorEvolucionInstancia_Nombre= iei!=null?iei.Nombre	:String.Empty 
                    , FechaEstimada = ie.FechaEstimada 
                    , CantidadEstimada=ie!=null?ie.CantidadEstimada:0 
                    , FechaReal = ie.FechaReal 
                    , CantidadReal = ie.CantidadReal
                    , IdIndicadorEvolucion = ie!=null?ie.IdIndicadorEvolucion:0
                    , IdIndicador = i!=null?i.IdIndicador:0 
                }
            );
           return query.ToList(); 
        }
       public List<PrestamoComponentesReportResult> GetPrestamoComponentes(PrestamoFilter filter)
        {
            var query = (
                //Matias 20161202 - Bug impresion de Componentes de un Prestamo
                /*
                 * from p in this.Context.Prestamos
                join pc in Context.PrestamoComponentes on p.IdPrestamo equals pc.IdPrestamo
                //join psc in this.Context.PrestamoSubComponentes on pc.IdPrestamoComponente equals psc.IdPrestamoComponente
                join _t5 in this.Context.PrestamoSubComponentes on pc.IdPrestamoComponente equals _t5.IdPrestamoComponente into t5
                from tt5 in t5.DefaultIfEmpty()
                join pf in this.Context.PrestamoFinanciamientos on new { IdPrestamoSubComponente = psc.IdPrestamoSubComponente, IdPrestamoComponente = psc.IdPrestamoComponente } equals new { IdPrestamoSubComponente = pf.IdPrestamoSubComponente.HasValue ? pf.IdPrestamoSubComponente.Value : 0, IdPrestamoComponente = pf.IdPrestamoComponente }
                join ff in this.Context.FuenteFinanciamientos on pf.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento 
                join o in this.Context.Objetivos on pc.IdObjetivo equals o.IdObjetivo
                where filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == p.IdPrestamo
                */

                from p in this.Context.Prestamos
                join pc in Context.PrestamoComponentes on p.IdPrestamo equals pc.IdPrestamo
                //join psc in this.Context.PrestamoSubComponentes on pc.IdPrestamoComponente equals psc.IdPrestamoComponente
                join _t5 in this.Context.PrestamoSubComponentes on pc.IdPrestamoComponente equals _t5.IdPrestamoComponente into t5 from tt5 in t5.DefaultIfEmpty()
                join pf in this.Context.PrestamoFinanciamientos on new { IdPrestamoSubComponente = tt5.IdPrestamoSubComponente != null ? tt5.IdPrestamoSubComponente : 0, IdPrestamoComponente = pc.IdPrestamoComponente } equals new { IdPrestamoSubComponente = pf.IdPrestamoSubComponente.Value, IdPrestamoComponente = pf.IdPrestamoComponente }
                join ff in this.Context.FuenteFinanciamientos on pf.IdFuenteFinanciamiento equals ff.IdFuenteFinanciamiento
                join o in this.Context.Objetivos on pc.IdObjetivo equals o.IdObjetivo
                where filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == p.IdPrestamo
                //FinMatias 20161202 - Bug impresion de Componentes de un Prestamo
                
                // select new PrestamoComponentes() { 

                select new PrestamoComponentesReportResult()
                { 
                    Componente_Nombre = o.Nombre 
                    ,SubComponente_Descripcion = tt5.Descripcion 
                    ,FuenteFinanciamiento_Nombre = ff.Nombre    
                    ,PrestamoFinanciamiento_Monto = pf.Monto 
                }
            );
           return query.ToList(); 
        } 
    }
}
