using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SubProcesoFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSubProceso", IsRequired = false)]public int? IdSubProceso{get;set;}		
[DataMember(Name = "IdSubProceso_To", IsRequired = false)]		
public int? IdSubProceso_To{get;set;}		

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
		 [DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "IdProcesoIsNull", IsRequired = false)]
			  public bool? IdProcesoIsNull{get;set;}[DataMember(Name = "IdProceso", IsRequired = false)]public int? IdProceso{get;set;}		

		#endregion
    }
}
