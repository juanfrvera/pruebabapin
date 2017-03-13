using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _JurisdiccionResult : IResult<int>
    {        
		public virtual int ID{get{return IdJurisdiccion;}}
		 public int IdJurisdiccion{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Jurisdiccion ToEntity()
		{
		   Jurisdiccion _Jurisdiccion = new Jurisdiccion();
		_Jurisdiccion.IdJurisdiccion = this.IdJurisdiccion;
		 _Jurisdiccion.Codigo = this.Codigo;
		 _Jurisdiccion.Nombre = this.Nombre;
		 _Jurisdiccion.Activo = this.Activo;
		 
		  return _Jurisdiccion;
		}		
		public virtual void Set(Jurisdiccion entity)
		{		   
		 this.IdJurisdiccion= entity.IdJurisdiccion ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Jurisdiccion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdJurisdiccion.Equals(this.IdJurisdiccion))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Jurisdiccion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		