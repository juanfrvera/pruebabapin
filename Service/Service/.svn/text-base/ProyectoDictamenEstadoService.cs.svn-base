using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoDictamenEstadoService : _ProyectoDictamenEstadoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoDictamenEstadoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenEstadoService() {}
	   public static ProyectoDictamenEstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenEstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
