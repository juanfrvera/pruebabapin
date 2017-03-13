using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaEntidadEstadoFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaEntidadEstado", IsRequired = false)]public int? IdSistemaEntidadEstado{get;set;}		
[DataMember(Name = "IdSistemaEntidadEstado_To", IsRequired = false)]		
public int? IdSistemaEntidadEstado_To{get;set;}		
[DataMember(Name = "IdSistemaEntidad", IsRequired = false)]public int? IdSistemaEntidad{get;set;}		
[DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		#endregion
    }
}
