using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoCalidadFilter : Filter
    {   
		#region Private
		private string _DenominacionSugerida;
		 private string _DenominacionOriginal;
		 private string _Comenatrio;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoCalidad", IsRequired = false)]public int? IdProyectoCalidad{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "DenominacionOK", IsRequired = false)]public bool? DenominacionOK{get;set;}		

		  [DataMember(Name = "DenominacionSugerida", IsRequired = false)]
		  public string DenominacionSugerida
		  {
		   get{ if(_DenominacionSugerida==null)_DenominacionSugerida= string.Empty;
				return _DenominacionSugerida; 
				}
		   set{ _DenominacionSugerida=value;}
		  }
		 
		  [DataMember(Name = "DenominacionOriginal", IsRequired = false)]
		  public string DenominacionOriginal
		  {
		   get{ if(_DenominacionOriginal==null)_DenominacionOriginal= string.Empty;
				return _DenominacionOriginal; 
				}
		   set{ _DenominacionOriginal=value;}
		  }
		 [DataMember(Name = "ProyectoTipoOk", IsRequired = false)]public bool? ProyectoTipoOk{get;set;}		
[DataMember(Name = "IdProyectoTipoIsNull", IsRequired = false)]
			  public bool? IdProyectoTipoIsNull{get;set;}[DataMember(Name = "IdProyectoTipo", IsRequired = false)]public int? IdProyectoTipo{get;set;}		
[DataMember(Name = "EstadoOKIsNull", IsRequired = false)]
			  public bool? EstadoOKIsNull{get;set;}[DataMember(Name = "EstadoOK", IsRequired = false)]public int? EstadoOK{get;set;}		
[DataMember(Name = "EstadoOK_To", IsRequired = false)]		
public int? EstadoOK_To{get;set;}		
[DataMember(Name = "IdEstadoSugeridoIsNull", IsRequired = false)]
			  public bool? IdEstadoSugeridoIsNull{get;set;}[DataMember(Name = "IdEstadoSugerido", IsRequired = false)]public int? IdEstadoSugerido{get;set;}		
[DataMember(Name = "IdEstadoSugerido_To", IsRequired = false)]		
public int? IdEstadoSugerido_To{get;set;}		
[DataMember(Name = "ProcesoOk", IsRequired = false)]public bool? ProcesoOk{get;set;}		
[DataMember(Name = "IdProcesoIsNull", IsRequired = false)]
			  public bool? IdProcesoIsNull{get;set;}[DataMember(Name = "IdProceso", IsRequired = false)]public int? IdProceso{get;set;}		
[DataMember(Name = "FinalidadFuncionOk", IsRequired = false)]public bool? FinalidadFuncionOk{get;set;}		
[DataMember(Name = "IdClasificacionFuncionalIsNull", IsRequired = false)]
			  public bool? IdClasificacionFuncionalIsNull{get;set;}[DataMember(Name = "IdClasificacionFuncional", IsRequired = false)]public int? IdClasificacionFuncional{get;set;}		
[DataMember(Name = "ReqDictamen", IsRequired = false)]public bool? ReqDictamen{get;set;}		

		  [DataMember(Name = "Comenatrio", IsRequired = false)]
		  public string Comenatrio
		  {
		   get{ if(_Comenatrio==null)_Comenatrio= string.Empty;
				return _Comenatrio; 
				}
		   set{ _Comenatrio=value;}
		  }
		 [DataMember(Name = "IdEstado", IsRequired = false)]public int? IdEstado{get;set;}		
[DataMember(Name = "FechaEstadoIsNull", IsRequired = false)]
			  public bool? FechaEstadoIsNull{get;set;}[DataMember(Name = "FechaEstado", IsRequired = false)]public DateTime? FechaEstado{get;set;}		
[DataMember(Name = "FechaEstado_To", IsRequired = false)]		
public DateTime? FechaEstado_To{get;set;}		
[DataMember(Name = "LocalizacionOK", IsRequired = false)]public bool? LocalizacionOK{get;set;}		

		#endregion
    }
}
