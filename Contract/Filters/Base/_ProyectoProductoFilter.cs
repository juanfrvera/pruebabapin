using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoProductoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoProducto", IsRequired = false)]public int? IdProyectoProducto{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdObjetivo", IsRequired = false)]public int? IdObjetivo{get;set;}		

		#endregion
    }
}
