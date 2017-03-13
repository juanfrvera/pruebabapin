using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PlanPeriodoFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 private string _Sigla;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPlanPeriodo", IsRequired = false)]public int? IdPlanPeriodo{get;set;}		
[DataMember(Name = "IdPlanTipo", IsRequired = false)]public int? IdPlanTipo{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		  [DataMember(Name = "Sigla", IsRequired = false)]
		  public string Sigla
		  {
		   get{ if(_Sigla==null)_Sigla= string.Empty;
				return _Sigla; 
				}
		   set{ _Sigla=value;}
		  }
		 [DataMember(Name = "AnioInicial", IsRequired = false)]public int? AnioInicial{get;set;}		
[DataMember(Name = "AnioInicial_To", IsRequired = false)]		
public int? AnioInicial_To{get;set;}		
[DataMember(Name = "AnioFinal", IsRequired = false)]public int? AnioFinal{get;set;}		
[DataMember(Name = "AnioFinal_To", IsRequired = false)]		
public int? AnioFinal_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
