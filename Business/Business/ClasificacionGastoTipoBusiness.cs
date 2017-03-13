using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ClasificacionGastoTipoBusiness : _ClasificacionGastoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile ClasificacionGastoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoTipoBusiness() {}
	   public static ClasificacionGastoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ClasificacionGastoTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
