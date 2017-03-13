using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaAccionFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaAccion", IsRequired = false)]public int? IdSistemaAccion{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
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
[DataMember(Name = "IncluirEstado", IsRequired = false)]public bool? IncluirEstado{get;set;}		
[DataMember(Name = "EsLectura", IsRequired = false)]public bool? EsLectura{get;set;}		

		#endregion
    }
}
