using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _AdministracionTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdAdministracionTipo;}}
		 public int IdAdministracionTipo{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual AdministracionTipo ToEntity()
		{
		   AdministracionTipo _AdministracionTipo = new AdministracionTipo();
		_AdministracionTipo.IdAdministracionTipo = this.IdAdministracionTipo;
		 _AdministracionTipo.Codigo = this.Codigo;
		 _AdministracionTipo.Nombre = this.Nombre;
		 _AdministracionTipo.Activo = this.Activo;
		 
		  return _AdministracionTipo;
		}		
		public virtual void Set(AdministracionTipo entity)
		{		   
		 this.IdAdministracionTipo= entity.IdAdministracionTipo ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(AdministracionTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdAdministracionTipo.Equals(this.IdAdministracionTipo))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("AdministracionTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		