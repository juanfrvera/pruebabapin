using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoLocalizacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoLocalizacion", IsRequired = false)]public int? IdProyectoLocalizacion{get;set;}		
[DataMember(Name = "IdProyectoLocalizacion_To", IsRequired = false)]		
public int? IdProyectoLocalizacion_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

		#endregion
    }
}
