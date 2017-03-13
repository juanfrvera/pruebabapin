using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _GeoreferenciacionPuntoData : EntityData<GeoreferenciacionPunto,GeoreferenciacionPuntoFilter,GeoreferenciacionPuntoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.GeoreferenciacionPunto entity)
		{			
			return entity.IdGeoreferenciacionPunto;
		}		
		public override GeoreferenciacionPunto GetByEntity(GeoreferenciacionPunto entity)
        {
            return this.GetById(entity.IdGeoreferenciacionPunto);
        }
        public override GeoreferenciacionPunto GetById(int id)
        {
            return (from o in this.Table where o.IdGeoreferenciacionPunto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<GeoreferenciacionPunto> Query(GeoreferenciacionPuntoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdGeoreferenciacionPunto == null || o.IdGeoreferenciacionPunto >=  filter.IdGeoreferenciacionPunto) && (filter.IdGeoreferenciacionPunto_To == null || o.IdGeoreferenciacionPunto <= filter.IdGeoreferenciacionPunto_To)
					  && (filter.IdGeoreferenciacion == null || filter.IdGeoreferenciacion == 0 || o.IdGeoreferenciacion==filter.IdGeoreferenciacion)
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Longitud == null || o.Longitud >=  filter.Longitud) && (filter.Longitud_To == null || o.Longitud <= filter.Longitud_To)
					  && (filter.Latitud == null || o.Latitud >=  filter.Latitud) && (filter.Latitud_To == null || o.Latitud <= filter.Latitud_To)
					  && (filter.descripcion == null || filter.descripcion.Trim() == string.Empty || filter.descripcion.Trim() == "%"  || (filter.descripcion.EndsWith("%") && filter.descripcion.StartsWith("%") && (o.descripcion.Contains(filter.descripcion.Replace("%", "")))) || (filter.descripcion.EndsWith("%") && o.descripcion.StartsWith(filter.descripcion.Replace("%",""))) || (filter.descripcion.StartsWith("%") && o.descripcion.EndsWith(filter.descripcion.Replace("%",""))) || o.descripcion == filter.descripcion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<GeoreferenciacionPuntoResult> QueryResult(GeoreferenciacionPuntoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Georeferenciacions on o.IdGeoreferenciacion equals t1.IdGeoreferenciacion   
				   select new GeoreferenciacionPuntoResult(){
					 IdGeoreferenciacionPunto=o.IdGeoreferenciacionPunto
					 ,IdGeoreferenciacion=o.IdGeoreferenciacion
					 ,Orden=o.Orden
					 ,Longitud=o.Longitud
					 ,Latitud=o.Latitud
					 ,descripcion=o.descripcion
					,Georeferenciacion_IdGeoreferenciacionTipo= t1.IdGeoreferenciacionTipo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.GeoreferenciacionPunto Copy(nc.GeoreferenciacionPunto entity)
        {           
            nc.GeoreferenciacionPunto _new = new nc.GeoreferenciacionPunto();
		 _new.IdGeoreferenciacion= entity.IdGeoreferenciacion;
		 _new.Orden= entity.Orden;
		 _new.Longitud= entity.Longitud;
		 _new.Latitud= entity.Latitud;
		 _new.descripcion= entity.descripcion;
		return _new;			
        }
		public override int CopyAndSave(GeoreferenciacionPunto entity,string renameFormat)
        {
            GeoreferenciacionPunto  newEntity = Copy(entity);
            newEntity.descripcion = string.Format(renameFormat,newEntity.descripcion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(GeoreferenciacionPunto entity, int id)
        {            
            entity.IdGeoreferenciacionPunto = id;            
        }
		public override void Set(GeoreferenciacionPunto source,GeoreferenciacionPunto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacionPunto= source.IdGeoreferenciacionPunto ;
		 target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.Orden= source.Orden ;
		 target.Longitud= source.Longitud ;
		 target.Latitud= source.Latitud ;
		 target.descripcion= source.descripcion ;
		 		  
		}
		public override void Set(GeoreferenciacionPuntoResult source,GeoreferenciacionPunto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacionPunto= source.IdGeoreferenciacionPunto ;
		 target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.Orden= source.Orden ;
		 target.Longitud= source.Longitud ;
		 target.Latitud= source.Latitud ;
		 target.descripcion= source.descripcion ;
		 
		}
		public override void Set(GeoreferenciacionPunto source,GeoreferenciacionPuntoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacionPunto= source.IdGeoreferenciacionPunto ;
		 target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.Orden= source.Orden ;
		 target.Longitud= source.Longitud ;
		 target.Latitud= source.Latitud ;
		 target.descripcion= source.descripcion ;
		 	
		}		
		public override void Set(GeoreferenciacionPuntoResult source,GeoreferenciacionPuntoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacionPunto= source.IdGeoreferenciacionPunto ;
		 target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.Orden= source.Orden ;
		 target.Longitud= source.Longitud ;
		 target.Latitud= source.Latitud ;
		 target.descripcion= source.descripcion ;
		 target.Georeferenciacion_IdGeoreferenciacionTipo= source.Georeferenciacion_IdGeoreferenciacionTipo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(GeoreferenciacionPunto source,GeoreferenciacionPunto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGeoreferenciacionPunto.Equals(target.IdGeoreferenciacionPunto))return false;
		  if(!source.IdGeoreferenciacion.Equals(target.IdGeoreferenciacion))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Longitud.Equals(target.Longitud))return false;
		  if(!source.Latitud.Equals(target.Latitud))return false;
		  if((source.descripcion == null)?target.descripcion!=null:  !( (target.descripcion== String.Empty && source.descripcion== null) || (target.descripcion==null && source.descripcion== String.Empty )) &&  !source.descripcion.Trim().Replace ("\r","").Equals(target.descripcion.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(GeoreferenciacionPuntoResult source,GeoreferenciacionPuntoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGeoreferenciacionPunto.Equals(target.IdGeoreferenciacionPunto))return false;
		  if(!source.IdGeoreferenciacion.Equals(target.IdGeoreferenciacion))return false;
		  if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Longitud.Equals(target.Longitud))return false;
		  if(!source.Latitud.Equals(target.Latitud))return false;
		  if((source.descripcion == null)?target.descripcion!=null: !( (target.descripcion== String.Empty && source.descripcion== null) || (target.descripcion==null && source.descripcion== String.Empty )) && !source.descripcion.Trim().Replace ("\r","").Equals(target.descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.Georeferenciacion_IdGeoreferenciacionTipo.Equals(target.Georeferenciacion_IdGeoreferenciacionTipo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
