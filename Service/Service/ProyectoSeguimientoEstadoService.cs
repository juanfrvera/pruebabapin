using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoSeguimientoEstadoService : _ProyectoSeguimientoEstadoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoSeguimientoEstadoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoEstadoService() {}
	   public static ProyectoSeguimientoEstadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoEstadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
