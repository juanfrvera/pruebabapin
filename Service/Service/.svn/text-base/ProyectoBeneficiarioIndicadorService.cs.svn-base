using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoBeneficiarioIndicadorService : _ProyectoBeneficiarioIndicadorService 
    {	  
	   #region Singleton
	   private static volatile ProyectoBeneficiarioIndicadorService current;
	   private static object syncRoot = new Object();

	   //private ProyectoBeneficiarioIndicadorService() {}
	   public static ProyectoBeneficiarioIndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoBeneficiarioIndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
