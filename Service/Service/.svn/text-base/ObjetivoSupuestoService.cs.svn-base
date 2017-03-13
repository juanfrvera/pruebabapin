using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ObjetivoSupuestoService : _ObjetivoSupuestoService 
    {	  
	   #region Singleton
	   private static volatile ObjetivoSupuestoService current;
	   private static object syncRoot = new Object();

	   //private ObjetivoSupuestoService() {}
	   public static ObjetivoSupuestoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoSupuestoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
