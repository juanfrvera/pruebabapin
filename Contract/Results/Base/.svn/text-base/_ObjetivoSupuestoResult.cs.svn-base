using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ObjetivoSupuestoResult : IResult<int>
    {        
		public virtual int ID{get{return IdObjetivoSupuesto;}}
		 public int IdObjetivoSupuesto{get;set;}
		 public int IdObjetivo{get;set;}
		 public string Descripcion{get;set;}
		 
		 public string Objetivo_Nombre{get;set;}	
					
		public virtual ObjetivoSupuesto ToEntity()
		{
		   ObjetivoSupuesto _ObjetivoSupuesto = new ObjetivoSupuesto();
		_ObjetivoSupuesto.IdObjetivoSupuesto = this.IdObjetivoSupuesto;
		 _ObjetivoSupuesto.IdObjetivo = this.IdObjetivo;
		 _ObjetivoSupuesto.Descripcion = this.Descripcion;
		 
		  return _ObjetivoSupuesto;
		}		
		public virtual void Set(ObjetivoSupuesto entity)
		{		   
		 this.IdObjetivoSupuesto= entity.IdObjetivoSupuesto ;
		  this.IdObjetivo= entity.IdObjetivo ;
		  this.Descripcion= entity.Descripcion ;
		 		  
		}		
		public virtual bool Equals(ObjetivoSupuesto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdObjetivoSupuesto.Equals(this.IdObjetivoSupuesto))return false;
		  if(!entity.IdObjetivo.Equals(this.IdObjetivo))return false;
		  if(!entity.Descripcion.Equals(this.Descripcion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ObjetivoSupuesto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Objetivo","Objetivo_Nombre")
			,new DataColumnMapping("Descripcion","Descripcion")
			}));
		}
	}
}
		