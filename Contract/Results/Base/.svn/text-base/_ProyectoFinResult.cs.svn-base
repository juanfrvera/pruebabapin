using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoFinResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoFin;}}
		 public int IdProyectoFin{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdProgramaObjetivo{get;set;}
		 
    //     public int ProgramaObjetivo_IdPrograma{get;set;}	
    //public int ProgramaObjetivo_IDObjetivo{get;set;}	
    //public int Proyecto_IdTipoProyecto{get;set;}	
    //public int Proyecto_IdSubPrograma{get;set;}	
    //public int Proyecto_Codigo{get;set;}	
    //public string Proyecto_ProyectoDenominacion{get;set;}	
    //public string Proyecto_ProyectoSituacionActual{get;set;}	
    //public string Proyecto_ProyectoDescripcion{get;set;}	
    //public string Proyecto_ProyectoObservacion{get;set;}	
    //public int Proyecto_IdEstado{get;set;}	
    //public int? Proyecto_IdProceso{get;set;}	
    //public int? Proyecto_IdModalidadContratacion{get;set;}	
    //public int? Proyecto_IdFinalidadFuncion{get;set;}	
    //public int? Proyecto_IdOrganismoPrioridad{get;set;}	
    //public int? Proyecto_SubPrioridad{get;set;}	
    //public bool Proyecto_EsBorrador{get;set;}	
    //public bool? Proyecto_EsProyecto{get;set;}	
    //public int? Proyecto_NroProyecto{get;set;}	
    //public int? Proyecto_AnioCorriente{get;set;}	
    //public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
    //public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
    //public DateTime Proyecto_FechaAlta{get;set;}	
    //public DateTime Proyecto_FechaModificacion{get;set;}	
    //public int Proyecto_IdUsuarioModificacion{get;set;}	
    //public int? Proyecto_IdProyectoPlan{get;set;}	
    //public bool Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoFin ToEntity()
		{
		   ProyectoFin _ProyectoFin = new ProyectoFin();
		_ProyectoFin.IdProyectoFin = this.IdProyectoFin;
		 _ProyectoFin.IdProyecto = this.IdProyecto;
		 _ProyectoFin.IdProgramaObjetivo = this.IdProgramaObjetivo;
		 
		  return _ProyectoFin;
		}		
		public virtual void Set(ProyectoFin entity)
		{		   
		 this.IdProyectoFin= entity.IdProyectoFin ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdProgramaObjetivo= entity.IdProgramaObjetivo ;
		 		  
		}		
		public virtual bool Equals(ProyectoFin entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoFin.Equals(this.IdProyectoFin))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdProgramaObjetivo.Equals(this.IdProgramaObjetivo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoFin", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ProgramaObjetivo","ProgramaObjetivo_IdProgramaObjetivo")
			}));
		}
	}
}
		