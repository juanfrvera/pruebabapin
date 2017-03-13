using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoEstadoService : _PrestamoEstadoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoEstadoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoEstadoService() {}
	   public static PrestamoEstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoEstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
