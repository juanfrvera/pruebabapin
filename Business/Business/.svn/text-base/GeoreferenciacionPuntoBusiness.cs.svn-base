using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class GeoreferenciacionPuntoBusiness : _GeoreferenciacionPuntoBusiness 
    {   
	   #region Singleton
	   private static volatile GeoreferenciacionPuntoBusiness current;
	   private static object syncRoot = new Object();

	   //private GeoreferenciacionPuntoBusiness() {}
	   public static GeoreferenciacionPuntoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new GeoreferenciacionPuntoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(GeoreferenciacionPunto entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion

    }
}
