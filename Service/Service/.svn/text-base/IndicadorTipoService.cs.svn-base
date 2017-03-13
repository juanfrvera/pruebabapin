using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorTipoService : _IndicadorTipoService 
    {	  
	   #region Singleton
	   private static volatile IndicadorTipoService current;
	   private static object syncRoot = new Object();

	   //private IndicadorTipoService() {}
	   public static IndicadorTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
