using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _CaracterEconomicoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdCaracterEconomicoTipo;}}
		 public int IdCaracterEconomicoTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual CaracterEconomicoTipo ToEntity()
		{
		   CaracterEconomicoTipo _CaracterEconomicoTipo = new CaracterEconomicoTipo();
		_CaracterEconomicoTipo.IdCaracterEconomicoTipo = this.IdCaracterEconomicoTipo;
		 _CaracterEconomicoTipo.Nombre = this.Nombre;
		 _CaracterEconomicoTipo.Nivel = this.Nivel;
		 
		  return _CaracterEconomicoTipo;
		}		
		public virtual void Set(CaracterEconomicoTipo entity)
		{		   
		 this.IdCaracterEconomicoTipo= entity.IdCaracterEconomicoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(CaracterEconomicoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdCaracterEconomicoTipo.Equals(this.IdCaracterEconomicoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("CaracterEconomicoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("CaracterEconomicoTipo","IdCaracterEconomicoTipo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel","Nivel")
			}));
		}
	}
}
		