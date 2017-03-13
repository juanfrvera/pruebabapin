using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class DictamenTipoData : _DictamenTipoData 
    { 
	   #region Singleton
	   private static volatile DictamenTipoData current;
	   private static object syncRoot = new Object();

	   //private DictamenTipoData() {}
	   public static DictamenTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new DictamenTipoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
