using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaRealizadoPeriodoService : _ProyectoEtapaRealizadoPeriodoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaRealizadoPeriodoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaRealizadoPeriodoService() {}
	   public static ProyectoEtapaRealizadoPeriodoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaRealizadoPeriodoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
