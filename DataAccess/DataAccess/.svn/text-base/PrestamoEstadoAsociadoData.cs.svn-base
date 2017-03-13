using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoEstadoAsociadoData : _PrestamoEstadoAsociadoData 
    { 
	   #region Singleton
	   private static volatile PrestamoEstadoAsociadoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoEstadoAsociadoData() {}
	   public static PrestamoEstadoAsociadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoEstadoAsociadoData();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
