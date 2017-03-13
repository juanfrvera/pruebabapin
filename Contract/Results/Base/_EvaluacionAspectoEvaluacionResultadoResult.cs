using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EvaluacionAspectoEvaluacionResultadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEvalaucionAspectoEvaluacionResultado;}}
		 public int IdEvalaucionAspectoEvaluacionResultado{get;set;}
		 public int IdEvaluacionAspecto{get;set;}
		 public int IdEvaluacionResultado{get;set;}
		 
		 public string EvaluacionAspecto_Codigo{get;set;}	
	public string EvaluacionAspecto_Nombre{get;set;}	
	public string EvaluacionAspecto_Evaluacion{get;set;}	
	public bool EvaluacionAspecto_Activo{get;set;}	
	public string EvaluacionResultado_Codigo{get;set;}	
	public string EvaluacionResultado_Nombre{get;set;}	
	public string EvaluacionResultado_Aspecto{get;set;}	
	public bool EvaluacionResultado_Aprobado{get;set;}	
	public int EvaluacionResultado_Orden{get;set;}	
	public bool EvaluacionResultado_Activo{get;set;}	
					
		public virtual EvaluacionAspectoEvaluacionResultado ToEntity()
		{
		   EvaluacionAspectoEvaluacionResultado _EvaluacionAspectoEvaluacionResultado = new EvaluacionAspectoEvaluacionResultado();
		_EvaluacionAspectoEvaluacionResultado.IdEvalaucionAspectoEvaluacionResultado = this.IdEvalaucionAspectoEvaluacionResultado;
		 _EvaluacionAspectoEvaluacionResultado.IdEvaluacionAspecto = this.IdEvaluacionAspecto;
		 _EvaluacionAspectoEvaluacionResultado.IdEvaluacionResultado = this.IdEvaluacionResultado;
		 
		  return _EvaluacionAspectoEvaluacionResultado;
		}		
		public virtual void Set(EvaluacionAspectoEvaluacionResultado entity)
		{		   
		 this.IdEvalaucionAspectoEvaluacionResultado= entity.IdEvalaucionAspectoEvaluacionResultado ;
		  this.IdEvaluacionAspecto= entity.IdEvaluacionAspecto ;
		  this.IdEvaluacionResultado= entity.IdEvaluacionResultado ;
		 		  
		}		
		public virtual bool Equals(EvaluacionAspectoEvaluacionResultado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEvalaucionAspectoEvaluacionResultado.Equals(this.IdEvalaucionAspectoEvaluacionResultado))return false;
		  if(!entity.IdEvaluacionAspecto.Equals(this.IdEvaluacionAspecto))return false;
		  if(!entity.IdEvaluacionResultado.Equals(this.IdEvaluacionResultado))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EvaluacionAspectoEvaluacionResultado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("EvaluacionAspecto","EvaluacionAspecto_Nombre")
			,new DataColumnMapping("EvaluacionResultado","EvaluacionResultado_Nombre")
			}));
		}
	}
}
		