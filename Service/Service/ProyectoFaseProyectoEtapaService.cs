using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoFaseProyectoEtapaService : _ProyectoFaseProyectoEtapaService 
    {	  
	   #region Singleton
	   private static volatile ProyectoFaseProyectoEtapaService current;
	   private static object syncRoot = new Object();

	   //private ProyectoFaseProyectoEtapaService() {}
	   public static ProyectoFaseProyectoEtapaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoFaseProyectoEtapaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
