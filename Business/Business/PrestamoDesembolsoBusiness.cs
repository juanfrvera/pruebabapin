using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoDesembolsoBusiness : _PrestamoDesembolsoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoDesembolsoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoDesembolsoBusiness() {}
	   public static PrestamoDesembolsoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDesembolsoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
