using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class GeoreferenciacionPuntoService : _GeoreferenciacionPuntoService 
    {	  
	   #region Singleton
	   private static volatile GeoreferenciacionPuntoService current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionPuntoService() {}
	   public static GeoreferenciacionPuntoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionPuntoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
