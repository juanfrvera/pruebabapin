using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoSubConvenioFilter : Filter
    {   
		#region Private
		private string _Codigo;
		 private string _Descripcion;
		 private string _Contraparte;
		 private string _Ejecutor;
		 private string _Observaciones;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoSubConvenio", IsRequired = false)]public int? IdPrestamoSubConvenio{get;set;}		
[DataMember(Name = "IdPrestamoSubConvenio_To", IsRequired = false)]		
public int? IdPrestamoSubConvenio_To{get;set;}		
[DataMember(Name = "IdPrestamoConvenio", IsRequired = false)]public int? IdPrestamoConvenio{get;set;}		

		  [DataMember(Name = "Codigo", IsRequired = false)]
		  public string Codigo
		  {
		   get{ if(_Codigo==null)_Codigo= string.Empty;
				return _Codigo; 
				}
		   set{ _Codigo=value;}
		  }
		 
		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 [DataMember(Name = "IdTipoSubConvenio", IsRequired = false)]public int? IdTipoSubConvenio{get;set;}		

		  [DataMember(Name = "Contraparte", IsRequired = false)]
		  public string Contraparte
		  {
		   get{ if(_Contraparte==null)_Contraparte= string.Empty;
				return _Contraparte; 
				}
		   set{ _Contraparte=value;}
		  }
		 [DataMember(Name = "MontoTotal", IsRequired = false)]public decimal? MontoTotal{get;set;}		
[DataMember(Name = "MontoTotal_To", IsRequired = false)]		
public decimal? MontoTotal_To{get;set;}		
[DataMember(Name = "MontoPrestamo", IsRequired = false)]public decimal? MontoPrestamo{get;set;}		
[DataMember(Name = "MontoPrestamo_To", IsRequired = false)]		
public decimal? MontoPrestamo_To{get;set;}		
[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		

		  [DataMember(Name = "Ejecutor", IsRequired = false)]
		  public string Ejecutor
		  {
		   get{ if(_Ejecutor==null)_Ejecutor= string.Empty;
				return _Ejecutor; 
				}
		   set{ _Ejecutor=value;}
		  }
		 
		  [DataMember(Name = "Observaciones", IsRequired = false)]
		  public string Observaciones
		  {
		   get{ if(_Observaciones==null)_Observaciones= string.Empty;
				return _Observaciones; 
				}
		   set{ _Observaciones=value;}
		  }
		 
		#endregion
    }
}
