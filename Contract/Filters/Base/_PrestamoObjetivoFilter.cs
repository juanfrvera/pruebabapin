using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoObjetivoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoObjetivo", IsRequired = false)]public int? IdPrestamoObjetivo{get;set;}		
[DataMember(Name = "IdPrestamoObjetivo_To", IsRequired = false)]		
public int? IdPrestamoObjetivo_To{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdObjetivo", IsRequired = false)]public int? IdObjetivo{get;set;}		

		#endregion
    }
}
