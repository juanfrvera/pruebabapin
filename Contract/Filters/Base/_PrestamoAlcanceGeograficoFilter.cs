using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoAlcanceGeograficoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoAlcanceGeografico", IsRequired = false)]public int? IdPrestamoAlcanceGeografico{get;set;}		
[DataMember(Name = "IdPrestamoAlcanceGeografico_To", IsRequired = false)]		
public int? IdPrestamoAlcanceGeografico_To{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

		#endregion
    }
}
