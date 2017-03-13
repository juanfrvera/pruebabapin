using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorSectorBusiness : _IndicadorSectorBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorSectorBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorSectorBusiness() {}
	   public static IndicadorSectorBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorSectorBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
