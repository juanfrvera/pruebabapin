using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class TextCategoryService : _TextCategoryService 
    {	  
	   #region Singleton
	   private static volatile TextCategoryService current;
	   private static object syncRoot = new Object();

	   //private TextCategoryService() {}
	   public static TextCategoryService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextCategoryService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
