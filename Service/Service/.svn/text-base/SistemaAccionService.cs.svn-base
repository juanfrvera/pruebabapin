using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaAccionService : _SistemaAccionService 
    {	  
	   #region Singleton
	   private static volatile SistemaAccionService current;
	   private static object syncRoot = new Object();

	   //private SistemaAccionService() {}
	   public static SistemaAccionService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaAccionService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
