using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _EvaluacionAspectoFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 private string _Evaluacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdEvaluacionAspecto", IsRequired = false)]public int? IdEvaluacionAspecto{get;set;}		

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
		 
		  [DataMember(Name = "Evaluacion", IsRequired = false)]
		  public string Evaluacion
		  {
		   get{ if(_Evaluacion==null)_Evaluacion= string.Empty;
				return _Evaluacion; 
				}
		   set{ _Evaluacion=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
