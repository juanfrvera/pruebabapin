using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _GestionTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdGestionTipo;}}
		 public int IdGestionTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual GestionTipo ToEntity()
		{
		   GestionTipo _GestionTipo = new GestionTipo();
		_GestionTipo.IdGestionTipo = this.IdGestionTipo;
		 _GestionTipo.Nombre = this.Nombre;
		 _GestionTipo.Activo = this.Activo;
		 
		  return _GestionTipo;
		}		
		public virtual void Set(GestionTipo entity)
		{		   
		 this.IdGestionTipo= entity.IdGestionTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(GestionTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdGestionTipo.Equals(this.IdGestionTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("GestionTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		