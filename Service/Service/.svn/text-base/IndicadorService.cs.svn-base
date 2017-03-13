using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorService : _IndicadorService 
    {	  
	   #region Singleton
	   private static volatile IndicadorService current;
	   private static object syncRoot = new Object();

	   //private IndicadorService() {}
	   public static IndicadorService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
