using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SubJurisdiccionResult : IResult<int>
    {        
		public virtual int ID{get{return IdSubJuridiccion;}}
		 public int IdSubJuridiccion{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual SubJurisdiccion ToEntity()
		{
		   SubJurisdiccion _SubJurisdiccion = new SubJurisdiccion();
		_SubJurisdiccion.IdSubJuridiccion = this.IdSubJuridiccion;
		 _SubJurisdiccion.Codigo = this.Codigo;
		 _SubJurisdiccion.Nombre = this.Nombre;
		 _SubJurisdiccion.Activo = this.Activo;
		 
		  return _SubJurisdiccion;
		}		
		public virtual void Set(SubJurisdiccion entity)
		{		   
		 this.IdSubJuridiccion= entity.IdSubJuridiccion ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(SubJurisdiccion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSubJuridiccion.Equals(this.IdSubJuridiccion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SubJurisdiccion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		