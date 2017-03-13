using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class DictamenService : _DictamenService 
    {	  
	   #region Singleton
	   private static volatile DictamenService current;
	   private static object syncRoot = new Object();

	   //private DictamenService() {}
	   public static DictamenService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
