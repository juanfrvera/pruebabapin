using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _AuditSessionFilter : Filter
    {   
		#region Private
		private string _UserName;
		 private string _SessionId;
		 private string _Login;
		 private string _Rols;
		 private string _Area;
		 private string _IP;
		 private string _BrowserVersion;
		 private string _OperatingSystem;
		 private string _Mandate;
		 private string _Message;
		 private string _Comments;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdAuditSession", IsRequired = false)]public int? IdAuditSession{get;set;}		

		  [DataMember(Name = "UserName", IsRequired = false)]
		  public string UserName
		  {
		   get{ if(_UserName==null)_UserName= string.Empty;
				return _UserName; 
				}
		   set{ _UserName=value;}
		  }
		 
		  [DataMember(Name = "SessionId", IsRequired = false)]
		  public string SessionId
		  {
		   get{ if(_SessionId==null)_SessionId= string.Empty;
				return _SessionId; 
				}
		   set{ _SessionId=value;}
		  }
		 
		  [DataMember(Name = "Login", IsRequired = false)]
		  public string Login
		  {
		   get{ if(_Login==null)_Login= string.Empty;
				return _Login; 
				}
		   set{ _Login=value;}
		  }
		 
		  [DataMember(Name = "Rols", IsRequired = false)]
		  public string Rols
		  {
		   get{ if(_Rols==null)_Rols= string.Empty;
				return _Rols; 
				}
		   set{ _Rols=value;}
		  }
		 
		  [DataMember(Name = "Area", IsRequired = false)]
		  public string Area
		  {
		   get{ if(_Area==null)_Area= string.Empty;
				return _Area; 
				}
		   set{ _Area=value;}
		  }
		 
		  [DataMember(Name = "IP", IsRequired = false)]
		  public string IP
		  {
		   get{ if(_IP==null)_IP= string.Empty;
				return _IP; 
				}
		   set{ _IP=value;}
		  }
		 
		  [DataMember(Name = "BrowserVersion", IsRequired = false)]
		  public string BrowserVersion
		  {
		   get{ if(_BrowserVersion==null)_BrowserVersion= string.Empty;
				return _BrowserVersion; 
				}
		   set{ _BrowserVersion=value;}
		  }
		 
		  [DataMember(Name = "OperatingSystem", IsRequired = false)]
		  public string OperatingSystem
		  {
		   get{ if(_OperatingSystem==null)_OperatingSystem= string.Empty;
				return _OperatingSystem; 
				}
		   set{ _OperatingSystem=value;}
		  }
		 [DataMember(Name = "StartDateIsNull", IsRequired = false)]
			  public bool? StartDateIsNull{get;set;}[DataMember(Name = "StartDate", IsRequired = false)]public DateTime? StartDate{get;set;}		
[DataMember(Name = "StartDate_To", IsRequired = false)]		
public DateTime? StartDate_To{get;set;}		
[DataMember(Name = "EndDateIsNull", IsRequired = false)]
			  public bool? EndDateIsNull{get;set;}[DataMember(Name = "EndDate", IsRequired = false)]public DateTime? EndDate{get;set;}		
[DataMember(Name = "EndDate_To", IsRequired = false)]		
public DateTime? EndDate_To{get;set;}		

		  [DataMember(Name = "Mandate", IsRequired = false)]
		  public string Mandate
		  {
		   get{ if(_Mandate==null)_Mandate= string.Empty;
				return _Mandate; 
				}
		   set{ _Mandate=value;}
		  }
		 
		  [DataMember(Name = "Message", IsRequired = false)]
		  public string Message
		  {
		   get{ if(_Message==null)_Message= string.Empty;
				return _Message; 
				}
		   set{ _Message=value;}
		  }
		 
		  [DataMember(Name = "Comments", IsRequired = false)]
		  public string Comments
		  {
		   get{ if(_Comments==null)_Comments= string.Empty;
				return _Comments; 
				}
		   set{ _Comments=value;}
		  }
		 
		#endregion
    }
}
