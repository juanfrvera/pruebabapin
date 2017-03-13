using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EvaluacionTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEvaluacionTipo;}}
		 public int IdEvaluacionTipo{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool? Activo{get;set;}
		 
		 				
		public virtual EvaluacionTipo ToEntity()
		{
		   EvaluacionTipo _EvaluacionTipo = new EvaluacionTipo();
		_EvaluacionTipo.IdEvaluacionTipo = this.IdEvaluacionTipo;
		 _EvaluacionTipo.Codigo = this.Codigo;
		 _EvaluacionTipo.Nombre = this.Nombre;
		 _EvaluacionTipo.Activo = this.Activo;
		 
		  return _EvaluacionTipo;
		}		
		public virtual void Set(EvaluacionTipo entity)
		{		   
		 this.IdEvaluacionTipo= entity.IdEvaluacionTipo ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EvaluacionTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEvaluacionTipo.Equals(this.IdEvaluacionTipo))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.Activo == null)?this.Activo!=null:!entity.Activo.Equals(this.Activo))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EvaluacionTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		