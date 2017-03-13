using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoPlanFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoPlan", IsRequired = false)]public int? IdProyectoPlan{get;set;}		
[DataMember(Name = "IdProyectoPlan_To", IsRequired = false)]		
public int? IdProyectoPlan_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdPlanPeriodo", IsRequired = false)]public int? IdPlanPeriodo{get;set;}		
[DataMember(Name = "IdPlanVersion", IsRequired = false)]public int? IdPlanVersion{get;set;}		
[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		

		#endregion
    }
}
