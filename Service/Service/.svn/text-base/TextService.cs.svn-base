using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class TextService : _TextService 
    {	  
	   #region Singleton
	   private static volatile TextService current;
	   private static object syncRoot = new Object();

	   //private TextService() {}
	   public static TextService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
