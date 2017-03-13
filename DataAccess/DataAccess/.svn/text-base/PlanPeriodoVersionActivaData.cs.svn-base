using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PlanPeriodoVersionActivaData : _PlanPeriodoVersionActivaData 
    { 
	   #region Singleton
	   private static volatile PlanPeriodoVersionActivaData current;
	   private static object syncRoot = new Object();

	   //private PlanPeriodoVersionActivaData() {}
	   public static PlanPeriodoVersionActivaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanPeriodoVersionActivaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPlanPeriodoVersionActiva"; } }
       protected override IQueryable<PlanPeriodoVersionActiva> Query(PlanPeriodoVersionActivaFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdPlanPeriodoVersionActiva == null || o.IdPlanPeriodoVersionActiva >= filter.IdPlanPeriodoVersionActiva) && (filter.IdPlanPeriodoVersionActiva_To == null || o.IdPlanPeriodoVersionActiva <= filter.IdPlanPeriodoVersionActiva_To)
                   && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo == filter.IdPlanPeriodo)
                   && (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || o.IdPlanVersion == filter.IdPlanVersion)
                   && (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || o.PlanPeriodo.IdPlanTipo == filter.IdPlanTipo || o.PlanVersion.IdPlanTipo == filter.IdPlanTipo)
                   select o
                   ).AsQueryable();
       }
        protected override IQueryable<PlanPeriodoVersionActivaResult> QueryResult(PlanPeriodoVersionActivaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PlanPeriodos on o.IdPlanPeriodo equals t1.IdPlanPeriodo   
				    join t2  in this.Context.PlanVersions on o.IdPlanVersion equals t2.IdPlanVersion   
                    join t3 in this.Context.PlanTipos on t1.IdPlanTipo equals t3.IdPlanTipo
				   select new PlanPeriodoVersionActivaResult(){
					 IdPlanPeriodoVersionActiva=o.IdPlanPeriodoVersionActiva
					 ,IdPlanPeriodo=o.IdPlanPeriodo
					 ,IdPlanVersion=o.IdPlanVersion
					,PlanPeriodo_IdPlanTipo= t1.IdPlanTipo	
						,PlanPeriodo_Nombre= t1.Nombre	
						,PlanPeriodo_Sigla= t1.Sigla	
						,PlanPeriodo_AnioInicial= t1.AnioInicial	
						,PlanPeriodo_AnioFinal= t1.AnioFinal	
						,PlanPeriodo_Activo= t1.Activo	
						,PlanVersion_IdPlanTipo= t2.IdPlanTipo	
						,PlanVersion_Nombre= t2.Nombre	
						,PlanVersion_Orden= t2.Orden	
						,PlanVersion_Activo= t2.Activo	
                        ,PlanTipo_Nombre=t3.Nombre
                        ,PlanTipo_Orden= t3.Orden
						}
                    ).AsQueryable();
        }
    }
}
