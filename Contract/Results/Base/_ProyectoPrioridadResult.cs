using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoPrioridadResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoPrioridad;}}
		 public int IdProyectoPrioridad{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdPlanPeriodo{get;set;}
		 public int? IdPrioridad{get;set;}
		 public int Puntaje{get;set;}
		 public bool? ReqArt15{get;set;}
		 public int? IdClasificacion{get;set;}
		 public string Comentario{get;set;}
		 public bool PrioridadAsignada{get;set;}
		 public bool ConfRequerimientos{get;set;}
		 
		 public string Clasificacion_Nombre{get;set;}	
	public bool? Clasificacion_Activo{get;set;}	
	public int PlanPeriodo_IdPlanTipo{get;set;}	
	public string PlanPeriodo_Nombre{get;set;}	
	public string PlanPeriodo_Sigla{get;set;}	
	public int PlanPeriodo_AnioInicial{get;set;}	
	public int PlanPeriodo_AnioFinal{get;set;}	
	public bool PlanPeriodo_Activo{get;set;}	
	public string Prioridad_Sigla{get;set;}	
	public int? Prioridad_Orden{get;set;}	
	public string Prioridad_Nombre{get;set;}	
	public bool? Prioridad_Activo{get;set;}	
	public int Proyecto_IdTipoProyecto{get;set;}	
	public int Proyecto_IdSubPrograma{get;set;}	
	public int Proyecto_Codigo{get;set;}	
	public string Proyecto_ProyectoDenominacion{get;set;}	
	public string Proyecto_ProyectoSituacionActual{get;set;}	
	public string Proyecto_ProyectoDescripcion{get;set;}	
	public string Proyecto_ProyectoObservacion{get;set;}	
	public int Proyecto_IdEstado{get;set;}	
	public int? Proyecto_IdProceso{get;set;}	
	public int? Proyecto_IdModalidadContratacion{get;set;}	
	public int? Proyecto_IdFinalidadFuncion{get;set;}	
	public int? Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? Proyecto_SubPrioridad{get;set;}	
	public bool Proyecto_EsBorrador{get;set;}	
	public bool? Proyecto_EsProyecto{get;set;}	
	public int? Proyecto_NroProyecto{get;set;}	
	public int? Proyecto_AnioCorriente{get;set;}	
	public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime Proyecto_FechaAlta{get;set;}	
	public DateTime Proyecto_FechaModificacion{get;set;}	
	public int Proyecto_IdUsuarioModificacion{get;set;}	
	public int? Proyecto_IdProyectoPlan{get;set;}	
	public bool Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoPrioridad ToEntity()
		{
		   ProyectoPrioridad _ProyectoPrioridad = new ProyectoPrioridad();
		_ProyectoPrioridad.IdProyectoPrioridad = this.IdProyectoPrioridad;
		 _ProyectoPrioridad.IdProyecto = this.IdProyecto;
		 _ProyectoPrioridad.IdPlanPeriodo = this.IdPlanPeriodo;
		 _ProyectoPrioridad.IdPrioridad = this.IdPrioridad;
		 _ProyectoPrioridad.Puntaje = this.Puntaje;
		 _ProyectoPrioridad.ReqArt15 = this.ReqArt15;
		 _ProyectoPrioridad.IdClasificacion = this.IdClasificacion;
		 _ProyectoPrioridad.Comentario = this.Comentario;
		 _ProyectoPrioridad.PrioridadAsignada = this.PrioridadAsignada;
		 _ProyectoPrioridad.ConfRequerimientos = this.ConfRequerimientos;
		 
		  return _ProyectoPrioridad;
		}		
		public virtual void Set(ProyectoPrioridad entity)
		{		   
		 this.IdProyectoPrioridad= entity.IdProyectoPrioridad ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdPlanPeriodo= entity.IdPlanPeriodo ;
		  this.IdPrioridad= entity.IdPrioridad ;
		  this.Puntaje= entity.Puntaje ;
		  this.ReqArt15= entity.ReqArt15 ;
		  this.IdClasificacion= entity.IdClasificacion ;
		  this.Comentario= entity.Comentario ;
		  this.PrioridadAsignada= entity.PrioridadAsignada ;
		  this.ConfRequerimientos= entity.ConfRequerimientos ;
		 		  
		}		
		public virtual bool Equals(ProyectoPrioridad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoPrioridad.Equals(this.IdProyectoPrioridad))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdPlanPeriodo.Equals(this.IdPlanPeriodo))return false;
		  if((entity.IdPrioridad == null)?(this.IdPrioridad.HasValue && this.IdPrioridad.Value > 0):!entity.IdPrioridad.Equals(this.IdPrioridad))return false;
						  if(!entity.Puntaje.Equals(this.Puntaje))return false;
		  if((entity.ReqArt15 == null)?this.ReqArt15!=null:!entity.ReqArt15.Equals(this.ReqArt15))return false;
			 if((entity.IdClasificacion == null)?(this.IdClasificacion.HasValue && this.IdClasificacion.Value > 0):!entity.IdClasificacion.Equals(this.IdClasificacion))return false;
						  if((entity.Comentario == null)?this.Comentario!=null:!entity.Comentario.Equals(this.Comentario))return false;
			 if(!entity.PrioridadAsignada.Equals(this.PrioridadAsignada))return false;
		  if(!entity.ConfRequerimientos.Equals(this.ConfRequerimientos))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoPrioridad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("PlanPeriodo","PlanPeriodo_Nombre")
			,new DataColumnMapping("Prioridad","Prioridad_Nombre")
			,new DataColumnMapping("Puntaje","Puntaje")
			,new DataColumnMapping("ReqArt15","ReqArt15")
			,new DataColumnMapping("Clasificacion","Clasificacion_Nombre")
			,new DataColumnMapping("Comentario","Comentario")
			,new DataColumnMapping("PrioridadAsignada","PrioridadAsignada")
			,new DataColumnMapping("ConfRequerimientos","ConfRequerimientos")
			}));
		}
	}
}
		