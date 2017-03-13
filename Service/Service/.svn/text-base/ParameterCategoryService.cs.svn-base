using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ParameterCategoryService : _ParameterCategoryService 
    {	  
	   #region Singleton
	   private static volatile ParameterCategoryService current;
	   private static object syncRoot = new Object();

	   //private ParameterCategoryService() {}
	   public static ParameterCategoryService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ParameterCategoryService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
