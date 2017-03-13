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
    public abstract class _OrganismoData : EntityData<Organismo,OrganismoFilter,OrganismoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Organismo entity)
		{			
			return entity.IdOrganismo;
		}		
		public override Organismo GetByEntity(Organismo entity)
        {
            return this.GetById(entity.IdOrganismo);
        }
        public override Organismo GetById(int id)
        {
            return (from o in this.Table where o.IdOrganismo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Organismo> Query(OrganismoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOrganismo == null || filter.IdOrganismo == 0 || o.IdOrganismo==filter.IdOrganismo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OrganismoResult> QueryResult(OrganismoFilter filter)
        {
		  return (from o in Query(filter)					
					select new OrganismoResult(){
					 IdOrganismo=o.IdOrganismo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Organismo Copy(nc.Organismo entity)
        {           
            nc.Organismo _new = new nc.Organismo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Organismo entity,string renameFormat)
        {
            Organismo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Organismo entity, int id)
        {            
            entity.IdOrganismo = id;            
        }
		public override void Set(Organismo source,Organismo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismo= source.IdOrganismo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(OrganismoResult source,Organismo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismo= source.IdOrganismo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Organismo source,OrganismoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismo= source.IdOrganismo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(OrganismoResult source,OrganismoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismo= source.IdOrganismo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Organismo source,Organismo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismo.Equals(target.IdOrganismo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(OrganismoResult source,OrganismoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismo.Equals(target.IdOrganismo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
