using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProgramaObjetivoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProgramaObjetivo", IsRequired = false)]public int? IdProgramaObjetivo{get;set;}		
[DataMember(Name = "IdPrograma", IsRequired = false)]public int? IdPrograma{get;set;}		
[DataMember(Name = "IDObjetivo", IsRequired = false)]public int? IDObjetivo{get;set;}		

		#endregion
    }
}
