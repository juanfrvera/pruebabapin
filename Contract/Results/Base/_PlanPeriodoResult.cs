using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PlanPeriodoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPlanPeriodo;}}
		 public int IdPlanPeriodo{get;set;}
		 public int IdPlanTipo{get;set;}
		 public string Nombre{get;set;}
		 public string Sigla{get;set;}
		 public int AnioInicial{get;set;}
		 public int AnioFinal{get;set;}
		 public bool Activo{get;set;}
		 
		 public string PlanTipo_Sigla{get;set;}	
	public string PlanTipo_Nombre{get;set;}	
	public int PlanTipo_Orden{get;set;}	
	public bool PlanTipo_Activo{get;set;}	
					
		public virtual PlanPeriodo ToEntity()
		{
		   PlanPeriodo _PlanPeriodo = new PlanPeriodo();
		_PlanPeriodo.IdPlanPeriodo = this.IdPlanPeriodo;
		 _PlanPeriodo.IdPlanTipo = this.IdPlanTipo;
		 _PlanPeriodo.Nombre = this.Nombre;
		 _PlanPeriodo.Sigla = this.Sigla;
		 _PlanPeriodo.AnioInicial = this.AnioInicial;
		 _PlanPeriodo.AnioFinal = this.AnioFinal;
		 _PlanPeriodo.Activo = this.Activo;
		 
		  return _PlanPeriodo;
		}		
		public virtual void Set(PlanPeriodo entity)
		{		   
		 this.IdPlanPeriodo= entity.IdPlanPeriodo ;
		  this.IdPlanTipo= entity.IdPlanTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Sigla= entity.Sigla ;
		  this.AnioInicial= entity.AnioInicial ;
		  this.AnioFinal= entity.AnioFinal ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(PlanPeriodo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPlanPeriodo.Equals(this.IdPlanPeriodo))return false;
		  if(!entity.IdPlanTipo.Equals(this.IdPlanTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Sigla.Equals(this.Sigla))return false;
		  if(!entity.AnioInicial.Equals(this.AnioInicial))return false;
		  if(!entity.AnioFinal.Equals(this.AnioFinal))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PlanPeriodo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PlanTipo","PlanTipo_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("AnioInicial","AnioInicial")
			,new DataColumnMapping("AnioFinal","AnioFinal")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		