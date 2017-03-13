using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _IndicadorObjetivoFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 private string _Funcion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdIndicadorPriorizacion", IsRequired = false)]public int? IdIndicadorPriorizacion{get;set;}		
[DataMember(Name = "IdIndicadorPriorizacion_To", IsRequired = false)]		
public int? IdIndicadorPriorizacion_To{get;set;}		

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
		 [DataMember(Name = "IdUnidadMedida", IsRequired = false)]public int? IdUnidadMedida{get;set;}		

		  [DataMember(Name = "Funcion", IsRequired = false)]
		  public string Funcion
		  {
		   get{ if(_Funcion==null)_Funcion= string.Empty;
				return _Funcion; 
				}
		   set{ _Funcion=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
