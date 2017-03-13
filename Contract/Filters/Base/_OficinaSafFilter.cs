using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _OficinaSafFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdOficinaSaf", IsRequired = false)]public int? IdOficinaSaf{get;set;}		
[DataMember(Name = "IdOficina", IsRequired = false)]public int? IdOficina{get;set;}		
[DataMember(Name = "IdSaf", IsRequired = false)]public int? IdSaf{get;set;}		

		#endregion
    }
}
