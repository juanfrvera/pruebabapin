using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoDemoraResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoDemora;}}
		 public int IdProyectoDemora{get;set;}
		 public int IdProyecto{get;set;}
		 public string Justificacion{get;set;}
		 public DateTime Fecha{get;set;}
		 
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
					
		public virtual ProyectoDemora ToEntity()
		{
		   ProyectoDemora _ProyectoDemora = new ProyectoDemora();
		_ProyectoDemora.IdProyectoDemora = this.IdProyectoDemora;
		 _ProyectoDemora.IdProyecto = this.IdProyecto;
		 _ProyectoDemora.Justificacion = this.Justificacion;
		 _ProyectoDemora.Fecha = this.Fecha;
		 
		  return _ProyectoDemora;
		}		
		public virtual void Set(ProyectoDemora entity)
		{		   
		 this.IdProyectoDemora= entity.IdProyectoDemora ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.Justificacion= entity.Justificacion ;
		  this.Fecha= entity.Fecha ;
		 		  
		}		
		public virtual bool Equals(ProyectoDemora entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoDemora.Equals(this.IdProyectoDemora))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.Justificacion.Equals(this.Justificacion))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoDemora", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Justificacion","Justificacion")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			}));
		}
	}
}
		