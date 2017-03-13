using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _GeoreferenciacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdGeoreferenciacion", IsRequired = false)]public int? IdGeoreferenciacion{get;set;}		
[DataMember(Name = "IdGeoreferenciacionTipo", IsRequired = false)]public int? IdGeoreferenciacionTipo{get;set;}		

		#endregion
    }
}
