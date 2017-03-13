using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorTipo;}}
		 public int IdIndicadorTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool SectorRequerido{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual IndicadorTipo ToEntity()
		{
		   IndicadorTipo _IndicadorTipo = new IndicadorTipo();
		_IndicadorTipo.IdIndicadorTipo = this.IdIndicadorTipo;
		 _IndicadorTipo.Nombre = this.Nombre;
		 _IndicadorTipo.SectorRequerido = this.SectorRequerido;
		 _IndicadorTipo.Activo = this.Activo;
		 
		  return _IndicadorTipo;
		}		
		public virtual void Set(IndicadorTipo entity)
		{		   
		 this.IdIndicadorTipo= entity.IdIndicadorTipo ;
		  this.Nombre= entity.Nombre ;
		  this.SectorRequerido= entity.SectorRequerido ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorTipo.Equals(this.IdIndicadorTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.SectorRequerido.Equals(this.SectorRequerido))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("SectorRequerido","SectorRequerido")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		