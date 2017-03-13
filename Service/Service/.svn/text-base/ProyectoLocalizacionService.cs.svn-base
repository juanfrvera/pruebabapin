using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoLocalizacionService : _ProyectoLocalizacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoLocalizacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoLocalizacionService() {}
	   public static ProyectoLocalizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoLocalizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
