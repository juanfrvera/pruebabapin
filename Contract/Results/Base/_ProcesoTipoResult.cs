using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProcesoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProcesoTipo;}}
		 public int IdProcesoTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual ProcesoTipo ToEntity()
		{
		   ProcesoTipo _ProcesoTipo = new ProcesoTipo();
		_ProcesoTipo.IdProcesoTipo = this.IdProcesoTipo;
		 _ProcesoTipo.Nombre = this.Nombre;
		 _ProcesoTipo.Nivel = this.Nivel;
		 
		  return _ProcesoTipo;
		}		
		public virtual void Set(ProcesoTipo entity)
		{		   
		 this.IdProcesoTipo= entity.IdProcesoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(ProcesoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProcesoTipo.Equals(this.IdProcesoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
	}
}
		