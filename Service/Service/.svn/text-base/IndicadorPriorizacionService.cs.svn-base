using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorPriorizacionService : _IndicadorPriorizacionService 
    {	  
	   #region Singleton
	   private static volatile IndicadorPriorizacionService current;
	   private static object syncRoot = new Object();

	   //private IndicadorPriorizacionService() {}
	   public static IndicadorPriorizacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorPriorizacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
