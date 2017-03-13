using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PriorityResult : IResult<int>
    {        
		public virtual int ID{get{return IdPriority;}}
		 public int IdPriority{get;set;}
		 public string Name{get;set;}
		 public string Img{get;set;}
		 
		 				
		public virtual Priority ToEntity()
		{
		   Priority _Priority = new Priority();
		_Priority.IdPriority = this.IdPriority;
		 _Priority.Name = this.Name;
		 _Priority.Img = this.Img;
		 
		  return _Priority;
		}		
		public virtual void Set(Priority entity)
		{		   
		 this.IdPriority= entity.IdPriority ;
		  this.Name= entity.Name ;
		  this.Img= entity.Img ;
		 		  
		}		
		public virtual bool Equals(Priority entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPriority.Equals(this.IdPriority))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if((entity.Img == null)?this.Img!=null:!entity.Img.Equals(this.Img))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Priority", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Priority","IdPriority")
			,new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Img","Img")
			}));
		}
	}
}
		