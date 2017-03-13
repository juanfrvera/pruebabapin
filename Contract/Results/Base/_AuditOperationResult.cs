using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _AuditOperationResult : IResult<int>
    {        
		public virtual int ID{get{return IdAuditOperation;}}
		 public int IdAuditOperation{get;set;}
		 public int IdAuditSession{get;set;}
		 public string UserName{get;set;}
		 public string EntityName{get;set;}
		 public string EntityBaseName{get;set;}
		 public string TypeName{get;set;}
		 public string EntityId{get;set;}
		 public string EntityKey{get;set;}
		 public string Module{get;set;}
		 public string ServiceType{get;set;}
		 public string Service{get;set;}
		 public string Operation{get;set;}
		 public string StatusName{get;set;}
		 public string Info{get;set;}
		 public string Comment{get;set;}
		 public string DataOld{get;set;}
		 public string DataPreOperation{get;set;}
		 public string DataPostOperation{get;set;}
		 public DateTime StartDate{get;set;}
		 public DateTime? EndDate{get;set;}
		 public bool EnableViewLog{get;set;}
		 public string ApplicationName{get;set;}
		 public string FormPath{get;set;}
		 public string FormName{get;set;}
		 public string UserControlName{get;set;}
		 public string UserControlPath{get;set;}
		 
		 public string AuditSession_UserName{get;set;}	
	public string AuditSession_SessionId{get;set;}	
	public string AuditSession_Login{get;set;}	
	public string AuditSession_Rols{get;set;}	
	public string AuditSession_Area{get;set;}	
	public string AuditSession_IP{get;set;}	
	public string AuditSession_BrowserVersion{get;set;}	
	public string AuditSession_OperatingSystem{get;set;}	
	public DateTime? AuditSession_StartDate{get;set;}	
	public DateTime? AuditSession_EndDate{get;set;}	
	public string AuditSession_Mandate{get;set;}	
	public string AuditSession_Message{get;set;}	
	public string AuditSession_Comments{get;set;}	
					
		public virtual AuditOperation ToEntity()
		{
		   AuditOperation _AuditOperation = new AuditOperation();
		_AuditOperation.IdAuditOperation = this.IdAuditOperation;
		 _AuditOperation.IdAuditSession = this.IdAuditSession;
		 _AuditOperation.UserName = this.UserName;
		 _AuditOperation.EntityName = this.EntityName;
		 _AuditOperation.EntityBaseName = this.EntityBaseName;
		 _AuditOperation.TypeName = this.TypeName;
		 _AuditOperation.EntityId = this.EntityId;
		 _AuditOperation.EntityKey = this.EntityKey;
		 _AuditOperation.Module = this.Module;
		 _AuditOperation.ServiceType = this.ServiceType;
		 _AuditOperation.Service = this.Service;
		 _AuditOperation.Operation = this.Operation;
		 _AuditOperation.StatusName = this.StatusName;
		 _AuditOperation.Info = this.Info;
		 _AuditOperation.Comment = this.Comment;
		 _AuditOperation.DataOld = this.DataOld;
		 _AuditOperation.DataPreOperation = this.DataPreOperation;
		 _AuditOperation.DataPostOperation = this.DataPostOperation;
		 _AuditOperation.StartDate = this.StartDate;
		 _AuditOperation.EndDate = this.EndDate;
		 _AuditOperation.EnableViewLog = this.EnableViewLog;
		 _AuditOperation.ApplicationName = this.ApplicationName;
		 _AuditOperation.FormPath = this.FormPath;
		 _AuditOperation.FormName = this.FormName;
		 _AuditOperation.UserControlName = this.UserControlName;
		 _AuditOperation.UserControlPath = this.UserControlPath;
		 
		  return _AuditOperation;
		}		
		public virtual void Set(AuditOperation entity)
		{		   
		 this.IdAuditOperation= entity.IdAuditOperation ;
		  this.IdAuditSession= entity.IdAuditSession ;
		  this.UserName= entity.UserName ;
		  this.EntityName= entity.EntityName ;
		  this.EntityBaseName= entity.EntityBaseName ;
		  this.TypeName= entity.TypeName ;
		  this.EntityId= entity.EntityId ;
		  this.EntityKey= entity.EntityKey ;
		  this.Module= entity.Module ;
		  this.ServiceType= entity.ServiceType ;
		  this.Service= entity.Service ;
		  this.Operation= entity.Operation ;
		  this.StatusName= entity.StatusName ;
		  this.Info= entity.Info ;
		  this.Comment= entity.Comment ;
		  this.DataOld= entity.DataOld ;
		  this.DataPreOperation= entity.DataPreOperation ;
		  this.DataPostOperation= entity.DataPostOperation ;
		  this.StartDate= entity.StartDate ;
		  this.EndDate= entity.EndDate ;
		  this.EnableViewLog= entity.EnableViewLog ;
		  this.ApplicationName= entity.ApplicationName ;
		  this.FormPath= entity.FormPath ;
		  this.FormName= entity.FormName ;
		  this.UserControlName= entity.UserControlName ;
		  this.UserControlPath= entity.UserControlPath ;
		 		  
		}		
		public virtual bool Equals(AuditOperation entity)
        {
		   if(entity == null)return false;
         if(!entity.IdAuditOperation.Equals(this.IdAuditOperation))return false;
		  if(!entity.IdAuditSession.Equals(this.IdAuditSession))return false;
		  if((entity.UserName == null)?this.UserName!=null:!entity.UserName.Equals(this.UserName))return false;
			 if((entity.EntityName == null)?this.EntityName!=null:!entity.EntityName.Equals(this.EntityName))return false;
			 if((entity.EntityBaseName == null)?this.EntityBaseName!=null:!entity.EntityBaseName.Equals(this.EntityBaseName))return false;
			 if((entity.TypeName == null)?this.TypeName!=null:!entity.TypeName.Equals(this.TypeName))return false;
			 if((entity.EntityId == null)?this.EntityId!=null:!entity.EntityId.Equals(this.EntityId))return false;
			 if((entity.EntityKey == null)?this.EntityKey!=null:!entity.EntityKey.Equals(this.EntityKey))return false;
			 if((entity.Module == null)?this.Module!=null:!entity.Module.Equals(this.Module))return false;
			 if((entity.ServiceType == null)?this.ServiceType!=null:!entity.ServiceType.Equals(this.ServiceType))return false;
			 if((entity.Service == null)?this.Service!=null:!entity.Service.Equals(this.Service))return false;
			 if((entity.Operation == null)?this.Operation!=null:!entity.Operation.Equals(this.Operation))return false;
			 if((entity.StatusName == null)?this.StatusName!=null:!entity.StatusName.Equals(this.StatusName))return false;
			 if((entity.Info == null)?this.Info!=null:!entity.Info.Equals(this.Info))return false;
			 if((entity.Comment == null)?this.Comment!=null:!entity.Comment.Equals(this.Comment))return false;
			 if((entity.DataOld == null)?this.DataOld!=null:!entity.DataOld.Equals(this.DataOld))return false;
			 if((entity.DataPreOperation == null)?this.DataPreOperation!=null:!entity.DataPreOperation.Equals(this.DataPreOperation))return false;
			 if((entity.DataPostOperation == null)?this.DataPostOperation!=null:!entity.DataPostOperation.Equals(this.DataPostOperation))return false;
			 if(!entity.StartDate.Equals(this.StartDate))return false;
		  if((entity.EndDate == null)?this.EndDate!=null:!entity.EndDate.Equals(this.EndDate))return false;
			 if(!entity.EnableViewLog.Equals(this.EnableViewLog))return false;
		  if((entity.ApplicationName == null)?this.ApplicationName!=null:!entity.ApplicationName.Equals(this.ApplicationName))return false;
			 if((entity.FormPath == null)?this.FormPath!=null:!entity.FormPath.Equals(this.FormPath))return false;
			 if((entity.FormName == null)?this.FormName!=null:!entity.FormName.Equals(this.FormName))return false;
			 if((entity.UserControlName == null)?this.UserControlName!=null:!entity.UserControlName.Equals(this.UserControlName))return false;
			 if((entity.UserControlPath == null)?this.UserControlPath!=null:!entity.UserControlPath.Equals(this.UserControlPath))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("AuditOperation", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("AuditSession","AuditSession_UserName")
			,new DataColumnMapping("UserName","UserName")
			,new DataColumnMapping("EntityName","EntityName")
			,new DataColumnMapping("EntityBaseName","EntityBaseName")
			,new DataColumnMapping("TypeName","TypeName")
			,new DataColumnMapping("Entity","EntityId")
			,new DataColumnMapping("EntityKey","EntityKey")
			,new DataColumnMapping("Module","Module")
			,new DataColumnMapping("ServiceType","ServiceType")
			,new DataColumnMapping("Service","Service")
			,new DataColumnMapping("Operation","Operation")
			,new DataColumnMapping("StatusName","StatusName")
			,new DataColumnMapping("Info","Info")
			,new DataColumnMapping("Comment","Comment")
			,new DataColumnMapping("DataOld","DataOld")
			,new DataColumnMapping("DataPreOperation","DataPreOperation")
			,new DataColumnMapping("DataPostOperation","DataPostOperation")
			,new DataColumnMapping("StartDate","StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("EndDate","EndDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("EnableViewLog","EnableViewLog")
			,new DataColumnMapping("ApplicationName","ApplicationName")
			,new DataColumnMapping("FormPath","FormPath")
			,new DataColumnMapping("FormName","FormName")
			,new DataColumnMapping("UserControlName","UserControlName")
			,new DataColumnMapping("UserControlPath","UserControlPath")
			}));
		}
	}
}
		