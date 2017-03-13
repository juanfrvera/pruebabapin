using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PlanTipoService : _PlanTipoService 
    {	  
	   #region Singleton
	   private static volatile PlanTipoService current;
	   private static object syncRoot = new Object();

	   //private PlanTipoService() {}
	   public static PlanTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       //Matias 20170210 - Ticket #REQ653581
       public ListPaged<PlanTipo> GetPlanTipoPlanesActivosResult(PlanTipoFilter filter)
       {
           return PlanTipoBusiness.Current.GetPlanTipoPlanesActivosResult(filter);
       }
       //FinMatias 20170210 - Ticket #REQ653581
    }
}
