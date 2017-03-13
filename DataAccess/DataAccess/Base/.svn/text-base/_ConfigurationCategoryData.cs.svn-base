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
    public abstract class _ConfigurationCategoryData : EntityData<ConfigurationCategory,ConfigurationCategoryFilter,ConfigurationCategoryResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ConfigurationCategory entity)
		{			
			return entity.IdConfigurationCategory;
		}		
		public override ConfigurationCategory GetByEntity(ConfigurationCategory entity)
        {
            return this.GetById(entity.IdConfigurationCategory);
        }
        public override ConfigurationCategory GetById(int id)
        {
            return (from o in this.Table where o.IdConfigurationCategory == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ConfigurationCategory> Query(ConfigurationCategoryFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdConfigurationCategory == null || filter.IdConfigurationCategory == 0 || o.IdConfigurationCategory==filter.IdConfigurationCategory)
					  && (filter.Name == null || filter.Name.Trim() == string.Empty || filter.Name.Trim() == "%"  || (filter.Name.EndsWith("%") && filter.Name.StartsWith("%") && (o.Name.Contains(filter.Name.Replace("%", "")))) || (filter.Name.EndsWith("%") && o.Name.StartsWith(filter.Name.Replace("%",""))) || (filter.Name.StartsWith("%") && o.Name.EndsWith(filter.Name.Replace("%",""))) || o.Name == filter.Name )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ConfigurationCategoryResult> QueryResult(ConfigurationCategoryFilter filter)
        {
		  return (from o in Query(filter)					
					select new ConfigurationCategoryResult(){
					 IdConfigurationCategory=o.IdConfigurationCategory
					 ,Name=o.Name
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ConfigurationCategory Copy(nc.ConfigurationCategory entity)
        {           
            nc.ConfigurationCategory _new = new nc.ConfigurationCategory();
		 _new.Name= entity.Name;
		return _new;			
        }
		public override int CopyAndSave(ConfigurationCategory entity,string renameFormat)
        {
            ConfigurationCategory  newEntity = Copy(entity);
            newEntity.Name = string.Format(renameFormat,newEntity.Name);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ConfigurationCategory entity, int id)
        {            
            entity.IdConfigurationCategory = id;            
        }
		public override void Set(ConfigurationCategory source,ConfigurationCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Name= source.Name ;
		 		  
		}
		public override void Set(ConfigurationCategoryResult source,ConfigurationCategory target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Name= source.Name ;
		 
		}
		public override void Set(ConfigurationCategory source,ConfigurationCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Name= source.Name ;
		 	
		}		
		public override void Set(ConfigurationCategoryResult source,ConfigurationCategoryResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdConfigurationCategory= source.IdConfigurationCategory ;
		 target.Name= source.Name ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ConfigurationCategory source,ConfigurationCategory target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdConfigurationCategory.Equals(target.IdConfigurationCategory))return false;
		  if((source.Name == null)?target.Name!=null:  !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) &&  !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(ConfigurationCategoryResult source,ConfigurationCategoryResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdConfigurationCategory.Equals(target.IdConfigurationCategory))return false;
		  if((source.Name == null)?target.Name!=null: !( (target.Name== String.Empty && source.Name== null) || (target.Name==null && source.Name== String.Empty )) && !source.Name.Trim().Replace ("\r","").Equals(target.Name.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
