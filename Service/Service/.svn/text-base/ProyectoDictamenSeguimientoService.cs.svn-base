using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoDictamenSeguimientoService : _ProyectoDictamenSeguimientoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoDictamenSeguimientoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoDictamenSeguimientoService() {}
	   public static ProyectoDictamenSeguimientoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDictamenSeguimientoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
