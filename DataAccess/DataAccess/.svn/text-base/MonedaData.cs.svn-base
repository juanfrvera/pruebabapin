using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MonedaData : _MonedaData 
    {
	   #region Singleton
	   private static volatile MonedaData current;
	   private static object syncRoot = new Object();

	   //private MonedaData() {}
	   public static MonedaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MonedaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMoneda"; } }    
    }
}
