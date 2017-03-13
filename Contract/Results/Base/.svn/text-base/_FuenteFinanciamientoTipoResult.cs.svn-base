using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _FuenteFinanciamientoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdFuenteFinanciamientoTipo;}}
		 public int IdFuenteFinanciamientoTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual FuenteFinanciamientoTipo ToEntity()
		{
		   FuenteFinanciamientoTipo _FuenteFinanciamientoTipo = new FuenteFinanciamientoTipo();
		_FuenteFinanciamientoTipo.IdFuenteFinanciamientoTipo = this.IdFuenteFinanciamientoTipo;
		 _FuenteFinanciamientoTipo.Nombre = this.Nombre;
		 _FuenteFinanciamientoTipo.Nivel = this.Nivel;
		 
		  return _FuenteFinanciamientoTipo;
		}		
		public virtual void Set(FuenteFinanciamientoTipo entity)
		{		   
		 this.IdFuenteFinanciamientoTipo= entity.IdFuenteFinanciamientoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(FuenteFinanciamientoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdFuenteFinanciamientoTipo.Equals(this.IdFuenteFinanciamientoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("FuenteFinanciamientoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel","Nivel")
			}));
		}
	}
}
		