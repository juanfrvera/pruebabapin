using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEvaluacionResult : IResult<int>
    {        
		public virtual int ID{get{return Id_ProyectoEvaluacion;}}
		 public int Id_ProyectoEvaluacion{get;set;}
		 public int Id_Proyecto{get;set;}
		 public string MarcoLegal{get;set;}
		 public string EstudioRealizado{get;set;}
		 public string EstudioaRealizar{get;set;}
		 public string SituacionSinProyecto{get;set;}
		 public string OpcionA{get;set;}
		 public string OpcionB{get;set;}
		 public string OpcionJustificacion{get;set;}
		 public string CriterioEvaluacion{get;set;}
		 public int? HorizonteEvaluacion{get;set;}
		 public decimal? TasaReferencia{get;set;}
		 
		 public int _Proyecto_IdTipoProyecto{get;set;}	
	public int _Proyecto_IdSubPrograma{get;set;}	
	public int _Proyecto_Codigo{get;set;}	
	public string _Proyecto_ProyectoDenominacion{get;set;}	
	public string _Proyecto_ProyectoSituacionActual{get;set;}	
	public string _Proyecto_ProyectoDescripcion{get;set;}	
	public string _Proyecto_ProyectoObservacion{get;set;}	
	public int _Proyecto_IdEstado{get;set;}	
	public int? _Proyecto_IdProceso{get;set;}	
	public int? _Proyecto_IdModalidadContratacion{get;set;}	
	public int? _Proyecto_IdFinalidadFuncion{get;set;}	
	public int? _Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? _Proyecto_SubPrioridad{get;set;}	
	public bool _Proyecto_EsBorrador{get;set;}	
	public bool? _Proyecto_EsProyecto{get;set;}	
	public int? _Proyecto_NroProyecto{get;set;}	
	public int? _Proyecto_AnioCorriente{get;set;}	
	public DateTime? _Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? _Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime _Proyecto_FechaAlta{get;set;}	
	public DateTime _Proyecto_FechaModificacion{get;set;}	
	public int _Proyecto_IdUsuarioModificacion{get;set;}	
	public int? _Proyecto_IdProyectoPlan{get;set;}	
	public bool _Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoEvaluacion ToEntity()
		{
		   ProyectoEvaluacion _ProyectoEvaluacion = new ProyectoEvaluacion();
		_ProyectoEvaluacion.Id_ProyectoEvaluacion = this.Id_ProyectoEvaluacion;
		 _ProyectoEvaluacion.Id_Proyecto = this.Id_Proyecto;
		 _ProyectoEvaluacion.MarcoLegal = this.MarcoLegal;
		 _ProyectoEvaluacion.EstudioRealizado = this.EstudioRealizado;
		 _ProyectoEvaluacion.EstudioaRealizar = this.EstudioaRealizar;
		 _ProyectoEvaluacion.SituacionSinProyecto = this.SituacionSinProyecto;
		 _ProyectoEvaluacion.OpcionA = this.OpcionA;
		 _ProyectoEvaluacion.OpcionB = this.OpcionB;
		 _ProyectoEvaluacion.OpcionJustificacion = this.OpcionJustificacion;
		 _ProyectoEvaluacion.CriterioEvaluacion = this.CriterioEvaluacion;
		 _ProyectoEvaluacion.HorizonteEvaluacion = this.HorizonteEvaluacion;
		 _ProyectoEvaluacion.TasaReferencia = this.TasaReferencia;
		 
		  return _ProyectoEvaluacion;
		}		
		public virtual void Set(ProyectoEvaluacion entity)
		{		   
		 this.Id_ProyectoEvaluacion= entity.Id_ProyectoEvaluacion ;
		  this.Id_Proyecto= entity.Id_Proyecto ;
		  this.MarcoLegal= entity.MarcoLegal ;
		  this.EstudioRealizado= entity.EstudioRealizado ;
		  this.EstudioaRealizar= entity.EstudioaRealizar ;
		  this.SituacionSinProyecto= entity.SituacionSinProyecto ;
		  this.OpcionA= entity.OpcionA ;
		  this.OpcionB= entity.OpcionB ;
		  this.OpcionJustificacion= entity.OpcionJustificacion ;
		  this.CriterioEvaluacion= entity.CriterioEvaluacion ;
		  this.HorizonteEvaluacion= entity.HorizonteEvaluacion ;
		  this.TasaReferencia= entity.TasaReferencia ;
		 		  
		}		
		public virtual bool Equals(ProyectoEvaluacion entity)
        {
		   if(entity == null)return false;
         if(!entity.Id_ProyectoEvaluacion.Equals(this.Id_ProyectoEvaluacion))return false;
		  if(!entity.Id_Proyecto.Equals(this.Id_Proyecto))return false;
		  if((entity.MarcoLegal == null)?this.MarcoLegal!=null:!entity.MarcoLegal.Equals(this.MarcoLegal))return false;
			 if((entity.EstudioRealizado == null)?this.EstudioRealizado!=null:!entity.EstudioRealizado.Equals(this.EstudioRealizado))return false;
			 if((entity.EstudioaRealizar == null)?this.EstudioaRealizar!=null:!entity.EstudioaRealizar.Equals(this.EstudioaRealizar))return false;
			 if((entity.SituacionSinProyecto == null)?this.SituacionSinProyecto!=null:!entity.SituacionSinProyecto.Equals(this.SituacionSinProyecto))return false;
			 if((entity.OpcionA == null)?this.OpcionA!=null:!entity.OpcionA.Equals(this.OpcionA))return false;
			 if((entity.OpcionB == null)?this.OpcionB!=null:!entity.OpcionB.Equals(this.OpcionB))return false;
			 if((entity.OpcionJustificacion == null)?this.OpcionJustificacion!=null:!entity.OpcionJustificacion.Equals(this.OpcionJustificacion))return false;
			 if((entity.CriterioEvaluacion == null)?this.CriterioEvaluacion!=null:!entity.CriterioEvaluacion.Equals(this.CriterioEvaluacion))return false;
			 if((entity.HorizonteEvaluacion == null)?this.HorizonteEvaluacion!=null:!entity.HorizonteEvaluacion.Equals(this.HorizonteEvaluacion))return false;
			 if((entity.TasaReferencia == null)?this.TasaReferencia!=null:!entity.TasaReferencia.Equals(this.TasaReferencia))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEvaluacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("_Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("MarcoLegal","MarcoLegal")
			,new DataColumnMapping("EstudioRealizado","EstudioRealizado")
			,new DataColumnMapping("EstudioaRealizar","EstudioaRealizar")
			,new DataColumnMapping("SituacionSinProyecto","SituacionSinProyecto")
			,new DataColumnMapping("OpcionA","Opciona")
			,new DataColumnMapping("OpcionB","Opcionb")
			,new DataColumnMapping("OpcionJustificacion","OpcionJustificacion")
			,new DataColumnMapping("CriterioEvaluacion","CriterioEvaluacion")
			,new DataColumnMapping("HorizonteEvaluacion","HorizonteEvaluacion")
			,new DataColumnMapping("TasaReferencia","TasaReferencia")
			}));
		}
	}
}
		