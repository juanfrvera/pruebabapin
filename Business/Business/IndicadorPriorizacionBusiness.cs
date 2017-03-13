using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorPriorizacionBusiness : _IndicadorPriorizacionBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorPriorizacionBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorPriorizacionBusiness() {}
	   public static IndicadorPriorizacionBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorPriorizacionBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
