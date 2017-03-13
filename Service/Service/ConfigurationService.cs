using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ConfigurationService : _ConfigurationService 
    {	  
	   #region Singleton
	   private static volatile ConfigurationService current;
	   private static object syncRoot = new Object();

	   //private ConfigurationService() {}
	   public static ConfigurationService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ConfigurationService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
