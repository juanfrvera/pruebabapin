using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class GeoreferenciacionService : _GeoreferenciacionService 
    {	  
	   #region Singleton
	   private static volatile GeoreferenciacionService current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionService() {}
	   public static GeoreferenciacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
