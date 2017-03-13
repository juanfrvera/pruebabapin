using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoFileFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoFile", IsRequired = false)]public int? IdPrestamoFile{get;set;}		
[DataMember(Name = "IdPrestamoFile_To", IsRequired = false)]		
public int? IdPrestamoFile_To{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdFile", IsRequired = false)]public int? IdFile{get;set;}		

		#endregion
    }
}
