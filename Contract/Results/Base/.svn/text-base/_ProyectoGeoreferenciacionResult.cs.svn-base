using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoGeoreferenciacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoGeoreferenciacion;}}
		 public int IdProyectoGeoreferenciacion{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdGeoreferenciacion{get;set;}
		 
		 public int Georeferenciacion_Tipo{get;set;}	
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
					
		public virtual ProyectoGeoreferenciacion ToEntity()
		{
		   ProyectoGeoreferenciacion _ProyectoGeoreferenciacion = new ProyectoGeoreferenciacion();
		_ProyectoGeoreferenciacion.IdProyectoGeoreferenciacion = this.IdProyectoGeoreferenciacion;
		 _ProyectoGeoreferenciacion.IdProyecto = this.IdProyecto;
		 _ProyectoGeoreferenciacion.IdGeoreferenciacion = this.IdGeoreferenciacion;
		 
		  return _ProyectoGeoreferenciacion;
		}		
		public virtual void Set(ProyectoGeoreferenciacion entity)
		{		   
		 this.IdProyectoGeoreferenciacion= entity.IdProyectoGeoreferenciacion ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdGeoreferenciacion= entity.IdGeoreferenciacion ;
		 		  
		}		
		public virtual bool Equals(ProyectoGeoreferenciacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoGeoreferenciacion.Equals(this.IdProyectoGeoreferenciacion))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdGeoreferenciacion.Equals(this.IdGeoreferenciacion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoGeoreferenciacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Georeferenciacion","Georeferenciacion_IdGeoreferenciacion")
			}));
		}
	}
}
		