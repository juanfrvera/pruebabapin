using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoSeguimientoLocalizacionFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoSeguimientoLocalizacion", IsRequired = false)]public int? IdProyectoSeguimientoLocalizacion{get;set;}		
[DataMember(Name = "IdProyectoSeguimientoLocalizacion_To", IsRequired = false)]		
public int? IdProyectoSeguimientoLocalizacion_To{get;set;}		
[DataMember(Name = "IdProyectoSeguimiento", IsRequired = false)]public int? IdProyectoSeguimiento{get;set;}		
[DataMember(Name = "IdCalificacionGeografica", IsRequired = false)]public int? IdCalificacionGeografica{get;set;}		

		#endregion
    }
}
