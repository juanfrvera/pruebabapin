using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoProductoFilter : Filter
    {   
		#region Private
		private string _Descripcion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoProducto", IsRequired = false)]public int? IdPrestamoProducto{get;set;}		
[DataMember(Name = "IdPrestamoProducto_To", IsRequired = false)]		
public int? IdPrestamoProducto_To{get;set;}		
[DataMember(Name = "IdPrestamoComponente", IsRequired = false)]public int? IdPrestamoComponente{get;set;}		
[DataMember(Name = "IdPrestamoSubComponenteIsNull", IsRequired = false)]
			  public bool? IdPrestamoSubComponenteIsNull{get;set;}[DataMember(Name = "IdPrestamoSubComponente", IsRequired = false)]public int? IdPrestamoSubComponente{get;set;}		

		  [DataMember(Name = "Descripcion", IsRequired = false)]
		  public string Descripcion
		  {
		   get{ if(_Descripcion==null)_Descripcion= string.Empty;
				return _Descripcion; 
				}
		   set{ _Descripcion=value;}
		  }
		 [DataMember(Name = "MontoPrestamo", IsRequired = false)]public decimal? MontoPrestamo{get;set;}		
[DataMember(Name = "MontoPrestamo_To", IsRequired = false)]		
public decimal? MontoPrestamo_To{get;set;}		
[DataMember(Name = "MontoContraparte", IsRequired = false)]public decimal? MontoContraparte{get;set;}		
[DataMember(Name = "MontoContraparte_To", IsRequired = false)]		
public decimal? MontoContraparte_To{get;set;}		
[DataMember(Name = "InicioGestionIsNull", IsRequired = false)]
			  public bool? InicioGestionIsNull{get;set;}[DataMember(Name = "InicioGestion", IsRequired = false)]public bool? InicioGestion{get;set;}		
[DataMember(Name = "NegociarAutorizacionIsNull", IsRequired = false)]
			  public bool? NegociarAutorizacionIsNull{get;set;}[DataMember(Name = "NegociarAutorizacion", IsRequired = false)]public bool? NegociarAutorizacion{get;set;}		
[DataMember(Name = "EjecucionIsNull", IsRequired = false)]
			  public bool? EjecucionIsNull{get;set;}[DataMember(Name = "Ejecucion", IsRequired = false)]public bool? Ejecucion{get;set;}		
[DataMember(Name = "IdProyectoIsNull", IsRequired = false)]
			  public bool? IdProyectoIsNull{get;set;}[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}

[DataMember(Name = "IdProyectoOrigenFinanciamiento", IsRequired = false)]
public int? IdProyectoOrigenFinanciamiento { get; set; }
		
		#endregion
    }
}
