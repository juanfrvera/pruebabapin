using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class IndicadorObjetivoBusiness : _IndicadorObjetivoBusiness 
    {   
	   #region Singleton
	   private static volatile IndicadorObjetivoBusiness current;
	   private static object syncRoot = new Object();

	   //private IndicadorObjetivoBusiness() {}
	   public static IndicadorObjetivoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorObjetivoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
