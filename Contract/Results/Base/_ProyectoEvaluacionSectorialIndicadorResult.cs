using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEvaluacionSectorialIndicadorResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoEvaluacionSectorialIndicador;}}
		 public int IdProyectoEvaluacionSectorialIndicador{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdIndicadorClase{get;set;}
		 public bool Indirecto{get;set;}
         public decimal? Valor { get; set; }
		 public int IdIndicador{get;set;}
		 
		 public int? Indicador_IdMedioVerificacion{get;set;}	
	public string Indicador_Observacion{get;set;}	
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
					
		public virtual ProyectoEvaluacionSectorialIndicador ToEntity()
		{
		   ProyectoEvaluacionSectorialIndicador _ProyectoEvaluacionSectorialIndicador = new ProyectoEvaluacionSectorialIndicador();
		_ProyectoEvaluacionSectorialIndicador.IdProyectoEvaluacionSectorialIndicador = this.IdProyectoEvaluacionSectorialIndicador;
		 _ProyectoEvaluacionSectorialIndicador.IdProyecto = this.IdProyecto;
		 _ProyectoEvaluacionSectorialIndicador.IdIndicadorClase = this.IdIndicadorClase;
		 _ProyectoEvaluacionSectorialIndicador.Indirecto = this.Indirecto;
         _ProyectoEvaluacionSectorialIndicador.Valor = this.Valor;
		 _ProyectoEvaluacionSectorialIndicador.IdIndicador = this.IdIndicador;
		 
		  return _ProyectoEvaluacionSectorialIndicador;
		}		
		public virtual void Set(ProyectoEvaluacionSectorialIndicador entity)
		{		   
		 this.IdProyectoEvaluacionSectorialIndicador= entity.IdProyectoEvaluacionSectorialIndicador ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdIndicadorClase= entity.IdIndicadorClase ;
		  this.Indirecto= entity.Indirecto ;
          this.Valor = entity.Valor;
		  this.IdIndicador= entity.IdIndicador ;
		 		  
		}		
		public virtual bool Equals(ProyectoEvaluacionSectorialIndicador entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEvaluacionSectorialIndicador.Equals(this.IdProyectoEvaluacionSectorialIndicador))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdIndicadorClase.Equals(this.IdIndicadorClase))return false;
		  if(!entity.Indirecto.Equals(this.Indirecto))return false;
          if (!entity.Valor.Equals(this.Valor)) return false;
		  if(!entity.IdIndicador.Equals(this.IdIndicador))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEvaluacionSectorialIndicador", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("IndicadorClase","IndicadorClase_Nombre")
			,new DataColumnMapping("Indirecto","Indirecto")
			,new DataColumnMapping("Indicador","Indicador_Observacion")
            ,new DataColumnMapping("Valor","Valor")
			}));
		}
	}
}
		