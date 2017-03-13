using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class NumerationService : _NumerationService 
    {	  
	   #region Singleton
	   private static volatile NumerationService current;
	   private static object syncRoot = new Object();

	   //private NumerationService() {}
	   public static NumerationService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new NumerationService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
