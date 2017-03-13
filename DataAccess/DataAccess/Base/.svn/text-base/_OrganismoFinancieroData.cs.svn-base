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
    public abstract class _OrganismoFinancieroData : EntityData<OrganismoFinanciero,OrganismoFinancieroFilter,OrganismoFinancieroResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.OrganismoFinanciero entity)
		{			
			return entity.IdOrganismoFinanciero;
		}		
		public override OrganismoFinanciero GetByEntity(OrganismoFinanciero entity)
        {
            return this.GetById(entity.IdOrganismoFinanciero);
        }
        public override OrganismoFinanciero GetById(int id)
        {
            return (from o in this.Table where o.IdOrganismoFinanciero == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<OrganismoFinanciero> Query(OrganismoFinancieroFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOrganismoFinanciero == null || filter.IdOrganismoFinanciero == 0 || o.IdOrganismoFinanciero==filter.IdOrganismoFinanciero)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OrganismoFinancieroResult> QueryResult(OrganismoFinancieroFilter filter)
        {
		  return (from o in Query(filter)					
					select new OrganismoFinancieroResult(){
					 IdOrganismoFinanciero=o.IdOrganismoFinanciero
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.OrganismoFinanciero Copy(nc.OrganismoFinanciero entity)
        {           
            nc.OrganismoFinanciero _new = new nc.OrganismoFinanciero();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(OrganismoFinanciero entity,string renameFormat)
        {
            OrganismoFinanciero  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(OrganismoFinanciero entity, int id)
        {            
            entity.IdOrganismoFinanciero = id;            
        }
		public override void Set(OrganismoFinanciero source,OrganismoFinanciero target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(OrganismoFinancieroResult source,OrganismoFinanciero target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(OrganismoFinanciero source,OrganismoFinancieroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(OrganismoFinancieroResult source,OrganismoFinancieroResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOrganismoFinanciero= source.IdOrganismoFinanciero ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(OrganismoFinanciero source,OrganismoFinanciero target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(OrganismoFinancieroResult source,OrganismoFinancieroResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOrganismoFinanciero.Equals(target.IdOrganismoFinanciero))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
