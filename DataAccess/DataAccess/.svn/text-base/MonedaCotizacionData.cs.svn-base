using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MonedaCotizacionData : _MonedaCotizacionData 
    {  
	   #region Singleton
	   private static volatile MonedaCotizacionData current;
	   private static object syncRoot = new Object();

	   //private MonedaCotizacionData() {}
	   public static MonedaCotizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MonedaCotizacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMonedaCotizacion"; } }   
    }
}
