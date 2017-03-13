using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoCalidadLocalizacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoCalidadLocalizacion", IsRequired = false)]public int? IdProyectoCalidadLocalizacion{get;set;}		
[DataMember(Name = "IdProyectoCalidadLocalizacion_To", IsRequired = false)]		
public int? IdProyectoCalidadLocalizacion_To{get;set;}		
[DataMember(Name = "IdProyectoCalidad", IsRequired = false)]public int? IdProyectoCalidad{get;set;}		
[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

		#endregion
    }
}
