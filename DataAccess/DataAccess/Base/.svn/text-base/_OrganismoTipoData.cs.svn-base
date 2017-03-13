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
    public abstract class _OrganismoTipoData : EntityData<OrganismoTipo,OrganismoTipoFilter,OrganismoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.OrganismoTipo entity)
		{			
			return entity.IdOrganismoTipo;
		}		
		public override OrganismoTipo GetByEntity(OrganismoTipo entity)
        {
            return this.GetById(entity.IdOrganismoTipo);
        }
        public override OrganismoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdOrganismoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<OrganismoTipo> Query(OrganismoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOrganismoTipo == null || filter.IdOrganismoTipo == 0 || o.IdOrganismoTipo==filter.IdOrganismoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OrganismoTipoResult> QueryResult(OrganismoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new OrganismoTipoResult(){
					 IdOrganismoTipo=o.IdOrganismoTipo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.OrganismoTipo Copy(nc.OrganismoTipo entity)
        {           
            nc.OrganismoTipo _new = new nc.OrganismoTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(OrganismoTipo entity,string renameFormat)
        {
            OrganismoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(OrganismoTipo entity, int id)
        {            
            entity.IdOrganismoTipo = id;            
        }
		public override void Set(OrganismoTipo source,OrganismoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoTipo= source.IdOrganismoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(OrganismoTipoResult source,OrganismoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoTipo= source.IdOrganismoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(OrganismoTipo source,OrganismoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoTipo= source.IdOrganismoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(OrganismoTipoResult source,OrganismoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoTipo= source.IdOrganismoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(OrganismoTipo source,OrganismoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoTipo.Equals(target.IdOrganismoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(OrganismoTipoResult source,OrganismoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoTipo.Equals(target.IdOrganismoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
