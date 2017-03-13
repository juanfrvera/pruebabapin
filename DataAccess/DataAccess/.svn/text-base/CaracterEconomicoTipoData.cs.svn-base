using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class CaracterEconomicoTipoData : _CaracterEconomicoTipoData
    {
	   #region Singleton
	   private static volatile CaracterEconomicoTipoData current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoTipoData() {}
	   public static CaracterEconomicoTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdCaracterEconomicoTipo"; } } 
    }
}
