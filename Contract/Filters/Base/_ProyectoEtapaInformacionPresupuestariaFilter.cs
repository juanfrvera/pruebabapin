using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoEtapaInformacionPresupuestariaFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoEtapaInformacionPresupuestaria", IsRequired = false)]public int? IdProyectoEtapaInformacionPresupuestaria{get;set;}		
[DataMember(Name = "IdProyectoEtapa", IsRequired = false)]public int? IdProyectoEtapa{get;set;}		
[DataMember(Name = "IdClasificacionGasto", IsRequired = false)]public int? IdClasificacionGasto{get;set;}		
[DataMember(Name = "IdFuenteFinanciamiento", IsRequired = false)]public int? IdFuenteFinanciamiento{get;set;}		
[DataMember(Name = "IdMoneda", IsRequired = false)]public int? IdMoneda{get;set;}		

		#endregion
    }
}
