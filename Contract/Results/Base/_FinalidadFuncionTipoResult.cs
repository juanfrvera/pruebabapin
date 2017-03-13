using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _FinalidadFuncionTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdFinalidadFuncionTipo;}}
		 public int IdFinalidadFuncionTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Nivel{get;set;}
		 
		 				
		public virtual FinalidadFuncionTipo ToEntity()
		{
		   FinalidadFuncionTipo _FinalidadFuncionTipo = new FinalidadFuncionTipo();
		_FinalidadFuncionTipo.IdFinalidadFuncionTipo = this.IdFinalidadFuncionTipo;
		 _FinalidadFuncionTipo.Nombre = this.Nombre;
		 _FinalidadFuncionTipo.Nivel = this.Nivel;
		 
		  return _FinalidadFuncionTipo;
		}		
		public virtual void Set(FinalidadFuncionTipo entity)
		{		   
		 this.IdFinalidadFuncionTipo= entity.IdFinalidadFuncionTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Nivel= entity.Nivel ;
		 		  
		}		
		public virtual bool Equals(FinalidadFuncionTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdFinalidadFuncionTipo.Equals(this.IdFinalidadFuncionTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Nivel.Equals(this.Nivel))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("FinalidadFuncionTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel","Nivel")
			}));
		}
	}
}
		