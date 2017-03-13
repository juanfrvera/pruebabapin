using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorDetalleBusiness : _IndicadorDetalleBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorDetalleBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorDetalleBusiness() {}
	   public static IndicadorDetalleBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorDetalleBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
