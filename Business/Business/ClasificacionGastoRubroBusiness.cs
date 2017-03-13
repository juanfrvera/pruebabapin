using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class ClasificacionGastoRubroBusiness : _ClasificacionGastoRubroBusiness 
    {   
	   #region Singleton
	   private static volatile ClasificacionGastoRubroBusiness current;
	   private static object syncRoot = new Object();

	   //private ClasificacionGastoRubroBusiness() {}
	   public static ClasificacionGastoRubroBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ClasificacionGastoRubroBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(ClasificacionGastoRubro entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
