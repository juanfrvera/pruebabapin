using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoEtapaFilter : Filter
    {   
		#region Private
		private string _Nombre;
		 private string _CodigoVinculacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoEtapa", IsRequired = false)]public int? IdProyectoEtapa{get;set;}		

		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 
		  [DataMember(Name = "CodigoVinculacion", IsRequired = false)]
		  public string CodigoVinculacion
		  {
		   get{ if(_CodigoVinculacion==null)_CodigoVinculacion= string.Empty;
				return _CodigoVinculacion; 
				}
		   set{ _CodigoVinculacion=value;}
		  }
		 [DataMember(Name = "IdEstadoIsNull", IsRequired = false)]
			  public bool? IdEstadoIsNull{get;set;}[DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		
[DataMember(Name = "FechaInicioEstimadaIsNull", IsRequired = false)]
			  public bool? FechaInicioEstimadaIsNull{get;set;}[DataMember(Name = "FechaInicioEstimada", IsRequired = false)]public DateTime? FechaInicioEstimada{get;set;}		
[DataMember(Name = "FechaInicioEstimada_To", IsRequired = false)]		
public DateTime? FechaInicioEstimada_To{get;set;}		
[DataMember(Name = "FechaFinEstimadaIsNull", IsRequired = false)]
			  public bool? FechaFinEstimadaIsNull{get;set;}[DataMember(Name = "FechaFinEstimada", IsRequired = false)]public DateTime? FechaFinEstimada{get;set;}		
[DataMember(Name = "FechaFinEstimada_To", IsRequired = false)]		
public DateTime? FechaFinEstimada_To{get;set;}		
[DataMember(Name = "FechaInicioRealizadaIsNull", IsRequired = false)]
			  public bool? FechaInicioRealizadaIsNull{get;set;}[DataMember(Name = "FechaInicioRealizada", IsRequired = false)]public DateTime? FechaInicioRealizada{get;set;}		
[DataMember(Name = "FechaInicioRealizada_To", IsRequired = false)]		
public DateTime? FechaInicioRealizada_To{get;set;}		
[DataMember(Name = "FechaFinRealizadaIsNull", IsRequired = false)]
			  public bool? FechaFinRealizadaIsNull{get;set;}[DataMember(Name = "FechaFinRealizada", IsRequired = false)]public DateTime? FechaFinRealizada{get;set;}		
[DataMember(Name = "FechaFinRealizada_To", IsRequired = false)]		
public DateTime? FechaFinRealizada_To{get;set;}		
[DataMember(Name = "IdEtapa", IsRequired = false)]public int? IdEtapa{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "NroEtapaIsNull", IsRequired = false)]
			  public bool? NroEtapaIsNull{get;set;}[DataMember(Name = "NroEtapa", IsRequired = false)]public int? NroEtapa{get;set;}		
[DataMember(Name = "NroEtapa_To", IsRequired = false)]		
public int? NroEtapa_To{get;set;}		

		#endregion
    }
}
