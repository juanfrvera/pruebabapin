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
    public abstract class _OrganismoPrioridadData : EntityData<OrganismoPrioridad,OrganismoPrioridadFilter,OrganismoPrioridadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.OrganismoPrioridad entity)
		{			
			return entity.IdOrganismoPrioridad;
		}		
		public override OrganismoPrioridad GetByEntity(OrganismoPrioridad entity)
        {
            return this.GetById(entity.IdOrganismoPrioridad);
        }
        public override OrganismoPrioridad GetById(int id)
        {
            return (from o in this.Table where o.IdOrganismoPrioridad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<OrganismoPrioridad> Query(OrganismoPrioridadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOrganismoPrioridad == null || filter.IdOrganismoPrioridad == 0 || o.IdOrganismoPrioridad==filter.IdOrganismoPrioridad)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OrganismoPrioridadResult> QueryResult(OrganismoPrioridadFilter filter)
        {
		  return (from o in Query(filter)					
					select new OrganismoPrioridadResult(){
					 IdOrganismoPrioridad=o.IdOrganismoPrioridad
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.OrganismoPrioridad Copy(nc.OrganismoPrioridad entity)
        {           
            nc.OrganismoPrioridad _new = new nc.OrganismoPrioridad();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(OrganismoPrioridad entity,string renameFormat)
        {
            OrganismoPrioridad  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(OrganismoPrioridad entity, int id)
        {            
            entity.IdOrganismoPrioridad = id;            
        }
		public override void Set(OrganismoPrioridad source,OrganismoPrioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(OrganismoPrioridadResult source,OrganismoPrioridad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(OrganismoPrioridad source,OrganismoPrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(OrganismoPrioridadResult source,OrganismoPrioridadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(OrganismoPrioridad source,OrganismoPrioridad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(OrganismoPrioridadResult source,OrganismoPrioridadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
