using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorPriorizacionData : _IndicadorPriorizacionData 
    { 
	   #region Singleton
	   private static volatile IndicadorPriorizacionData current;
	   private static object syncRoot = new Object();

	   //private IndicadorPriorizacionData() {}
	   public static IndicadorPriorizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorPriorizacionData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
