using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoConvenioFilter : Filter
    {   
		#region Private
		private string _Sigla;
		 private string _Numero;
		 private string _Observacion;
		 private string _DatosModalidadFinanciera;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoConvenio", IsRequired = false)]public int? IdPrestamoConvenio{get;set;}		
[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdOrganismoFinanciero", IsRequired = false)]public int? IdOrganismoFinanciero{get;set;}		

		  [DataMember(Name = "Sigla", IsRequired = false)]
		  public string Sigla
		  {
		   get{ if(_Sigla==null)_Sigla= string.Empty;
				return _Sigla; 
				}
		   set{ _Sigla=value;}
		  }
		 
		  [DataMember(Name = "Numero", IsRequired = false)]
		  public string Numero
		  {
		   get{ if(_Numero==null)_Numero= string.Empty;
				return _Numero; 
				}
		   set{ _Numero=value;}
		  }
		 [DataMember(Name = "MontoTotal", IsRequired = false)]public decimal? MontoTotal{get;set;}		
[DataMember(Name = "MontoTotal_To", IsRequired = false)]		
public decimal? MontoTotal_To{get;set;}		
[DataMember(Name = "MontoPrestamo", IsRequired = false)]public decimal? MontoPrestamo{get;set;}		
[DataMember(Name = "MontoPrestamo_To", IsRequired = false)]		
public decimal? MontoPrestamo_To{get;set;}		
[DataMember(Name = "IdMoneda", IsRequired = false)]public int? IdMoneda{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 [DataMember(Name = "IdModalidadFinancieraIsNull", IsRequired = false)]
			  public bool? IdModalidadFinancieraIsNull{get;set;}[DataMember(Name = "IdModalidadFinanciera", IsRequired = false)]public int? IdModalidadFinanciera{get;set;}		
[DataMember(Name = "IdModalidadFinanciera_To", IsRequired = false)]		
public int? IdModalidadFinanciera_To{get;set;}		

		  [DataMember(Name = "DatosModalidadFinanciera", IsRequired = false)]
		  public string DatosModalidadFinanciera
		  {
		   get{ if(_DatosModalidadFinanciera==null)_DatosModalidadFinanciera= string.Empty;
				return _DatosModalidadFinanciera; 
				}
		   set{ _DatosModalidadFinanciera=value;}
		  }
		 
		#endregion
    }
}
