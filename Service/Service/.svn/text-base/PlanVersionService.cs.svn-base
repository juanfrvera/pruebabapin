using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PlanVersionService : _PlanVersionService 
    {	  
	   #region Singleton
	   private static volatile PlanVersionService current;
	   private static object syncRoot = new Object();

	   //private PlanVersionService() {}
	   public static PlanVersionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PlanVersionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
