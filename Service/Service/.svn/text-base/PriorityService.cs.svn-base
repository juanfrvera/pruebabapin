using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PriorityService : _PriorityService 
    {	  
	   #region Singleton
	   private static volatile PriorityService current;
	   private static object syncRoot = new Object();

	   //private PriorityService() {}
	   public static PriorityService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PriorityService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
