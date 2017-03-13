using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MessageSendResult : IResult<int>
    {        
		public virtual int ID{get{return IdMessageSend;}}
		 public int IdMessageSend{get;set;}
		 public int IdMessage{get;set;}
		 public int IdUserTo{get;set;}
		 public int IdMediaTo{get;set;}
		 public bool IsRead{get;set;}
		 public DateTime? ReadDate{get;set;}
		 
		 public int Message_IdMediaFrom{get;set;}	
	public int Message_IdUserFrom{get;set;}	
	public int Message_IdPriority{get;set;}	
	public string Message_Subject{get;set;}	
	public string Message_Body{get;set;}	
	public DateTime Message_StartDate{get;set;}	
	public DateTime? Message_SendDate{get;set;}	
	public bool Message_IsManual{get;set;}	
	public int? Message_IdProyecto{get;set;}	
	public string MediaTo_Name{get;set;}	
	public string MediaTo_Img{get;set;}	
	public string UserTo_NombreUsuario{get;set;}	
	public string UserTo_Clave{get;set;}	
	public bool UserTo_Activo{get;set;}	
	public bool UserTo_EsSectioralista{get;set;}	
	public int UserTo_IdLanguage{get;set;}	
					
		public virtual MessageSend ToEntity()
		{
		   MessageSend _MessageSend = new MessageSend();
		_MessageSend.IdMessageSend = this.IdMessageSend;
		 _MessageSend.IdMessage = this.IdMessage;
		 _MessageSend.IdUserTo = this.IdUserTo;
		 _MessageSend.IdMediaTo = this.IdMediaTo;
		 _MessageSend.IsRead = this.IsRead;
		 _MessageSend.ReadDate = this.ReadDate;
		 
		  return _MessageSend;
		}		
		public virtual void Set(MessageSend entity)
		{		   
		 this.IdMessageSend= entity.IdMessageSend ;
		  this.IdMessage= entity.IdMessage ;
		  this.IdUserTo= entity.IdUserTo ;
		  this.IdMediaTo= entity.IdMediaTo ;
		  this.IsRead= entity.IsRead ;
		  this.ReadDate= entity.ReadDate ;
		 		  
		}		
		public virtual bool Equals(MessageSend entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMessageSend.Equals(this.IdMessageSend))return false;
		  if(!entity.IdMessage.Equals(this.IdMessage))return false;
		  if(!entity.IdUserTo.Equals(this.IdUserTo))return false;
		  if(!entity.IdMediaTo.Equals(this.IdMediaTo))return false;
		  if(!entity.IsRead.Equals(this.IsRead))return false;
		  if((entity.ReadDate == null)?this.ReadDate!=null:!entity.ReadDate.Equals(this.ReadDate))return false;
			
		  return true;
        }
	}
}
		