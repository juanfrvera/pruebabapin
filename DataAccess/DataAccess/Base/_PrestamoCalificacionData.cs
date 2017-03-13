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
    public abstract class _PrestamoCalificacionData : EntityData<PrestamoCalificacion,PrestamoCalificacionFilter,PrestamoCalificacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoCalificacion entity)
		{			
			return entity.IdPrestamoCalificacion;
		}		
		public override PrestamoCalificacion GetByEntity(PrestamoCalificacion entity)
        {
            return this.GetById(entity.IdPrestamoCalificacion);
        }
        public override PrestamoCalificacion GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoCalificacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoCalificacion> Query(PrestamoCalificacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoCalificacion == null || filter.IdPrestamoCalificacion == 0 || o.IdPrestamoCalificacion==filter.IdPrestamoCalificacion)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoCalificacionResult> QueryResult(PrestamoCalificacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new PrestamoCalificacionResult(){
					 IdPrestamoCalificacion=o.IdPrestamoCalificacion
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoCalificacion Copy(nc.PrestamoCalificacion entity)
        {           
            nc.PrestamoCalificacion _new = new nc.PrestamoCalificacion();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(PrestamoCalificacion entity,string renameFormat)
        {
            PrestamoCalificacion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoCalificacion entity, int id)
        {            
            entity.IdPrestamoCalificacion = id;            
        }
		public override void Set(PrestamoCalificacion source,PrestamoCalificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoCalificacion= source.IdPrestamoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PrestamoCalificacionResult source,PrestamoCalificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoCalificacion= source.IdPrestamoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(PrestamoCalificacion source,PrestamoCalificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoCalificacion= source.IdPrestamoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PrestamoCalificacionResult source,PrestamoCalificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoCalificacion= source.IdPrestamoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoCalificacion source,PrestamoCalificacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoCalificacion.Equals(target.IdPrestamoCalificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoCalificacionResult source,PrestamoCalificacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoCalificacion.Equals(target.IdPrestamoCalificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
