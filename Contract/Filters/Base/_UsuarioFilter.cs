using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _UsuarioFilter : Filter
    {   
		#region Private
		private string _NombreUsuario;
		 private string _Clave;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		

		  [DataMember(Name = "NombreUsuario", IsRequired = false)]
		  public string NombreUsuario
		  {
		   get{ if(_NombreUsuario==null)_NombreUsuario= string.Empty;
				return _NombreUsuario; 
				}
		   set{ _NombreUsuario=value;}
		  }
		 
		  [DataMember(Name = "Clave", IsRequired = false)]
		  public string Clave
		  {
		   get{ if(_Clave==null)_Clave= string.Empty;
				return _Clave; 
				}
		   set{ _Clave=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "EsSectioralista", IsRequired = false)]public bool? EsSectioralista{get;set;}		
[DataMember(Name = "IdLanguage", IsRequired = false)]public int? IdLanguage{get;set;}		
[DataMember(Name = "AccesoTotal", IsRequired = false)]public bool? AccesoTotal{get;set;}		

		#endregion
    }
}
