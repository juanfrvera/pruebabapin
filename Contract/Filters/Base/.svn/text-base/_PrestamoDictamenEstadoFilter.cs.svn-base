using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoDictamenEstadoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoDictamenEstado", IsRequired = false)]public int? IdPrestamoDictamenEstado{get;set;}		
[DataMember(Name = "IdPrestamoDictamenEstado_To", IsRequired = false)]		
public int? IdPrestamoDictamenEstado_To{get;set;}		
[DataMember(Name = "IdPrestamoDictamen", IsRequired = false)]public int? IdPrestamoDictamen{get;set;}		
[DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		
[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 [DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		

		#endregion
    }
}
