using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoObjetivoService : _PrestamoObjetivoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoObjetivoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoService() {}
	   public static PrestamoObjetivoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
