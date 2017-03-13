using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionGeograficaTipoService : _ClasificacionGeograficaTipoService 
    {	  
	   #region Singleton
	   private static volatile ClasificacionGeograficaTipoService current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGeograficaTipoService() {}
	   public static ClasificacionGeograficaTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGeograficaTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
