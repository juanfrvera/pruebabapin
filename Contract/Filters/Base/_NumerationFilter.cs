using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _NumerationFilter : Filter
    {   
		#region Private
		private string _Code;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdNumeration", IsRequired = false)]public int? IdNumeration{get;set;}		
[DataMember(Name = "IdNumeration_To", IsRequired = false)]		
public int? IdNumeration_To{get;set;}		

		  [DataMember(Name = "Code", IsRequired = false)]
		  public string Code
		  {
		   get{ if(_Code==null)_Code= string.Empty;
				return _Code; 
				}
		   set{ _Code=value;}
		  }
		 [DataMember(Name = "Lastvalue", IsRequired = false)]public int? Lastvalue{get;set;}		
[DataMember(Name = "Lastvalue_To", IsRequired = false)]		
public int? Lastvalue_To{get;set;}		

		#endregion
    }
}
