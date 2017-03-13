using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoSeguimientoEstadoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoSeguimientoEstado", IsRequired = false)]public int? IdProyectoSeguimientoEstado{get;set;}		
[DataMember(Name = "IdProyectoSeguimiento", IsRequired = false)]public int? IdProyectoSeguimiento{get;set;}		
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
