using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ConfigurationCategoryResult : IResult<int>
    {        
		public virtual int ID{get{return IdConfigurationCategory;}}
		 public int IdConfigurationCategory{get;set;}
		 public string Name{get;set;}
		 
		 				
		public virtual ConfigurationCategory ToEntity()
		{
		   ConfigurationCategory _ConfigurationCategory = new ConfigurationCategory();
		_ConfigurationCategory.IdConfigurationCategory = this.IdConfigurationCategory;
		 _ConfigurationCategory.Name = this.Name;
		 
		  return _ConfigurationCategory;
		}		
		public virtual void Set(ConfigurationCategory entity)
		{		   
		 this.IdConfigurationCategory= entity.IdConfigurationCategory ;
		  this.Name= entity.Name ;
		 		  
		}		
		public virtual bool Equals(ConfigurationCategory entity)
        {
		   if(entity == null)return false;
         if(!entity.IdConfigurationCategory.Equals(this.IdConfigurationCategory))return false;
		  if((entity.Name == null)?this.Name!=null:!entity.Name.Equals(this.Name))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ConfigurationCategory", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			}));
		}
	}
}
		