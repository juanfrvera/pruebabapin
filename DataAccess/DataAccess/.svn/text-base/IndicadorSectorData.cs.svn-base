using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorSectorData : _IndicadorSectorData 
    { 
	   #region Singleton
	   private static volatile IndicadorSectorData current;
	   private static object syncRoot = new Object();

	   //private IndicadorSectorData() {}
	   public static IndicadorSectorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorSectorData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
