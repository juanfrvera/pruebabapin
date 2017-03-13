using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoGeoreferenciacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoGeoreferenciacion", IsRequired = false)]public int? IdProyectoGeoreferenciacion{get;set;}		
[DataMember(Name = "IdProyectoGeoreferenciacion_To", IsRequired = false)]		
public int? IdProyectoGeoreferenciacion_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdGeoreferenciacion", IsRequired = false)]public int? IdGeoreferenciacion{get;set;}		

		#endregion
    }
}
