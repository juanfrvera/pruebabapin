using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EvaluacionTipoEvaluacionAspectoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEvalaucionTipoEvaluacionAspecto;}}
		 public int IdEvalaucionTipoEvaluacionAspecto{get;set;}
		 public int IdEvaluacionTipo{get;set;}
		 public int IdEvaluacionAspecto{get;set;}
		 
		 public string EvaluacionAspecto_Codigo{get;set;}	
	public string EvaluacionAspecto_Nombre{get;set;}	
	public string EvaluacionAspecto_Evaluacion{get;set;}	
	public bool EvaluacionAspecto_Activo{get;set;}	
	public string EvaluacionTipo_Codigo{get;set;}	
	public string EvaluacionTipo_Nombre{get;set;}	
	public bool? EvaluacionTipo_Activo{get;set;}	
					
		public virtual EvaluacionTipoEvaluacionAspecto ToEntity()
		{
		   EvaluacionTipoEvaluacionAspecto _EvaluacionTipoEvaluacionAspecto = new EvaluacionTipoEvaluacionAspecto();
		_EvaluacionTipoEvaluacionAspecto.IdEvalaucionTipoEvaluacionAspecto = this.IdEvalaucionTipoEvaluacionAspecto;
		 _EvaluacionTipoEvaluacionAspecto.IdEvaluacionTipo = this.IdEvaluacionTipo;
		 _EvaluacionTipoEvaluacionAspecto.IdEvaluacionAspecto = this.IdEvaluacionAspecto;
		 
		  return _EvaluacionTipoEvaluacionAspecto;
		}		
		public virtual void Set(EvaluacionTipoEvaluacionAspecto entity)
		{		   
		 this.IdEvalaucionTipoEvaluacionAspecto= entity.IdEvalaucionTipoEvaluacionAspecto ;
		  this.IdEvaluacionTipo= entity.IdEvaluacionTipo ;
		  this.IdEvaluacionAspecto= entity.IdEvaluacionAspecto ;
		 		  
		}		
		public virtual bool Equals(EvaluacionTipoEvaluacionAspecto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEvalaucionTipoEvaluacionAspecto.Equals(this.IdEvalaucionTipoEvaluacionAspecto))return false;
		  if(!entity.IdEvaluacionTipo.Equals(this.IdEvaluacionTipo))return false;
		  if(!entity.IdEvaluacionAspecto.Equals(this.IdEvaluacionAspecto))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EvaluacionTipoEvaluacionAspecto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("EvaluacionTipo","EvaluacionTipo_Nombre")
			,new DataColumnMapping("EvaluacionAspecto","EvaluacionAspecto_Nombre")
			}));
		}
	}
}
		