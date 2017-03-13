using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoDesembolsoData : _PrestamoDesembolsoData 
    { 
	   #region Singleton
	   private static volatile PrestamoDesembolsoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoDesembolsoData() {}
	   public static PrestamoDesembolsoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDesembolsoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoDesembolso"; } }
    }
}
