using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SafService : _SafService 
    {	  
	   #region Singleton
	   private static volatile SafService current;
	   private static object syncRoot = new Object();

	   //private SafService() {}
	   public static SafService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SafService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public virtual SafResult GetResultById(int id)
       {
           return Business.GetResultById(id);
       }
    }
}
