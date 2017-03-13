using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _AuditOperationFilter : Filter
    {   
		#region Private
		private string _UserName;
		 private string _EntityName;
		 private string _EntityBaseName;
		 private string _TypeName;
		 private string _EntityId;
		 private string _EntityKey;
		 private string _Module;
		 private string _ServiceType;
		 private string _Service;
		 private string _Operation;
		 private string _StatusName;
		 private string _Info;
		 private string _Comment;
		 private string _DataOld;
		 private string _DataPreOperation;
		 private string _DataPostOperation;
		 private string _ApplicationName;
		 private string _FormPath;
		 private string _FormName;
		 private string _UserControlName;
		 private string _UserControlPath;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdAuditOperation", IsRequired = false)]public int? IdAuditOperation{get;set;}		
[DataMember(Name = "IdAuditSession", IsRequired = false)]public int? IdAuditSession{get;set;}		

		  [DataMember(Name = "UserName", IsRequired = false)]
		  public string UserName
		  {
		   get{ if(_UserName==null)_UserName= string.Empty;
				return _UserName; 
				}
		   set{ _UserName=value;}
		  }
		 
		  [DataMember(Name = "EntityName", IsRequired = false)]
		  public string EntityName
		  {
		   get{ if(_EntityName==null)_EntityName= string.Empty;
				return _EntityName; 
				}
		   set{ _EntityName=value;}
		  }
		 
		  [DataMember(Name = "EntityBaseName", IsRequired = false)]
		  public string EntityBaseName
		  {
		   get{ if(_EntityBaseName==null)_EntityBaseName= string.Empty;
				return _EntityBaseName; 
				}
		   set{ _EntityBaseName=value;}
		  }
		 
		  [DataMember(Name = "TypeName", IsRequired = false)]
		  public string TypeName
		  {
		   get{ if(_TypeName==null)_TypeName= string.Empty;
				return _TypeName; 
				}
		   set{ _TypeName=value;}
		  }
		 
		  [DataMember(Name = "EntityId", IsRequired = false)]
		  public string EntityId
		  {
		   get{ if(_EntityId==null)_EntityId= string.Empty;
				return _EntityId; 
				}
		   set{ _EntityId=value;}
		  }
		 
		  [DataMember(Name = "EntityKey", IsRequired = false)]
		  public string EntityKey
		  {
		   get{ if(_EntityKey==null)_EntityKey= string.Empty;
				return _EntityKey; 
				}
		   set{ _EntityKey=value;}
		  }
		 
		  [DataMember(Name = "Module", IsRequired = false)]
		  public string Module
		  {
		   get{ if(_Module==null)_Module= string.Empty;
				return _Module; 
				}
		   set{ _Module=value;}
		  }
		 
		  [DataMember(Name = "ServiceType", IsRequired = false)]
		  public string ServiceType
		  {
		   get{ if(_ServiceType==null)_ServiceType= string.Empty;
				return _ServiceType; 
				}
		   set{ _ServiceType=value;}
		  }
		 
		  [DataMember(Name = "Service", IsRequired = false)]
		  public string Service
		  {
		   get{ if(_Service==null)_Service= string.Empty;
				return _Service; 
				}
		   set{ _Service=value;}
		  }
		 
		  [DataMember(Name = "Operation", IsRequired = false)]
		  public string Operation
		  {
		   get{ if(_Operation==null)_Operation= string.Empty;
				return _Operation; 
				}
		   set{ _Operation=value;}
		  }
		 
		  [DataMember(Name = "StatusName", IsRequired = false)]
		  public string StatusName
		  {
		   get{ if(_StatusName==null)_StatusName= string.Empty;
				return _StatusName; 
				}
		   set{ _StatusName=value;}
		  }
		 
		  [DataMember(Name = "Info", IsRequired = false)]
		  public string Info
		  {
		   get{ if(_Info==null)_Info= string.Empty;
				return _Info; 
				}
		   set{ _Info=value;}
		  }
		 
		  [DataMember(Name = "Comment", IsRequired = false)]
		  public string Comment
		  {
		   get{ if(_Comment==null)_Comment= string.Empty;
				return _Comment; 
				}
		   set{ _Comment=value;}
		  }
		 
		  [DataMember(Name = "DataOld", IsRequired = false)]
		  public string DataOld
		  {
		   get{ if(_DataOld==null)_DataOld= string.Empty;
				return _DataOld; 
				}
		   set{ _DataOld=value;}
		  }
		 
		  [DataMember(Name = "DataPreOperation", IsRequired = false)]
		  public string DataPreOperation
		  {
		   get{ if(_DataPreOperation==null)_DataPreOperation= string.Empty;
				return _DataPreOperation; 
				}
		   set{ _DataPreOperation=value;}
		  }
		 
		  [DataMember(Name = "DataPostOperation", IsRequired = false)]
		  public string DataPostOperation
		  {
		   get{ if(_DataPostOperation==null)_DataPostOperation= string.Empty;
				return _DataPostOperation; 
				}
		   set{ _DataPostOperation=value;}
		  }
		 [DataMember(Name = "StartDate", IsRequired = false)]public DateTime? StartDate{get;set;}		
[DataMember(Name = "StartDate_To", IsRequired = false)]		
public DateTime? StartDate_To{get;set;}		
[DataMember(Name = "EndDateIsNull", IsRequired = false)]
			  public bool? EndDateIsNull{get;set;}[DataMember(Name = "EndDate", IsRequired = false)]public DateTime? EndDate{get;set;}		
[DataMember(Name = "EndDate_To", IsRequired = false)]		
public DateTime? EndDate_To{get;set;}		
[DataMember(Name = "EnableViewLog", IsRequired = false)]public bool? EnableViewLog{get;set;}		

		  [DataMember(Name = "ApplicationName", IsRequired = false)]
		  public string ApplicationName
		  {
		   get{ if(_ApplicationName==null)_ApplicationName= string.Empty;
				return _ApplicationName; 
				}
		   set{ _ApplicationName=value;}
		  }
		 
		  [DataMember(Name = "FormPath", IsRequired = false)]
		  public string FormPath
		  {
		   get{ if(_FormPath==null)_FormPath= string.Empty;
				return _FormPath; 
				}
		   set{ _FormPath=value;}
		  }
		 
		  [DataMember(Name = "FormName", IsRequired = false)]
		  public string FormName
		  {
		   get{ if(_FormName==null)_FormName= string.Empty;
				return _FormName; 
				}
		   set{ _FormName=value;}
		  }
		 
		  [DataMember(Name = "UserControlName", IsRequired = false)]
		  public string UserControlName
		  {
		   get{ if(_UserControlName==null)_UserControlName= string.Empty;
				return _UserControlName; 
				}
		   set{ _UserControlName=value;}
		  }
		 
		  [DataMember(Name = "UserControlPath", IsRequired = false)]
		  public string UserControlPath
		  {
		   get{ if(_UserControlPath==null)_UserControlPath= string.Empty;
				return _UserControlPath; 
				}
		   set{ _UserControlPath=value;}
		  }
		 
		#endregion
    }
}
