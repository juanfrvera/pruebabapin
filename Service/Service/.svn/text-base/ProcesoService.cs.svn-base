using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProcesoService : _ProcesoService 
    {	  
	   #region Singleton
	   private static volatile ProcesoService current;
	   private static object syncRoot = new Object();

	   //private ProcesoService() {}
	   public static ProcesoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProcesoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
