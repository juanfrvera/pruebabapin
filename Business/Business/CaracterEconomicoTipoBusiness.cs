using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class CaracterEconomicoTipoBusiness : _CaracterEconomicoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile CaracterEconomicoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private CaracterEconomicoTipoBusiness() {}
	   public static CaracterEconomicoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new CaracterEconomicoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(CaracterEconomicoTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
