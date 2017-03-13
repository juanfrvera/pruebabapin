using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _DictamenTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdDictamenTipo;}}
		 public int IdDictamenTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual DictamenTipo ToEntity()
		{
		   DictamenTipo _DictamenTipo = new DictamenTipo();
		_DictamenTipo.IdDictamenTipo = this.IdDictamenTipo;
		 _DictamenTipo.Nombre = this.Nombre;
		 _DictamenTipo.Nivel = this.Nivel;
		 
		  return _DictamenTipo;
		}		
		public virtual void Set(DictamenTipo entity)
		{		   
		 this.IdDictamenTipo= entity.IdDictamenTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(DictamenTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdDictamenTipo.Equals(this.IdDictamenTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
	}
}
		