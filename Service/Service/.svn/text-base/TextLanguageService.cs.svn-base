using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class TextLanguageService : _TextLanguageService 
    {	  
	   #region Singleton
	   private static volatile TextLanguageService current;
	   private static object syncRoot = new Object();

	   //private TextLanguageService() {}
	   public static TextLanguageService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextLanguageService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
