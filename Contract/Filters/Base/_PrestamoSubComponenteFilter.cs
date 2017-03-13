using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoSubComponenteFilter : Filter
    {   
		#region Private
		private string _Descripcion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoSubComponente", IsRequired = false)]public int? IdPrestamoSubComponente{get;set;}		
[DataMember(Name = "IdPrestamoComponente", IsRequired = false)]public int? IdPrestamoComponente{get;set;}		

		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 
		#endregion
    }
}
