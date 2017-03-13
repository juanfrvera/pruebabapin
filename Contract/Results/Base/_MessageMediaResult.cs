using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MessageMediaResult : IResult<int>
    {        
		public virtual int ID{get{return IdMessageMedia;}}
		 public int IdMessageMedia{get;set;}
		 public string Name{get;set;}
		 public string Img{get;set;}
		 
		 				
		public virtual MessageMedia ToEntity()
		{
		   MessageMedia _MessageMedia = new MessageMedia();
		_MessageMedia.IdMessageMedia = this.IdMessageMedia;
		 _MessageMedia.Name = this.Name;
		 _MessageMedia.Img = this.Img;
		 
		  return _MessageMedia;
		}		
		public virtual void Set(MessageMedia entity)
		{		   
		 this.IdMessageMedia= entity.IdMessageMedia ;
		  this.Name= entity.Name ;
		  this.Img= entity.Img ;
		 		  
		}		
		public virtual bool Equals(MessageMedia entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMessageMedia.Equals(this.IdMessageMedia))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if((entity.Img == null)?this.Img!=null:!entity.Img.Equals(this.Img))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("MessageMedia", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("MessageMedia","IdMessageMedia")
			,new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Img","Img")
			}));
		}
	}
}
		