using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ActividadPermisoBusiness : _ActividadPermisoBusiness 
    {   
	   #region Singleton
	   private static volatile ActividadPermisoBusiness current;
	   private static object syncRoot = new Object();

	   //private ActividadPermisoBusiness() {}
	   public static ActividadPermisoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ActividadPermisoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ActividadPermiso entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
