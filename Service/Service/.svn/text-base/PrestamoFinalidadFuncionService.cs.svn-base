using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoFinalidadFuncionService : _PrestamoFinalidadFuncionService 
    {	  
	   #region Singleton
	   private static volatile PrestamoFinalidadFuncionService current;
	   private static object syncRoot = new Object();

	   //private PrestamoFinalidadFuncionService() {}
	   public static PrestamoFinalidadFuncionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoFinalidadFuncionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
