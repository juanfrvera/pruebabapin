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
    public abstract class _GeoreferenciacionData : EntityData<Georeferenciacion,GeoreferenciacionFilter,GeoreferenciacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Georeferenciacion entity)
		{			
			return entity.IdGeoreferenciacion;
		}		
		public override Georeferenciacion GetByEntity(Georeferenciacion entity)
        {
            return this.GetById(entity.IdGeoreferenciacion);
        }
        public override Georeferenciacion GetById(int id)
        {
            return (from o in this.Table where o.IdGeoreferenciacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Georeferenciacion> Query(GeoreferenciacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdGeoreferenciacion == null || filter.IdGeoreferenciacion == 0 || o.IdGeoreferenciacion==filter.IdGeoreferenciacion)
					  && (filter.IdGeoreferenciacionTipo == null || filter.IdGeoreferenciacionTipo == 0 || o.IdGeoreferenciacionTipo==filter.IdGeoreferenciacionTipo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<GeoreferenciacionResult> QueryResult(GeoreferenciacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.GeoreferenciacionTipos on o.IdGeoreferenciacionTipo equals t1.IdGeoreferenciacionTipo   
				   select new GeoreferenciacionResult(){
					 IdGeoreferenciacion=o.IdGeoreferenciacion
					 ,IdGeoreferenciacionTipo=o.IdGeoreferenciacionTipo
					,GeoreferenciacionTipo_Nombre= t1.Nombre	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Georeferenciacion Copy(nc.Georeferenciacion entity)
        {           
            nc.Georeferenciacion _new = new nc.Georeferenciacion();
		 _new.IdGeoreferenciacionTipo= entity.IdGeoreferenciacionTipo;
		return _new;			
        }
		public override int CopyAndSave(Georeferenciacion entity,string renameFormat)
        {
            Georeferenciacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Georeferenciacion entity, int id)
        {            
            entity.IdGeoreferenciacion = id;            
        }
		public override void Set(Georeferenciacion source,Georeferenciacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.IdGeoreferenciacionTipo= source.IdGeoreferenciacionTipo ;
		 		  
		}
		public override void Set(GeoreferenciacionResult source,Georeferenciacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.IdGeoreferenciacionTipo= source.IdGeoreferenciacionTipo ;
		 
		}
		public override void Set(Georeferenciacion source,GeoreferenciacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.IdGeoreferenciacionTipo= source.IdGeoreferenciacionTipo ;
		 	
		}		
		public override void Set(GeoreferenciacionResult source,GeoreferenciacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGeoreferenciacion= source.IdGeoreferenciacion ;
		 target.IdGeoreferenciacionTipo= source.IdGeoreferenciacionTipo ;
		 target.GeoreferenciacionTipo_Nombre= source.GeoreferenciacionTipo_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Georeferenciacion source,Georeferenciacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGeoreferenciacion.Equals(target.IdGeoreferenciacion))return false;
		  if(!source.IdGeoreferenciacionTipo.Equals(target.IdGeoreferenciacionTipo))return false;
		 
		  return true;
        }
		public override bool Equals(GeoreferenciacionResult source,GeoreferenciacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGeoreferenciacion.Equals(target.IdGeoreferenciacion))return false;
		  if(!source.IdGeoreferenciacionTipo.Equals(target.IdGeoreferenciacionTipo))return false;
		  if((source.GeoreferenciacionTipo_Nombre == null)?target.GeoreferenciacionTipo_Nombre!=null: !( (target.GeoreferenciacionTipo_Nombre== String.Empty && source.GeoreferenciacionTipo_Nombre== null) || (target.GeoreferenciacionTipo_Nombre==null && source.GeoreferenciacionTipo_Nombre== String.Empty )) &&   !source.GeoreferenciacionTipo_Nombre.Trim().Replace ("\r","").Equals(target.GeoreferenciacionTipo_Nombre.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
