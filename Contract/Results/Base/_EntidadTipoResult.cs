using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _EntidadTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdEntidadTipo;}}
		 public int IdEntidadTipo{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual EntidadTipo ToEntity()
		{
		   EntidadTipo _EntidadTipo = new EntidadTipo();
		_EntidadTipo.IdEntidadTipo = this.IdEntidadTipo;
		 _EntidadTipo.Codigo = this.Codigo;
		 _EntidadTipo.Nombre = this.Nombre;
		 _EntidadTipo.Activo = this.Activo;
		 
		  return _EntidadTipo;
		}		
		public virtual void Set(EntidadTipo entity)
		{		   
		 this.IdEntidadTipo= entity.IdEntidadTipo ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(EntidadTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdEntidadTipo.Equals(this.IdEntidadTipo))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("EntidadTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		