using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaEstimadoPeriodoService : _ProyectoEtapaEstimadoPeriodoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaEstimadoPeriodoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaEstimadoPeriodoService() {}
	   public static ProyectoEtapaEstimadoPeriodoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaEstimadoPeriodoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
