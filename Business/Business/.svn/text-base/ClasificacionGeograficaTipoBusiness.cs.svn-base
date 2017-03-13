using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ClasificacionGeograficaTipoBusiness : _ClasificacionGeograficaTipoBusiness 
    {   
	   #region Singleton
	   private static volatile ClasificacionGeograficaTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGeograficaTipoBusiness() {}
	   public static ClasificacionGeograficaTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGeograficaTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ClasificacionGeograficaTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
