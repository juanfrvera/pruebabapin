using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SubProcesoService : _SubProcesoService 
    {	  
	   #region Singleton
	   private static volatile SubProcesoService current;
	   private static object syncRoot = new Object();

	   //private SubProcesoService() {}
	   public static SubProcesoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProcesoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
