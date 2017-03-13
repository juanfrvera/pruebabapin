using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class PrestamoObjetivoBusiness : _PrestamoObjetivoBusiness 
    {   
	   #region Singleton
	   private static volatile PrestamoObjetivoBusiness current;
	   private static object syncRoot = new Object();

	   //private PrestamoObjetivoBusiness() {}
	   public static PrestamoObjetivoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoObjetivoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion


       #region Actions

       public override void Update(PrestamoObjetivo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
