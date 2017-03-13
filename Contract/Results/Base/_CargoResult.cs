using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _CargoResult : IResult<int>
    {        
		public virtual int ID{get{return IdCargo;}}
		 public int IdCargo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 public string Codigo{get;set;}
		 
		 				
		public virtual Cargo ToEntity()
		{
		   Cargo _Cargo = new Cargo();
		_Cargo.IdCargo = this.IdCargo;
		 _Cargo.Nombre = this.Nombre;
		 _Cargo.Activo = this.Activo;
		 _Cargo.Codigo = this.Codigo;
		 
		  return _Cargo;
		}		
		public virtual void Set(Cargo entity)
		{		   
		 this.IdCargo= entity.IdCargo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		  this.Codigo= entity.Codigo ;
		 		  
		}		
		public virtual bool Equals(Cargo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdCargo.Equals(this.IdCargo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Cargo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Codigo","Codigo")
			}));
		}
	}
}
		