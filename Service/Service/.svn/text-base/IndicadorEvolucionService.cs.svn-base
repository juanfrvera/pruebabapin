using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorEvolucionService : _IndicadorEvolucionService 
    {	  
	   #region Singleton
	   private static volatile IndicadorEvolucionService current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionService() {}
	   public static IndicadorEvolucionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
