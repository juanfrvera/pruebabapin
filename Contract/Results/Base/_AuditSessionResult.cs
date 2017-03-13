using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _AuditSessionResult : IResult<int>
    {        
		public virtual int ID{get{return IdAuditSession;}}
		 public int IdAuditSession{get;set;}
		 public string UserName{get;set;}
		 public string SessionId{get;set;}
		 public string Login{get;set;}
		 public string Rols{get;set;}
		 public string Area{get;set;}
		 public string IP{get;set;}
		 public string BrowserVersion{get;set;}
		 public string OperatingSystem{get;set;}
		 public DateTime? StartDate{get;set;}
		 public DateTime? EndDate{get;set;}
		 public string Mandate{get;set;}
		 public string Message{get;set;}
		 public string Comments{get;set;}
		 
		 				
		public virtual AuditSession ToEntity()
		{
		   AuditSession _AuditSession = new AuditSession();
		_AuditSession.IdAuditSession = this.IdAuditSession;
		 _AuditSession.UserName = this.UserName;
		 _AuditSession.SessionId = this.SessionId;
		 _AuditSession.Login = this.Login;
		 _AuditSession.Rols = this.Rols;
		 _AuditSession.Area = this.Area;
		 _AuditSession.IP = this.IP;
		 _AuditSession.BrowserVersion = this.BrowserVersion;
		 _AuditSession.OperatingSystem = this.OperatingSystem;
		 _AuditSession.StartDate = this.StartDate;
		 _AuditSession.EndDate = this.EndDate;
		 _AuditSession.Mandate = this.Mandate;
		 _AuditSession.Message = this.Message;
		 _AuditSession.Comments = this.Comments;
		 
		  return _AuditSession;
		}		
		public virtual void Set(AuditSession entity)
		{		   
		 this.IdAuditSession= entity.IdAuditSession ;
		  this.UserName= entity.UserName ;
		  this.SessionId= entity.SessionId ;
		  this.Login= entity.Login ;
		  this.Rols= entity.Rols ;
		  this.Area= entity.Area ;
		  this.IP= entity.IP ;
		  this.BrowserVersion= entity.BrowserVersion ;
		  this.OperatingSystem= entity.OperatingSystem ;
		  this.StartDate= entity.StartDate ;
		  this.EndDate= entity.EndDate ;
		  this.Mandate= entity.Mandate ;
		  this.Message= entity.Message ;
		  this.Comments= entity.Comments ;
		 		  
		}		
		public virtual bool Equals(AuditSession entity)
        {
		   if(entity == null)return false;
         if(!entity.IdAuditSession.Equals(this.IdAuditSession))return false;
		  if(!entity.UserName.Equals(this.UserName))return false;
		  if(!entity.SessionId.Equals(this.SessionId))return false;
		  if((entity.Login == null)?this.Login!=null:!entity.Login.Equals(this.Login))return false;
			 if((entity.Rols == null)?this.Rols!=null:!entity.Rols.Equals(this.Rols))return false;
			 if((entity.Area == null)?this.Area!=null:!entity.Area.Equals(this.Area))return false;
			 if((entity.IP == null)?this.IP!=null:!entity.IP.Equals(this.IP))return false;
			 if((entity.BrowserVersion == null)?this.BrowserVersion!=null:!entity.BrowserVersion.Equals(this.BrowserVersion))return false;
			 if((entity.OperatingSystem == null)?this.OperatingSystem!=null:!entity.OperatingSystem.Equals(this.OperatingSystem))return false;
			 if((entity.StartDate == null)?this.StartDate!=null:!entity.StartDate.Equals(this.StartDate))return false;
			 if((entity.EndDate == null)?this.EndDate!=null:!entity.EndDate.Equals(this.EndDate))return false;
			 if((entity.Mandate == null)?this.Mandate!=null:!entity.Mandate.Equals(this.Mandate))return false;
			 if((entity.Message == null)?this.Message!=null:!entity.Message.Equals(this.Message))return false;
			 if((entity.Comments == null)?this.Comments!=null:!entity.Comments.Equals(this.Comments))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("AuditSession", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("UserName","UserName")
			,new DataColumnMapping("Session","SessionId")
			,new DataColumnMapping("Login","Login")
			,new DataColumnMapping("Rols","Rols")
			,new DataColumnMapping("Area","Area")
			,new DataColumnMapping("IP","Ip")
			,new DataColumnMapping("BrowserVersion","BrowserVersion")
			,new DataColumnMapping("OperatingSystem","OperatingSystem")
			,new DataColumnMapping("StartDate","StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("EndDate","EndDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Mandate","Mandate")
			,new DataColumnMapping("Message","Message")
			,new DataColumnMapping("Comments","Comments")
			}));
		}
	}
}
		