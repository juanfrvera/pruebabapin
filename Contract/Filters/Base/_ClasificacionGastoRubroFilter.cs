using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ClasificacionGastoRubroFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdClasificacionGastoRubro", IsRequired = false)]public int? IdClasificacionGastoRubro{get;set;}		

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
		 
		#endregion
    }
}
