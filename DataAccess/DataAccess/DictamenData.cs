using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class DictamenData : _DictamenData 
    { 
	   #region Singleton
	   private static volatile DictamenData current;
	   private static object syncRoot = new Object();

	   //private DictamenData() {}
	   public static DictamenData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
