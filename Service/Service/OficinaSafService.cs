using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OficinaSafService : _OficinaSafService 
    {	  
	   #region Singleton
	   private static volatile OficinaSafService current;
	   private static object syncRoot = new Object();

	   //private OficinaSafService() {}
	   public static OficinaSafService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaSafService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
