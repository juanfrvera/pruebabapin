using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoTipoFilter : Filter
    {   
		#region Private
		private string _Sigla;
		 private string _Nombre;
		 private string _Tipo;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoTipo", IsRequired = false)]public int? IdProyectoTipo{get;set;}		

		  [DataMember(Name = "Sigla", IsRequired = false)]
		  public string Sigla
		  {
		   get{ if(_Sigla==null)_Sigla= string.Empty;
				return _Sigla; 
				}
		   set{ _Sigla=value;}
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

		  [DataMember(Name = "Tipo", IsRequired = false)]
		  public string Tipo
		  {
		   get{ if(_Tipo==null)_Tipo= string.Empty;
				return _Tipo; 
				}
		   set{ _Tipo=value;}
		  }
		 
		#endregion
    }
}
