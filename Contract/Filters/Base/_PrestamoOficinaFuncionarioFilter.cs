using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoOficinaFuncionarioFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoOficinaPerfilFuncionario", IsRequired = false)]public int? IdPrestamoOficinaPerfilFuncionario{get;set;}		
[DataMember(Name = "IdPrestamoOficinaPerfilFuncionario_To", IsRequired = false)]		
public int? IdPrestamoOficinaPerfilFuncionario_To{get;set;}		
[DataMember(Name = "IdPrestamoOficinaPerfil", IsRequired = false)]public int? IdPrestamoOficinaPerfil{get;set;}		
[DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		
[DataMember(Name = "IdUsuario_To", IsRequired = false)]		
public int? IdUsuario_To{get;set;}		

		#endregion
    }
}
