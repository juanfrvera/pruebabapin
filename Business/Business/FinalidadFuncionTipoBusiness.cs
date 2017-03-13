using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class FinalidadFuncionTipoBusiness : _FinalidadFuncionTipoBusiness 
    {   
	   #region Singleton
	   private static volatile FinalidadFuncionTipoBusiness current;
	   private static object syncRoot = new Object();

	   //private FinalidadFuncionTipoBusiness() {}
	   public static FinalidadFuncionTipoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FinalidadFuncionTipoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       #region Actions

       public override void Update(FinalidadFuncionTipo entity, IContextUser contextUser)
       {
           base.Update(entity, contextUser);
           SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
           Singletons.COUNT_CHANGES = 0;

       }

       #endregion
    }
}
