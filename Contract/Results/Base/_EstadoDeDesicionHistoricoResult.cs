using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EstadoDeDesicionHistoricoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEstadoDeDesicionHistorico;}}
		 public int IdEstadoDeDesicionHistorico{get;set;}
		 public int IdEstadoDeDesicion{get;set;}
		 public int IdProyecto{get;set;}
		 public DateTime Fecha{get;set;}
		 public int IdUsuario{get;set;}
		 public string Observacion{get;set;}
		 
		 public string EstadoDeDesicion_Nombre{get;set;}	
	public string EstadoDeDesicion_Codigo{get;set;}	
	public int EstadoDeDesicion_Orden{get;set;}	
	public string EstadoDeDesicion_Descripcion{get;set;}	
	public bool EstadoDeDesicion_Activo{get;set;}	
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
	public bool Proyecto_Activo{get;set;}	
	public int? Proyecto_IdEstadoDeDesicion{get;set;}	
	public string Usuario_NombreUsuario{get;set;}	
	public string Usuario_Clave{get;set;}	
	public bool Usuario_Activo{get;set;}	
	public bool Usuario_EsSectioralista{get;set;}	
	public int Usuario_IdLanguage{get;set;}	
	public bool Usuario_AccesoTotal{get;set;}	
					
		public virtual EstadoDeDesicionHistorico ToEntity()
		{
		   EstadoDeDesicionHistorico _EstadoDeDesicionHistorico = new EstadoDeDesicionHistorico();
		_EstadoDeDesicionHistorico.IdEstadoDeDesicionHistorico = this.IdEstadoDeDesicionHistorico;
		 _EstadoDeDesicionHistorico.IdEstadoDeDesicion = this.IdEstadoDeDesicion;
		 _EstadoDeDesicionHistorico.IdProyecto = this.IdProyecto;
		 _EstadoDeDesicionHistorico.Fecha = this.Fecha;
		 _EstadoDeDesicionHistorico.IdUsuario = this.IdUsuario;
		 _EstadoDeDesicionHistorico.Observacion = this.Observacion;
		 
		  return _EstadoDeDesicionHistorico;
		}		
		public virtual void Set(EstadoDeDesicionHistorico entity)
		{		   
		 this.IdEstadoDeDesicionHistorico= entity.IdEstadoDeDesicionHistorico ;
		  this.IdEstadoDeDesicion= entity.IdEstadoDeDesicion ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.Fecha= entity.Fecha ;
		  this.IdUsuario= entity.IdUsuario ;
		  this.Observacion= entity.Observacion ;
		 		  
		}		
		public virtual bool Equals(EstadoDeDesicionHistorico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEstadoDeDesicionHistorico.Equals(this.IdEstadoDeDesicionHistorico))return false;
		  if(!entity.IdEstadoDeDesicion.Equals(this.IdEstadoDeDesicion))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EstadoDeDesicionHistorico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("EstadoDeDesicion","EstadoDeDesicion_Nombre")
			,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Usuario","Usuario_NombreUsuario")
			,new DataColumnMapping("Observacion","Observacion")
			}));
		}
	}
}
		