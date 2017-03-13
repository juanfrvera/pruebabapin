using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ObjetivoSupuestoFilter : Filter
    {   
		#region Private
		private string _Descripcion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdObjetivoSupuesto", IsRequired = false)]public int? IdObjetivoSupuesto{get;set;}		
[DataMember(Name = "IdObjetivoSupuesto_To", IsRequired = false)]		
public int? IdObjetivoSupuesto_To{get;set;}		
[DataMember(Name = "IdObjetivo", IsRequired = false)]public int? IdObjetivo{get;set;}		

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
