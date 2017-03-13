using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoAlcanceGeograficoData : _PrestamoAlcanceGeograficoData 
    { 
	   #region Singleton
	   private static volatile PrestamoAlcanceGeograficoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoAlcanceGeograficoData() {}
	   public static PrestamoAlcanceGeograficoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoAlcanceGeograficoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoAlcanceGeografico"; } }
    }
}
