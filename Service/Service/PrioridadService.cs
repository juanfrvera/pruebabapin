using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrioridadService : _PrioridadService 
    {	  
	   #region Singleton
	   private static volatile PrioridadService current;
	   private static object syncRoot = new Object();

	   //private PrioridadService() {}
	   public static PrioridadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrioridadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
