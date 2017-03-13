using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorEvolucionInstanciaResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorEvolucionInstancia;}}
		 public int IdIndicadorEvolucionInstancia{get;set;}
		 public string Nombre{get;set;}
		 public int? Orden{get;set;}
		 
		 				
		public virtual IndicadorEvolucionInstancia ToEntity()
		{
		   IndicadorEvolucionInstancia _IndicadorEvolucionInstancia = new IndicadorEvolucionInstancia();
		_IndicadorEvolucionInstancia.IdIndicadorEvolucionInstancia = this.IdIndicadorEvolucionInstancia;
		 _IndicadorEvolucionInstancia.Nombre = this.Nombre;
		 _IndicadorEvolucionInstancia.Orden = this.Orden;
		 
		  return _IndicadorEvolucionInstancia;
		}		
		public virtual void Set(IndicadorEvolucionInstancia entity)
		{		   
		 this.IdIndicadorEvolucionInstancia= entity.IdIndicadorEvolucionInstancia ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		 		  
		}		
		public virtual bool Equals(IndicadorEvolucionInstancia entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorEvolucionInstancia.Equals(this.IdIndicadorEvolucionInstancia))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.Orden == null)?this.Orden!=null:!entity.Orden.Equals(this.Orden))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorEvolucionInstancia", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("IndicadorEvolucionInstancia","IdIndicadorEvolucionInstancia")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Orden","Orden")
			}));
		}
	}
}
		