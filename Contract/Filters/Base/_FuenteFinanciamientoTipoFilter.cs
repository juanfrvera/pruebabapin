using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _FuenteFinanciamientoTipoFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdFuenteFinanciamientoTipo", IsRequired = false)]public int? IdFuenteFinanciamientoTipo{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 [DataMember(Name = "Nivel", IsRequired = false)]public int? Nivel{get;set;}		
[DataMember(Name = "Nivel_To", IsRequired = false)]		
public int? Nivel_To{get;set;}		

		#endregion
    }
}
