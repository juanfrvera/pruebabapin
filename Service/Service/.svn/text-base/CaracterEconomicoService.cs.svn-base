using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class CaracterEconomicoService : _CaracterEconomicoService 
    {	  
	   #region Singleton
	   private static volatile CaracterEconomicoService current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoService() {}
	   public static CaracterEconomicoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public ListPaged<NodeResult> GetNodesResult(CaracterEconomicoFilter filter)
       {
           return Business.GetNodesResult(filter);
       }
    }
}
