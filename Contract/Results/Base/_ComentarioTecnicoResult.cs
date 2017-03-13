using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ComentarioTecnicoResult : IResult<int>
    {        
		public virtual int ID{get{return IdComentarioTecnico;}}
		 public int IdComentarioTecnico{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual ComentarioTecnico ToEntity()
		{
		   ComentarioTecnico _ComentarioTecnico = new ComentarioTecnico();
		_ComentarioTecnico.IdComentarioTecnico = this.IdComentarioTecnico;
		 _ComentarioTecnico.Nombre = this.Nombre;
		 _ComentarioTecnico.Activo = this.Activo;
		 
		  return _ComentarioTecnico;
		}		
		public virtual void Set(ComentarioTecnico entity)
		{		   
		 this.IdComentarioTecnico= entity.IdComentarioTecnico ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(ComentarioTecnico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdComentarioTecnico.Equals(this.IdComentarioTecnico))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ComentarioTecnico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		