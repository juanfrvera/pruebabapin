using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _FaseResult : IResult<int>
    {        
		public virtual int ID{get{return IdFase;}}
		 public int IdFase{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Fase ToEntity()
		{
		   Fase _Fase = new Fase();
		_Fase.IdFase = this.IdFase;
		 _Fase.Codigo = this.Codigo;
		 _Fase.Nombre = this.Nombre;
		 _Fase.Orden = this.Orden;
		 _Fase.Activo = this.Activo;
		 
		  return _Fase;
		}		
		public virtual void Set(Fase entity)
		{		   
		 this.IdFase= entity.IdFase ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Fase entity)
        {
		   if(entity == null)return false;
         if(!entity.IdFase.Equals(this.IdFase))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Fase", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		