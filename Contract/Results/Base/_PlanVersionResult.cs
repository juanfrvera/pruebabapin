using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PlanVersionResult : IResult<int>
    {        
		public virtual int ID{get{return IdPlanVersion;}}
		 public int IdPlanVersion{get;set;}
		 public int IdPlanTipo{get;set;}
		 public string Nombre{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 
		 public string PlanTipo_Sigla{get;set;}	
	public string PlanTipo_Nombre{get;set;}	
	public int PlanTipo_Orden{get;set;}	
	public bool PlanTipo_Activo{get;set;}	
					
		public virtual PlanVersion ToEntity()
		{
		   PlanVersion _PlanVersion = new PlanVersion();
		_PlanVersion.IdPlanVersion = this.IdPlanVersion;
		 _PlanVersion.IdPlanTipo = this.IdPlanTipo;
		 _PlanVersion.Nombre = this.Nombre;
		 _PlanVersion.Orden = this.Orden;
		 _PlanVersion.Activo = this.Activo;
		 
		  return _PlanVersion;
		}		
		public virtual void Set(PlanVersion entity)
		{		   
		 this.IdPlanVersion= entity.IdPlanVersion ;
		  this.IdPlanTipo= entity.IdPlanTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(PlanVersion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPlanVersion.Equals(this.IdPlanVersion))return false;
		  if(!entity.IdPlanTipo.Equals(this.IdPlanTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PlanVersion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PlanTipo","PlanTipo_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Orden","Orden")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		