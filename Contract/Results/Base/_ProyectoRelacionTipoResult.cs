using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoRelacionTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoRelacionTipo;}}
		 public int IdProyectoRelacionTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual ProyectoRelacionTipo ToEntity()
		{
		   ProyectoRelacionTipo _ProyectoRelacionTipo = new ProyectoRelacionTipo();
		_ProyectoRelacionTipo.IdProyectoRelacionTipo = this.IdProyectoRelacionTipo;
		 _ProyectoRelacionTipo.Nombre = this.Nombre;
		 _ProyectoRelacionTipo.Activo = this.Activo;
		 
		  return _ProyectoRelacionTipo;
		}		
		public virtual void Set(ProyectoRelacionTipo entity)
		{		   
		 this.IdProyectoRelacionTipo= entity.IdProyectoRelacionTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(ProyectoRelacionTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoRelacionTipo.Equals(this.IdProyectoRelacionTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoRelacionTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoRelacionTipo","IdProyectoRelacionTipo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		