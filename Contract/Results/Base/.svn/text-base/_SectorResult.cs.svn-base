using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SectorResult : IResult<int>
    {        
		public virtual int ID{get{return IdSector;}}
		 public int IdSector{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual Sector ToEntity()
		{
		   Sector _Sector = new Sector();
		_Sector.IdSector = this.IdSector;
		 _Sector.Codigo = this.Codigo;
		 _Sector.Nombre = this.Nombre;
		 _Sector.Activo = this.Activo;
		 
		  return _Sector;
		}		
		public virtual void Set(Sector entity)
		{		   
		 this.IdSector= entity.IdSector ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Sector entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSector.Equals(this.IdSector))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Sector", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		