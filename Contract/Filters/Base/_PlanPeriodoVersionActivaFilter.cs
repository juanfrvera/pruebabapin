using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PlanPeriodoVersionActivaFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPlanPeriodoVersionActiva", IsRequired = false)]public int? IdPlanPeriodoVersionActiva{get;set;}		
[DataMember(Name = "IdPlanPeriodoVersionActiva_To", IsRequired = false)]		
public int? IdPlanPeriodoVersionActiva_To{get;set;}		
[DataMember(Name = "IdPlanPeriodo", IsRequired = false)]public int? IdPlanPeriodo{get;set;}		
[DataMember(Name = "IdPlanVersion", IsRequired = false)]public int? IdPlanVersion{get;set;}		

		#endregion
    }
}
