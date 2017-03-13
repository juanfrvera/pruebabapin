using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _GeoreferenciacionPuntoFilter : Filter
    {   
		#region Private
		private string _descripcion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdGeoreferenciacionPunto", IsRequired = false)]public int? IdGeoreferenciacionPunto{get;set;}		
[DataMember(Name = "IdGeoreferenciacionPunto_To", IsRequired = false)]		
public int? IdGeoreferenciacionPunto_To{get;set;}		
[DataMember(Name = "IdGeoreferenciacion", IsRequired = false)]public int? IdGeoreferenciacion{get;set;}		
[DataMember(Name = "Orden", IsRequired = false)]public int? Orden{get;set;}		
[DataMember(Name = "Orden_To", IsRequired = false)]		
public int? Orden_To{get;set;}		
[DataMember(Name = "Longitud", IsRequired = false)]public decimal? Longitud{get;set;}		
[DataMember(Name = "Longitud_To", IsRequired = false)]		
public decimal? Longitud_To{get;set;}		
[DataMember(Name = "Latitud", IsRequired = false)]public decimal? Latitud{get;set;}		
[DataMember(Name = "Latitud_To", IsRequired = false)]		
public decimal? Latitud_To{get;set;}		

		  [DataMember(Name = "descripcion", IsRequired = false)]
		  public string descripcion
		  {
		   get{ if(_descripcion==null)_descripcion= string.Empty;
				return _descripcion; 
				}
		   set{ _descripcion=value;}
		  }
		 
		#endregion
    }
}
