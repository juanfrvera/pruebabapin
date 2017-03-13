using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ModalidadFinancieraFilter : Filter
    {   
		#region Private
		private string _Sigla;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdModalidadFinanciera", IsRequired = false)]public int? IdModalidadFinanciera{get;set;}		
[DataMember(Name = "IdModalidadFinanciera_To", IsRequired = false)]		
public int? IdModalidadFinanciera_To{get;set;}		
[DataMember(Name = "IdOrganismoFinanciero", IsRequired = false)]public int? IdOrganismoFinanciero{get;set;}		

		  [DataMember(Name = "Sigla", IsRequired = false)]
		  public string Sigla
		  {
		   get{ if(_Sigla==null)_Sigla= string.Empty;
				return _Sigla; 
				}
		   set{ _Sigla=value;}
		  }
		 
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
