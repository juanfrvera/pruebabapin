using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorSectorService : _IndicadorSectorService 
    {	  
	   #region Singleton
	   private static volatile IndicadorSectorService current;
	   private static object syncRoot = new Object();

	   //private IndicadorSectorService() {}
	   public static IndicadorSectorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorSectorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
