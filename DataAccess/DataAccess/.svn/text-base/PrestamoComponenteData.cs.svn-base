using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoComponenteData : _PrestamoComponenteData 
    { 
	   #region Singleton
	   private static volatile PrestamoComponenteData current;
	   private static object syncRoot = new Object();

	   //private PrestamoComponenteData() {}
	   public static PrestamoComponenteData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoComponenteData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoComponente"; } }
    }
}
