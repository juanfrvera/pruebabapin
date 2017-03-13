using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SistemaCommandService : _SistemaCommandService 
    {	  
	   #region Singleton
	   private static volatile SistemaCommandService current;
	   private static object syncRoot = new Object();

	   //private SistemaCommandService() {}
	   public static SistemaCommandService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SistemaCommandService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
