using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoSubConvenioBusiness : _PrestamoSubConvenioBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoSubConvenioBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubConvenioBusiness() {}
	   public static PrestamoSubConvenioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubConvenioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoSubConvenio entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
