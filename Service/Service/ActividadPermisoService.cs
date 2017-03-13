using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ActividadPermisoService : _ActividadPermisoService 
    {	  
	   #region Singleton
	   private static volatile ActividadPermisoService current;
	   private static object syncRoot = new Object();

	   //private ActividadPermisoService() {}
	   public static ActividadPermisoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadPermisoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
