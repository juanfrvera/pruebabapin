using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorRubroResult : IResult<int>
    {        
		public virtual int ID{get{return IdIndicadorRubro;}}
		 public int IdIndicadorRubro{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual IndicadorRubro ToEntity()
		{
		   IndicadorRubro _IndicadorRubro = new IndicadorRubro();
		_IndicadorRubro.IdIndicadorRubro = this.IdIndicadorRubro;
		 _IndicadorRubro.Nombre = this.Nombre;
		 _IndicadorRubro.Activo = this.Activo;
		 
		  return _IndicadorRubro;
		}		
		public virtual void Set(IndicadorRubro entity)
		{		   
		 this.IdIndicadorRubro= entity.IdIndicadorRubro ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(IndicadorRubro entity)
        {
		   if(entity == null)return false;
         if(!entity.IdIndicadorRubro.Equals(this.IdIndicadorRubro))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("IndicadorRubro", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		