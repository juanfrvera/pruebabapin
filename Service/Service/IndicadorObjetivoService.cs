using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorObjetivoService : _IndicadorObjetivoService 
    {	  
	   #region Singleton
	   private static volatile IndicadorObjetivoService current;
	   private static object syncRoot = new Object();

	   //private IndicadorObjetivoService() {}
	   public static IndicadorObjetivoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorObjetivoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
