using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ClasificacionGeograficaFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Nombre;
		 private string _Descripcion;
		 private string _BreadcrumbId;
		 private string _BreadcrumOrden;
		 private string _DescripcionInvertida;
		 private string _BreadcrumbCode;
		 private string _DescripcionCodigo;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdClasificacionGeografica", IsRequired = false)]public int? IdClasificacionGeografica{get;set;}		

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
		 [DataMember(Name = "IdClasificacionGeograficaTipo", IsRequired = false)]public int? IdClasificacionGeograficaTipo{get;set;}		
[DataMember(Name = "IdClasificacionGeograficaPadreIsNull", IsRequired = false)]
			  public bool? IdClasificacionGeograficaPadreIsNull{get;set;}[DataMember(Name = "IdClasificacionGeograficaPadre", IsRequired = false)]public int? IdClasificacionGeograficaPadre{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 
		  [DataMember(Name = "BreadcrumbId", IsRequired = false)]
		  public string BreadcrumbId
		  {
		   get{ if(_BreadcrumbId==null)_BreadcrumbId= string.Empty;
				return _BreadcrumbId; 
				}
		   set{ _BreadcrumbId=value;}
		  }
		 
		  [DataMember(Name = "BreadcrumOrden", IsRequired = false)]
		  public string BreadcrumOrden
		  {
		   get{ if(_BreadcrumOrden==null)_BreadcrumOrden= string.Empty;
				return _BreadcrumOrden; 
				}
		   set{ _BreadcrumOrden=value;}
		  }
		 [DataMember(Name = "OrdenIsNull", IsRequired = false)]
			  public bool? OrdenIsNull{get;set;}[DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		
[DataMember(Name = "NivelIsNull", IsRequired = false)]
			  public bool? NivelIsNull{get;set;}[DataMember(Name = "Nivel", IsRequired = false)]public int? Nivel{get;set;}		
[DataMember(Name = "Nivel_To", IsRequired = false)]		
public int? Nivel_To{get;set;}		

		  [DataMember(Name = "DescripcionInvertida", IsRequired = false)]
		  public string DescripcionInvertida
		  {
		   get{ if(_DescripcionInvertida==null)_DescripcionInvertida= string.Empty;
				return _DescripcionInvertida; 
				}
		   set{ _DescripcionInvertida=value;}
		  }
		 [DataMember(Name = "Seleccionable", IsRequired = false)]public bool? Seleccionable{get;set;}		

		  [DataMember(Name = "BreadcrumbCode", IsRequired = false)]
		  public string BreadcrumbCode
		  {
		   get{ if(_BreadcrumbCode==null)_BreadcrumbCode= string.Empty;
				return _BreadcrumbCode; 
				}
		   set{ _BreadcrumbCode=value;}
		  }
		 
		  [DataMember(Name = "DescripcionCodigo", IsRequired = false)]
		  public string DescripcionCodigo
		  {
		   get{ if(_DescripcionCodigo==null)_DescripcionCodigo= string.Empty;
				return _DescripcionCodigo; 
				}
		   set{ _DescripcionCodigo=value;}
		  }
		 
		#endregion
    }
}
