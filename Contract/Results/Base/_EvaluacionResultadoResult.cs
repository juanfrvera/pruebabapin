using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EvaluacionResultadoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEvaluacionResultado;}}
		 public int IdEvaluacionResultado{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public string Aspecto{get;set;}
		 public bool Aprobado{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual EvaluacionResultado ToEntity()
		{
		   EvaluacionResultado _EvaluacionResultado = new EvaluacionResultado();
		_EvaluacionResultado.IdEvaluacionResultado = this.IdEvaluacionResultado;
		 _EvaluacionResultado.Codigo = this.Codigo;
		 _EvaluacionResultado.Nombre = this.Nombre;
		 _EvaluacionResultado.Aspecto = this.Aspecto;
		 _EvaluacionResultado.Aprobado = this.Aprobado;
		 _EvaluacionResultado.Orden = this.Orden;
		 _EvaluacionResultado.Activo = this.Activo;
		 
		  return _EvaluacionResultado;
		}		
		public virtual void Set(EvaluacionResultado entity)
		{		   
		 this.IdEvaluacionResultado= entity.IdEvaluacionResultado ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Aspecto= entity.Aspecto ;
		  this.Aprobado= entity.Aprobado ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EvaluacionResultado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEvaluacionResultado.Equals(this.IdEvaluacionResultado))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Aspecto.Equals(this.Aspecto))return false;
		  if(!entity.Aprobado.Equals(this.Aprobado))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EvaluacionResultado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Aspecto","Aspecto")
			,new DataColumnMapping("Aprobado","Aprobado")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		