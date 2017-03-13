using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorPriorizacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorPriorizacion;}}
		 public int IdIndicadorPriorizacion{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual IndicadorPriorizacion ToEntity()
		{
		   IndicadorPriorizacion _IndicadorPriorizacion = new IndicadorPriorizacion();
		_IndicadorPriorizacion.IdIndicadorPriorizacion = this.IdIndicadorPriorizacion;
		 _IndicadorPriorizacion.Codigo = this.Codigo;
		 _IndicadorPriorizacion.Nombre = this.Nombre;
		 _IndicadorPriorizacion.Activo = this.Activo;
		 
		  return _IndicadorPriorizacion;
		}		
		public virtual void Set(IndicadorPriorizacion entity)
		{		   
		 this.IdIndicadorPriorizacion= entity.IdIndicadorPriorizacion ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorPriorizacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorPriorizacion.Equals(this.IdIndicadorPriorizacion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
	}
}
		