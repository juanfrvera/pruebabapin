using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class DictamenBusiness : _DictamenBusiness 
    {   
	   #region Singleton
	   private static volatile DictamenBusiness current;
	   private static object syncRoot = new Object();

	   //private DictamenBusiness() {}
	   public static DictamenBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
