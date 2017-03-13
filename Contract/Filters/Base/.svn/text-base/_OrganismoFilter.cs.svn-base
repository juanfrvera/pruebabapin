using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _OrganismoFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdOrganismo", IsRequired = false)]public int? IdOrganismo{get;set;}		
[DataMember(Name = "IdOrganismo_To", IsRequired = false)]		
public int? IdOrganismo_To{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
