using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class CargoService : _CargoService 
    {	  
	   #region Singleton
	   private static volatile CargoService current;
	   private static object syncRoot = new Object();

	   //private CargoService() {}
	   public static CargoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CargoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
