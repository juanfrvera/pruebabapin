using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorSectorResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorSector;}}
		 public int IdIndicadorSector{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual IndicadorSector ToEntity()
		{
		   IndicadorSector _IndicadorSector = new IndicadorSector();
		_IndicadorSector.IdIndicadorSector = this.IdIndicadorSector;
		 _IndicadorSector.Nombre = this.Nombre;
		 _IndicadorSector.Activo = this.Activo;
		 
		  return _IndicadorSector;
		}		
		public virtual void Set(IndicadorSector entity)
		{		   
		 this.IdIndicadorSector= entity.IdIndicadorSector ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorSector entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorSector.Equals(this.IdIndicadorSector))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
	}
}
		