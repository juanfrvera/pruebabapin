using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoObjetivoEspecificoService : _PrestamoObjetivoEspecificoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoObjetivoEspecificoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoEspecificoService() {}
	   public static PrestamoObjetivoEspecificoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoEspecificoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
