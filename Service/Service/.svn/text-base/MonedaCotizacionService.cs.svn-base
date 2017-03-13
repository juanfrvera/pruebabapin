using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MonedaCotizacionService : _MonedaCotizacionService 
    {	  
	   #region Singleton
	   private static volatile MonedaCotizacionService current;
	   private static object syncRoot = new Object();

	   //private MonedaCotizacionService() {}
	   public static MonedaCotizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MonedaCotizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
