using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoBeneficioIndicadorService : _ProyectoBeneficioIndicadorService 
    {	  
	   #region Singleton
	   private static volatile ProyectoBeneficioIndicadorService current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficioIndicadorService() {}
	   public static ProyectoBeneficioIndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficioIndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
