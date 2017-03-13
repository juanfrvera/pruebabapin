using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoIndicadorEconomicoService : _ProyectoIndicadorEconomicoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoIndicadorEconomicoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoIndicadorEconomicoService() {}
	   public static ProyectoIndicadorEconomicoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoIndicadorEconomicoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
