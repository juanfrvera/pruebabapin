using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoEstadoAsociadoService : _PrestamoEstadoAsociadoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoEstadoAsociadoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoEstadoAsociadoService() {}
	   public static PrestamoEstadoAsociadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoEstadoAsociadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
