using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorMedioVerificacionService : _IndicadorMedioVerificacionService 
    {	  
	   #region Singleton
	   private static volatile IndicadorMedioVerificacionService current;
	   private static object syncRoot = new Object();

	   //private IndicadorMedioVerificacionService() {}
	   public static IndicadorMedioVerificacionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorMedioVerificacionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
