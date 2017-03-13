using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoProductoService : _PrestamoProductoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoProductoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoProductoService() {}
	   public static PrestamoProductoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoProductoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
