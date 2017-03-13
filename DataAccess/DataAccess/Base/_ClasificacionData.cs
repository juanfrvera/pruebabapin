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
    public abstract class _ClasificacionData : EntityData<Clasificacion,ClasificacionFilter,ClasificacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Clasificacion entity)
		{			
			return entity.IdClasificacion;
		}		
		public override Clasificacion GetByEntity(Clasificacion entity)
        {
            return this.GetById(entity.IdClasificacion);
        }
        public override Clasificacion GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Clasificacion> Query(ClasificacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacion == null || filter.IdClasificacion == 0 || o.IdClasificacion==filter.IdClasificacion)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionResult> QueryResult(ClasificacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new ClasificacionResult(){
					 IdClasificacion=o.IdClasificacion
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Clasificacion Copy(nc.Clasificacion entity)
        {           
            nc.Clasificacion _new = new nc.Clasificacion();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Clasificacion entity,string renameFormat)
        {
            Clasificacion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Clasificacion entity, int id)
        {            
            entity.IdClasificacion = id;            
        }
		public override void Set(Clasificacion source,Clasificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacion= source.IdClasificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ClasificacionResult source,Clasificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacion= source.IdClasificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Clasificacion source,ClasificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacion= source.IdClasificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ClasificacionResult source,ClasificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacion= source.IdClasificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Clasificacion source,Clasificacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacion.Equals(target.IdClasificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ClasificacionResult source,ClasificacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacion.Equals(target.IdClasificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
