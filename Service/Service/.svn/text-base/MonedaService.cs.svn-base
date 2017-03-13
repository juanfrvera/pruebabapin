using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MonedaService : _MonedaService 
    {	  
	   #region Singleton
	   private static volatile MonedaService current;
	   private static object syncRoot = new Object();

	   //private MonedaService() {}
	   public static MonedaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MonedaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
