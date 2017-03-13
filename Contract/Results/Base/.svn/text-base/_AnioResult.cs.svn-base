using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _AnioResult : IResult<int>
    {        
		public virtual int ID{get{return IdAnio;}}
		 public int IdAnio{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Anio ToEntity()
		{
		   Anio _Anio = new Anio();
		_Anio.IdAnio = this.IdAnio;
		 _Anio.Nombre = this.Nombre;
		 _Anio.Activo = this.Activo;
		 
		  return _Anio;
		}		
		public virtual void Set(Anio entity)
		{		   
		 this.IdAnio= entity.IdAnio ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Anio entity)
        {
		   if(entity == null)return false;
         if(!entity.IdAnio.Equals(this.IdAnio))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Anio", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		