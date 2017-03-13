using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SubProcesoData : _SubProcesoData 
    { 
	   #region Singleton
	   private static volatile SubProcesoData current;
	   private static object syncRoot = new Object();

	   //private SubProcesoData() {}
	   public static SubProcesoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProcesoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
