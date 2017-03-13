using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class DictamenTipoBusiness : _DictamenTipoBusiness 
    {   
	   #region Singleton
	   private static volatile DictamenTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private DictamenTipoBusiness() {}
	   public static DictamenTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
