using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ClasificacionGeograficaTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdClasificacionGeograficaTipo;}}
		 public int IdClasificacionGeograficaTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual ClasificacionGeograficaTipo ToEntity()
		{
		   ClasificacionGeograficaTipo _ClasificacionGeograficaTipo = new ClasificacionGeograficaTipo();
		_ClasificacionGeograficaTipo.IdClasificacionGeograficaTipo = this.IdClasificacionGeograficaTipo;
		 _ClasificacionGeograficaTipo.Nombre = this.Nombre;
		 _ClasificacionGeograficaTipo.Nivel = this.Nivel;
		 
		  return _ClasificacionGeograficaTipo;
		}		
		public virtual void Set(ClasificacionGeograficaTipo entity)
		{		   
		 this.IdClasificacionGeograficaTipo= entity.IdClasificacionGeograficaTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(ClasificacionGeograficaTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdClasificacionGeograficaTipo.Equals(this.IdClasificacionGeograficaTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ClasificacionGeograficaTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel","Nivel")
			}));
		}
	}
}
		