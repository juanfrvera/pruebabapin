using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class TransferenciaService : _TransferenciaService 
    {	  
	   #region Singleton
	   private static volatile TransferenciaService current;
	   private static object syncRoot = new Object();

	   //private TransferenciaService() {}
	   public static TransferenciaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
