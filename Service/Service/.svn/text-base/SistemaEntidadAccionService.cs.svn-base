using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaEntidadAccionService : _SistemaEntidadAccionService 
    {	  
	   #region Singleton
	   private static volatile SistemaEntidadAccionService current;
	   private static object syncRoot = new Object();

	   //private SistemaEntidadAccionService() {}
	   public static SistemaEntidadAccionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaEntidadAccionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
