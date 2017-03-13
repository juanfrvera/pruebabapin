using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaEntidadAccionFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaEntidadAccion", IsRequired = false)]public int? IdSistemaEntidadAccion{get;set;}		
[DataMember(Name = "IdSistemaEntidadAccion_To", IsRequired = false)]		
public int? IdSistemaEntidadAccion_To{get;set;}		
[DataMember(Name = "IdSistemaEntidad", IsRequired = false)]public int? IdSistemaEntidad{get;set;}		
[DataMember(Name = "IdSistemaAccion", IsRequired = false)]public int? IdSistemaAccion{get;set;}		

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
