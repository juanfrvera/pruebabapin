using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoTipo;}}
		 public int IdProyectoTipo{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 public string Tipo{get;set;}
		 
		 				
		public virtual ProyectoTipo ToEntity()
		{
		   ProyectoTipo _ProyectoTipo = new ProyectoTipo();
		_ProyectoTipo.IdProyectoTipo = this.IdProyectoTipo;
		 _ProyectoTipo.Sigla = this.Sigla;
		 _ProyectoTipo.Nombre = this.Nombre;
		 _ProyectoTipo.Activo = this.Activo;
		 _ProyectoTipo.Tipo = this.Tipo;
		 
		  return _ProyectoTipo;
		}		
		public virtual void Set(ProyectoTipo entity)
		{		   
		 this.IdProyectoTipo= entity.IdProyectoTipo ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		  this.Tipo= entity.Tipo ;
		 		  
		}		
		public virtual bool Equals(ProyectoTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoTipo.Equals(this.IdProyectoTipo))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.Tipo.Equals(this.Tipo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Tipo","Tipo")
			}));
		}
	}
}
		