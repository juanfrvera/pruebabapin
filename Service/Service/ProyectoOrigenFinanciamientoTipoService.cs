using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoOrigenFinanciamientoTipoService : _ProyectoOrigenFinanciamientoTipoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoOrigenFinanciamientoTipoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoOrigenFinanciamientoTipoService() {}
	   public static ProyectoOrigenFinanciamientoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoOrigenFinanciamientoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
