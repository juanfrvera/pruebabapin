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
    public abstract class _ActividadData : EntityData<Actividad,ActividadFilter,ActividadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Actividad entity)
		{			
			return entity.IdActividad;
		}		
		public override Actividad GetByEntity(Actividad entity)
        {
            return this.GetById(entity.IdActividad);
        }
        public override Actividad GetById(int id)
        {
            return (from o in this.Table where o.IdActividad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Actividad> Query(ActividadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdActividad == null || filter.IdActividad == 0 || o.IdActividad==filter.IdActividad)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ActividadResult> QueryResult(ActividadFilter filter)
        {
		  return (from o in Query(filter)					
					select new ActividadResult(){
					 IdActividad=o.IdActividad
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Actividad Copy(nc.Actividad entity)
        {           
            nc.Actividad _new = new nc.Actividad();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Actividad entity,string renameFormat)
        {
            Actividad  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Actividad entity, int id)
        {            
            entity.IdActividad = id;            
        }
		public override void Set(Actividad source,Actividad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividad= source.IdActividad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ActividadResult source,Actividad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividad= source.IdActividad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Actividad source,ActividadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividad= source.IdActividad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ActividadResult source,ActividadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividad= source.IdActividad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Actividad source,Actividad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdActividad.Equals(target.IdActividad))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ActividadResult source,ActividadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdActividad.Equals(target.IdActividad))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
