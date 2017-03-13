using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ParameterCategoryResult : IResult<int>
    {        
		public virtual int ID{get{return IdParameterCategoty;}}
		 public int IdParameterCategoty{get;set;}
		 public string Name{get;set;}
		 public string Description{get;set;}
		 
		 				
		public virtual ParameterCategory ToEntity()
		{
		   ParameterCategory _ParameterCategory = new ParameterCategory();
		_ParameterCategory.IdParameterCategoty = this.IdParameterCategoty;
		 _ParameterCategory.Name = this.Name;
		 _ParameterCategory.Description = this.Description;
		 
		  return _ParameterCategory;
		}		
		public virtual void Set(ParameterCategory entity)
		{		   
		 this.IdParameterCategoty= entity.IdParameterCategoty ;
		  this.Name= entity.Name ;
		  this.Description= entity.Description ;
		 		  
		}		
		public virtual bool Equals(ParameterCategory entity)
        {
		   if(entity == null)return false;
         if(!entity.IdParameterCategoty.Equals(this.IdParameterCategoty))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if((entity.Description == null)?this.Description!=null:!entity.Description.Equals(this.Description))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ParameterCategory", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Description","Description")
			}));
		}
	}
}
		