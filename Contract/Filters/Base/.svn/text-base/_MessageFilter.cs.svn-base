using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _MessageFilter : Filter
    {   
		#region Private
		private string _Subject;
		 private string _Body;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdMessage", IsRequired = false)]public int? IdMessage{get;set;}		
[DataMember(Name = "IdMediaFrom", IsRequired = false)]public int? IdMediaFrom{get;set;}		
[DataMember(Name = "IdUserFrom", IsRequired = false)]public int? IdUserFrom{get;set;}		
[DataMember(Name = "IdPriority", IsRequired = false)]public int? IdPriority{get;set;}		

		  [DataMember(Name = "Subject", IsRequired = false)]
		  public string Subject
		  {
		   get{ if(_Subject==null)_Subject= string.Empty;
				return _Subject; 
				}
		   set{ _Subject=value;}
		  }
		 
		  [DataMember(Name = "Body", IsRequired = false)]
		  public string Body
		  {
		   get{ if(_Body==null)_Body= string.Empty;
				return _Body; 
				}
		   set{ _Body=value;}
		  }
		 [DataMember(Name = "StartDate", IsRequired = false)]public DateTime? StartDate{get;set;}		
[DataMember(Name = "StartDate_To", IsRequired = false)]		
public DateTime? StartDate_To{get;set;}		
[DataMember(Name = "SendDateIsNull", IsRequired = false)]
			  public bool? SendDateIsNull{get;set;}[DataMember(Name = "SendDate", IsRequired = false)]public DateTime? SendDate{get;set;}		
[DataMember(Name = "SendDate_To", IsRequired = false)]		
public DateTime? SendDate_To{get;set;}		
[DataMember(Name = "IsManual", IsRequired = false)]public bool? IsManual{get;set;}		
[DataMember(Name = "IdProyectoIsNull", IsRequired = false)]
			  public bool? IdProyectoIsNull{get;set;}[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		

		#endregion
    }
}
