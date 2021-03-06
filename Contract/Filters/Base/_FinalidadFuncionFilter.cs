using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _FinalidadFuncionFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Denominacion;
		 private string _BreadcrumbId;
		 private string _BreadcrumbOrden;
		 private string _Descripcion;
		 private string _DescripcionInvertida;
		 private string _BreadcrumbCode;
		 private string _DescripcionCodigo;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdFinalidadFuncion", IsRequired = false)]public int? IdFinalidadFuncion{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 
		  [DataMember(Name = "Denominacion", IsRequired = false)]
		  public string Denominacion
		  {
		   get{ if(_Denominacion==null)_Denominacion= string.Empty;
				return _Denominacion; 
				}
		   set{ _Denominacion=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		
[DataMember(Name = "IdFinalidadFunciontipoIsNull", IsRequired = false)]
			  public bool? IdFinalidadFunciontipoIsNull{get;set;}[DataMember(Name = "IdFinalidadFunciontipo", IsRequired = false)]public int? IdFinalidadFunciontipo{get;set;}		
[DataMember(Name = "IdFinalidadFuncionPadreIsNull", IsRequired = false)]
			  public bool? IdFinalidadFuncionPadreIsNull{get;set;}[DataMember(Name = "IdFinalidadFuncionPadre", IsRequired = false)]public int? IdFinalidadFuncionPadre{get;set;}		

		  [DataMember(Name = "BreadcrumbId", IsRequired = false)]
		  public string BreadcrumbId
		  {
		   get{ if(_BreadcrumbId==null)_BreadcrumbId= string.Empty;
				return _BreadcrumbId; 
				}
		   set{ _BreadcrumbId=value;}
		  }
		 
		  [DataMember(Name = "BreadcrumbOrden", IsRequired = false)]
		  public string BreadcrumbOrden
		  {
		   get{ if(_BreadcrumbOrden==null)_BreadcrumbOrden= string.Empty;
				return _BreadcrumbOrden; 
				}
		   set{ _BreadcrumbOrden=value;}
		  }
		 [DataMember(Name = "NivelIsNull", IsRequired = false)]
			  public bool? NivelIsNull{get;set;}[DataMember(Name = "Nivel", IsRequired = false)]public int? Nivel{get;set;}		
[DataMember(Name = "Nivel_To", IsRequired = false)]		
public int? Nivel_To{get;set;}		
[DataMember(Name = "OrdenIsNull", IsRequired = false)]
			  public bool? OrdenIsNull{get;set;}[DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		

		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 
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
