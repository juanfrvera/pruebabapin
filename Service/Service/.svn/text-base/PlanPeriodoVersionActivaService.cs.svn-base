using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PlanPeriodoVersionActivaService : _PlanPeriodoVersionActivaService 
    {	  
	   #region Singleton
	   private static volatile PlanPeriodoVersionActivaService current;
	   private static object syncRoot = new Object();

	   //private PlanPeriodoVersionActivaService() {}
	   public static PlanPeriodoVersionActivaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanPeriodoVersionActivaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
