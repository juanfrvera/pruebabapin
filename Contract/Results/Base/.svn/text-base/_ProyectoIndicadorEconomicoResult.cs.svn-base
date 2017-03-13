using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoIndicadorEconomicoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoIndicadorEconomico;}}
		 public int IdProyectoIndicadorEconomico{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdIndicadorClase{get;set;}
		 public decimal? Valor{get;set;}
		 public int? Anio{get;set;}
		 public string Observacion{get;set;}
		 
		 public int IndicadorClase_IdIndicadorTipo{get;set;}	
	public string IndicadorClase_Sigla{get;set;}	
	public string IndicadorClase_Nombre{get;set;}	
	public int IndicadorClase_IdUnidad{get;set;}	
	public int? IndicadorClase_RangoInicial{get;set;}	
	public int? IndicadorClase_RangoFinal{get;set;}	
	public bool IndicadorClase_Activo{get;set;}	
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
					
		public virtual ProyectoIndicadorEconomico ToEntity()
		{
		   ProyectoIndicadorEconomico _ProyectoIndicadorEconomico = new ProyectoIndicadorEconomico();
		_ProyectoIndicadorEconomico.IdProyectoIndicadorEconomico = this.IdProyectoIndicadorEconomico;
		 _ProyectoIndicadorEconomico.IdProyecto = this.IdProyecto;
		 _ProyectoIndicadorEconomico.IdIndicadorClase = this.IdIndicadorClase;
		 _ProyectoIndicadorEconomico.Valor = this.Valor;
		 _ProyectoIndicadorEconomico.Anio = this.Anio;
		 _ProyectoIndicadorEconomico.Observacion = this.Observacion;
		 
		  return _ProyectoIndicadorEconomico;
		}		
		public virtual void Set(ProyectoIndicadorEconomico entity)
		{		   
		 this.IdProyectoIndicadorEconomico= entity.IdProyectoIndicadorEconomico ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdIndicadorClase= entity.IdIndicadorClase ;
		  this.Valor= entity.Valor ;
		  this.Anio= entity.Anio ;
		  this.Observacion= entity.Observacion ;
		 		  
		}		
		public virtual bool Equals(ProyectoIndicadorEconomico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoIndicadorEconomico.Equals(this.IdProyectoIndicadorEconomico))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdIndicadorClase.Equals(this.IdIndicadorClase))return false;
		  if((entity.Valor == null)?this.Valor!=null:!entity.Valor.Equals(this.Valor))return false;
			 if((entity.Anio == null)?this.Anio!=null:!entity.Anio.Equals(this.Anio))return false;
			 if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoIndicadorEconomico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("IndicadorClase","IndicadorClase_Nombre")
			,new DataColumnMapping("Valor","Valor")
			,new DataColumnMapping("Anio","Anio")
			,new DataColumnMapping("Observacion","Observacion")
			}));
		}
	}
}
		