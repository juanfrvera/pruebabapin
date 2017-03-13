using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ClasificacionGastoTipoService : _ClasificacionGastoTipoService 
    {	  
	   #region Singleton
	   private static volatile ClasificacionGastoTipoService current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoTipoService() {}
	   public static ClasificacionGastoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
