using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class PrestamoDesembolsoService : _PrestamoDesembolsoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoDesembolsoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoDesembolsoService() {}
	   public static PrestamoDesembolsoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDesembolsoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
