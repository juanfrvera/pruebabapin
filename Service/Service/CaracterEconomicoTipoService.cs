using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class CaracterEconomicoTipoService : _CaracterEconomicoTipoService 
    {	  
	   #region Singleton
	   private static volatile CaracterEconomicoTipoService current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoTipoService() {}
	   public static CaracterEconomicoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
