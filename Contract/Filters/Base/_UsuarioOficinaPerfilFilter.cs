using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _UsuarioOficinaPerfilFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdUsuarioOficinaPerfil", IsRequired = false)]public int? IdUsuarioOficinaPerfil{get;set;}		
[DataMember(Name = "IdUsuarioOficinaPerfil_To", IsRequired = false)]		
public int? IdUsuarioOficinaPerfil_To{get;set;}		
[DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		
[DataMember(Name = "IdOficina", IsRequired = false)]public int? IdOficina{get;set;}		
[DataMember(Name = "IdPerfil", IsRequired = false)]public int? IdPerfil{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "HeredaConsulta", IsRequired = false)]public bool? HeredaConsulta{get;set;}		
[DataMember(Name = "HeredaEdicion", IsRequired = false)]public bool? HeredaEdicion{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 [DataMember(Name = "AccesoTotal", IsRequired = false)]public bool? AccesoTotal{get;set;}		

		#endregion
    }
}
