using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoEstadoAsociadoBusiness : _PrestamoEstadoAsociadoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoEstadoAsociadoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoEstadoAsociadoBusiness() {}
	   public static PrestamoEstadoAsociadoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoEstadoAsociadoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
