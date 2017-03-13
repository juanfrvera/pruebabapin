using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FuenteFinanciamientoTipoService : _FuenteFinanciamientoTipoService 
    {	  
	   #region Singleton
	   private static volatile FuenteFinanciamientoTipoService current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoTipoService() {}
	   public static FuenteFinanciamientoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
