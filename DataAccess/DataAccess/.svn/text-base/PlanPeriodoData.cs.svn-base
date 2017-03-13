using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PlanPeriodoData : _PlanPeriodoData 
    { 
	   #region Singleton
	   private static volatile PlanPeriodoData current;
	   private static object syncRoot = new Object();

	   //private PlanPeriodoData() {}
	   public static PlanPeriodoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanPeriodoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPlanPeriodo"; } }

       protected override IQueryable<PlanPeriodo> Query(PlanPeriodoFilter filter)
       {
           return (from o in base.Query(filter)
            where
               (filter.EsPlanPeriodoVersionActivo == null || filter.EsPlanPeriodoVersionActivo == false ||
                   (from ppva in this.Context.PlanPeriodoVersionActivas
                    select ppva.IdPlanPeriodo).Contains(o.IdPlanPeriodo)
               )
            select o);  
       }

       //Matias 20170210 - Ticket #REQ653581
       public IQueryable<PlanPeriodo> QueryResultPlanesActivos(PlanPeriodoFilter filter)
       {
           IQueryable<PlanPeriodo> query = (from o in Query(filter)
                                         join t2 in this.Context.PlanPeriodoVersionActivas on o.IdPlanPeriodo equals t2.IdPlanPeriodo
                                         select o
                   ).AsQueryable();
           
           return query.Distinct();
       }
        //FinMatias 20170210 - Ticket #REQ653581
    }
}
