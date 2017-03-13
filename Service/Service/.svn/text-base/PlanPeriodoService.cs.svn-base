using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PlanPeriodoService : _PlanPeriodoService 
    {	  
	   #region Singleton
	   private static volatile PlanPeriodoService current;
	   private static object syncRoot = new Object();

	   //private PlanPeriodoService() {}
	   public static PlanPeriodoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanPeriodoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       //Matias 20170210 - Ticket #REQ653581
       public ListPaged<PlanPeriodo> GetPlanPeriodoPlanesActivosResult(PlanPeriodoFilter filter)
       {
           return PlanPeriodoBusiness.Current.GetPlanPeriodoPlanesActivosResult(filter);
       }
       //FinMatias 20170210 - Ticket #REQ653581
    }
}
