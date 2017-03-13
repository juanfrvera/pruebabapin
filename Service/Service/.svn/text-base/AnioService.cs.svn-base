using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class AnioService : _AnioService 
    {	  
	   #region Singleton
	   private static volatile AnioService current;
	   private static object syncRoot = new Object();

	   //private AnioService() {}
	   public static AnioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AnioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
