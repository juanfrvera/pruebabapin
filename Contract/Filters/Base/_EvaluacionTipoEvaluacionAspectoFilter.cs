using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _EvaluacionTipoEvaluacionAspectoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdEvalaucionTipoEvaluacionAspecto", IsRequired = false)]public int? IdEvalaucionTipoEvaluacionAspecto{get;set;}		
[DataMember(Name = "IdEvalaucionTipoEvaluacionAspecto_To", IsRequired = false)]		
public int? IdEvalaucionTipoEvaluacionAspecto_To{get;set;}		
[DataMember(Name = "IdEvaluacionTipo", IsRequired = false)]public int? IdEvaluacionTipo{get;set;}		
[DataMember(Name = "IdEvaluacionAspecto", IsRequired = false)]public int? IdEvaluacionAspecto{get;set;}		

		#endregion
    }
}
