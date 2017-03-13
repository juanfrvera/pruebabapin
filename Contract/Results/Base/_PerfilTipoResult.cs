using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PerfilTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPerfilTipo;}}
		 public int IdPerfilTipo{get;set;}
		 public string Nombre{get;set;}
		 
		 				
		public virtual PerfilTipo ToEntity()
		{
		   PerfilTipo _PerfilTipo = new PerfilTipo();
		_PerfilTipo.IdPerfilTipo = this.IdPerfilTipo;
		 _PerfilTipo.Nombre = this.Nombre;
		 
		  return _PerfilTipo;
		}		
		public virtual void Set(PerfilTipo entity)
		{		   
		 this.IdPerfilTipo= entity.IdPerfilTipo ;
		  this.Nombre= entity.Nombre ;
		 		  
		}		
		public virtual bool Equals(PerfilTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPerfilTipo.Equals(this.IdPerfilTipo))return false;
		  if((entity.Nombre == null)?this.Nombre!=null:!entity.Nombre.Equals(this.Nombre))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PerfilTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PerfilTipo","IdPerfilTipo")
			,new DataColumnMapping("Nombre","Nombre")
			}));
		}
	}
}
		