using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoProductoProyectoEtapaFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoProductoProyectoEtapa", IsRequired = false)]public int? IdProyectoProductoProyectoEtapa{get;set;}		
[DataMember(Name = "IdProyectoProductoProyectoEtapa_To", IsRequired = false)]		
public int? IdProyectoProductoProyectoEtapa_To{get;set;}		
[DataMember(Name = "IdProyectoProducto", IsRequired = false)]public int? IdProyectoProducto{get;set;}		
[DataMember(Name = "IdProyectoEtapa", IsRequired = false)]public int? IdProyectoEtapa{get;set;}		

		#endregion
    }
}
