using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoObjetivoData : _PrestamoObjetivoData 
    { 
	   #region Singleton
	   private static volatile PrestamoObjetivoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoData() {}
	   public static PrestamoObjetivoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoObjetivo"; } } 
    }
}
