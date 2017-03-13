using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PlanVersionFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPlanVersion", IsRequired = false)]public int? IdPlanVersion{get;set;}		
[DataMember(Name = "IdPlanTipo", IsRequired = false)]public int? IdPlanTipo{get;set;}		

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
