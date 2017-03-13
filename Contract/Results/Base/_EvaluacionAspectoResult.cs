using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EvaluacionAspectoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEvaluacionAspecto;}}
		 public int IdEvaluacionAspecto{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public string Evaluacion{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual EvaluacionAspecto ToEntity()
		{
		   EvaluacionAspecto _EvaluacionAspecto = new EvaluacionAspecto();
		_EvaluacionAspecto.IdEvaluacionAspecto = this.IdEvaluacionAspecto;
		 _EvaluacionAspecto.Codigo = this.Codigo;
		 _EvaluacionAspecto.Nombre = this.Nombre;
		 _EvaluacionAspecto.Evaluacion = this.Evaluacion;
		 _EvaluacionAspecto.Activo = this.Activo;
		 
		  return _EvaluacionAspecto;
		}		
		public virtual void Set(EvaluacionAspecto entity)
		{		   
		 this.IdEvaluacionAspecto= entity.IdEvaluacionAspecto ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Evaluacion= entity.Evaluacion ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EvaluacionAspecto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEvaluacionAspecto.Equals(this.IdEvaluacionAspecto))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.Evaluacion == null)?this.Evaluacion!=null:!entity.Evaluacion.Equals(this.Evaluacion))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EvaluacionAspecto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Evaluacion","Evaluacion")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		