using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class DictamenTipoService : _DictamenTipoService 
    {	  
	   #region Singleton
	   private static volatile DictamenTipoService current;
	   private static object syncRoot = new Object();

	   //private DictamenTipoService() {}
	   public static DictamenTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
