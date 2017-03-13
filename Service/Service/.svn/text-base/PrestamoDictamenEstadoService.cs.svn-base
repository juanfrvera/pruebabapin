using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoDictamenEstadoService : _PrestamoDictamenEstadoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoDictamenEstadoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenEstadoService() {}
	   public static PrestamoDictamenEstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenEstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
