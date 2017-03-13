using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoAlcanceGeograficoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoAlcanceGeografico", IsRequired = false)]public int? IdProyectoAlcanceGeografico{get;set;}		
[DataMember(Name = "IdProyectoAlcanceGeografico_To", IsRequired = false)]		
public int? IdProyectoAlcanceGeografico_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

		#endregion
    }
}
