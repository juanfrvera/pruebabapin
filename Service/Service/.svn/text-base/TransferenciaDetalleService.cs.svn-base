using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class TransferenciaDetalleService : _TransferenciaDetalleService 
    {	  
	   #region Singleton
	   private static volatile TransferenciaDetalleService current;
	   private static object syncRoot = new Object();

	   //private TransferenciaDetalleService() {}
	   public static TransferenciaDetalleService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaDetalleService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
