using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoIndicadorPriorizacionService : _ProyectoIndicadorPriorizacionService 
    {	  
	   #region Singleton
	   private static volatile ProyectoIndicadorPriorizacionService current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorPriorizacionService() {}
	   public static ProyectoIndicadorPriorizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorPriorizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
