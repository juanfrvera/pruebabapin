using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoSubConvenioService : _PrestamoSubConvenioService 
    {	  
	   #region Singleton
	   private static volatile PrestamoSubConvenioService current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubConvenioService() {}
	   public static PrestamoSubConvenioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubConvenioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
