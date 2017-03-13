using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoEstadoData : _PrestamoEstadoData 
    {
	   #region Singleton
	   private static volatile PrestamoEstadoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoEstadoData() {}
	   public static PrestamoEstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoEstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoEstado"; } } 
    }
}
