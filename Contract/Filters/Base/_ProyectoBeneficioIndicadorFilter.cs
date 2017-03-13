using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoBeneficioIndicadorFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoBeneficioIndicador", IsRequired = false)]public int? IdProyectoBeneficioIndicador{get;set;}		
[DataMember(Name = "IdProyectoBeneficioIndicador_To", IsRequired = false)]		
public int? IdProyectoBeneficioIndicador_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdIndicadorClase", IsRequired = false)]public int? IdIndicadorClase{get;set;}		
[DataMember(Name = "Indirecto", IsRequired = false)]public bool? Indirecto{get;set;}		
[DataMember(Name = "IdIndicador", IsRequired = false)]public int? IdIndicador{get;set;}		

		#endregion
    }
}
