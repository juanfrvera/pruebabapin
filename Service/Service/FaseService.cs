using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FaseService : _FaseService 
    {	  
	   #region Singleton
	   private static volatile FaseService current;
	   private static object syncRoot = new Object();

	   //private FaseService() {}
	   public static FaseService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FaseService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
