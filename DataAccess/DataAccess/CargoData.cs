using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class CargoData : _CargoData 
    {
	   #region Singleton
	   private static volatile CargoData current;
	   private static object syncRoot = new Object();

	   //private CargoData() {}
	   public static CargoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CargoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdCargo"; } }  
    }
}
