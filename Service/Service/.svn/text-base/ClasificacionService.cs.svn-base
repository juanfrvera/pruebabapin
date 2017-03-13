using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionService : _ClasificacionService 
    {	  
	   #region Singleton
	   private static volatile ClasificacionService current;
	   private static object syncRoot = new Object();

	   //private ClasificacionService() {}
	   public static ClasificacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
