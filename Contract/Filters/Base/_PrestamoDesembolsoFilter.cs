using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _PrestamoDesembolsoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdPrestamoDesembolso", IsRequired = false)]public int? IdPrestamoDesembolso{get;set;}		
[DataMember(Name = "IdPrestamoDesembolso_To", IsRequired = false)]		
public int? IdPrestamoDesembolso_To{get;set;}		
[DataMember(Name = "IdPrestamoIsNull", IsRequired = false)]
			  public bool? IdPrestamoIsNull{get;set;}[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "FechaIsNull", IsRequired = false)]
			  public bool? FechaIsNull{get;set;}[DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		
[DataMember(Name = "MontoAcumuladoIsNull", IsRequired = false)]
			  public bool? MontoAcumuladoIsNull{get;set;}[DataMember(Name = "MontoAcumulado", IsRequired = false)]public decimal? MontoAcumulado{get;set;}		
[DataMember(Name = "MontoAcumulado_To", IsRequired = false)]		
public decimal? MontoAcumulado_To{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
		  public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 
		#endregion
    }
}
