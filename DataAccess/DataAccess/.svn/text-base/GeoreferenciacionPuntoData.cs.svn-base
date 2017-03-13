using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class GeoreferenciacionPuntoData : _GeoreferenciacionPuntoData
    {  
	   #region Singleton
	   private static volatile GeoreferenciacionPuntoData current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionPuntoData() {}
	   public static GeoreferenciacionPuntoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionPuntoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdGeoreferenciacionPunto"; } } 
        protected override IQueryable<GeoreferenciacionPunto> Query(GeoreferenciacionPuntoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdGeoreferenciacionPunto == null || o.IdGeoreferenciacionPunto >=  filter.IdGeoreferenciacionPunto) && (filter.IdGeoreferenciacionPunto_To == null || o.IdGeoreferenciacionPunto <= filter.IdGeoreferenciacionPunto_To)
					  && (filter.IdGeoreferenciacion == null || filter.IdGeoreferenciacion == 0 || o.IdGeoreferenciacion==filter.IdGeoreferenciacion)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Longitud == null || o.Longitud >=  filter.Longitud) && (filter.Longitud_To == null || o.Longitud <= filter.Longitud_To)
					  && (filter.Latitud == null || o.Latitud >=  filter.Latitud) && (filter.Latitud_To == null || o.Latitud <= filter.Latitud_To)
					  && (filter.descripcion == null || filter.descripcion.Trim() == string.Empty || filter.descripcion.Trim() == "%"  || (filter.descripcion.EndsWith("%") && filter.descripcion.StartsWith("%") && (o.descripcion.Contains(filter.descripcion.Replace("%", "")))) || (filter.descripcion.EndsWith("%") && o.descripcion.StartsWith(filter.descripcion.Replace("%",""))) || (filter.descripcion.StartsWith("%") && o.descripcion.EndsWith(filter.descripcion.Replace("%",""))) || o.descripcion == filter.descripcion )
                      && ( filter.IdProyecto == null || filter.IdProyecto == 0 || 
                            (from pg in this.Context.ProyectoGeoreferenciacions 
                             where pg.IdProyecto == filter.IdProyecto 
                             select pg.IdProyectoGeoreferenciacion).Contains ( o.IdGeoreferenciacion) 
                        )
					  select o
                    ).AsQueryable();
        }
	       protected override IQueryable<GeoreferenciacionPuntoResult> QueryResult(GeoreferenciacionPuntoFilter filter)
        {
		  return (from o in Query(filter)					
					join t1  in this.Context.Georeferenciacions on o.IdGeoreferenciacion equals t1.IdGeoreferenciacion   
				    join t2  in this.Context.GeoreferenciacionTipos on t1.IdGeoreferenciacionTipo equals t2.IdGeoreferenciacionTipo   
				   
                  select new GeoreferenciacionPuntoResult(){
					 IdGeoreferenciacionPunto=o.IdGeoreferenciacionPunto
					 ,IdGeoreferenciacion=o.IdGeoreferenciacion
					 ,Orden=o.Orden
					 ,Longitud=o.Longitud
					 ,Latitud=o.Latitud
					 ,descripcion=o.descripcion
					,Georeferenciacion_IdGeoreferenciacionTipo= t1.IdGeoreferenciacionTipo
                    , GeoreferenciacionTipo_Nombre = t2.Nombre
	                }
                    ).AsQueryable();
        }
      
        
    }
}
