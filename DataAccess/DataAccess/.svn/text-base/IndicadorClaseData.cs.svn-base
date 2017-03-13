using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorClaseData : _IndicadorClaseData
    {
	   #region Singleton
	   private static volatile IndicadorClaseData current;
	   private static object syncRoot = new Object();

	   //private IndicadorClaseData() {}
	   public static IndicadorClaseData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorClaseData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorClase"; } }   

       public override ListPaged<SimpleResult<int>> GetSimpleList(IndicadorClaseFilter filter)
       {
           return ListPaged<SimpleResult<int>>((from o in Query(filter)
                                                select new SimpleResult<int> 
                                                { ID = o.IdIndicadorClase, Text = o.Nombre }).AsQueryable(), filter);
       }

       protected override IQueryable<IndicadorClase> Query(IndicadorClaseFilter filter)
       {
           return (from o in base.Query(filter)
                   where (
                   
                   
                   (filter.IdIndicadorRubro == null || filter.IdIndicadorRubro == 0 || 
                           (from irr in this.Context.IndicadorRelacionRubros 
                           where irr.IdIndicadorRubro == filter.IdIndicadorRubro 
                           select irr.IdIndicadorClase).Contains(o.IdIndicadorClase))

                           && ((filter.BusquedaIndicador == null || filter.BusquedaIndicador == string.Empty || 
                                o.Nombre.Contains(filter.BusquedaIndicador) || o.Sigla.Contains(filter.BusquedaIndicador)                                
                                ))
                           
                           )
                   select o 
                   ).AsQueryable();
       }
       protected override IQueryable<IndicadorClaseResult> QueryResult(IndicadorClaseFilter filter)
       {
		  return (from o in Query(filter)					
				  join t1  in this.Context.IndicadorTipos on o.IdIndicadorTipo equals t1.IdIndicadorTipo   
				  join t2  in this.Context.UnidadMedidas on o.IdUnidad equals t2.IdUnidadMedida
				  select new IndicadorClaseResult(){
					 IdIndicadorClase=o.IdIndicadorClase
					 ,IdIndicadorTipo=o.IdIndicadorTipo
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,IdUnidad=o.IdUnidad
					 ,RangoInicial=o.RangoInicial
					 ,RangoFinal=o.RangoFinal
					 ,Activo=o.Activo
					,IndicadorTipo_Nombre= t1.Nombre	
					,IndicadorTipo_Activo= t1.Activo
	                ,IndicadorTipo_SectorRequerido= t1.SectorRequerido
					,Unidad_Sigla= t2.Sigla	
					,Unidad_Nombre= t2.Nombre	
					,Unidad_Activo= t2.Activo
                    //,IdIndicadorRubro = (from r in this.Context.IndicadorRelacionRubros 
                    //      where o.IdIndicadorClase == r.IdIndicadorClase 
                    //       select r.IdIndicadorRubro).FirstOrDefault()
						}
                    ).AsQueryable();
       }

       /*German 20140129 - tarea 110*/
       public ListPaged<NodeResult> GetNodesResult(IndicadorClaseFilter filter)
       {
           IQueryable<NodeResult> query =
               (from ff in QueryWithOrder(filter)
                select new NodeResult()
                {
                    Id = ff.IdIndicadorClase,
                    Text = ff.Nombre,
                    Codigo = Convert.ToString(ff.IdIndicadorClase),
                    Level = 1,
                    Orden = 1,
                    BreadcrumbId = Convert.ToString(ff.IdIndicadorClase),
                    BreadcrumbOrden = Convert.ToString(ff.IdIndicadorClase),
                    BreadcrumbCodigo = Convert.ToString(ff.IdIndicadorClase),
                    ParentId = null,
                    Descripcion = ff.Nombre,
                    DescripcionInvertida = ff.Nombre,
                    Seleccionable = true
                }).AsQueryable<NodeResult>();
           return ListPaged<NodeResult>(query, filter);
       }

       protected IQueryable<IndicadorClase> QueryWithOrder(IndicadorClaseFilter filter)
       {
           return (from o in base.Query(filter)
                   where (


                   (filter.IdIndicadorRubro == null || filter.IdIndicadorRubro == 0 ||
                           (from irr in this.Context.IndicadorRelacionRubros
                            where irr.IdIndicadorRubro == filter.IdIndicadorRubro
                            select irr.IdIndicadorClase).Contains(o.IdIndicadorClase))

                           && ((filter.BusquedaIndicador == null || filter.BusquedaIndicador == string.Empty ||
                                o.Nombre.Contains(filter.BusquedaIndicador) || o.Sigla.Contains(filter.BusquedaIndicador)
                                ))

                           )
                   orderby o.IdIndicadorClase
                   select o
                   ).AsQueryable();
       }
        /*Fin German 20140129 - tarea 110*/
      

    }
}
