using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorDetalleData : _IndicadorDetalleData 
    { 
	   #region Singleton
	   private static volatile IndicadorDetalleData current;
	   private static object syncRoot = new Object();

	   //private IndicadorDetalleData() {}
	   public static IndicadorDetalleData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorDetalleData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
