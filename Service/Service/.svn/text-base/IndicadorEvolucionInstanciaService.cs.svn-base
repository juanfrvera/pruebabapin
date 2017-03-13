using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorEvolucionInstanciaService : _IndicadorEvolucionInstanciaService 
    {	  
	   #region Singleton
	   private static volatile IndicadorEvolucionInstanciaService current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionInstanciaService() {}
	   public static IndicadorEvolucionInstanciaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionInstanciaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
