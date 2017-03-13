using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoCalidadLocalizacionService : _ProyectoCalidadLocalizacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoCalidadLocalizacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoCalidadLocalizacionService() {}
	   public static ProyectoCalidadLocalizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoCalidadLocalizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
