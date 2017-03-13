using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorObjetivoData : _IndicadorObjetivoData 
    { 
	   #region Singleton
	   private static volatile IndicadorObjetivoData current;
	   private static object syncRoot = new Object();

	   //private IndicadorObjetivoData() {}
	   public static IndicadorObjetivoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorObjetivoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
