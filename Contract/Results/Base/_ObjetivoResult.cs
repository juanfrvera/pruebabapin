using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ObjetivoResult : IResult<int>
    {        
		public virtual int ID{get{return IdObjetivo;}}
		 public int IdObjetivo{get;set;}
		 public string Nombre{get;set;}
		 
		 				
		public virtual Objetivo ToEntity()
		{
		   Objetivo _Objetivo = new Objetivo();
		_Objetivo.IdObjetivo = this.IdObjetivo;
		 _Objetivo.Nombre = this.Nombre;
		 
		  return _Objetivo;
		}		
		public virtual void Set(Objetivo entity)
		{		   
		 this.IdObjetivo= entity.IdObjetivo ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(Objetivo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdObjetivo.Equals(this.IdObjetivo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Objetivo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		