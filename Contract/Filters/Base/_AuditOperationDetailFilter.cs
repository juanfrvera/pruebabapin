using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _AuditOperationDetailFilter : Filter
    {   
		#region Private
		private string _Detail;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdOperationDetail", IsRequired = false)]public int? IdOperationDetail{get;set;}		
[DataMember(Name = "IdOperationDetail_To", IsRequired = false)]		
public int? IdOperationDetail_To{get;set;}		
[DataMember(Name = "IdAuditOperation", IsRequired = false)]public int? IdAuditOperation{get;set;}		
[DataMember(Name = "ParentIdIsNull", IsRequired = false)]
			  public bool? ParentIdIsNull{get;set;}[DataMember(Name = "ParentId", IsRequired = false)]public int? ParentId{get;set;}		
[DataMember(Name = "ParentId_To", IsRequired = false)]		
public int? ParentId_To{get;set;}		

		  [DataMember(Name = "Detail", IsRequired = false)]
		  public string Detail
		  {
		   get{ if(_Detail==null)_Detail= string.Empty;
				return _Detail; 
				}
		   set{ _Detail=value;}
		  }
		 [DataMember(Name = "StartDate", IsRequired = false)]public DateTime? StartDate{get;set;}		
[DataMember(Name = "StartDate_To", IsRequired = false)]		
public DateTime? StartDate_To{get;set;}		
[DataMember(Name = "EndDateIsNull", IsRequired = false)]
			  public bool? EndDateIsNull{get;set;}[DataMember(Name = "EndDate", IsRequired = false)]public DateTime? EndDate{get;set;}		
[DataMember(Name = "EndDate_To", IsRequired = false)]		
public DateTime? EndDate_To{get;set;}		

		#endregion
    }
}
