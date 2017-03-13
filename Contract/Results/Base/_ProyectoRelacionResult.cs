using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoRelacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoRelacion;}}
		 public int IdProyectoRelacion{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdProyectoRelacionado{get;set;}
		 public int IdProyectoRelacionTipo{get;set;}
		 
    //     public int ProyectoRelacionado_IdTipoProyecto{get;set;}	
    //public int ProyectoRelacionado_IdSubPrograma{get;set;}	
	public int ProyectoRelacionado_Codigo{get;set;}	
    public string ProyectoRelacionado_ProyectoDenominacion{get;set;}	
    //public string ProyectoRelacionado_ProyectoSituacionActual{get;set;}	
    //public string ProyectoRelacionado_ProyectoDescripcion{get;set;}	
    //public string ProyectoRelacionado_ProyectoObservacion{get;set;}	
    //public int ProyectoRelacionado_IdEstado{get;set;}	
    //public int? ProyectoRelacionado_IdProceso{get;set;}	
    //public int? ProyectoRelacionado_IdModalidadContratacion{get;set;}	
    //public int? ProyectoRelacionado_IdFinalidadFuncion{get;set;}	
    //public int? ProyectoRelacionado_IdOrganismoPrioridad{get;set;}	
    //public int? ProyectoRelacionado_SubPrioridad{get;set;}	
    //public bool ProyectoRelacionado_EsBorrador{get;set;}	
    //public bool? ProyectoRelacionado_EsProyecto{get;set;}	
    //public int? ProyectoRelacionado_NroProyecto{get;set;}	
    //public int? ProyectoRelacionado_AnioCorriente{get;set;}	
    //public DateTime? ProyectoRelacionado_FechaInicioEjecucionCalculada{get;set;}	
    //public DateTime? ProyectoRelacionado_FechaFinEjecucionCalculada{get;set;}	
    //public DateTime ProyectoRelacionado_FechaAlta{get;set;}	
    //public DateTime ProyectoRelacionado_FechaModificacion{get;set;}	
    //public int ProyectoRelacionado_IdUsuarioModificacion{get;set;}	
    //public int? ProyectoRelacionado_IdProyectoPlan{get;set;}	
    //public bool ProyectoRelacionado_EvaluarValidaciones{get;set;}	
    //public int Proyecto_IdTipoProyecto{get;set;}	
    //public int Proyecto_IdSubPrograma{get;set;}	
    //public int Proyecto_Codigo{get;set;}	
    public string Proyecto_ProyectoDenominacion{get;set;}	
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
	public string ProyectoRelacionTipo_Nombre{get;set;}	
	//public bool ProyectoRelacionTipo_Activo{get;set;}	
					
		public virtual ProyectoRelacion ToEntity()
		{
		   ProyectoRelacion _ProyectoRelacion = new ProyectoRelacion();
		_ProyectoRelacion.IdProyectoRelacion = this.IdProyectoRelacion;
		 _ProyectoRelacion.IdProyecto = this.IdProyecto;
		 _ProyectoRelacion.IdProyectoRelacionado = this.IdProyectoRelacionado;
		 _ProyectoRelacion.IdProyectoRelacionTipo = this.IdProyectoRelacionTipo;
		 
		  return _ProyectoRelacion;
		}		
		public virtual void Set(ProyectoRelacion entity)
		{		   
		 this.IdProyectoRelacion= entity.IdProyectoRelacion ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdProyectoRelacionado= entity.IdProyectoRelacionado ;
		  this.IdProyectoRelacionTipo= entity.IdProyectoRelacionTipo ;
		 		  
		}		
		public virtual bool Equals(ProyectoRelacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoRelacion.Equals(this.IdProyectoRelacion))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdProyectoRelacionado.Equals(this.IdProyectoRelacionado))return false;
		  if(!entity.IdProyectoRelacionTipo.Equals(this.IdProyectoRelacionTipo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoRelacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		     new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ProyectoRelacionado","ProyectoRelacionado_ProyectoDenominacion")
			,new DataColumnMapping("ProyectoRelacionTipo","ProyectoRelacionTipo_Nombre")
			}));
		}
	}
}
		