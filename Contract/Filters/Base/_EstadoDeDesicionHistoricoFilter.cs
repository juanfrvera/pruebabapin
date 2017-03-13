using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _EstadoDeDesicionHistoricoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdEstadoDeDesicionHistorico", IsRequired = false)]public int? IdEstadoDeDesicionHistorico{get;set;}		
[DataMember(Name = "IdEstadoDeDesicionHistorico_To", IsRequired = false)]		
public int? IdEstadoDeDesicionHistorico_To{get;set;}		
[DataMember(Name = "IdEstadoDeDesicion", IsRequired = false)]public int? IdEstadoDeDesicion{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		
[DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 
		#endregion
    }
}
