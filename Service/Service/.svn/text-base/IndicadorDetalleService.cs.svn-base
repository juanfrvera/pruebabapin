using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class IndicadorDetalleService : _IndicadorDetalleService 
    {	  
	   #region Singleton
	   private static volatile IndicadorDetalleService current;
	   private static object syncRoot = new Object();

	   //private IndicadorDetalleService() {}
	   public static IndicadorDetalleService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorDetalleService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
