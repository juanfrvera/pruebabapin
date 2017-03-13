using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoSeguimientoLocalizacionService : _ProyectoSeguimientoLocalizacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoSeguimientoLocalizacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoLocalizacionService() {}
	   public static ProyectoSeguimientoLocalizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoLocalizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
