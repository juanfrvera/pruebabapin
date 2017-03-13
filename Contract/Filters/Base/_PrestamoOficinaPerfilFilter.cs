using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoOficinaPerfilFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoOficinaPerfil", IsRequired = false)]public int? IdPrestamoOficinaPerfil{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdOficina", IsRequired = false)]public int? IdOficina{get;set;}		
[DataMember(Name = "IdPerfil", IsRequired = false)]public int? IdPerfil{get;set;}		

		#endregion
    }
}
