using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaReporteFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 private string _Codigo;
		 private string _Descripcion;
		 private string _FileName;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaReporte", IsRequired = false)]public int? IdSistemaReporte{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 
		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 [DataMember(Name = "IdSistemaEntidad", IsRequired = false)]public int? IdSistemaEntidad{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "EsListado", IsRequired = false)]public bool? EsListado{get;set;}		

		  [DataMember(Name = "FileName", IsRequired = false)]
		  public string FileName
		  {
		   get{ if(_FileName==null)_FileName= string.Empty;
				return _FileName; 
				}
		   set{ _FileName=value;}
		  }
		 
		#endregion
    }
}
