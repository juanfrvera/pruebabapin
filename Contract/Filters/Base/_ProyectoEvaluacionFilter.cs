using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoEvaluacionFilter : Filter
    {   
		#region Private
		private string _MarcoLegal;
		 private string _EstudioRealizado;
		 private string _EstudioaRealizar;
		 private string _SituacionSinProyecto;
		 private string _OpcionA;
		 private string _OpcionB;
		 private string _OpcionJustificacion;
		 private string _CriterioEvaluacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "Id_ProyectoEvaluacion", IsRequired = false)]public int? Id_ProyectoEvaluacion{get;set;}		
[DataMember(Name = "Id_ProyectoEvaluacion_To", IsRequired = false)]		
public int? Id_ProyectoEvaluacion_To{get;set;}		
[DataMember(Name = "Id_Proyecto", IsRequired = false)]public int? Id_Proyecto{get;set;}		

		  [DataMember(Name = "MarcoLegal", IsRequired = false)]
		  public string MarcoLegal
		  {
		   get{ if(_MarcoLegal==null)_MarcoLegal= string.Empty;
				return _MarcoLegal; 
				}
		   set{ _MarcoLegal=value;}
		  }
		 
		  [DataMember(Name = "EstudioRealizado", IsRequired = false)]
		  public string EstudioRealizado
		  {
		   get{ if(_EstudioRealizado==null)_EstudioRealizado= string.Empty;
				return _EstudioRealizado; 
				}
		   set{ _EstudioRealizado=value;}
		  }
		 
		  [DataMember(Name = "EstudioaRealizar", IsRequired = false)]
		  public string EstudioaRealizar
		  {
		   get{ if(_EstudioaRealizar==null)_EstudioaRealizar= string.Empty;
				return _EstudioaRealizar; 
				}
		   set{ _EstudioaRealizar=value;}
		  }
		 
		  [DataMember(Name = "SituacionSinProyecto", IsRequired = false)]
		  public string SituacionSinProyecto
		  {
		   get{ if(_SituacionSinProyecto==null)_SituacionSinProyecto= string.Empty;
				return _SituacionSinProyecto; 
				}
		   set{ _SituacionSinProyecto=value;}
		  }
		 
		  [DataMember(Name = "OpcionA", IsRequired = false)]
		  public string OpcionA
		  {
		   get{ if(_OpcionA==null)_OpcionA= string.Empty;
				return _OpcionA; 
				}
		   set{ _OpcionA=value;}
		  }
		 
		  [DataMember(Name = "OpcionB", IsRequired = false)]
		  public string OpcionB
		  {
		   get{ if(_OpcionB==null)_OpcionB= string.Empty;
				return _OpcionB; 
				}
		   set{ _OpcionB=value;}
		  }
		 
		  [DataMember(Name = "OpcionJustificacion", IsRequired = false)]
		  public string OpcionJustificacion
		  {
		   get{ if(_OpcionJustificacion==null)_OpcionJustificacion= string.Empty;
				return _OpcionJustificacion; 
				}
		   set{ _OpcionJustificacion=value;}
		  }
		 
		  [DataMember(Name = "CriterioEvaluacion", IsRequired = false)]
		  public string CriterioEvaluacion
		  {
		   get{ if(_CriterioEvaluacion==null)_CriterioEvaluacion= string.Empty;
				return _CriterioEvaluacion; 
				}
		   set{ _CriterioEvaluacion=value;}
		  }
		 [DataMember(Name = "HorizonteEvaluacionIsNull", IsRequired = false)]
			  public bool? HorizonteEvaluacionIsNull{get;set;}[DataMember(Name = "HorizonteEvaluacion", IsRequired = false)]public int? HorizonteEvaluacion{get;set;}		
[DataMember(Name = "HorizonteEvaluacion_To", IsRequired = false)]		
public int? HorizonteEvaluacion_To{get;set;}		
[DataMember(Name = "TasaReferenciaIsNull", IsRequired = false)]
			  public bool? TasaReferenciaIsNull{get;set;}[DataMember(Name = "TasaReferencia", IsRequired = false)]public decimal? TasaReferencia{get;set;}		
[DataMember(Name = "TasaReferencia_To", IsRequired = false)]		
public decimal? TasaReferencia_To{get;set;}		

		#endregion
    }
}
