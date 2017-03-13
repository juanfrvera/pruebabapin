using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PlanPeriodoBusiness : _PlanPeriodoBusiness 
    {   
	   #region Singleton
	   private static volatile PlanPeriodoBusiness current;
	   private static object syncRoot = new Object();

	   //private PlanPeriodoBusiness() {}
	   public static PlanPeriodoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanPeriodoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public override PlanPeriodo GetNew()
       {
           PlanPeriodo entity = base.GetNew();
           entity.Activo = true;
           return entity;
       }

       //Matias 20170210 - Ticket #REQ653581
       public ListPaged<PlanPeriodo> GetPlanPeriodoPlanesActivosResult(PlanPeriodoFilter filter)
       {
           ListPaged<PlanPeriodo> result = new ListPaged<PlanPeriodo>(PlanPeriodoData.Current.QueryResultPlanesActivos(filter));
           return result;
       }
       //FinMatias 20170210 - Ticket #REQ653581

       #region Actions

       public override void Update(PlanPeriodo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
