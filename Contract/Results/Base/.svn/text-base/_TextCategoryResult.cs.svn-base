using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TextCategoryResult : IResult<int>
    {        
		public virtual int ID{get{return IdTextCategory;}}
		 public int IdTextCategory{get;set;}
		 public string Name{get;set;}
		 public string Description{get;set;}
		 
		 				
		public virtual TextCategory ToEntity()
		{
		   TextCategory _TextCategory = new TextCategory();
		_TextCategory.IdTextCategory = this.IdTextCategory;
		 _TextCategory.Name = this.Name;
		 _TextCategory.Description = this.Description;
		 
		  return _TextCategory;
		}		
		public virtual void Set(TextCategory entity)
		{		   
		 this.IdTextCategory= entity.IdTextCategory ;
		  this.Name= entity.Name ;
		  this.Description= entity.Description ;
		 		  
		}		
		public virtual bool Equals(TextCategory entity)
        {
		   if(entity == null)return false;
         if(!entity.IdTextCategory.Equals(this.IdTextCategory))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if((entity.Description == null)?this.Description!=null:!entity.Description.Equals(this.Description))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("TextCategory", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Description","Description")
			}));
		}
	}
}
		