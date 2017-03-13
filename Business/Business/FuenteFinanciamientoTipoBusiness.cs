using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class FuenteFinanciamientoTipoBusiness : _FuenteFinanciamientoTipoBusiness 
    {   
	   #region Singleton
	   private static volatile FuenteFinanciamientoTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private FuenteFinanciamientoTipoBusiness() {}
	   public static FuenteFinanciamientoTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FuenteFinanciamientoTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(FuenteFinanciamientoTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
