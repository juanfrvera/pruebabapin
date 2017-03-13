using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrioridadResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrioridad;}}
		 public int IdPrioridad{get;set;}
		 public string Sigla{get;set;}
		 public int Orden{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Prioridad ToEntity()
		{
		   Prioridad _Prioridad = new Prioridad();
		_Prioridad.IdPrioridad = this.IdPrioridad;
		 _Prioridad.Sigla = this.Sigla;
		 _Prioridad.Orden = this.Orden;
		 _Prioridad.Nombre = this.Nombre;
		 _Prioridad.Activo = this.Activo;
		 
		  return _Prioridad;
		}		
		public virtual void Set(Prioridad entity)
		{		   
		 this.IdPrioridad= entity.IdPrioridad ;
		  this.Sigla= entity.Sigla ;
		  this.Orden= entity.Orden ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Prioridad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrioridad.Equals(this.IdPrioridad))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Prioridad", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		