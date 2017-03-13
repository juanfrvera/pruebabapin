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
    public abstract class _ProyectoCalificacionData : EntityData<ProyectoCalificacion,ProyectoCalificacionFilter,ProyectoCalificacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoCalificacion entity)
		{			
			return entity.IdProyectoCalificacion;
		}		
		public override ProyectoCalificacion GetByEntity(ProyectoCalificacion entity)
        {
            return this.GetById(entity.IdProyectoCalificacion);
        }
        public override ProyectoCalificacion GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoCalificacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoCalificacion> Query(ProyectoCalificacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoCalificacion == null || filter.IdProyectoCalificacion == 0 || o.IdProyectoCalificacion==filter.IdProyectoCalificacion)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoCalificacionResult> QueryResult(ProyectoCalificacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new ProyectoCalificacionResult(){
					 IdProyectoCalificacion=o.IdProyectoCalificacion
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoCalificacion Copy(nc.ProyectoCalificacion entity)
        {           
            nc.ProyectoCalificacion _new = new nc.ProyectoCalificacion();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoCalificacion entity,string renameFormat)
        {
            ProyectoCalificacion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoCalificacion entity, int id)
        {            
            entity.IdProyectoCalificacion = id;            
        }
		public override void Set(ProyectoCalificacion source,ProyectoCalificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalificacion= source.IdProyectoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ProyectoCalificacionResult source,ProyectoCalificacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalificacion= source.IdProyectoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(ProyectoCalificacion source,ProyectoCalificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalificacion= source.IdProyectoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ProyectoCalificacionResult source,ProyectoCalificacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalificacion= source.IdProyectoCalificacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoCalificacion source,ProyectoCalificacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalificacion.Equals(target.IdProyectoCalificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoCalificacionResult source,ProyectoCalificacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalificacion.Equals(target.IdProyectoCalificacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
