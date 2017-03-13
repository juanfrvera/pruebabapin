using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoFaseProyectoEtapaFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoFaseProyectoEtapa", IsRequired = false)]public int? IdProyectoFaseProyectoEtapa{get;set;}		
[DataMember(Name = "IdProyectoFaseProyectoEtapa_To", IsRequired = false)]		
public int? IdProyectoFaseProyectoEtapa_To{get;set;}		
[DataMember(Name = "IdProyectoFase", IsRequired = false)]public int? IdProyectoFase{get;set;}		
[DataMember(Name = "IdProyectoEtapa", IsRequired = false)]public int? IdProyectoEtapa{get;set;}		

		#endregion
    }
}
