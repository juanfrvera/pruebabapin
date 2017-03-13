using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PerfilActividadFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPerfilActividad", IsRequired = false)]public int? IdPerfilActividad{get;set;}		
[DataMember(Name = "IdPerfilActividad_To", IsRequired = false)]		
public int? IdPerfilActividad_To{get;set;}		
[DataMember(Name = "IdPerfil", IsRequired = false)]public int? IdPerfil{get;set;}		
[DataMember(Name = "IdActividad", IsRequired = false)]public int? IdActividad{get;set;}		

		#endregion
    }
}
