using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _EvaluacionResultadoFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 private string _Aspecto;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdEvaluacionResultado", IsRequired = false)]public int? IdEvaluacionResultado{get;set;}		

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
		 
		  [DataMember(Name = "Aspecto", IsRequired = false)]
		  public string Aspecto
		  {
		   get{ if(_Aspecto==null)_Aspecto= string.Empty;
				return _Aspecto; 
				}
		   set{ _Aspecto=value;}
		  }
		 [DataMember(Name = "Aprobado", IsRequired = false)]public bool? Aprobado{get;set;}		
[DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
