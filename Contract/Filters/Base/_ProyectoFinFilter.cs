using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoFinFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoFin", IsRequired = false)]public int? IdProyectoFin{get;set;}		
[DataMember(Name = "IdProyectoFin_To", IsRequired = false)]		
public int? IdProyectoFin_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdProgramaObjetivo", IsRequired = false)]public int? IdProgramaObjetivo{get;set;}		

		#endregion
    }
}
