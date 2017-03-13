using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MessageAttachResult : IResult<int>
    {        
		public virtual int ID{get{return IdMessageAttach;}}
		 public int IdMessageAttach{get;set;}
		 public int IdMessage{get;set;}
		 public string FileName{get;set;}
		 public string FileType{get;set;}
		 public byte[] FileContent{get;set;}
		 
		 public int Message_IdMediaFrom{get;set;}	
	public int Message_IdUserFrom{get;set;}	
	public int Message_IdPriority{get;set;}	
	public string Message_Subject{get;set;}	
	public string Message_Body{get;set;}	
	public DateTime Message_StartDate{get;set;}	
	public DateTime? Message_SendDate{get;set;}	
	public bool Message_IsManual{get;set;}	
	public int? Message_IdProyecto{get;set;}	
					
		public virtual MessageAttach ToEntity()
		{
		   MessageAttach _MessageAttach = new MessageAttach();
		_MessageAttach.IdMessageAttach = this.IdMessageAttach;
		 _MessageAttach.IdMessage = this.IdMessage;
		 _MessageAttach.FileName = this.FileName;
		 _MessageAttach.FileType = this.FileType;
		 _MessageAttach.FileContent = this.FileContent;
		 
		  return _MessageAttach;
		}		
		public virtual void Set(MessageAttach entity)
		{		   
		 this.IdMessageAttach= entity.IdMessageAttach ;
		  this.IdMessage= entity.IdMessage ;
		  this.FileName= entity.FileName ;
		  this.FileType= entity.FileType ;
		  this.FileContent= entity.FileContent ;
		 		  
		}		
		public virtual bool Equals(MessageAttach entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMessageAttach.Equals(this.IdMessageAttach))return false;
		  if(!entity.IdMessage.Equals(this.IdMessage))return false;
		  if(!entity.FileName.Equals(this.FileName))return false;
		  if(!entity.FileType.Equals(this.FileType))return false;
		  if((entity.FileContent == null)?this.FileContent!=null:!entity.FileContent.Equals(this.FileContent))return false;
			
		  return true;
        }
	}
}
		