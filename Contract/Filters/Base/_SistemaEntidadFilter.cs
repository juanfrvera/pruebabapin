using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaEntidadFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 private string _EntidadTipo;
		 private string _EntidadClase;
		 private string _EntidadClaseBase;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaEntidad", IsRequired = false)]public int? IdSistemaEntidad{get;set;}		

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
		 
		  [DataMember(Name = "EntidadTipo", IsRequired = false)]
		  public string EntidadTipo
		  {
		   get{ if(_EntidadTipo==null)_EntidadTipo= string.Empty;
				return _EntidadTipo; 
				}
		   set{ _EntidadTipo=value;}
		  }
		 
		  [DataMember(Name = "EntidadClase", IsRequired = false)]
		  public string EntidadClase
		  {
		   get{ if(_EntidadClase==null)_EntidadClase= string.Empty;
				return _EntidadClase; 
				}
		   set{ _EntidadClase=value;}
		  }
		 
		  [DataMember(Name = "EntidadClaseBase", IsRequired = false)]
		  public string EntidadClaseBase
		  {
		   get{ if(_EntidadClaseBase==null)_EntidadClaseBase= string.Empty;
				return _EntidadClaseBase; 
				}
		   set{ _EntidadClaseBase=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "IncluirSeguridadIsNull", IsRequired = false)]
			  public bool? IncluirSeguridadIsNull{get;set;}[DataMember(Name = "IncluirSeguridad", IsRequired = false)]public bool? IncluirSeguridad{get;set;}		
[DataMember(Name = "IncluirConfiguracionIsNull", IsRequired = false)]
			  public bool? IncluirConfiguracionIsNull{get;set;}[DataMember(Name = "IncluirConfiguracion", IsRequired = false)]public bool? IncluirConfiguracion{get;set;}		

		#endregion
    }
}
