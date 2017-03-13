using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PlanTipoFilter : Filter
    {   
		#region Private
		private string _Sigla;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPlanTipo", IsRequired = false)]public int? IdPlanTipo{get;set;}		

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
		 [DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
