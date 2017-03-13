using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MonedaResult : IResult<int>
    {        
		public virtual int ID{get{return IdMoneda;}}
		 public int IdMoneda{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 public bool Base{get;set;}
		 
		 				
		public virtual Moneda ToEntity()
		{
		   Moneda _Moneda = new Moneda();
		_Moneda.IdMoneda = this.IdMoneda;
		 _Moneda.Sigla = this.Sigla;
		 _Moneda.Nombre = this.Nombre;
		 _Moneda.Activo = this.Activo;
		 _Moneda.Base = this.Base;
		 
		  return _Moneda;
		}		
		public virtual void Set(Moneda entity)
		{		   
		 this.IdMoneda= entity.IdMoneda ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		  this.Base= entity.Base ;
		 		  
		}		
		public virtual bool Equals(Moneda entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMoneda.Equals(this.IdMoneda))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.Base.Equals(this.Base))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Moneda", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("Base","Base")
			}));
		}
	}
}
		