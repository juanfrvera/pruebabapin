using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoCalificacionService : _PrestamoCalificacionService 
    {	  
	   #region Singleton
	   private static volatile PrestamoCalificacionService current;
	   private static object syncRoot = new Object();

	   //private PrestamoCalificacionService() {}
	   public static PrestamoCalificacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoCalificacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
