using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoComponenteFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoComponente", IsRequired = false)]public int? IdPrestamoComponente{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdObjetivo", IsRequired = false)]public int? IdObjetivo{get;set;}		

		#endregion
    }
}
