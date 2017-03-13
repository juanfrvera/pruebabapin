using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoFilter : Filter
    {   
		#region Private
		private string _Denominacion;
		 private string _Descripcion;
		 private string _Observacion;
		 private string _ResponsablePolitico;
		 private string _ResponsableTecnico;
		 private string _CodigoVinculacion1;
		 private string _CodigoVinculacion2;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdPrograma", IsRequired = false)]public int? IdPrograma{get;set;}		
[DataMember(Name = "Numero", IsRequired = false)]public int? Numero{get;set;}		
[DataMember(Name = "Numero_To", IsRequired = false)]		
public int? Numero_To{get;set;}		

		  [DataMember(Name = "Denominacion", IsRequired = false)]
		  public string Denominacion
		  {
		   get{ if(_Denominacion==null)_Denominacion= string.Empty;
				return _Denominacion; 
				}
		   set{ _Denominacion=value;}
		  }
		 
		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 
		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 [DataMember(Name = "FechaAlta", IsRequired = false)]public DateTime? FechaAlta{get;set;}		
[DataMember(Name = "FechaAlta_To", IsRequired = false)]		
public DateTime? FechaAlta_To{get;set;}		
[DataMember(Name = "FechaModificacion", IsRequired = false)]public DateTime? FechaModificacion{get;set;}		
[DataMember(Name = "FechaModificacion_To", IsRequired = false)]		
public DateTime? FechaModificacion_To{get;set;}		
[DataMember(Name = "IdUsuarioModificacion", IsRequired = false)]public int? IdUsuarioModificacion{get;set;}		
[DataMember(Name = "IdUsuarioModificacion_To", IsRequired = false)]		
public int? IdUsuarioModificacion_To{get;set;}		
[DataMember(Name = "IdEstadoActualIsNull", IsRequired = false)]
			  public bool? IdEstadoActualIsNull{get;set;}[DataMember(Name = "IdEstadoActual", IsRequired = false)]public int? IdEstadoActual{get;set;}		
[DataMember(Name = "IdEstadoActual_To", IsRequired = false)]		
public int? IdEstadoActual_To{get;set;}		

		  [DataMember(Name = "ResponsablePolitico", IsRequired = false)]
		  public string ResponsablePolitico
		  {
		   get{ if(_ResponsablePolitico==null)_ResponsablePolitico= string.Empty;
				return _ResponsablePolitico; 
				}
		   set{ _ResponsablePolitico=value;}
		  }
		 
		  [DataMember(Name = "ResponsableTecnico", IsRequired = false)]
		  public string ResponsableTecnico
		  {
		   get{ if(_ResponsableTecnico==null)_ResponsableTecnico= string.Empty;
				return _ResponsableTecnico; 
				}
		   set{ _ResponsableTecnico=value;}
		  }
		 
		  [DataMember(Name = "CodigoVinculacion1", IsRequired = false)]
		  public string CodigoVinculacion1
		  {
		   get{ if(_CodigoVinculacion1==null)_CodigoVinculacion1= string.Empty;
				return _CodigoVinculacion1; 
				}
		   set{ _CodigoVinculacion1=value;}
		  }
		 
		  [DataMember(Name = "CodigoVinculacion2", IsRequired = false)]
		  public string CodigoVinculacion2
		  {
		   get{ if(_CodigoVinculacion2==null)_CodigoVinculacion2= string.Empty;
				return _CodigoVinculacion2; 
				}
		   set{ _CodigoVinculacion2=value;}
		  }
		 [DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
