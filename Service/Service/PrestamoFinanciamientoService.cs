using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoFinanciamientoService : _PrestamoFinanciamientoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoFinanciamientoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoFinanciamientoService() {}
	   public static PrestamoFinanciamientoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFinanciamientoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
