using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PlanTipoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPlanTipo;}}
		 public int IdPlanTipo{get;set;}
		 public string Sigla{get;set;}
		 public string Nombre{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 
		 				
		public virtual PlanTipo ToEntity()
		{
		   PlanTipo _PlanTipo = new PlanTipo();
		_PlanTipo.IdPlanTipo = this.IdPlanTipo;
		 _PlanTipo.Sigla = this.Sigla;
		 _PlanTipo.Nombre = this.Nombre;
		 _PlanTipo.Orden = this.Orden;
		 _PlanTipo.Activo = this.Activo;
		 
		  return _PlanTipo;
		}		
		public virtual void Set(PlanTipo entity)
		{		   
		 this.IdPlanTipo= entity.IdPlanTipo ;
		  this.Sigla= entity.Sigla ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(PlanTipo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPlanTipo.Equals(this.IdPlanTipo))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PlanTipo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		