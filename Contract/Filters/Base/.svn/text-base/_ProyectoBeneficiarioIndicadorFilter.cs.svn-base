using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoBeneficiarioIndicadorFilter : Filter
    {   
		#region Private
		private string _Beneficiario;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoBeneficiarioIndicador", IsRequired = false)]public int? IdProyectoBeneficiarioIndicador{get;set;}		
[DataMember(Name = "IdProyectoBeneficiarioIndicador_To", IsRequired = false)]		
public int? IdProyectoBeneficiarioIndicador_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		

		  [DataMember(Name = "Beneficiario", IsRequired = false)]
		  public string Beneficiario
		  {
		   get{ if(_Beneficiario==null)_Beneficiario= string.Empty;
				return _Beneficiario; 
				}
		   set{ _Beneficiario=value;}
		  }
		 [DataMember(Name = "Indirecto", IsRequired = false)]public bool? Indirecto{get;set;}		
[DataMember(Name = "IdIndicador", IsRequired = false)]public int? IdIndicador{get;set;}		

		#endregion
    }
}
