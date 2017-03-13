using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoSubComponenteService : _PrestamoSubComponenteService 
    {	  
	   #region Singleton
	   private static volatile PrestamoSubComponenteService current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubComponenteService() {}
	   public static PrestamoSubComponenteService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubComponenteService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
