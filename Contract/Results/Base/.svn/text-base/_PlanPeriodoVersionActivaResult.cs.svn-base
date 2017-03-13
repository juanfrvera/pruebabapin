using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PlanPeriodoVersionActivaResult : IResult<int>
    {        
		public virtual int ID{get{return IdPlanPeriodoVersionActiva;}}
		 public int IdPlanPeriodoVersionActiva{get;set;}
		 public int IdPlanPeriodo{get;set;}
		 public int IdPlanVersion{get;set;}
		 
		 public int PlanPeriodo_IdPlanTipo{get;set;}	
	public string PlanPeriodo_Nombre{get;set;}	
	public string PlanPeriodo_Sigla{get;set;}	
	public int PlanPeriodo_AnioInicial{get;set;}	
	public int PlanPeriodo_AnioFinal{get;set;}	
	public bool PlanPeriodo_Activo{get;set;}	
	public int PlanVersion_IdPlanTipo{get;set;}	
	public string PlanVersion_Nombre{get;set;}	
	public int PlanVersion_Orden{get;set;}	
	public bool PlanVersion_Activo{get;set;}	
					
		public virtual PlanPeriodoVersionActiva ToEntity()
		{
		   PlanPeriodoVersionActiva _PlanPeriodoVersionActiva = new PlanPeriodoVersionActiva();
		_PlanPeriodoVersionActiva.IdPlanPeriodoVersionActiva = this.IdPlanPeriodoVersionActiva;
		 _PlanPeriodoVersionActiva.IdPlanPeriodo = this.IdPlanPeriodo;
		 _PlanPeriodoVersionActiva.IdPlanVersion = this.IdPlanVersion;
		 
		  return _PlanPeriodoVersionActiva;
		}		
		public virtual void Set(PlanPeriodoVersionActiva entity)
		{		   
		 this.IdPlanPeriodoVersionActiva= entity.IdPlanPeriodoVersionActiva ;
		  this.IdPlanPeriodo= entity.IdPlanPeriodo ;
		  this.IdPlanVersion= entity.IdPlanVersion ;
		 		  
		}		
		public virtual bool Equals(PlanPeriodoVersionActiva entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPlanPeriodoVersionActiva.Equals(this.IdPlanPeriodoVersionActiva))return false;
		  if(!entity.IdPlanPeriodo.Equals(this.IdPlanPeriodo))return false;
		  if(!entity.IdPlanVersion.Equals(this.IdPlanVersion))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PlanPeriodoVersionActiva", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PlanPeriodo","PlanPeriodo_Nombre")
			,new DataColumnMapping("PlanVersion","PlanVersion_Nombre")
			}));
		}
	}
}
		