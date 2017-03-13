using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ConfigurationCategoryService : _ConfigurationCategoryService 
    {	  
	   #region Singleton
	   private static volatile ConfigurationCategoryService current;
	   private static object syncRoot = new Object();

	   //private ConfigurationCategoryService() {}
	   public static ConfigurationCategoryService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ConfigurationCategoryService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
