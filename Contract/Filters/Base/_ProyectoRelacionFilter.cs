using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoRelacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoRelacion", IsRequired = false)]public int? IdProyectoRelacion{get;set;}		
[DataMember(Name = "IdProyectoRelacion_To", IsRequired = false)]		
public int? IdProyectoRelacion_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdProyectoRelacionado", IsRequired = false)]public int? IdProyectoRelacionado{get;set;}		
[DataMember(Name = "IdProyectoRelacionTipo", IsRequired = false)]public int? IdProyectoRelacionTipo{get;set;}		

		#endregion
    }
}
